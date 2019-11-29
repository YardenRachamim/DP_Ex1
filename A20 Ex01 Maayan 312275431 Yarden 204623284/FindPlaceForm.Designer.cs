using System;

namespace FacebookApp
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelSearchBox = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.pictureBoxClearSearch = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBoxArrows = new System.Windows.Forms.PictureBox();
            this.buttonFindPlaces = new System.Windows.Forms.Button();
            this.listBoxPlaces = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClearSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrows)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLoadXMLList
            // 
            this.buttonLoadXMLList.Location = new System.Drawing.Point(27, 535);
            this.buttonLoadXMLList.Name = "buttonLoadXMLList";
            this.buttonLoadXMLList.Size = new System.Drawing.Size(143, 30);
            this.buttonLoadXMLList.TabIndex = 2;
            this.buttonLoadXMLList.Text = "Load close friend";
            this.buttonLoadXMLList.UseVisualStyleBackColor = true;
            this.buttonLoadXMLList.Click += new System.EventHandler(this.buttonLoadXMLList_Click);
            // 
            // listBoxNotSelected
            // 
            this.listBoxNotSelected.FormattingEnabled = true;
            this.listBoxNotSelected.ItemHeight = 16;
            this.listBoxNotSelected.Location = new System.Drawing.Point(15, 57);
            this.listBoxNotSelected.Name = "listBoxNotSelected";
            this.listBoxNotSelected.Size = new System.Drawing.Size(209, 308);
            this.listBoxNotSelected.TabIndex = 3;
            this.listBoxNotSelected.DoubleClick += new System.EventHandler(this.listBoxNotSelected_SelectedIndexDoubleClicked);
            // 
            // listBoxSelected
            // 
            this.listBoxSelected.FormattingEnabled = true;
            this.listBoxSelected.ItemHeight = 16;
            this.listBoxSelected.Location = new System.Drawing.Point(284, 57);
            this.listBoxSelected.Name = "listBoxSelected";
            this.listBoxSelected.Size = new System.Drawing.Size(209, 308);
            this.listBoxSelected.TabIndex = 4;
            this.listBoxSelected.DoubleClick += new System.EventHandler(this.listBoxSelected_SelectedIndexDoubleClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelSearchBox);
            this.panel1.Controls.Add(this.pictureBoxClearSearch);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxSearch);
            this.panel1.Controls.Add(this.pictureBoxArrows);
            this.panel1.Controls.Add(this.listBoxNotSelected);
            this.panel1.Controls.Add(this.listBoxSelected);
            this.panel1.Location = new System.Drawing.Point(18, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 412);
            this.panel1.TabIndex = 6;
            // 
            // labelSearchBox
            // 
            this.labelSearchBox.AutoSize = true;
            this.labelSearchBox.BackColor = System.Drawing.Color.White;
            this.labelSearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelSearchBox.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelSearchBox.Location = new System.Drawing.Point(27, 5);
            this.labelSearchBox.Name = "labelSearchBox";
            this.labelSearchBox.Size = new System.Drawing.Size(54, 16);
            this.labelSearchBox.TabIndex = 12;
            this.labelSearchBox.Text = "Name...";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBoxSearch.Location = new System.Drawing.Point(15, 2);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(209, 22);
            this.textBoxSearch.TabIndex = 9;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // pictureBoxClearSearch
            // 
            this.pictureBoxClearSearch.ImageLocation = "https://cdn2.iconfinder.com/data/icons/media-and-navigation-buttons-round/512/But" +
    "ton_12-512.png";
            this.pictureBoxClearSearch.Location = new System.Drawing.Point(204, 7);
            this.pictureBoxClearSearch.Name = "pictureBoxClearSearch";
            this.pictureBoxClearSearch.Size = new System.Drawing.Size(15, 15);
            this.pictureBoxClearSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxClearSearch.TabIndex = 8;
            this.pictureBoxClearSearch.TabStop = false;
            this.pictureBoxClearSearch.Click += new System.EventHandler(this.pictureBoxClearSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(281, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Selected";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Not selected";
            // 
            // pictureBoxArrows
            // 
            this.pictureBoxArrows.ImageLocation = "https://cdn.iconscout.com/icon/free/png-512/arrow-path-way-direction-sign-bidirec" +
    "tional-left-right-2-30091.png";
            this.pictureBoxArrows.Location = new System.Drawing.Point(227, 184);
            this.pictureBoxArrows.Name = "pictureBoxArrows";
            this.pictureBoxArrows.Size = new System.Drawing.Size(56, 60);
            this.pictureBoxArrows.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxArrows.TabIndex = 5;
            this.pictureBoxArrows.TabStop = false;
            // 
            // buttonFindPlaces
            // 
            this.buttonFindPlaces.Location = new System.Drawing.Point(324, 54);
            this.buttonFindPlaces.Name = "buttonFindPlaces";
            this.buttonFindPlaces.Size = new System.Drawing.Size(191, 30);
            this.buttonFindPlaces.TabIndex = 7;
            this.buttonFindPlaces.Text = "Find places liked by all";
            this.buttonFindPlaces.UseVisualStyleBackColor = true;
            this.buttonFindPlaces.Click += new System.EventHandler(this.buttonFindPlaces_Click);
            // 
            // listBoxPlaces
            // 
            this.listBoxPlaces.FormattingEnabled = true;
            this.listBoxPlaces.ItemHeight = 16;
            this.listBoxPlaces.Location = new System.Drawing.Point(668, 105);
            this.listBoxPlaces.Name = "listBoxPlaces";
            this.listBoxPlaces.Size = new System.Drawing.Size(349, 404);
            this.listBoxPlaces.TabIndex = 12;
            // 
            // FindPlaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 605);
            this.Controls.Add(this.listBoxPlaces);
            this.Controls.Add(this.buttonFindPlaces);
            this.Controls.Add(this.buttonLoadXMLList);
            this.Controls.Add(this.panel1);
            this.Name = "FindPlaceForm";
            this.Text = "Find places to hang out with close friends";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClearSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrows)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonLoadXMLList;
        private System.Windows.Forms.ListBox listBoxNotSelected;
        private System.Windows.Forms.ListBox listBoxSelected;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonFindPlaces;
        private System.Windows.Forms.PictureBox pictureBoxArrows;
        private System.Windows.Forms.PictureBox pictureBoxClearSearch;
        private System.Windows.Forms.ListBox listBoxPlaces;
        private System.Windows.Forms.Label labelSearchBox;
    }
}