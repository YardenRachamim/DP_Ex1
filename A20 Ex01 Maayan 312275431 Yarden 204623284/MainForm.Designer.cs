namespace A20_Ex01_Maayan_312275431_Yarden_204623284
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoggedInUserPictureBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelUserDetails = new System.Windows.Forms.Label();
            this.listBoxDetails = new System.Windows.Forms.ListBox();
            this.listBoxPosts = new System.Windows.Forms.ListBox();
            this.checkBoxPosts = new System.Windows.Forms.CheckBox();
            this.checkBoxAlbums = new System.Windows.Forms.CheckBox();
            this.listBoxAlbums = new System.Windows.Forms.ListBox();
            this.checkBoxFriends = new System.Windows.Forms.CheckBox();
            this.listBoxFriends = new System.Windows.Forms.ListBox();
            this.buttonFindPlaces = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LoggedInUserPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoggedInUserPictureBox
            // 
            this.LoggedInUserPictureBox.Location = new System.Drawing.Point(3, 31);
            this.LoggedInUserPictureBox.Name = "LoggedInUserPictureBox";
            this.LoggedInUserPictureBox.Size = new System.Drawing.Size(132, 116);
            this.LoggedInUserPictureBox.TabIndex = 0;
            this.LoggedInUserPictureBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelUserDetails);
            this.panel1.Controls.Add(this.listBoxDetails);
            this.panel1.Controls.Add(this.LoggedInUserPictureBox);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(363, 154);
            this.panel1.TabIndex = 2;
            // 
            // labelUserDetails
            // 
            this.labelUserDetails.AutoSize = true;
            this.labelUserDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelUserDetails.Location = new System.Drawing.Point(3, 3);
            this.labelUserDetails.Name = "labelUserDetails";
            this.labelUserDetails.Size = new System.Drawing.Size(117, 25);
            this.labelUserDetails.TabIndex = 3;
            this.labelUserDetails.Text = "User Details";
            // 
            // listBoxDetails
            // 
            this.listBoxDetails.FormattingEnabled = true;
            this.listBoxDetails.ItemHeight = 16;
            this.listBoxDetails.Location = new System.Drawing.Point(141, 31);
            this.listBoxDetails.Name = "listBoxDetails";
            this.listBoxDetails.Size = new System.Drawing.Size(214, 116);
            this.listBoxDetails.TabIndex = 2;
            // 
            // listBoxPosts
            // 
            this.listBoxPosts.FormattingEnabled = true;
            this.listBoxPosts.ItemHeight = 16;
            this.listBoxPosts.Location = new System.Drawing.Point(15, 256);
            this.listBoxPosts.Name = "listBoxPosts";
            this.listBoxPosts.Size = new System.Drawing.Size(350, 436);
            this.listBoxPosts.TabIndex = 3;
            // 
            // checkBoxPosts
            // 
            this.checkBoxPosts.AutoSize = true;
            this.checkBoxPosts.Location = new System.Drawing.Point(15, 229);
            this.checkBoxPosts.Name = "checkBoxPosts";
            this.checkBoxPosts.Size = new System.Drawing.Size(102, 21);
            this.checkBoxPosts.TabIndex = 4;
            this.checkBoxPosts.Text = "Show posts";
            this.checkBoxPosts.UseVisualStyleBackColor = true;
            this.checkBoxPosts.CheckedChanged += new System.EventHandler(this.checkBoxPosts_CheckedChanged);
            // 
            // checkBoxAlbums
            // 
            this.checkBoxAlbums.AutoSize = true;
            this.checkBoxAlbums.Location = new System.Drawing.Point(395, 229);
            this.checkBoxAlbums.Name = "checkBoxAlbums";
            this.checkBoxAlbums.Size = new System.Drawing.Size(162, 21);
            this.checkBoxAlbums.TabIndex = 6;
            this.checkBoxAlbums.Text = "Show album\'s names";
            this.checkBoxAlbums.UseVisualStyleBackColor = true;
            this.checkBoxAlbums.CheckedChanged += new System.EventHandler(this.checkBoxAlbums_CheckedChanged);
            // 
            // listBoxAlbums
            // 
            this.listBoxAlbums.FormattingEnabled = true;
            this.listBoxAlbums.ItemHeight = 16;
            this.listBoxAlbums.Location = new System.Drawing.Point(395, 256);
            this.listBoxAlbums.Name = "listBoxAlbums";
            this.listBoxAlbums.Size = new System.Drawing.Size(350, 436);
            this.listBoxAlbums.TabIndex = 5;
            // 
            // checkBoxFriends
            // 
            this.checkBoxFriends.AutoSize = true;
            this.checkBoxFriends.Location = new System.Drawing.Point(775, 229);
            this.checkBoxFriends.Name = "checkBoxFriends";
            this.checkBoxFriends.Size = new System.Drawing.Size(111, 21);
            this.checkBoxFriends.TabIndex = 8;
            this.checkBoxFriends.Text = "Show friends";
            this.checkBoxFriends.UseVisualStyleBackColor = true;
            this.checkBoxFriends.CheckedChanged += new System.EventHandler(this.checkBoxFriends_CheckedChanged);
            // 
            // listBoxFriends
            // 
            this.listBoxFriends.FormattingEnabled = true;
            this.listBoxFriends.ItemHeight = 16;
            this.listBoxFriends.Location = new System.Drawing.Point(775, 256);
            this.listBoxFriends.Name = "listBoxFriends";
            this.listBoxFriends.Size = new System.Drawing.Size(350, 436);
            this.listBoxFriends.TabIndex = 9;
            // 
            // buttonFindPlaces
            // 
            this.buttonFindPlaces.Location = new System.Drawing.Point(470, 43);
            this.buttonFindPlaces.Name = "buttonFindPlaces";
            this.buttonFindPlaces.Size = new System.Drawing.Size(168, 101);
            this.buttonFindPlaces.TabIndex = 10;
            this.buttonFindPlaces.Text = "Find Places";
            this.buttonFindPlaces.UseVisualStyleBackColor = true;
            this.buttonFindPlaces.Click += new System.EventHandler(this.buttonFindPlaces_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 707);
            this.Controls.Add(this.buttonFindPlaces);
            this.Controls.Add(this.listBoxFriends);
            this.Controls.Add(this.checkBoxFriends);
            this.Controls.Add(this.checkBoxAlbums);
            this.Controls.Add(this.listBoxAlbums);
            this.Controls.Add(this.checkBoxPosts);
            this.Controls.Add(this.listBoxPosts);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Amazing FB App :)";
            ((System.ComponentModel.ISupportInitialize)(this.LoggedInUserPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox LoggedInUserPictureBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBoxDetails;
        private System.Windows.Forms.Label labelUserDetails;
        private System.Windows.Forms.ListBox listBoxPosts;
        private System.Windows.Forms.CheckBox checkBoxPosts;
        private System.Windows.Forms.CheckBox checkBoxAlbums;
        private System.Windows.Forms.ListBox listBoxAlbums;
        private System.Windows.Forms.CheckBox checkBoxFriends;
        private System.Windows.Forms.ListBox listBoxFriends;
        private System.Windows.Forms.Button buttonFindPlaces;
    }
}