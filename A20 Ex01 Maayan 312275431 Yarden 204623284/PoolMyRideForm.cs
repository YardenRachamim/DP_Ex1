using FacebookWrapper.ObjectModel;
using PoolMyRide;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace A20_Ex01_Maayan_312275431_Yarden_204623284
{
    public partial class PoolMyRideForm : Form
    {
        private Panel m_CurrentVisiblePanel;
        private readonly User sm_LoggedInUser = LoggedInUser.GetLoggedInUser;

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
                // TODO: add saving new ride to the db
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion NewRide

        #region JoinRide
        private void joinRideButton_Click(object sender, EventArgs e)
        {
            visualizePanel(JoinRide_panel);
        }
        #endregion JoinRide 

        #region FindeRide
        private void FindRideButton_Click(object sender, EventArgs e)
        {
            //visualizePanel(FindRide_panel);
            throw new NotImplementedException();
        }
        #endregion FindeRide
    }
}
