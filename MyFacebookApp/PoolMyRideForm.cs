using FacebookWrapper.ObjectModel;
using DataHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Utils;
using PoolMyRide;

namespace MyFacebookApp
{
    public partial class PoolMyRideForm : Form
    {
        private Panel m_CurrentVisiblePanel;
        private readonly User r_LoggedInUser = Singleton<UserDataManager>.Instance.LoggedInUser;
        private readonly DBHandler r_DBHandler = Singleton<DBHandler>.Instance;
        private Dictionary<string, RideGroup> m_UserGroupNameIDMapping = new Dictionary<string, RideGroup>();

        public PoolMyRideForm()
        {
            InitializeComponent();
            fetchUserData();
            loadUserProfilePicture();
            initializeNewRidePanelComponent();
            initalizePanelVisualization();
        }

        #region Fetch user data
        private void fetchUserData()
        {
            fetchUserRideGroups();
        }

        private void fetchUserRideGroups()
        {
            try
            {
                string userID = r_LoggedInUser.Id;
                List<string> rideGroupIDs = r_DBHandler.FetchAllUserRideGroupsIDs(userID);

                foreach (string ID in rideGroupIDs)
                {
                    FacebookObject singleRideGroup = null;

                    try
                    {
                        singleRideGroup = FacebookWrapper.FacebookService.GetObject(ID);
                    }catch(Exception ex)
                    {
                        continue;
                    }

                    string name = "";
                    RideGroup rideGroup = null;

                    if (singleRideGroup is Group)
                    {
                        Group group = singleRideGroup as Group;
                        rideGroup = new RideGroup(group.Id, group.Name);
                        rideGroup.AddEvents(group.Events);
                        name = group.Name;
                    }
                    else if(singleRideGroup is FriendList)
                    {
                        FriendList friendList = singleRideGroup as FriendList;

                        rideGroup = new RideGroup(friendList.Name);

                        List<string> eventIds = r_DBHandler.FetchAllGroupRideEvents(friendList.Id);

                        foreach (string eventId in eventIds)
                        {
                            Event friendListEvent = FacebookWrapper.FacebookService.GetObject(eventId);
                            rideGroup.AddEvent(friendListEvent);
                        }

                        name = friendList.Name;
                    }

                    m_UserGroupNameIDMapping[name] = rideGroup;
                }
            }
            catch (Exception ex)
            {
                // ...
            }
        }

        private void loadUserProfilePicture()
        {
            LoggedInUserPictureBox.LoadAsync(r_LoggedInUser.PictureNormalURL);
        }
        #endregion Fetch user data

        private void initalizePanelVisualization()
        {
            Control.ControlCollection formControls = this.Controls;

            foreach(Control singleControl in formControls)
            {
                Panel panel = singleControl as Panel;

                if(panel != null)
                {
                    panel.Visible = false;
                }
            }

            NewRide_panel.Visible = true;
            m_CurrentVisiblePanel = NewRide_panel;
        }

        private void visualizePanel(Panel i_PanelToVisualize)
        {
            m_CurrentVisiblePanel.Visible = false;
            m_CurrentVisiblePanel = i_PanelToVisualize;
            m_CurrentVisiblePanel.Visible = true;
        }

        #region NewRide
        private void newRideButton_Click(object sender, EventArgs e)
        {
            initializeNewRidePanelComponent();
            visualizePanel(NewRide_panel);
        }

        private void initializeNewRidePanelComponent()
        {
            Control.ControlCollection panelControls = NewRide_panel.Controls;

            WinFormUtils.ClearAllControlsFromAGivenList(panelControls);
            NewRide_submitButton.Click += new EventHandler(newRideSubmitButton_Click);
            initNewRideComboBox();
        }

        private void initNewRideComboBox()
        {
            fillFromAndToCityComboBoxes();
            fillGroupComboBox(NewRide_groupComboBox);
        }

