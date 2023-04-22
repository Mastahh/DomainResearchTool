namespace DomainResearchTool
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
            mainGrids = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            cbGridPageSize = new ComboBox();
            lblGridPageSize = new Label();
            gbHighlight.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            gbLogicSwitch.SuspendLayout();
            mainGrids.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // gbHighlight
            // 
            gbHighlight.Controls.Add(tableLayoutPanel1);
            gbHighlight.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            gbHighlight.Location = new Point(10, 3);
            gbHighlight.Margin = new Padding(10, 3, 3, 3);
            gbHighlight.Name = "gbHighlight";
            gbHighlight.Size = new Size(209, 140);
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
            tableLayoutPanel1.Size = new Size(203, 112);
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
            blazorWebViewDomains.Dock = DockStyle.Fill;
            blazorWebViewDomains.Location = new Point(3, 157);
            blazorWebViewDomains.MinimumSize = new Size(450, 500);
            blazorWebViewDomains.Name = "blazorWebViewDomains";
            blazorWebViewDomains.Size = new Size(450, 500);
            blazorWebViewDomains.TabIndex = 2;
            // 
            // gbLogicSwitch
            // 
            gbLogicSwitch.Controls.Add(radioOr);
            gbLogicSwitch.Controls.Add(radioAnd);
            gbLogicSwitch.Location = new Point(225, 7);
            gbLogicSwitch.Margin = new Padding(3, 7, 3, 3);
            gbLogicSwitch.Name = "gbLogicSwitch";
            gbLogicSwitch.Size = new Size(100, 136);
            gbLogicSwitch.TabIndex = 3;
            gbLogicSwitch.TabStop = false;
            // 
            // blazorWebViewFavorites
            // 
            blazorWebViewFavorites.Dock = DockStyle.Fill;
            blazorWebViewFavorites.Location = new Point(453, 157);
            blazorWebViewFavorites.MinimumSize = new Size(450, 500);
            blazorWebViewFavorites.Name = "blazorWebViewFavorites";
            blazorWebViewFavorites.Size = new Size(450, 500);
            blazorWebViewFavorites.TabIndex = 2;
            // 
            // mainGrids
            // 
            mainGrids.AutoSize = true;
            mainGrids.ColumnCount = 2;
            mainGrids.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 450F));
            mainGrids.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainGrids.Controls.Add(flowLayoutPanel1, 0, 0);
            mainGrids.Controls.Add(blazorWebViewFavorites, 1, 1);
            mainGrids.Controls.Add(blazorWebViewDomains, 0, 1);
            mainGrids.Controls.Add(tableLayoutPanel2, 1, 0);
            mainGrids.Dock = DockStyle.Fill;
            mainGrids.Location = new Point(0, 0);
            mainGrids.Name = "mainGrids";
            mainGrids.RowCount = 2;
            mainGrids.RowStyles.Add(new RowStyle());
            mainGrids.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainGrids.Size = new Size(798, 425);
            mainGrids.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(gbHighlight);
            flowLayoutPanel1.Controls.Add(gbLogicSwitch);
            flowLayoutPanel1.Location = new Point(3, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(365, 148);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 152F));
            tableLayoutPanel2.Controls.Add(cbGridPageSize, 1, 0);
            tableLayoutPanel2.Controls.Add(lblGridPageSize, 0, 0);
            tableLayoutPanel2.Location = new Point(453, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel2.Size = new Size(302, 100);
            tableLayoutPanel2.TabIndex = 6;
            // 
            // cbGridPageSize
            // 
            cbGridPageSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGridPageSize.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbGridPageSize.FormattingEnabled = true;
            cbGridPageSize.Location = new Point(153, 3);
            cbGridPageSize.Name = "cbGridPageSize";
            cbGridPageSize.Size = new Size(130, 29);
            cbGridPageSize.TabIndex = 4;
            cbGridPageSize.SelectedIndexChanged += cbGridPageSize_SelectedIndexChanged;
            // 
            // lblGridPageSize
            // 
            lblGridPageSize.AutoSize = true;
            lblGridPageSize.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblGridPageSize.Location = new Point(3, 5);
            lblGridPageSize.Margin = new Padding(3, 5, 3, 0);
            lblGridPageSize.Name = "lblGridPageSize";
            lblGridPageSize.Size = new Size(111, 21);
            lblGridPageSize.TabIndex = 5;
            lblGridPageSize.Text = "Grid page size:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(798, 425);
            Controls.Add(mainGrids);
            MinimumSize = new Size(804, 435);
            Name = "MainForm";
            Text = "Domain Research Tool v0.8";
            gbHighlight.ResumeLayout(false);
            gbHighlight.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            gbLogicSwitch.ResumeLayout(false);
            gbLogicSwitch.PerformLayout();
            mainGrids.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
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
        private TableLayoutPanel mainGrids;
        private FlowLayoutPanel flowLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private ComboBox cbGridPageSize;
        private Label lblGridPageSize;
    }
}