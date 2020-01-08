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
using MyFacebookApp.MyDBHandler;

namespace MyFacebookApp
{
    public partial class FindPlaceForm : Form
    {
        private Panel m_visiblePanel;
        private const string k_SearchBoxLabel = "Name...";
        private const string k_FileLastFriendsListPath = "./DB_LastCloseFriend.XML";
        private readonly UserDataManager r_UserDataManager = Singleton<UserDataManager>.Instance;
        private readonly IDBHandler r_DBHandlerAdapter = new DBHandlerAdapter();

        // TODO: debug
        private readonly BindingSource r_SelectedFriendsBinding = new BindingSource();
        private readonly BindingSource r_NotSelectedFriendsBinding = new BindingSource();
        private readonly List<User> r_NotSelectedUsers = new List<User>();
        private readonly List<User> r_SelectedUsers = new List<User>();

        public FindPlaceForm()
        {
            InitializeComponent();
            initializeListView();
            initializeVisiblePanel();
            initializeListBoxs();

            // TODO: debug
            r_SelectedFriendsBinding.DataSource = r_SelectedUsers;
            listBoxSelected.DataSource = r_SelectedFriendsBinding;

            r_NotSelectedFriendsBinding.DataSource = r_NotSelectedUsers;
            listBoxNotSelected.DataSource = r_NotSelectedFriendsBinding;

            initializeFriendsList();

            ShowDialog();
        }

        private void initializeListBoxs()
        {
            listBoxNotSelected.DisplayMember = "Name";
            listBoxSelected.DisplayMember = "Name";
        }

        private void initializeVisiblePanel()
        {
            m_visiblePanel = panelSelsectFriends;
            panelPagesResults.Visible = false;
        }

        private void initializeListView()
        {
            listViewCommonPages.View = View.Details;
            listViewCommonPages.FullRowSelect = true;
            listViewCommonPages.GridLines = true;
            listViewCommonPages.Columns.Add("Page Name", 300, HorizontalAlignment.Center);
            listViewCommonPages.Columns.Add("Common Likes", -2, HorizontalAlignment.Center);
        }

        private void initializeFriendsList()
        {
            r_NotSelectedFriendsBinding.Clear();
            foreach (User friend in r_UserDataManager.Friends)
            {
                r_NotSelectedFriendsBinding.Add(friend);
                friend.ReFetch(DynamicWrapper.eLoadOptions.Full);
            }

            if (r_UserDataManager.Friends.Count == 0)
            {
                MessageBox.Show("No Friends to retrieve...");
            }
        }

        private void listBoxNotSelected_SelectedIndexDoubleClicked(object sender, EventArgs e)
        {
            ListBox listBoxNotSelected = sender as ListBox;
            moveFriendToOtherList(r_NotSelectedFriendsBinding, r_SelectedFriendsBinding, listBoxNotSelected.SelectedItem);
        }

        private void listBoxSelected_SelectedIndexDoubleClicked(object sender, EventArgs e)
        {
            ListBox listBoxSelected = sender as ListBox;
            moveFriendToOtherList(r_SelectedFriendsBinding, r_NotSelectedFriendsBinding, listBoxSelected.SelectedItem);
        }

        private void moveFriendToOtherList(BindingSource i_SourceFrom, BindingSource i_SourceTo, object i_SelectedItem)
        {
            if (i_SelectedItem == null)
            {
                return; //Nothing was selected
            }
            User selectedFriend = i_SelectedItem as User;

            if (selectedFriend == null)
            {
                MessageBox.Show("Friend not found - ERROR");
            }

            i_SourceFrom.Remove(selectedFriend);
            if (i_SourceTo == r_NotSelectedFriendsBinding)
            {
                if (isContains(selectedFriend.Name, textBoxSearch.Text))
                {
                    i_SourceTo.Add(selectedFriend);
                }
            }
            else
            {
                i_SourceTo.Add(selectedFriend);
            }
        }

        private User getSelectedUserByName(string i_UserNameToFind)
        {
            User foundUser = null;
            foreach (User user in r_UserDataManager.Friends)
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

            r_NotSelectedFriendsBinding.Clear();

            foreach (User friend in r_UserDataManager.Friends)
            {
                if (isContains(friend.Name, textThatChanged))
                {
                    if (!r_SelectedFriendsBinding.Contains(friend))
                    {
                        r_NotSelectedFriendsBinding.Add(friend);
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
            try
            {
                List<string> lastFriendsnamesList = r_DBHandlerAdapter.LoadLastFriendsList();
                List<User> lastFriendsList = stringListToUserList(lastFriendsnamesList);
                loadListToSelectedFriends(lastFriendsList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error - " + ex.Message);
            }
        }

        private List<User> stringListToUserList(List<string> i_NamesList)
        {
            List<User> usersList = new List<User>();

            foreach (string name in i_NamesList)
            {
                User user = getSelectedUserByName(name);
                usersList.Add(user);
            }

            return usersList;
        }

        private void loadListToSelectedFriends(List<User> i_LastFriendsList)
        {
            foreach (User friend in i_LastFriendsList)
            {
                if (r_NotSelectedFriendsBinding.Contains(friend))
                {
                    r_NotSelectedFriendsBinding.Remove(friend);
                    if (!r_SelectedFriendsBinding.Contains(friend))
                    {
                        r_SelectedFriendsBinding.Add(friend);
                    }
                }
            }

            if (i_LastFriendsList.Count == 0)
            {
                MessageBox.Show("Last friend list is empty.");
            }
        }

        private bool isContains(string i_String, string i_subString)
        {
            bool isContain = i_String.ToLower().Contains(i_subString.ToLower());

            return isContain;
        }

        private void buttonFindPlaces_Click(object sender, EventArgs e)
        {
            writeLastFriendsList();
            findCommonPlacesLikedByAllFriends();
            changeVisiblePanel(panelPagesResults);
        }

        private void changeVisiblePanel(Panel i_PanelToView)
        {
            m_visiblePanel.Visible = false;
            m_visiblePanel = i_PanelToView;
            m_visiblePanel.Visible = true;
        }

        private void findCommonPlacesLikedByAllFriends()
        {
            CommonPages commonPages = new CommonPages();
            List<KeyValuePair<Page, int>> sortedLikedPages;

            try
            { 
                foreach (Page page in r_UserDataManager.LikedPages)
                {
                    commonPages.Add(page);
                }

                foreach (string friendName in r_SelectedFriendsBinding)
                {
                    User friendUser = getSelectedUserByName(friendName);

                    foreach (Page page in friendUser.LikedPages)
                    {
                        commonPages.Add(page);
                    }
                }

                sortedLikedPages = commonPages.GetSortedPagesByCommonLikesAsPairs();

                foreach (KeyValuePair<Page, int> pagePair in sortedLikedPages)
                {
                    ListViewItem item = new ListViewItem(pagePair.Key.Name);
                    item.SubItems.Add(pagePair.Value.ToString());
                    listViewCommonPages.Items.Add(item);
                }

            }
            catch(Facebook.FacebookOAuthException e)
            {
                //Facebook "OAuthException -#100 - Pages Public Content Access requires either app secret proof or an app token"
            }

        }

        private void writeLastFriendsList()
        {
            //List<User> selectedFriends = r_SelectedFriendsBinding.Cast<User>().ToList<User>();
            List<string> selectedFriendsNames = r_SelectedUsers.ConvertAll(user => user.Name);
            r_DBHandlerAdapter.WriteLastFriendsList(selectedFriendsNames);
        }


        private void buttonBack_Click(object sender, EventArgs e)
        {
            changeVisiblePanel(panelSelsectFriends);
        }
    }
}
