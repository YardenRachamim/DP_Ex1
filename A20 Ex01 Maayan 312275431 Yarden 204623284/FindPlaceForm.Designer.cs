namespace A20_Ex01_Maayan_312275431_Yarden_204623284
{
    partial class FindPlaceForm
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
            this.buttonLoadXMLList = new System.Windows.Forms.Button();
            this.listBoxNotSelected = new System.Windows.Forms.ListBox();
            this.listBoxSelected = new System.Windows.Forms.ListBox();
            this.panelSelsectFriends = new System.Windows.Forms.Panel();
            this.labelSearchBox = new System.Windows.Forms.Label();
            this.pictureBoxClearSearch = new System.Windows.Forms.PictureBox();
            this.buttonFindPlaces = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.pictureBoxArrows = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewCommonPages = new System.Windows.Forms.ListView();
            this.panelPagesResults = new System.Windows.Forms.Panel();
            this.buttonBack = new System.Windows.Forms.Button();
            this.panelSelsectFriends.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClearSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrows)).BeginInit();
            this.panelPagesResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLoadXMLList
            // 
            this.buttonLoadXMLList.Location = new System.Drawing.Point(15, 417);
            this.buttonLoadXMLList.Name = "buttonLoadXMLList";
            this.buttonLoadXMLList.Size = new System.Drawing.Size(196, 32);
            this.buttonLoadXMLList.TabIndex = 2;
            this.buttonLoadXMLList.Text = "Load last close friend List";
            this.buttonLoadXMLList.UseVisualStyleBackColor = true;
            this.buttonLoadXMLList.Click += new System.EventHandler(this.buttonLoadXMLList_Click);
            // 
            // listBoxNotSelected
            // 
            this.listBoxNotSelected.FormattingEnabled = true;
            this.listBoxNotSelected.ItemHeight = 16;
            this.listBoxNotSelected.Location = new System.Drawing.Point(15, 71);
            this.listBoxNotSelected.Name = "listBoxNotSelected";
            this.listBoxNotSelected.Size = new System.Drawing.Size(300, 324);
            this.listBoxNotSelected.TabIndex = 3;
            this.listBoxNotSelected.DoubleClick += new System.EventHandler(this.listBoxNotSelected_SelectedIndexDoubleClicked);
            // 
            // listBoxSelected
            // 
            this.listBoxSelected.FormattingEnabled = true;
            this.listBoxSelected.ItemHeight = 16;
            this.listBoxSelected.Location = new System.Drawing.Point(427, 71);
            this.listBoxSelected.Name = "listBoxSelected";
            this.listBoxSelected.Size = new System.Drawing.Size(300, 324);
            this.listBoxSelected.TabIndex = 4;
            this.listBoxSelected.DoubleClick += new System.EventHandler(this.listBoxSelected_SelectedIndexDoubleClicked);
            // 
            // panelSelsectFriends
            // 
            this.panelSelsectFriends.Controls.Add(this.labelSearchBox);
            this.panelSelsectFriends.Controls.Add(this.pictureBoxClearSearch);
            this.panelSelsectFriends.Controls.Add(this.buttonFindPlaces);
            this.panelSelsectFriends.Controls.Add(this.label3);
            this.panelSelsectFriends.Controls.Add(this.buttonLoadXMLList);
            this.panelSelsectFriends.Controls.Add(this.label2);
            this.panelSelsectFriends.Controls.Add(this.textBoxSearch);
            this.panelSelsectFriends.Controls.Add(this.pictureBoxArrows);
            this.panelSelsectFriends.Controls.Add(this.listBoxNotSelected);
            this.panelSelsectFriends.Controls.Add(this.listBoxSelected);
            this.panelSelsectFriends.Location = new System.Drawing.Point(12, 15);
            this.panelSelsectFriends.Name = "panelSelsectFriends";
            this.panelSelsectFriends.Size = new System.Drawing.Size(758, 477);
            this.panelSelsectFriends.TabIndex = 6;
            // 
            // labelSearchBox
            // 
            this.labelSearchBox.AutoSize = true;
            this.labelSearchBox.BackColor = System.Drawing.Color.White;
            this.labelSearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelSearchBox.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelSearchBox.Location = new System.Drawing.Point(27, 7);
            this.labelSearchBox.Name = "labelSearchBox";
            this.labelSearchBox.Size = new System.Drawing.Size(54, 16);
            this.labelSearchBox.TabIndex = 12;
            this.labelSearchBox.Text = "Name...";
            // 
            // pictureBoxClearSearch
            // 
            this.pictureBoxClearSearch.ImageLocation = "https://cdn2.iconfinder.com/data/icons/media-and-navigation-buttons-round/512/But" +
    "ton_12-512.png";
            this.pictureBoxClearSearch.Location = new System.Drawing.Point(293, 7);
            this.pictureBoxClearSearch.Name = "pictureBoxClearSearch";
            this.pictureBoxClearSearch.Size = new System.Drawing.Size(15, 15);
            this.pictureBoxClearSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxClearSearch.TabIndex = 8;
            this.pictureBoxClearSearch.TabStop = false;
            this.pictureBoxClearSearch.Click += new System.EventHandler(this.pictureBoxClearSearch_Click);
            // 
            // buttonFindPlaces
            // 
            this.buttonFindPlaces.Location = new System.Drawing.Point(518, 3);
            this.buttonFindPlaces.Name = "buttonFindPlaces";
            this.buttonFindPlaces.Size = new System.Drawing.Size(209, 30);
            this.buttonFindPlaces.TabIndex = 7;
            this.buttonFindPlaces.Text = "Find places liked by all";
            this.buttonFindPlaces.UseVisualStyleBackColor = true;
            this.buttonFindPlaces.Click += new System.EventHandler(this.buttonFindPlaces_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(424, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Selected";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Not selected";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBoxSearch.Location = new System.Drawing.Point(15, 4);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(301, 22);
            this.textBoxSearch.TabIndex = 9;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // pictureBoxArrows
            // 
            this.pictureBoxArrows.ImageLocation = "https://cdn.iconscout.com/icon/free/png-512/arrow-path-way-direction-sign-bidirec" +
    "tional-left-right-2-30091.png";
            this.pictureBoxArrows.Location = new System.Drawing.Point(344, 212);
            this.pictureBoxArrows.Name = "pictureBoxArrows";
            this.pictureBoxArrows.Size = new System.Drawing.Size(56, 60);
            this.pictureBoxArrows.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxArrows.TabIndex = 5;
            this.pictureBoxArrows.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Sorted Common Pages";
            // 
            // listViewCommonPages
            // 
            this.listViewCommonPages.HideSelection = false;
            this.listViewCommonPages.Location = new System.Drawing.Point(19, 51);
            this.listViewCommonPages.Name = "listViewCommonPages";
            this.listViewCommonPages.Size = new System.Drawing.Size(680, 382);
            this.listViewCommonPages.TabIndex = 14;
            this.listViewCommonPages.UseCompatibleStateImageBehavior = false;
            // 
            // panelPagesResults
            // 
            this.panelPagesResults.Controls.Add(this.buttonBack);
            this.panelPagesResults.Controls.Add(this.listViewCommonPages);
            this.panelPagesResults.Controls.Add(this.label1);
            this.panelPagesResults.Location = new System.Drawing.Point(12, 12);
            this.panelPagesResults.Name = "panelPagesResults";
            this.panelPagesResults.Size = new System.Drawing.Size(755, 480);
            this.panelPagesResults.TabIndex = 13;
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(19, 454);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 15;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // FindPlaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 506);
            this.Controls.Add(this.panelPagesResults);
            this.Controls.Add(this.panelSelsectFriends);
            this.Name = "FindPlaceForm";
            this.Text = "Find places to hang out with close friends";
            this.panelSelsectFriends.ResumeLayout(false);
            this.panelSelsectFriends.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClearSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrows)).EndInit();
            this.panelPagesResults.ResumeLayout(false);
            this.panelPagesResults.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonLoadXMLList;
        private System.Windows.Forms.ListBox listBoxNotSelected;
        private System.Windows.Forms.ListBox listBoxSelected;
        private System.Windows.Forms.Panel panelSelsectFriends;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonFindPlaces;
        private System.Windows.Forms.PictureBox pictureBoxArrows;
        private System.Windows.Forms.PictureBox pictureBoxClearSearch;
        private System.Windows.Forms.Label labelSearchBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewCommonPages;
        private System.Windows.Forms.Panel panelPagesResults;
        private System.Windows.Forms.Button buttonBack;
    }
}