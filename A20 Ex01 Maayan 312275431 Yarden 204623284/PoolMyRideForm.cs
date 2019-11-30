using FacebookWrapper.ObjectModel;
using PoolMyRide;
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
        private Panel m_CurrentVisiblePanel;
        private readonly User sm_LoggedInUser = LoggedInUser.GetLoggedInUser;
        private readonly DBHandler m_DBHandler = DBHandler.GetInstance;

        public PoolMyRideForm(MainForm i_MainForm)
        {
            InitializeComponent();
            loadUserProfilePicture();
            initializeNewRidePanelComponent();
            initalizePanelVisualization();
        }

        private void loadUserProfilePicture()
        {
            LoggedInUserPictureBox.LoadAsync(sm_LoggedInUser.PictureNormalURL);
        }

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
             Control.ControlCollection controls = NewRide_panel.Controls;

            foreach (Control singleControl in controls)
            {
                if (singleControl is ComboBox)
                {
                    ComboBox comboBox = singleControl as ComboBox;
                    handleNewRideComboBox(comboBox);
                }
            }
        }

        private void handleNewRideComboBox(ComboBox i_ComboBox)
        {
            Array validCityNames = Enum.GetValues(typeof(ePoolMyRidyCityOptions));

            foreach (ePoolMyRidyCityOptions cityName in validCityNames)
            {
                if(cityName != ePoolMyRidyCityOptions.None)
                i_ComboBox.Items.Add(cityName);
            }

            i_ComboBox.Text = validCityNames.GetValue(1).ToString();
        }

        private void newRideSubmitButton_Click(object sender, EventArgs e)
        {
            handleNewRideSubmission();
        }

        private void handleNewRideSubmission()
        {
            bool isCityFromValid = Enum.TryParse(NewRide_fromComboBox.Text, out ePoolMyRidyCityOptions cityFrom);
            bool isCityToValid = Enum.TryParse(NewRide_toComboBox.Text, out ePoolMyRidyCityOptions cityTo);
            DateTime rideDate = NewRide_dateTimePicker.Value;
            bool isDriver = NewRide_isDriverCheckBox.Checked;

            try
            {
                SingleRide newRide = new SingleRide(cityFrom, cityTo, rideDate, isDriver);

                m_DBHandler.AddSingleRide(newRide);
            }
            catch (Exception ex)
            {
                // TODO: catch the right Exception
                MessageBox.Show(ex.Message);
            }
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
            JoinRide_listBox.Items.Clear();
            MyUtils.RemoveAllClickEvents(JoinRide_button);
            try
            {
                List<RideGroup> userRideGroups = m_DBHandler.FetchAllUserRideGroups(sm_LoggedInUser);

                foreach (RideGroup ride in userRideGroups)
                {
                    JoinRide_listBox.Items.Add(ride);
                }
            }
            catch (Exception ex)
            {
                // TODO: change to the right Exception type
                MessageBox.Show(ex.Message);
            }
            
            JoinRide_button.Click += new EventHandler(JoinRide_availableGroup_Click);
            JoinRide_button.Text = "Show Available Rides";
        }

        private void JoinRide_availableGroup_Click(object sender, EventArgs e)
        {
            RideGroup selectedRideGroup = JoinRide_listBox.SelectedItem as RideGroup;

            if(selectedRideGroup != null)
            {
                try
                {
                    List<SingleRide> groupRides = m_DBHandler.FetchSingleRideGroupRides(selectedRideGroup);

                    foreach (SingleRide ride in groupRides)
                    {
                        JoinRide_listBox.Items.Clear();
                        JoinRide_listBox.Items.Add(ride);
                        MyUtils.RemoveAllClickEvents(JoinRide_button);
                        JoinRide_button.Click += new EventHandler(JoinRide_joinTheRide_Click);
                        JoinRide_button.Text = "Join the ride!";
                    }
                }
                catch (Exception ex)
                {
                    // TODO: change to the right Exception type
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a Ride Group");
            }
        }

        private void JoinRide_joinTheRide_Click(object sender, EventArgs e)
        {
            SingleRide singleRide = JoinRide_listBox.SelectedItem as SingleRide;

            if (singleRide != null)
            {
                // TODO: implement join the ride
            }
        }

        #endregion JoinRide 

        #region FindeRide
        private void findRideButton_Click(object sender, EventArgs e)
        {
            initializeRideGroupsPanelComponent();
            visualizePanel(RideGroups_panel);
        }

        private void initializeRideGroupsPanelComponent()
        {
            MyUtils.RemoveAllClickEvents(RideGroups_new);
            MyUtils.RemoveAllClickEvents(RideGroups_join);
            RideGroups_new.Click += new EventHandler(RideGroups_new_Click);
            RideGroups_join.Click += new EventHandler(RideGroups_join_Click);

            try
            {
                List<RideGroup> allRideGroups = m_DBHandler.FetchAllRideGroups();

                foreach (RideGroup rideGroup in allRideGroups)
                {
                    RideGroups_listBox.Items.Add(rideGroup);
                }

                RideGroups_listBox.Visible = true;
            }
            catch (Exception ex)
            {
                // TODO: change to the right Exception type
                MessageBox.Show(ex.Message);
            }
        }

        private void RideGroups_new_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void RideGroups_join_Click(object sender, EventArgs e)
        {
            RideGroup rideGroupToJoin = RideGroups_listBox.SelectedItem as RideGroup;

            if (rideGroupToJoin != null)
            {
                try
                {
                    m_DBHandler.AddUserToRideGroup(sm_LoggedInUser, rideGroupToJoin);
                }
                catch (Exception ex)
                {
                    // TODO: change to the right Exception type
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a group to join to");
            }
        }
        #endregion FindeRide
    }
}
