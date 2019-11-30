namespace A20_Ex01_Maayan_312275431_Yarden_204623284
{
    partial class PoolMyRideForm
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
            this.NewRideButton = new System.Windows.Forms.Button();
            this.LoggedInUserPictureBox = new System.Windows.Forms.PictureBox();
            this.JoinRideButton = new System.Windows.Forms.Button();
            this.RideGropButton = new System.Windows.Forms.Button();
            this.NewRide_panel = new System.Windows.Forms.Panel();
            this.NewRide_toComboBox = new System.Windows.Forms.ComboBox();
            this.NewRide_fromComboBox = new System.Windows.Forms.ComboBox();
            this.NewRide_submitButton = new System.Windows.Forms.Button();
            this.NewRide_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.NewRide_whenLabel = new System.Windows.Forms.Label();
            this.NewRide_toLabel = new System.Windows.Forms.Label();
            this.NewRide_fromLabel = new System.Windows.Forms.Label();
            this.NewRide_isDriverCheckBox = new System.Windows.Forms.CheckBox();
            this.NewRide_headerLabel = new System.Windows.Forms.Label();
            this.JoinRide_panel = new System.Windows.Forms.Panel();
            this.JoinRide_button = new System.Windows.Forms.Button();
            this.JoinRide_listBox = new System.Windows.Forms.ListBox();
            this.JoinRide_header = new System.Windows.Forms.Label();
            this.RideGroups_panel = new System.Windows.Forms.Panel();
            this.RideGroups_join = new System.Windows.Forms.Button();
            this.RideGroups_new = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.RideGroups_listBox = new System.Windows.Forms.ListBox();
            this.RideGroups_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LoggedInUserPictureBox)).BeginInit();
            this.NewRide_panel.SuspendLayout();
            this.JoinRide_panel.SuspendLayout();
            this.RideGroups_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // NewRideButton
            // 
            this.NewRideButton.Location = new System.Drawing.Point(12, 219);
            this.NewRideButton.Name = "NewRideButton";
            this.NewRideButton.Size = new System.Drawing.Size(163, 73);
            this.NewRideButton.TabIndex = 0;
            this.NewRideButton.Text = "New Ride";
            this.NewRideButton.UseVisualStyleBackColor = true;
            this.NewRideButton.Click += new System.EventHandler(this.newRideButton_Click);
            // 
            // LoggedInUserPictureBox
            // 
            this.LoggedInUserPictureBox.Location = new System.Drawing.Point(12, 13);
            this.LoggedInUserPictureBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LoggedInUserPictureBox.Name = "LoggedInUserPictureBox";
            this.LoggedInUserPictureBox.Size = new System.Drawing.Size(148, 145);
            this.LoggedInUserPictureBox.TabIndex = 1;
            this.LoggedInUserPictureBox.TabStop = false;
            // 
            // JoinRideButton
            // 
            this.JoinRideButton.Location = new System.Drawing.Point(12, 316);
            this.JoinRideButton.Name = "JoinRideButton";
            this.JoinRideButton.Size = new System.Drawing.Size(163, 73);
            this.JoinRideButton.TabIndex = 2;
            this.JoinRideButton.Text = "Join Existing Ride";
            this.JoinRideButton.UseVisualStyleBackColor = true;
            this.JoinRideButton.Click += new System.EventHandler(this.joinRideButton_Click);
            // 
            // RideGropButton
            // 
            this.RideGropButton.Location = new System.Drawing.Point(12, 420);
            this.RideGropButton.Name = "RideGropButton";
            this.RideGropButton.Size = new System.Drawing.Size(163, 73);
            this.RideGropButton.TabIndex = 3;
            this.RideGropButton.Text = "Ride Groups";
            this.RideGropButton.UseVisualStyleBackColor = true;
            this.RideGropButton.Click += new System.EventHandler(this.findRideButton_Click);
            // 
            // NewRide_panel
            // 
            this.NewRide_panel.Controls.Add(this.NewRide_toComboBox);
            this.NewRide_panel.Controls.Add(this.NewRide_fromComboBox);
            this.NewRide_panel.Controls.Add(this.NewRide_submitButton);
            this.NewRide_panel.Controls.Add(this.NewRide_dateTimePicker);
            this.NewRide_panel.Controls.Add(this.NewRide_whenLabel);
            this.NewRide_panel.Controls.Add(this.NewRide_toLabel);
            this.NewRide_panel.Controls.Add(this.NewRide_fromLabel);
            this.NewRide_panel.Controls.Add(this.NewRide_isDriverCheckBox);
            this.NewRide_panel.Controls.Add(this.NewRide_headerLabel);
            this.NewRide_panel.Location = new System.Drawing.Point(221, 219);
            this.NewRide_panel.Name = "NewRide_panel";
            this.NewRide_panel.Size = new System.Drawing.Size(761, 273);
            this.NewRide_panel.TabIndex = 4;
            // 
            // NewRide_toComboBox
            // 
            this.NewRide_toComboBox.FormattingEnabled = true;
            this.NewRide_toComboBox.Location = new System.Drawing.Point(114, 97);
            this.NewRide_toComboBox.Name = "NewRide_toComboBox";
            this.NewRide_toComboBox.Size = new System.Drawing.Size(121, 28);
            this.NewRide_toComboBox.TabIndex = 10;
            // 
            // NewRide_fromComboBox
            // 
            this.NewRide_fromComboBox.FormattingEnabled = true;
            this.NewRide_fromComboBox.Location = new System.Drawing.Point(114, 50);
            this.NewRide_fromComboBox.Name = "NewRide_fromComboBox";
            this.NewRide_fromComboBox.Size = new System.Drawing.Size(121, 28);
            this.NewRide_fromComboBox.TabIndex = 9;
            // 
            // NewRide_submitButton
            // 
            this.NewRide_submitButton.Location = new System.Drawing.Point(33, 220);
            this.NewRide_submitButton.Name = "NewRide_submitButton";
            this.NewRide_submitButton.Size = new System.Drawing.Size(168, 35);
            this.NewRide_submitButton.TabIndex = 8;
            this.NewRide_submitButton.Text = "Create a New Ride";
            this.NewRide_submitButton.UseVisualStyleBackColor = true;
            this.NewRide_submitButton.Click += new System.EventHandler(this.newRideSubmitButton_Click);
            // 
            // NewRide_dateTimePicker
            // 
            this.NewRide_dateTimePicker.Location = new System.Drawing.Point(104, 135);
            this.NewRide_dateTimePicker.Name = "NewRide_dateTimePicker";
            this.NewRide_dateTimePicker.Size = new System.Drawing.Size(277, 26);
            this.NewRide_dateTimePicker.TabIndex = 7;
            // 
            // NewRide_whenLabel
            // 
            this.NewRide_whenLabel.AutoSize = true;
            this.NewRide_whenLabel.Location = new System.Drawing.Point(29, 141);
            this.NewRide_whenLabel.Name = "NewRide_whenLabel";
            this.NewRide_whenLabel.Size = new System.Drawing.Size(51, 20);
            this.NewRide_whenLabel.TabIndex = 6;
            this.NewRide_whenLabel.Text = "When";
            // 
            // NewRide_toLabel
            // 
            this.NewRide_toLabel.AutoSize = true;
            this.NewRide_toLabel.Location = new System.Drawing.Point(29, 97);
            this.NewRide_toLabel.Name = "NewRide_toLabel";
            this.NewRide_toLabel.Size = new System.Drawing.Size(27, 20);
            this.NewRide_toLabel.TabIndex = 4;
            this.NewRide_toLabel.Text = "To";
            // 
            // NewRide_fromLabel
            // 
            this.NewRide_fromLabel.AutoSize = true;
            this.NewRide_fromLabel.Location = new System.Drawing.Point(29, 53);
            this.NewRide_fromLabel.Name = "NewRide_fromLabel";
            this.NewRide_fromLabel.Size = new System.Drawing.Size(46, 20);
            this.NewRide_fromLabel.TabIndex = 2;
            this.NewRide_fromLabel.Text = "From";
            // 
            // NewRide_isDriverCheckBox
            // 
            this.NewRide_isDriverCheckBox.AutoSize = true;
            this.NewRide_isDriverCheckBox.Location = new System.Drawing.Point(33, 180);
            this.NewRide_isDriverCheckBox.Name = "NewRide_isDriverCheckBox";
            this.NewRide_isDriverCheckBox.Size = new System.Drawing.Size(133, 24);
            this.NewRide_isDriverCheckBox.TabIndex = 1;
            this.NewRide_isDriverCheckBox.Text = "I want to drive";
            this.NewRide_isDriverCheckBox.UseVisualStyleBackColor = true;
            // 
            // NewRide_headerLabel
            // 
            this.NewRide_headerLabel.AutoSize = true;
            this.NewRide_headerLabel.Location = new System.Drawing.Point(3, 0);
            this.NewRide_headerLabel.Name = "NewRide_headerLabel";
            this.NewRide_headerLabel.Size = new System.Drawing.Size(77, 20);
            this.NewRide_headerLabel.TabIndex = 0;
            this.NewRide_headerLabel.Text = "New Ride";
            // 
            // JoinRide_panel
            // 
            this.JoinRide_panel.Controls.Add(this.JoinRide_button);
            this.JoinRide_panel.Controls.Add(this.JoinRide_listBox);
            this.JoinRide_panel.Controls.Add(this.JoinRide_header);
            this.JoinRide_panel.Location = new System.Drawing.Point(218, 222);
            this.JoinRide_panel.Name = "JoinRide_panel";
            this.JoinRide_panel.Size = new System.Drawing.Size(761, 273);
            this.JoinRide_panel.TabIndex = 11;
            // 
            // JoinRide_button
            // 
            this.JoinRide_button.Location = new System.Drawing.Point(0, 207);
            this.JoinRide_button.Name = "JoinRide_button";
            this.JoinRide_button.Size = new System.Drawing.Size(312, 45);
            this.JoinRide_button.TabIndex = 2;
            this.JoinRide_button.Text = "Show Available Rides";
            this.JoinRide_button.UseVisualStyleBackColor = true;
            this.JoinRide_button.Click += new System.EventHandler(this.JoinRide_availableGroup_Click);
            // 
            // JoinRide_listBox
            // 
            this.JoinRide_listBox.FormattingEnabled = true;
            this.JoinRide_listBox.ItemHeight = 20;
            this.JoinRide_listBox.Location = new System.Drawing.Point(3, 37);
            this.JoinRide_listBox.Name = "JoinRide_listBox";
            this.JoinRide_listBox.Size = new System.Drawing.Size(755, 164);
            this.JoinRide_listBox.TabIndex = 1;
            // 
            // JoinRide_header
            // 
            this.JoinRide_header.AutoSize = true;
            this.JoinRide_header.Location = new System.Drawing.Point(3, 0);
            this.JoinRide_header.Name = "JoinRide_header";
            this.JoinRide_header.Size = new System.Drawing.Size(165, 20);
            this.JoinRide_header.TabIndex = 0;
            this.JoinRide_header.Text = "Join to an existing ride";
            // 
            // RideGroups_panel
            // 
            this.RideGroups_panel.Controls.Add(this.RideGroups_label);
            this.RideGroups_panel.Controls.Add(this.RideGroups_listBox);
            this.RideGroups_panel.Controls.Add(this.RideGroups_join);
            this.RideGroups_panel.Controls.Add(this.RideGroups_new);
            this.RideGroups_panel.Location = new System.Drawing.Point(218, 204);
            this.RideGroups_panel.Name = "RideGroups_panel";
            this.RideGroups_panel.Size = new System.Drawing.Size(764, 394);
            this.RideGroups_panel.TabIndex = 12;
            // 
            // RideGroups_join
            // 
            this.RideGroups_join.Location = new System.Drawing.Point(41, 156);
            this.RideGroups_join.Name = "RideGroups_join";
            this.RideGroups_join.Size = new System.Drawing.Size(163, 73);
            this.RideGroups_join.TabIndex = 13;
            this.RideGroups_join.Text = "Join a Ride Group";
            this.RideGroups_join.UseVisualStyleBackColor = true;
            // 
            // RideGroups_new
            // 
            this.RideGroups_new.Location = new System.Drawing.Point(41, 59);
            this.RideGroups_new.Name = "RideGroups_new";
            this.RideGroups_new.Size = new System.Drawing.Size(163, 73);
            this.RideGroups_new.TabIndex = 14;
            this.RideGroups_new.Text = "New Ride Group";
            this.RideGroups_new.UseVisualStyleBackColor = true;
            // 
            // RideGroups_listBox
            // 
            this.RideGroups_listBox.FormattingEnabled = true;
            this.RideGroups_listBox.ItemHeight = 20;
            this.RideGroups_listBox.Location = new System.Drawing.Point(333, 55);
            this.RideGroups_listBox.Name = "RideGroups_listBox";
            this.RideGroups_listBox.Size = new System.Drawing.Size(405, 324);
            this.RideGroups_listBox.TabIndex = 15;
            // 
            // RideGroups_label
            // 
            this.RideGroups_label.AutoSize = true;
            this.RideGroups_label.Location = new System.Drawing.Point(333, 32);
            this.RideGroups_label.Name = "RideGroups_label";
            this.RideGroups_label.Size = new System.Drawing.Size(176, 30);
            this.RideGroups_label.TabIndex = 16;
            this.RideGroups_label.Text = "Existing groups";
            // 
            // PoolMyRideForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 695);
            this.Controls.Add(this.RideGroups_panel);
            this.Controls.Add(this.JoinRide_panel);
            this.Controls.Add(this.NewRide_panel);
            this.Controls.Add(this.RideGropButton);
            this.Controls.Add(this.JoinRideButton);
            this.Controls.Add(this.LoggedInUserPictureBox);
            this.Controls.Add(this.NewRideButton);
            this.Name = "PoolMyRideForm";
            this.Text = "PoolMyRideForm";
            ((System.ComponentModel.ISupportInitialize)(this.LoggedInUserPictureBox)).EndInit();
            this.NewRide_panel.ResumeLayout(false);
            this.NewRide_panel.PerformLayout();
            this.JoinRide_panel.ResumeLayout(false);
            this.JoinRide_panel.PerformLayout();
            this.RideGroups_panel.ResumeLayout(false);
            this.RideGroups_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NewRideButton;
        private System.Windows.Forms.PictureBox LoggedInUserPictureBox;
        private System.Windows.Forms.Button JoinRideButton;
        private System.Windows.Forms.Button RideGropButton;
        private System.Windows.Forms.Panel NewRide_panel;
        private System.Windows.Forms.Button NewRide_submitButton;
        private System.Windows.Forms.DateTimePicker NewRide_dateTimePicker;
        private System.Windows.Forms.Label NewRide_whenLabel;
        private System.Windows.Forms.Label NewRide_toLabel;
        private System.Windows.Forms.Label NewRide_fromLabel;
        private System.Windows.Forms.CheckBox NewRide_isDriverCheckBox;
        private System.Windows.Forms.Label NewRide_headerLabel;
        private System.Windows.Forms.ComboBox NewRide_toComboBox;
        private System.Windows.Forms.ComboBox NewRide_fromComboBox;
        private System.Windows.Forms.Panel JoinRide_panel;
        private System.Windows.Forms.Label JoinRide_header;
        private System.Windows.Forms.ListBox JoinRide_listBox;
        private System.Windows.Forms.Button JoinRide_button;
        private System.Windows.Forms.Panel RideGroups_panel;
        private System.Windows.Forms.Button RideGroups_join;
        private System.Windows.Forms.Button RideGroups_new;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ListBox RideGroups_listBox;
        private System.Windows.Forms.Label RideGroups_label;
    }
}