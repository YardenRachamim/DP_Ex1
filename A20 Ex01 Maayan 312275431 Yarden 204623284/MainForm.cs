using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Windows.Forms;

namespace A20_Ex01_Maayan_312275431_Yarden_204623284
{
    public partial class MainForm : Form
    {
        private FacebookObjectCollection<Post> m_Posts;
        private FacebookObjectCollection<Album> m_Albums;
        private readonly LoginForm r_LoginForm;

        public MainForm()
        {
            InitializeComponent();
            r_LoginForm = new LoginForm(this);
            r_LoginForm.ShowDialog();
        }

        public FacebookObjectCollection<User> Friends { get; set; }

        private void fetchUserPicture()
        {
            LoggedInUserPictureBox.LoadAsync(UIManager.GetLoggedInUser.PictureNormalURL);
        }

        public void StartForm()
        {
            fetchUserPicture();
            fetchUserDetails();
            this.ShowDialog();
        }

        private void fetchUserDetails()
        {
            listBoxDetails.Items.Add("First Name: " + UIManager.GetLoggedInUser.FirstName);
            listBoxDetails.Items.Add("Last Name: " + UIManager.GetLoggedInUser.LastName);
            listBoxDetails.Items.Add("Birthday: " + UIManager.GetLoggedInUser.Birthday);
            listBoxDetails.Items.Add("Hometown: " + UIManager.GetLoggedInUser.Hometown);
            listBoxDetails.Items.Add("RelationshipStatus: " + UIManager.GetLoggedInUser.RelationshipStatus);
            listBoxDetails.Items.Add("Religion: " + UIManager.GetLoggedInUser.Religion);
            listBoxDetails.Items.Add("TimeZone: " + UIManager.GetLoggedInUser.TimeZone);
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
            if (m_Posts == null)
            {
                m_Posts = UIManager.GetLoggedInUser.Posts;
            }

            foreach (Post post in m_Posts)
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

            if (m_Posts.Count == 0)
            {
                listBoxAlbums.Items.Add("No Posts to retrieve...");
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
            if (m_Albums == null)
            {
                m_Albums = UIManager.GetLoggedInUser.Albums;
            }

            foreach (Album album in m_Albums)
            {
                if (album.Name != null)
                {
                    listBoxAlbums.Items.Add(album.Name);
                }
            }

            if (m_Albums.Count == 0)
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
            if (Friends == null)
            {
                Friends = UIManager.GetLoggedInUser.Friends;
            }

            foreach (User friend in Friends)
            {
                listBoxFriends.Items.Add(friend.Name);
                friend.ReFetch(DynamicWrapper.eLoadOptions.Full);
            }

            if (Friends.Count == 0)
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
            FindPlaceForm findPlaceForm = new FindPlaceForm(this);
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
            // TODO: reset LoggedInUser. and reset all data
            resetAllUserData();
            this.Hide();
            r_LoginForm.Show();
        }

        private void resetAllUserData()
        {
            UIManager.RestartLoggedInUser();
            m_Albums = null;
            m_Posts = null;
            Friends = null;


        }
        #endregion Logout

    }
}
