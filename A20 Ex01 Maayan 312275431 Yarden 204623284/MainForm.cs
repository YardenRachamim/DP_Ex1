using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Windows.Forms;

namespace A20_Ex01_Maayan_312275431_Yarden_204623284
{
    public partial class MainForm : Form
    {
       // private FacebookObjectCollection<Post> UIManager.Instance.Posts;
       // private FacebookObjectCollection<Album> UIManager.Instance.Albums;
        private readonly LoginForm r_LoginForm;
        private readonly UserDataManager r_UserDataManager;

        public MainForm()
        {
            r_UserDataManager = UserDataManager.Instance;
            InitializeComponent();
            r_LoginForm = new LoginForm(this);
            r_LoginForm.ShowDialog();
        }

       // public FacebookObjectCollection<User> Friends { get; set; }

        private void fetchUserPicture()
        {
            LoggedInUserPictureBox.LoadAsync(r_UserDataManager.LoggedInUser.PictureNormalURL);
        }

        public void StartForm()
        {
            fetchUserPicture();
            fetchUserDetails();
            this.ShowDialog();
        }

        private void fetchUserDetails()
        {
            listBoxDetails.Items.Add("First Name: " + r_UserDataManager.LoggedInUser.FirstName);
            listBoxDetails.Items.Add("Last Name: " + r_UserDataManager.LoggedInUser.LastName);
            listBoxDetails.Items.Add("Birthday: " + r_UserDataManager.LoggedInUser.Birthday);
            listBoxDetails.Items.Add("Hometown: " + r_UserDataManager.LoggedInUser.Hometown);
            listBoxDetails.Items.Add("RelationshipStatus: " + r_UserDataManager.LoggedInUser.RelationshipStatus);
            listBoxDetails.Items.Add("Religion: " + r_UserDataManager.LoggedInUser.Religion);
            listBoxDetails.Items.Add("TimeZone: " + r_UserDataManager.LoggedInUser.TimeZone);
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
            if (r_UserDataManager.Posts == null)
            {
                r_UserDataManager.Posts = r_UserDataManager.LoggedInUser.Posts;
            }

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
            if (r_UserDataManager.Albums == null)
            {
                r_UserDataManager.Albums = r_UserDataManager.LoggedInUser.Albums;
            }

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
            if (r_UserDataManager.Friends == null)
            {
                r_UserDataManager.Friends = r_UserDataManager.LoggedInUser.Friends;
            }

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

        private void buttonFindPlaces_Click(object sender, EventArgs e)
        {
            FindPlaceForm findPlaceForm = new FindPlaceForm();
        }

        private void buttonPoolMyRide_Click(object sender, EventArgs e)
        {
            PoolMyRideForm poolMyRideForm = new PoolMyRideForm(this);

            poolMyRideForm.ShowDialog();
        }

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
