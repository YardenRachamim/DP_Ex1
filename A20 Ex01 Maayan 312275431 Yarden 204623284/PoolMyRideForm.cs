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

namespace A20_Ex01_Maayan_312275431_Yarden_204623284
{
    public partial class PoolMyRideForm : Form
    {
        // TODO:
        // Consider what will happen if user not belong to any group!

        private Panel m_CurrentVisiblePanel;
        private readonly User r_LoggedInUser = LoggedInUser.GetLoggedInUser;
        private readonly DBHandler r_DBHandler = DBHandler.GetInstance;
        private Dictionary<string, string> m_UserGroupNameIDMapping = new Dictionary<string, string>();
        private readonly List<Group> r_UserRideGroups = new List<Group>();

        public PoolMyRideForm(MainForm i_MainForm)
        {
            // TODO: make the window start in the right size 
            InitializeComponent();
            fetchUserData();
            loadUserProfilePicture();
            initializeNewRidePanelComponent();
            initalizePanelVisualization();
        }

        private void clearAllPanelControls(Panel i_panel)
        {
            Control.ControlCollection panelControls = i_panel.Controls;

            foreach(Control control in panelControls)
            {
                if (control is TextBox)
                {
                    TextBox txtbox = (TextBox) control;
                    txtbox.Text = string.Empty;
                }
                else if (control is CheckBox)
                {
                    CheckBox chkbox = (CheckBox) control;
                    chkbox.Checked = false;
                }
                else if (control is ListBox)
                {
                    ListBox listBox = (ListBox)control;
                    listBox.Items.Clear();
                }
                else if (control is DateTimePicker)
                {
                    DateTimePicker dtp = (DateTimePicker) control;
                    dtp.Value = DateTime.Now;
                }
                else if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox) control;
                    comboBox.Items.Clear();
                }
                else if(control is Button)
                {
                    Button button = (Button)control;
                    MyUtils.RemoveAllClickEvents(button);
                }
            }
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
                    Group singleRideGroup = FacebookWrapper.FacebookService.GetObject(ID);

                    r_UserRideGroups.Add(singleRideGroup);
                    m_UserGroupNameIDMapping[singleRideGroup.Name] = singleRideGroup.Id;
                }
            }
            catch (Exception ex)
            {
                // TODO: catch the right exception
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
            clearAllPanelControls(NewRide_panel);
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
                foreach(string rideGroupName in m_UserGroupNameIDMapping.Keys)
                {
                    i_ComboBox.Items.Add(rideGroupName);
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
                NewRideConrolsData controlsData = fetchNewRidePanelConrolersData();
                Group chosenRideGroup = FacebookWrapper.FacebookService.GetObject(controlsData.GroupID);
                string eventName = $"{r_LoggedInUser.Name} new Ride!";
                string eventDescription = getDescription(controlsData);
                Event groupRideEvent = chosenRideGroup.CreateEvent_DeprecatedSinceV2(eventName, 
                    controlsData.RideDate,
                    i_Description: eventDescription);

                r_DBHandler.SaveEventToGroupRides(chosenRideGroup.Id, groupRideEvent.Id);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string getDescription(NewRideConrolsData i_ControlsData)
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

        private NewRideConrolsData fetchNewRidePanelConrolersData()
        {
            Enum.TryParse(NewRide_fromComboBox.Text, out ePoolMyRidyCityOptions cityFrom);
            Enum.TryParse(NewRide_toComboBox.Text, out ePoolMyRidyCityOptions cityTo);
            DateTime rideDate = NewRide_dateTimePicker.Value;
            string groupName = NewRide_groupComboBox.Text;
            string groupID = m_UserGroupNameIDMapping[groupName];
            bool isUserDriver = NewRide_isDriverCheckBox.Checked;

            return new NewRideConrolsData(cityFrom, cityTo, rideDate, groupID, isUserDriver);
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
            clearAllPanelControls(JoinRide_panel);
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
                // TODO: change to the right Exception type
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
                    string groupID = m_UserGroupNameIDMapping[chosenGroupName];
                    List<string> groupRideEventsIDs =
                        r_DBHandler.FetchAllGroupRides(groupID);

                    foreach (string groupRideEventID in groupRideEventsIDs)
                    {
                        Event rideEvent =
                            FacebookWrapper.FacebookService.GetObject(groupRideEventID);

                        JoinRide_listBox.Items.Add(rideEvent);
                    }

                    MyUtils.RemoveAllClickEvents(JoinRide_button);
                    JoinRide_button.Text = "Join the ride!";
                    JoinRide_button.Click += 
                        new EventHandler(JoinRide_joinTheRide_Click);
                }
                catch(Exception ex)
                {
                    // TODO: consider show the user a message 
                    //or handle the exception in the right way
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
            }
            else
            {
                MessageBox.Show("Please choose a ride!");
            }
        }

        #endregion JoinRide 

        //#region FindRide
        //private void findRideButton_Click(object sender, EventArgs e)
        //{
        //    initializeRideGroupsPanelComponent();
        //    visualizePanel(RideGroups_panel);
        //}

        //private void initializeRideGroupsPanelComponent()
        //{
        //    MyUtils.RemoveAllClickEvents(RideGroups_new);
        //    MyUtils.RemoveAllClickEvents(RideGroups_join);
        //    RideGroups_new.Click += new EventHandler(RideGroups_new_Click);
        //    RideGroups_join.Click += new EventHandler(RideGroups_join_Click);

        //    try
        //    {
        //        List<RideGroup> allRideGroups = r_DBHandler.FetchAllRideGroups();
        //        RideGroups_listBox.Items.Clear();

        //        foreach (RideGroup rideGroup in allRideGroups)
        //        {
        //            RideGroups_listBox.Items.Add(rideGroup);
        //        }

        //        RideGroups_listBox.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        // TODO: change to the right Exception type
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void RideGroups_new_Click(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //private void RideGroups_join_Click(object sender, EventArgs e)
        //{
        //    RideGroup rideGroupToJoin = RideGroups_listBox.SelectedItem as RideGroup;

        //    if (rideGroupToJoin != null)
        //    {
        //        try
        //        {
        //            r_DBHandler.AddUserToRideGroup(r_LoggedInUser, rideGroupToJoin);
        //            MessageBox.Show($"You successfully joined to '{rideGroupToJoin}'");
        //        }
        //        catch (Exception ex)
        //        {
        //            // TODO: change to the right Exception type
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please select a group to join to");
        //    }
        //}
        //#endregion FindRide
    }
}
