using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace MyFacebookApp
{
    public partial class MainForm : Form
    {
       // private FacebookObjectCollection<Post> UIManager.Instance.Posts;
       // private FacebookObjectCollection<Album> UIManager.Instance.Albums;
        private readonly LoginForm r_LoginForm;
        private readonly UserDataManager r_UserDataManager;

        public MainForm()
        {
            r_UserDataManager = Singleton<UserDataManager>.Instance;
            InitializeComponent();
            r_LoginForm = new LoginForm(this);
            r_LoginForm.ShowDialog();
        }

        public void StartForm()
        {
            this.ShowDialog();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            fetchUserPicture();
            fetchUserDetails();
        }

        #region fetch/unfetch data
        private void fetchUserPicture()
        {
            LoggedInUserPictureBox.LoadAsync(r_UserDataManager.PictureNormalURL);
        }

        private void fetchUserDetails()
        {
            listBoxDetails.Invoke(new Action(() => listBoxDetails.Items.Add("First Name: " + r_UserDataManager.FirstName)));
            listBoxDetails.Invoke(new Action(() => listBoxDetails.Items.Add("Last Name: " + r_UserDataManager.LastName)));
            listBoxDetails.Invoke(new Action(() => listBoxDetails.Items.Add("Birthday: " + r_UserDataManager.Birthday)));
            listBoxDetails.Invoke(new Action(() => listBoxDetails.Items.Add("Hometown: " + r_UserDataManager.Hometown)));
            listBoxDetails.Invoke(new Action(() => listBoxDetails.Items.Add("RelationshipStatus: " + r_UserDataManager.RelationshipStatus)));
            listBoxDetails.Invoke(new Action(() => listBoxDetails.Items.Add("Religion: " + r_UserDataManager.Religion)));
            listBoxDetails.Invoke(new Action(() => listBoxDetails.Items.Add("TimeZone: " + r_UserDataManager.TimeZone)));
        }

        private void checkBoxPosts_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            if (checkBox.Checked == true)
            {
                fetchUserPosts();
            }
            else
            {
                unfetchUserPosts();
            }
        }

        private void unfetchUserPosts()
        {
            listBoxPosts.Items.Clear();
        }

        private void fetchUserPosts()
        {
            // TODO: add threads
            foreach (Post post in r_UserDataManager.Posts)
            {
                if (post.Message != null)
                {
                    listBoxPosts.Items.Add(post.Message);
                }
                else if (post.Caption != null)
                {
                    listBoxPosts.Items.Add(post.Caption);
                }
                else
                {
                    listBoxPosts.Items.Add(string.Format("[{0}]", post.Type));
                }
            }

            if (r_UserDataManager.Posts.Count == 0)
            {
                listBoxPosts.Items.Add("No Posts to retrieve...");
            }
        }

        private void checkBoxAlbums_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.Checked == true)
            {
                fetchUserAlbums();
            }
            else
            {
                unfetchUserAlbums();
            }
        }

        private void fetchUserAlbums()
        {
            // TODO: add threads
            foreach (Album album in r_UserDataManager.Albums)
            {
                if (album.Name != null)
                {
                    listBoxAlbums.Items.Add(album.Name);
                }
            }

            if (r_UserDataManager.Albums.Count == 0)
            {
                listBoxAlbums.Items.Add("No Albums to retrieve...");
            }
        }

        private void unfetchUserAlbums()
        {
            listBoxAlbums.Items.Clear();
        }

        private void checkBoxFriends_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.Checked == true)
            {
                fetchUserFriends();
            }
            else
            {
                unfetchUserFriends();
            }
        }

        private void fetchUserFriends()
        {
            // TODO: add threads
            foreach (User friend in r_UserDataManager.Friends)
            {
                listBoxFriends.Items.Add(friend.Name);
                friend.ReFetch(DynamicWrapper.eLoadOptions.Full);
            }

            if (r_UserDataManager.Friends.Count == 0)
            {
                listBoxFriends.Items.Add("No Friends to retrieve...");
            }
        }

        private void unfetchUserFriends()
        {
            listBoxFriends.Items.Clear();
        }
        #endregion fetch/unfetch data

        #region show other forms
        private void buttonFindPlaces_Click(object sender, EventArgs e)
        {
            FindPlaceForm findPlaceForm = new FindPlaceForm();
        }

        private void buttonPoolMyRide_Click(object sender, EventArgs e)
        {
            PoolMyRideForm poolMyRideForm = new PoolMyRideForm();

            poolMyRideForm.ShowDialog();
        }
        #endregion show other forms

        #region Logout
        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            FacebookWrapper.FacebookService.Logout(logOutCallback);
        }

        private void logOutCallback()
        {
            resetFormComponents();
            resetAllUserData();
            this.Hide();
            r_LoginForm.Show();
        }

        private void resetFormComponents()
        {
            Control.ControlCollection controls = this.Controls;

            foreach(Control control in controls)
            {
                if(control is ListBox)
                {
                    ((ListBox)control).Items.Clear();
                }
                else if (control is CheckBox)
                {
                    ((CheckBox)control).Checked = false;
                }
                else if (control is PictureBox)
                {
                    ((PictureBox)control).InitialImage = null;
                }

            }
        }

        private void resetAllUserData()
        {
            r_UserDataManager.RestartLoggedInUser();
        }
        #endregion Logout

    }
}