        private void fillFromAndToCityComboBoxes()
        {
            fillComboBoxWithCityNamesOptions(NewRide_toComboBox);
            fillComboBoxWithCityNamesOptions(NewRide_fromComboBox);
        }

        private void fillComboBoxWithCityNamesOptions(ComboBox i_ComboBox)
        {
            Array validCityNames = Enum.GetValues(typeof(ePoolMyRidyCityOptions));

            foreach (ePoolMyRidyCityOptions cityName in validCityNames)
            {
                if (cityName != ePoolMyRidyCityOptions.None)
                {
                    i_ComboBox.Items.Add(cityName);
                }
            }

            i_ComboBox.Text = validCityNames.GetValue(1).ToString();
        }

        private void fillGroupComboBox(ComboBox i_ComboBox)
        {
            if(m_UserGroupNameIDMapping != null && m_UserGroupNameIDMapping.Count > 0)
            {
                foreach(RideGroup rideGroupName in m_UserGroupNameIDMapping.Values)
                {
                    i_ComboBox.Items.Add(rideGroupName.Name);
                }
            }
        }

        private void newRideSubmitButton_Click(object sender, EventArgs e)
        {
            bool isUserBelongToARideGroup = 
                m_UserGroupNameIDMapping != null && m_UserGroupNameIDMapping.Count > 0;

            if (isUserBelongToARideGroup)
            {
                handleNewRideSubmission();
            }
            else
            {
                MessageBox.Show("Please join a Ride group first");
            }
        }

