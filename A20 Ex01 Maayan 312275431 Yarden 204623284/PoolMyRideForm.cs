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
        private readonly MainForm rm_MainForm;

        public PoolMyRideForm(MainForm i_MainForm)
        {
            InitializeComponent();
            rm_MainForm = i_MainForm;
            loadUserProfilePicture();
            initializeNewRidePanelComponent();
        }

        private void loadUserProfilePicture()
        {
            LoggedInUserPictureBox.LoadAsync(rm_MainForm.LoggedInUser.PictureNormalURL);
        }

        #region NewRide
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
            Array validCityNames = Enum.GetValues(typeof(PoolMyRidyCityOptions));

            foreach (PoolMyRidyCityOptions cityName in validCityNames)
            {
                i_ComboBox.Items.Add(cityName);
            }

            i_ComboBox.Text = validCityNames.GetValue(0).ToString();
        }

        private void newRideButton_Click(object sender, EventArgs e)
        {
            visualizePanel(NewRide_panel);
        }

        private void newRideSubmitButton_Click(object sender, EventArgs e)
        {
            // get all new ride data, and save it to a DB
            throw new NotImplementedException();
        }
        #endregion NewRide

        #region JoinRide
        private void joinRideButton_Click(object sender, EventArgs e)
        {
            //visualizePanel(JoinRide_panel);
            throw new NotImplementedException();
        }
        #endregion JoinRide

        #region FindeRide
        private void FindRideButton_Click(object sender, EventArgs e)
        {
            //visualizePanel(FindRide_panel);
            throw new NotImplementedException();
        }
        #endregion FindeRide

        private void visualizePanel(Panel i_PanelToVisualize)
        {
            // Unvisualize the current panel
            // visualize the i_PanelToVisualize
            throw new NotImplementedException();
        }
    }
}
