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
        private readonly LoginForm rm_LoginForm;

        public MainForm()
        {
            InitializeComponent();
            rm_LoginForm = new LoginForm(this);
            rm_LoginForm.ShowDialog();
        }

        public LoginResult Result { get; set; }
        public User LoggedInUser { get; set; }
        public FacebookObjectCollection<User> Friends { get; set; }

        private void fetchUserPicture()
        {
            LoggedInUserPictureBox.LoadAsync(LoggedInUser.PictureNormalURL);
        }

        public void StartForm()
        {
            fetchUserPicture();
            fetchUserDetails();
            this.ShowDialog();
        }

        private void fetchUserDetails()
        {
            listBoxDetails.Items.Add("First Name: " + LoggedInUser.FirstName);
            listBoxDetails.Items.Add("Last Name: " + LoggedInUser.LastName);
            listBoxDetails.Items.Add("Birthday: " + LoggedInUser.Birthday);
            listBoxDetails.Items.Add("Hometown: " + LoggedInUser.Hometown);
            listBoxDetails.Items.Add("RelationshipStatus: " + LoggedInUser.RelationshipStatus);
            listBoxDetails.Items.Add("Religion: " + LoggedInUser.Religion);
            listBoxDetails.Items.Add("TimeZone: " + LoggedInUser.TimeZone);
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
                m_Posts = LoggedInUser.Posts;
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
                m_Albums = LoggedInUser.Albums;
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
                Friends = LoggedInUser.Friends;
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
            this.Hide();

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
            this.Hide();
            rm_LoginForm.ShowDialog();
        }
        #endregion Logout

    }
}