        private void handleNewRideSubmission()
        {
            try
            {
                NewRide controlsData = fetchNewRidePanelConrolersData();
                RideGroup rideGroup = m_UserGroupNameIDMapping[controlsData.GroupID];
                //Group chosenRideFBGroup = FacebookWrapper.FacebookService.GetObject(controlsData.GroupID); 
                string eventName = $"{r_LoggedInUser.Name} new Ride!";
                string eventDescription = getDescription(controlsData);
                Event eventRide = rideGroup.CreateEvent(r_LoggedInUser, eventName,
                    controlsData.RideDate,
                    i_Description: eventDescription);

                r_DBHandler.SaveEventToGroupRide(rideGroup.Id, eventRide.Id);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string getDescription(NewRide i_ControlsData)
        {
            StringBuilder description = new StringBuilder();

            description.AppendLine($"Ride from {i_ControlsData.CityFrom} to {i_ControlsData.CityTo}");
            description.AppendLine($"at {i_ControlsData.RideDate}");

            if (i_ControlsData.IsUserDriver)
            {
                description.AppendLine($"{r_LoggedInUser.Name} will drive");
            }
            else
            {
                description.AppendLine($"{r_LoggedInUser.Name} looking for driver");
            }

            return description.ToString();
        }

        private NewRide fetchNewRidePanelConrolersData()
        {
            Enum.TryParse(NewRide_fromComboBox.Text, out ePoolMyRidyCityOptions cityFrom);
            Enum.TryParse(NewRide_toComboBox.Text, out ePoolMyRidyCityOptions cityTo);
            DateTime rideDate = NewRide_dateTimePicker.Value;
            string groupName = NewRide_groupComboBox.Text;
            string groupID = m_UserGroupNameIDMapping[groupName].Id;
            bool isUserDriver = NewRide_isDriverCheckBox.Checked;

            return new NewRide(cityFrom, cityTo, rideDate, groupID, isUserDriver);
        }
        #endregion NewRide

        #region JoinRide
        private void joinRideButton_Click(object sender, EventArgs e)
        {
            initializeJoinRidePanelComponent();
            visualizePanel(JoinRide_panel);
        }

        private void initializeJoinRidePanelComponent()
        {
            Control.ControlCollection panelControls = JoinRide_panel.Controls;

            WinFormUtils.ClearAllControlsFromAGivenList(panelControls);
            JoinRide_button.Click += new EventHandler(JoinRide_availableGroup_Click);
            JoinRide_button.Text = "Show Available Rides";

            try
            {
                foreach (string groupName in m_UserGroupNameIDMapping.Keys)
                {
                    JoinRide_listBox.Items.Add(groupName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void JoinRide_availableGroup_Click(object sender, EventArgs e)
        {
            handleAvailableGroupSubmission();
        }

        private void handleAvailableGroupSubmission()
        {
            string chosenGroupName = JoinRide_listBox.SelectedItem as string;
                
            if (chosenGroupName != null)
            {
                JoinRide_listBox.Items.Clear();

                try
                {
                    RideGroup chosenGroup = m_UserGroupNameIDMapping[chosenGroupName];
                    //Group chosenGroup = FacebookWrapper.FacebookService.GetObject(groupID);

                    foreach (Event groupRideEvent in chosenGroup.Events)
                    {
                        JoinRide_listBox.Items.Add(groupRideEvent);
                    }

                    WinFormUtils.RemoveAllClickEvents(JoinRide_button);
                    JoinRide_button.Text = "Join the ride!";
                    JoinRide_button.Click += 
                        new EventHandler(JoinRide_joinTheRide_Click);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please chose a specific group");
            }
        }

        private void JoinRide_joinTheRide_Click(object sender, EventArgs e)
        {
            handleJoinTheRideSubmission();
        }

        private void handleJoinTheRideSubmission()
        {
            Event chosenRideEvent = JoinRide_listBox.SelectedItem as Event;

            if(chosenRideEvent != null)
            {
                List<User> usersToInvite = new List<User>();

                usersToInvite.Add(r_LoggedInUser);

                try
                {
                    string rideEventOwnerName = chosenRideEvent.Owner.Name;
                    string rideEventName = chosenRideEvent.Name;
                    bool isUserInvited = chosenRideEvent.InviteUsers(usersToInvite);

                    if (isUserInvited)
                    {
                        chosenRideEvent.Respond(Event.eRsvpType.Attending);
                    }
                    else
                    {
                        throw new Exception("Can't send invitation to the user");
                    }

                    MessageBox.Show($"You successfully join to {rideEventName}, please contact {rideEventOwnerName} for more details");
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please choose a ride!");
            }
        }

        #endregion JoinRide 

        #region RideGroups
        private void findRideButton_Click(object sender, EventArgs e)
        {
            initializeRideGroupsPanelComponent();
            visualizePanel(RideGroups_panel);
        }

        private void initializeRideGroupsPanelComponent()
        {
            initButtons();
            initListBox();
        }

        private void initButtons()
        {
            RideGroups_join.Click += new EventHandler(rideGroups_join_Click); 
        }

        private void initListBox()
        {
            try
            {
                List<string> userGroupRideIDs = r_DBHandler.FetchAllUserRideGroupsIDs(r_LoggedInUser.Id);
                
                RideGroups_listBox.Items.Clear();

                foreach (RideGroup rideGroup in m_UserGroupNameIDMapping.Values)
                {
                    RideGroups_listBox.Items.Add(rideGroup);
                }
            }
            catch (Exception ex)
            {
                // ...
            }
        }

        private void rideGroups_join_Click(object sender, EventArgs e)
        {
            handleJoinRideGroupSumbission();
        }

        private void handleJoinRideGroupSumbission()
        {
            RideGroup chosenGroup = JoinRide_listBox.SelectedItem as RideGroup;

            if (chosenGroup != null)
            {
                bool isNeedToJoinManually;

                chosenGroup.AddMember(r_LoggedInUser, out isNeedToJoinManually);

                if (isNeedToJoinManually)
                {
                    MessageBox.Show($"please join this group manually using the following link www.facebook.com/{chosenGroup.Id}");
                }
                else
                {
                    MessageBox.Show($"you successfully joined '{chosenGroup.Name}'");
                }
            }
            else
            {
                MessageBox.Show("Please chose a group to join!");
            }
        }
        #endregion RideGroups
    }
}
