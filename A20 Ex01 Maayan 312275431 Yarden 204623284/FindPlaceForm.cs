using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace A20_Ex01_Maayan_312275431_Yarden_204623284
{
    public partial class FindPlaceForm : Form
    {
        private readonly MainForm r_MainForm;
        private readonly FacebookObjectCollection<User> r_FilteredOutFriend = new FacebookObjectCollection<User>();
        private const string k_SearchBoxLabel = "Name...";
        string k_FilePath = "./DB_LastCloseFriend.XML";

        public FindPlaceForm(MainForm i_MainForm)
        {
            r_MainForm = i_MainForm;
            InitializeComponent();
            initializeFriendsList();
            ShowDialog();
        }

        private void initializeFriendsList()
        {
            if (r_MainForm.Friends == null)
            {
                r_MainForm.Friends = r_MainForm.LoggedInUser.Friends;
            }

            listBoxNotSelected.Items.Clear();
            foreach (User friend in r_MainForm.Friends)
            {
                listBoxNotSelected.Items.Add(friend.Name);
                friend.ReFetch(DynamicWrapper.eLoadOptions.Full);
            }

            if (r_MainForm.Friends.Count == 0)
            {
                MessageBox.Show("No Friends to retrieve...");
            }
        }

        private void listBoxNotSelected_SelectedIndexDoubleClicked(object sender, EventArgs e)
        {
            ListBox listBoxNotSelected = sender as ListBox;
            moveFriendToOtherList(listBoxNotSelected, listBoxSelected);
        }

        private void listBoxSelected_SelectedIndexDoubleClicked(object sender, EventArgs e)
        {
            ListBox listBoxSelected = sender as ListBox;
            moveFriendToOtherList(listBoxSelected, listBoxNotSelected);
        }

        private void moveFriendToOtherList(ListBox i_ListBoxFrom, ListBox i_ListBoxTo)
        {
            if (i_ListBoxFrom.SelectedItem == null)
            {
                return; //Nothing was selected
            }
            User selectedFriend = getSelectedUserByName(i_ListBoxFrom.SelectedItem.ToString());

            if (selectedFriend == null)
            {
                MessageBox.Show("Friend not found - ERROR"); // TODO: what to do when error?
            }

            i_ListBoxFrom.Items.Remove(selectedFriend.Name);
            if (i_ListBoxTo.Name == "listBoxNotSelected")
            {
                if (isContains(selectedFriend.Name, textBoxSearch.Text))
                {
                    i_ListBoxTo.Items.Add(selectedFriend.Name);
                }
            }
            else
            {
                i_ListBoxTo.Items.Add(selectedFriend.Name);
            }
        }

        private User getSelectedUserByName(string i_UserNameToFind)
        {
            User foundUser = null;
            foreach (User user in r_MainForm.Friends)
            {
                if (user.Name == i_UserNameToFind)
                {
                    foundUser = user;
                }
            }

            return foundUser;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string textThatChanged = textBoxSearch.Text;

            listBoxNotSelected.Items.Clear();

            foreach (User friend in r_MainForm.Friends)
            {
                if (isContains(friend.Name, textThatChanged))
                {
                    if (!listBoxSelected.Items.Contains(friend.Name))
                    {
                        listBoxNotSelected.Items.Add(friend.Name);
                    }
                }
            }

            if (textThatChanged == "")
            {
                resetLabelTextBoxSearch(k_SearchBoxLabel);
            }
            else
            {
                resetLabelTextBoxSearch(String.Empty);
            }
        }

        private void resetLabelTextBoxSearch(string i_Text)
        {
            labelSearchBox.Text = i_Text;
        }

        private void pictureBoxClearSearch_Click(object sender, EventArgs e)
        {
            textBoxSearch.Text = String.Empty;
            resetLabelTextBoxSearch(k_SearchBoxLabel);
        }

        private void buttonLoadXMLList_Click(object sender, EventArgs e)
        {
            loadXMLList();
        }

        private void loadXMLList()
        {
            XmlDocument doc = new XmlDocument();

            createFileIfNotExist();
            try
            {
                doc.Load(k_FilePath);
                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    string friendNameFromXML = node.InnerText;
                    if (listBoxNotSelected.Items.Contains(friendNameFromXML))
                    {
                        listBoxNotSelected.Items.Remove(friendNameFromXML);
                        if (!listBoxSelected.Items.Contains(friendNameFromXML))
                        {
                            listBoxSelected.Items.Add(friendNameFromXML);
                        }
                    }
                }

                if (doc.DocumentElement.ChildNodes.Count == 0)
                {
                    MessageBox.Show("Last friend list is empty.");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error - " + e.Message);
            }
        }

        private bool isContains(string i_String, string i_subString)
        {
            bool isContain = i_String.ToLower().Contains(i_subString.ToLower());

            return isContain;
        }

        private void buttonFindPlaces_Click(object sender, EventArgs e)
        {
            writeToXMLLastFriendsList();
        }

        private void writeToXMLLastFriendsList()
        {
            createFileIfNotExist();
            try
            {
                foreach (string name in listBoxSelected.Items)
                {

                    XmlWriter xmlWriter = XmlWriter.Create("test.xml");

                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("users");

                    xmlWriter.WriteStartElement("user");
                    xmlWriter.WriteAttributeString("age", "42");
                    xmlWriter.WriteString("John Doe");
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("user");
                    xmlWriter.WriteAttributeString("age", "39");
                    xmlWriter.WriteString("Jane Doe");

                    xmlWriter.WriteEndDocument();
                    xmlWriter.Close();
                }
            }
            catch (Exception e)
            {

            }
        }

        private void createFileIfNotExist()
        {
            if (!File.Exists(k_FilePath))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(k_FilePath))
                {
                    sw.WriteLine("<lastFriendsList>");
                    sw.WriteLine("</lastFriendsList>");
                }
            }
        }
    }
}
