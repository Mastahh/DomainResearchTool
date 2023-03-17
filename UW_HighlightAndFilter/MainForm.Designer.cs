namespace UW_HighlightAndFilter
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gbHighlight = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            chkFirstNames = new CheckBox();
            chkCities = new CheckBox();
            chkStates = new CheckBox();
            chkServices = new CheckBox();
            lblFirstNameColor = new Label();
            lblCitiesColor = new Label();
            lblStatesColor = new Label();
            lblServicesColor = new Label();
            radioAnd = new RadioButton();
            radioOr = new RadioButton();
            colorDialog = new ColorDialog();
            blazorWebViewDomains = new Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView();
            gbLogicSwitch = new GroupBox();
            blazorWebViewFavorites = new Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView();
            gbHighlight.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            gbLogicSwitch.SuspendLayout();
            SuspendLayout();
            // 
            // gbHighlight
            // 
            gbHighlight.AutoSize = true;
            gbHighlight.Controls.Add(tableLayoutPanel1);
            gbHighlight.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            gbHighlight.Location = new Point(19, 16);
            gbHighlight.Margin = new Padding(10, 3, 3, 3);
            gbHighlight.Name = "gbHighlight";
            gbHighlight.Size = new Size(217, 140);
            gbHighlight.TabIndex = 0;
            gbHighlight.TabStop = false;
            gbHighlight.Text = "Highlight";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(chkFirstNames, 0, 0);
            tableLayoutPanel1.Controls.Add(chkCities, 0, 1);
            tableLayoutPanel1.Controls.Add(chkStates, 0, 2);
            tableLayoutPanel1.Controls.Add(chkServices, 0, 3);
            tableLayoutPanel1.Controls.Add(lblFirstNameColor, 1, 0);
            tableLayoutPanel1.Controls.Add(lblCitiesColor, 1, 1);
            tableLayoutPanel1.Controls.Add(lblStatesColor, 1, 2);
            tableLayoutPanel1.Controls.Add(lblServicesColor, 1, 3);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(3, 25);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tableLayoutPanel1.Size = new Size(211, 112);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // chkFirstNames
            // 
            chkFirstNames.CheckAlign = ContentAlignment.MiddleRight;
            chkFirstNames.Dock = DockStyle.Fill;
            chkFirstNames.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chkFirstNames.Location = new Point(3, 3);
            chkFirstNames.Name = "chkFirstNames";
            chkFirstNames.Size = new Size(144, 22);
            chkFirstNames.TabIndex = 0;
            chkFirstNames.Text = "First Names";
            chkFirstNames.UseVisualStyleBackColor = true;
            chkFirstNames.CheckedChanged += OnFilterEnable_CheckedChanged;
            // 
            // chkCities
            // 
            chkCities.CheckAlign = ContentAlignment.MiddleRight;
            chkCities.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chkCities.Location = new Point(3, 31);
            chkCities.Name = "chkCities";
            chkCities.Size = new Size(144, 22);
            chkCities.TabIndex = 0;
            chkCities.Text = "Cities";
            chkCities.UseVisualStyleBackColor = true;
            chkCities.CheckedChanged += OnFilterEnable_CheckedChanged;
            // 
            // chkStates
            // 
            chkStates.CheckAlign = ContentAlignment.MiddleRight;
            chkStates.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chkStates.Location = new Point(3, 59);
            chkStates.Name = "chkStates";
            chkStates.Size = new Size(144, 22);
            chkStates.TabIndex = 0;
            chkStates.Text = "States";
            chkStates.UseVisualStyleBackColor = true;
            chkStates.CheckedChanged += OnFilterEnable_CheckedChanged;
            // 
            // chkServices
            // 
            chkServices.CheckAlign = ContentAlignment.MiddleRight;
            chkServices.Dock = DockStyle.Fill;
            chkServices.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chkServices.Location = new Point(3, 87);
            chkServices.Name = "chkServices";
            chkServices.Size = new Size(144, 22);
            chkServices.TabIndex = 0;
            chkServices.Text = "Services";
            chkServices.UseVisualStyleBackColor = true;
            chkServices.CheckedChanged += OnFilterEnable_CheckedChanged;
            // 
            // lblFirstNameColor
            // 
            lblFirstNameColor.BorderStyle = BorderStyle.FixedSingle;
            lblFirstNameColor.Location = new Point(153, 5);
            lblFirstNameColor.Margin = new Padding(3, 5, 3, 0);
            lblFirstNameColor.Name = "lblFirstNameColor";
            lblFirstNameColor.Size = new Size(20, 20);
            lblFirstNameColor.TabIndex = 2;
            lblFirstNameColor.Click += OnLabelColor_Click;
            // 
            // lblCitiesColor
            // 
            lblCitiesColor.BorderStyle = BorderStyle.FixedSingle;
            lblCitiesColor.Location = new Point(153, 33);
            lblCitiesColor.Margin = new Padding(3, 5, 3, 0);
            lblCitiesColor.Name = "lblCitiesColor";
            lblCitiesColor.Size = new Size(20, 20);
            lblCitiesColor.TabIndex = 2;
            lblCitiesColor.Click += OnLabelColor_Click;
            // 
            // lblStatesColor
            // 
            lblStatesColor.BorderStyle = BorderStyle.FixedSingle;
            lblStatesColor.Location = new Point(153, 61);
            lblStatesColor.Margin = new Padding(3, 5, 3, 0);
            lblStatesColor.Name = "lblStatesColor";
            lblStatesColor.Size = new Size(20, 20);
            lblStatesColor.TabIndex = 2;
            lblStatesColor.Click += OnLabelColor_Click;
            // 
            // lblServicesColor
            // 
            lblServicesColor.BorderStyle = BorderStyle.FixedSingle;
            lblServicesColor.Location = new Point(153, 89);
            lblServicesColor.Margin = new Padding(3, 5, 3, 0);
            lblServicesColor.Name = "lblServicesColor";
            lblServicesColor.Size = new Size(20, 20);
            lblServicesColor.TabIndex = 2;
            lblServicesColor.Click += OnLabelColor_Click;
            // 
            // radioAnd
            // 
            radioAnd.AutoSize = true;
            radioAnd.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            radioAnd.Location = new Point(6, 53);
            radioAnd.Name = "radioAnd";
            radioAnd.Size = new Size(59, 25);
            radioAnd.TabIndex = 1;
            radioAnd.Text = "And";
            radioAnd.UseVisualStyleBackColor = true;
            radioAnd.CheckedChanged += OnLogicOrAnd_CheckedChanged;
            // 
            // radioOr
            // 
            radioOr.AutoSize = true;
            radioOr.Checked = true;
            radioOr.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            radioOr.Location = new Point(6, 22);
            radioOr.Name = "radioOr";
            radioOr.Size = new Size(46, 25);
            radioOr.TabIndex = 1;
            radioOr.TabStop = true;
            radioOr.Text = "Or";
            radioOr.UseVisualStyleBackColor = true;
            radioOr.CheckedChanged += OnLogicOrAnd_CheckedChanged;
            // 
            // blazorWebViewDomains
            // 
            blazorWebViewDomains.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            blazorWebViewDomains.Location = new Point(12, 162);
            blazorWebViewDomains.MinimumSize = new Size(450, 500);
            blazorWebViewDomains.Name = "blazorWebViewDomains";
            blazorWebViewDomains.Size = new Size(453, 500);
            blazorWebViewDomains.TabIndex = 2;
            // 
            // gbLogicSwitch
            // 
            gbLogicSwitch.Controls.Add(radioOr);
            gbLogicSwitch.Controls.Add(radioAnd);
            gbLogicSwitch.Location = new Point(239, 19);
            gbLogicSwitch.Name = "gbLogicSwitch";
            gbLogicSwitch.Size = new Size(217, 136);
            gbLogicSwitch.TabIndex = 3;
            gbLogicSwitch.TabStop = false;
            // 
            // blazorWebViewFavorites
            // 
            blazorWebViewFavorites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            blazorWebViewFavorites.Location = new Point(471, 162);
            blazorWebViewFavorites.MinimumSize = new Size(450, 500);
            blazorWebViewFavorites.Name = "blazorWebViewFavorites";
            blazorWebViewFavorites.Size = new Size(453, 500);
            blazorWebViewFavorites.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1234, 760);
            Controls.Add(gbLogicSwitch);
            Controls.Add(blazorWebViewFavorites);
            Controls.Add(blazorWebViewDomains);
            Controls.Add(gbHighlight);
            MinimumSize = new Size(1000, 600);
            Name = "MainForm";
            Text = "Hightlight and Filter v0.3";
            gbHighlight.ResumeLayout(false);
            gbHighlight.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            gbLogicSwitch.ResumeLayout(false);
            gbLogicSwitch.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gbHighlight;
        private CheckBox chkFirstNames;
        private TableLayoutPanel tableLayoutPanel1;
        private CheckBox chkCities;
        private CheckBox chkStates;
        private CheckBox chkServices;
        private ColorDialog colorDialog;
        private Label lblFirstNameColor;
        private Label lblCitiesColor;
        private Label lblStatesColor;
        private Label lblServicesColor;
        private RadioButton radioOr;
        private RadioButton radioAnd;
        private Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView blazorWebViewDomains;
        private GroupBox gbLogicSwitch;
        private Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView blazorWebViewFavorites;
    }
}