namespace PrevCap
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.saveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.filePathText = new System.Windows.Forms.TextBox();
            this.showFBDButton = new System.Windows.Forms.Button();
            this.positionText = new System.Windows.Forms.TextBox();
            this.previewButton = new System.Windows.Forms.Button();
            this.getPositionButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.watchCheck = new System.Windows.Forms.CheckBox();
            this.watchIntervalLabel = new System.Windows.Forms.Label();
            this.watchIntervalSpinner = new System.Windows.Forms.NumericUpDown();
            this.kancolleRadio = new System.Windows.Forms.RadioButton();
            this.shiroproRadio = new System.Windows.Forms.RadioButton();
            this.targetGroup = new System.Windows.Forms.GroupBox();
            this.successGettingPositionMark = new System.Windows.Forms.Label();
            this.watchDurationSpinner = new System.Windows.Forms.NumericUpDown();
            this.watchLengthLabel = new System.Windows.Forms.Label();
            this.showHistoryImageButton = new System.Windows.Forms.Button();
            this.displayLabel = new System.Windows.Forms.Label();
            this.displayCombo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.watchIntervalSpinner)).BeginInit();
            this.targetGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.watchDurationSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 78);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(77, 75);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "保存";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "保存先";
            // 
            // filePathText
            // 
            this.filePathText.Location = new System.Drawing.Point(57, 53);
            this.filePathText.Name = "filePathText";
            this.filePathText.Size = new System.Drawing.Size(263, 19);
            this.filePathText.TabIndex = 2;
            this.filePathText.TextChanged += new System.EventHandler(this.filePathText_TextChanged);
            // 
            // showFBDButton
            // 
            this.showFBDButton.Location = new System.Drawing.Point(326, 51);
            this.showFBDButton.Name = "showFBDButton";
            this.showFBDButton.Size = new System.Drawing.Size(23, 23);
            this.showFBDButton.TabIndex = 3;
            this.showFBDButton.Text = "...";
            this.showFBDButton.UseVisualStyleBackColor = true;
            this.showFBDButton.Click += new System.EventHandler(this.showFBDButton_Click);
            // 
            // positionText
            // 
            this.positionText.Location = new System.Drawing.Point(263, 82);
            this.positionText.Name = "positionText";
            this.positionText.ReadOnly = true;
            this.positionText.Size = new System.Drawing.Size(86, 19);
            this.positionText.TabIndex = 5;
            // 
            // previewButton
            // 
            this.previewButton.Location = new System.Drawing.Point(105, 78);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(77, 75);
            this.previewButton.TabIndex = 6;
            this.previewButton.Text = "プレビュー";
            this.previewButton.UseVisualStyleBackColor = true;
            this.previewButton.Click += new System.EventHandler(this.previewButton_Click);
            // 
            // getPositionButton
            // 
            this.getPositionButton.Location = new System.Drawing.Point(194, 78);
            this.getPositionButton.Name = "getPositionButton";
            this.getPositionButton.Size = new System.Drawing.Size(63, 27);
            this.getPositionButton.TabIndex = 7;
            this.getPositionButton.Text = "座標取得";
            this.getPositionButton.UseVisualStyleBackColor = true;
            this.getPositionButton.Click += new System.EventHandler(this.getPositionButton_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // watchCheck
            // 
            this.watchCheck.AutoSize = true;
            this.watchCheck.Location = new System.Drawing.Point(194, 111);
            this.watchCheck.Name = "watchCheck";
            this.watchCheck.Size = new System.Drawing.Size(72, 16);
            this.watchCheck.TabIndex = 8;
            this.watchCheck.Text = "画面監視";
            this.watchCheck.UseVisualStyleBackColor = true;
            this.watchCheck.CheckedChanged += new System.EventHandler(this.watchCheck_CheckedChanged);
            // 
            // watchIntervalLabel
            // 
            this.watchIntervalLabel.AutoSize = true;
            this.watchIntervalLabel.Location = new System.Drawing.Point(341, 112);
            this.watchIntervalLabel.Name = "watchIntervalLabel";
            this.watchIntervalLabel.Size = new System.Drawing.Size(29, 12);
            this.watchIntervalLabel.TabIndex = 10;
            this.watchIntervalLabel.Text = "秒毎";
            // 
            // watchIntervalSpinner
            // 
            this.watchIntervalSpinner.Location = new System.Drawing.Point(271, 108);
            this.watchIntervalSpinner.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.watchIntervalSpinner.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.watchIntervalSpinner.Name = "watchIntervalSpinner";
            this.watchIntervalSpinner.Size = new System.Drawing.Size(63, 19);
            this.watchIntervalSpinner.TabIndex = 11;
            this.watchIntervalSpinner.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.watchIntervalSpinner.ValueChanged += new System.EventHandler(this.watchIntervalSpinner_ValueChanged);
            // 
            // kancolleRadio
            // 
            this.kancolleRadio.AutoSize = true;
            this.kancolleRadio.Checked = true;
            this.kancolleRadio.Location = new System.Drawing.Point(6, 16);
            this.kancolleRadio.Name = "kancolleRadio";
            this.kancolleRadio.Size = new System.Drawing.Size(54, 16);
            this.kancolleRadio.TabIndex = 12;
            this.kancolleRadio.TabStop = true;
            this.kancolleRadio.Text = "艦これ";
            this.kancolleRadio.UseVisualStyleBackColor = true;
            this.kancolleRadio.CheckedChanged += new System.EventHandler(this.target_CheckedChanged);
            // 
            // shiroproRadio
            // 
            this.shiroproRadio.AutoSize = true;
            this.shiroproRadio.Location = new System.Drawing.Point(69, 16);
            this.shiroproRadio.Name = "shiroproRadio";
            this.shiroproRadio.Size = new System.Drawing.Size(53, 16);
            this.shiroproRadio.TabIndex = 13;
            this.shiroproRadio.Text = "城プロ";
            this.shiroproRadio.UseVisualStyleBackColor = true;
            // 
            // targetGroup
            // 
            this.targetGroup.Controls.Add(this.kancolleRadio);
            this.targetGroup.Controls.Add(this.shiroproRadio);
            this.targetGroup.Location = new System.Drawing.Point(8, 4);
            this.targetGroup.Name = "targetGroup";
            this.targetGroup.Size = new System.Drawing.Size(139, 41);
            this.targetGroup.TabIndex = 14;
            this.targetGroup.TabStop = false;
            this.targetGroup.Text = "対象";
            // 
            // successGettingPositionMark
            // 
            this.successGettingPositionMark.AutoSize = true;
            this.successGettingPositionMark.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.successGettingPositionMark.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.successGettingPositionMark.Location = new System.Drawing.Point(352, 86);
            this.successGettingPositionMark.Name = "successGettingPositionMark";
            this.successGettingPositionMark.Size = new System.Drawing.Size(18, 12);
            this.successGettingPositionMark.TabIndex = 15;
            this.successGettingPositionMark.Text = "○";
            this.successGettingPositionMark.Visible = false;
            // 
            // watchDurationSpinner
            // 
            this.watchDurationSpinner.Location = new System.Drawing.Point(271, 134);
            this.watchDurationSpinner.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.watchDurationSpinner.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.watchDurationSpinner.Name = "watchDurationSpinner";
            this.watchDurationSpinner.Size = new System.Drawing.Size(49, 19);
            this.watchDurationSpinner.TabIndex = 16;
            this.watchDurationSpinner.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.watchDurationSpinner.ValueChanged += new System.EventHandler(this.watchDurationSpinner_ValueChanged);
            // 
            // watchLengthLabel
            // 
            this.watchLengthLabel.AutoSize = true;
            this.watchLengthLabel.Location = new System.Drawing.Point(326, 136);
            this.watchLengthLabel.Name = "watchLengthLabel";
            this.watchLengthLabel.Size = new System.Drawing.Size(41, 12);
            this.watchLengthLabel.TabIndex = 17;
            this.watchLengthLabel.Text = "分前迄";
            // 
            // showHistoryImageButton
            // 
            this.showHistoryImageButton.Location = new System.Drawing.Point(194, 131);
            this.showHistoryImageButton.Name = "showHistoryImageButton";
            this.showHistoryImageButton.Size = new System.Drawing.Size(71, 23);
            this.showHistoryImageButton.TabIndex = 18;
            this.showHistoryImageButton.Text = "確認";
            this.showHistoryImageButton.UseVisualStyleBackColor = true;
            this.showHistoryImageButton.Click += new System.EventHandler(this.showHistoryImageButton_Click);
            // 
            // displayLabel
            // 
            this.displayLabel.AutoSize = true;
            this.displayLabel.Location = new System.Drawing.Point(160, 22);
            this.displayLabel.Name = "displayLabel";
            this.displayLabel.Size = new System.Drawing.Size(64, 12);
            this.displayLabel.TabIndex = 19;
            this.displayLabel.Text = "ディスプレイ：";
            // 
            // displayCombo
            // 
            this.displayCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.displayCombo.FormattingEnabled = true;
            this.displayCombo.Location = new System.Drawing.Point(229, 18);
            this.displayCombo.Name = "displayCombo";
            this.displayCombo.Size = new System.Drawing.Size(130, 20);
            this.displayCombo.TabIndex = 20;
            this.displayCombo.SelectedIndexChanged += new System.EventHandler(this.displayCombo_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 161);
            this.Controls.Add(this.displayCombo);
            this.Controls.Add(this.displayLabel);
            this.Controls.Add(this.showHistoryImageButton);
            this.Controls.Add(this.watchLengthLabel);
            this.Controls.Add(this.watchDurationSpinner);
            this.Controls.Add(this.successGettingPositionMark);
            this.Controls.Add(this.targetGroup);
            this.Controls.Add(this.watchIntervalSpinner);
            this.Controls.Add(this.watchIntervalLabel);
            this.Controls.Add(this.watchCheck);
            this.Controls.Add(this.getPositionButton);
            this.Controls.Add(this.previewButton);
            this.Controls.Add(this.positionText);
            this.Controls.Add(this.showFBDButton);
            this.Controls.Add(this.filePathText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "思い出しキャプチャー";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.watchIntervalSpinner)).EndInit();
            this.targetGroup.ResumeLayout(false);
            this.targetGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.watchDurationSpinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox filePathText;
        private System.Windows.Forms.Button showFBDButton;
        private System.Windows.Forms.TextBox positionText;
        private System.Windows.Forms.Button previewButton;
        private System.Windows.Forms.Button getPositionButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox watchCheck;
        private System.Windows.Forms.Label watchIntervalLabel;
        private System.Windows.Forms.NumericUpDown watchIntervalSpinner;
        private System.Windows.Forms.RadioButton kancolleRadio;
        private System.Windows.Forms.RadioButton shiroproRadio;
        private System.Windows.Forms.GroupBox targetGroup;
        private System.Windows.Forms.Label successGettingPositionMark;
        private System.Windows.Forms.NumericUpDown watchDurationSpinner;
        private System.Windows.Forms.Label watchLengthLabel;
        private System.Windows.Forms.Button showHistoryImageButton;
        private System.Windows.Forms.Label displayLabel;
        private System.Windows.Forms.ComboBox displayCombo;
    }
}

