namespace Assignment_3_Solar4U
{
    partial class SearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.SearchOrderLabel = new System.Windows.Forms.Label();
            this.SearchPanel = new System.Windows.Forms.Panel();
            this.NoteLabel = new System.Windows.Forms.Label();
            this.FindOrderButton = new System.Windows.Forms.Button();
            this.SearchInfoPanel = new System.Windows.Forms.Panel();
            this.OrderInfoTextBox = new System.Windows.Forms.TextBox();
            this.SearchPanel.SuspendLayout();
            this.SearchInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(6, 71);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(168, 28);
            this.SearchTextBox.TabIndex = 0;
            // 
            // SearchOrderLabel
            // 
            this.SearchOrderLabel.AutoSize = true;
            this.SearchOrderLabel.Location = new System.Drawing.Point(6, 34);
            this.SearchOrderLabel.Name = "SearchOrderLabel";
            this.SearchOrderLabel.Size = new System.Drawing.Size(125, 18);
            this.SearchOrderLabel.TabIndex = 1;
            this.SearchOrderLabel.Text = "Search Order:";
            // 
            // SearchPanel
            // 
            this.SearchPanel.BackColor = System.Drawing.SystemColors.Highlight;
            this.SearchPanel.Controls.Add(this.NoteLabel);
            this.SearchPanel.Controls.Add(this.FindOrderButton);
            this.SearchPanel.Controls.Add(this.SearchOrderLabel);
            this.SearchPanel.Controls.Add(this.SearchTextBox);
            this.SearchPanel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SearchPanel.Location = new System.Drawing.Point(27, 39);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Size = new System.Drawing.Size(223, 285);
            this.SearchPanel.TabIndex = 2;
            // 
            // NoteLabel
            // 
            this.NoteLabel.AutoSize = true;
            this.NoteLabel.Location = new System.Drawing.Point(9, 106);
            this.NoteLabel.Name = "NoteLabel";
            this.NoteLabel.Size = new System.Drawing.Size(197, 54);
            this.NoteLabel.TabIndex = 5;
            this.NoteLabel.Text = "Note: \r\nBy Date(dd-mm-yyyy)\r\nBy Transaction Number";
            // 
            // FindOrderButton
            // 
            this.FindOrderButton.BackColor = System.Drawing.Color.DarkOrange;
            this.FindOrderButton.Location = new System.Drawing.Point(9, 217);
            this.FindOrderButton.Name = "FindOrderButton";
            this.FindOrderButton.Size = new System.Drawing.Size(84, 35);
            this.FindOrderButton.TabIndex = 4;
            this.FindOrderButton.Text = "Search";
            this.FindOrderButton.UseVisualStyleBackColor = false;
            this.FindOrderButton.Click += new System.EventHandler(this.FindOrderButton_Click);
            // 
            // SearchInfoPanel
            // 
            this.SearchInfoPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.SearchInfoPanel.Controls.Add(this.OrderInfoTextBox);
            this.SearchInfoPanel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SearchInfoPanel.Location = new System.Drawing.Point(296, 39);
            this.SearchInfoPanel.Name = "SearchInfoPanel";
            this.SearchInfoPanel.Size = new System.Drawing.Size(417, 399);
            this.SearchInfoPanel.TabIndex = 3;
            // 
            // OrderInfoTextBox
            // 
            this.OrderInfoTextBox.AcceptsReturn = true;
            this.OrderInfoTextBox.AcceptsTab = true;
            this.OrderInfoTextBox.Location = new System.Drawing.Point(34, 17);
            this.OrderInfoTextBox.Multiline = true;
            this.OrderInfoTextBox.Name = "OrderInfoTextBox";
            this.OrderInfoTextBox.ReadOnly = true;
            this.OrderInfoTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OrderInfoTextBox.Size = new System.Drawing.Size(335, 379);
            this.OrderInfoTextBox.TabIndex = 0;
            this.OrderInfoTextBox.Visible = false;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 450);
            this.Controls.Add(this.SearchInfoPanel);
            this.Controls.Add(this.SearchPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SearchForm";
            this.Text = "Solar4U Searching Page";
            this.SearchPanel.ResumeLayout(false);
            this.SearchPanel.PerformLayout();
            this.SearchInfoPanel.ResumeLayout(false);
            this.SearchInfoPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Label SearchOrderLabel;
        private System.Windows.Forms.Panel SearchPanel;
        private System.Windows.Forms.Button FindOrderButton;
        private System.Windows.Forms.Panel SearchInfoPanel;
        private System.Windows.Forms.Label NoteLabel;
        private System.Windows.Forms.TextBox OrderInfoTextBox;
    }
}