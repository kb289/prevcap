namespace PrevCap
{
    partial class CustomGameForm
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
            this.indentifierLabel = new System.Windows.Forms.Label();
            this.identifierText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.windowRadio = new System.Windows.Forms.RadioButton();
            this.sizeRadio = new System.Windows.Forms.RadioButton();
            this.widthText = new System.Windows.Forms.TextBox();
            this.heightText = new System.Windows.Forms.TextBox();
            this.xLabel = new System.Windows.Forms.Label();
            this.windowCombo = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.targetAreaPanel = new System.Windows.Forms.Panel();
            this.areaTypePanel = new System.Windows.Forms.Panel();
            this.clientAreaRadio = new System.Windows.Forms.RadioButton();
            this.windowAreaRadio = new System.Windows.Forms.RadioButton();
            this.targetAreaPanel.SuspendLayout();
            this.areaTypePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // indentifierLabel
            // 
            this.indentifierLabel.AutoSize = true;
            this.indentifierLabel.Location = new System.Drawing.Point(30, 28);
            this.indentifierLabel.Name = "indentifierLabel";
            this.indentifierLabel.Size = new System.Drawing.Size(83, 12);
            this.indentifierLabel.TabIndex = 0;
            this.indentifierLabel.Text = "保存時識別子：";
            // 
            // identifierText
            // 
            this.identifierText.Location = new System.Drawing.Point(124, 25);
            this.identifierText.Name = "identifierText";
            this.identifierText.Size = new System.Drawing.Size(154, 19);
            this.identifierText.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "キャプチャー範囲：";
            // 
            // windowRadio
            // 
            this.windowRadio.AutoSize = true;
            this.windowRadio.Location = new System.Drawing.Point(0, 31);
            this.windowRadio.Name = "windowRadio";
            this.windowRadio.Size = new System.Drawing.Size(90, 16);
            this.windowRadio.TabIndex = 3;
            this.windowRadio.Text = "ウィンドウ指定";
            this.windowRadio.UseVisualStyleBackColor = true;
            // 
            // sizeRadio
            // 
            this.sizeRadio.AutoSize = true;
            this.sizeRadio.Location = new System.Drawing.Point(0, 0);
            this.sizeRadio.Name = "sizeRadio";
            this.sizeRadio.Size = new System.Drawing.Size(76, 16);
            this.sizeRadio.TabIndex = 4;
            this.sizeRadio.Text = "サイズ指定";
            this.sizeRadio.UseVisualStyleBackColor = true;
            this.sizeRadio.CheckedChanged += new System.EventHandler(this.sizeRadio_CheckedChanged);
            // 
            // widthText
            // 
            this.widthText.Location = new System.Drawing.Point(238, 68);
            this.widthText.Name = "widthText";
            this.widthText.Size = new System.Drawing.Size(53, 19);
            this.widthText.TabIndex = 5;
            // 
            // heightText
            // 
            this.heightText.Location = new System.Drawing.Point(326, 68);
            this.heightText.Name = "heightText";
            this.heightText.Size = new System.Drawing.Size(53, 19);
            this.heightText.TabIndex = 6;
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(303, 71);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(11, 12);
            this.xLabel.TabIndex = 7;
            this.xLabel.Text = "x";
            // 
            // windowCombo
            // 
            this.windowCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.windowCombo.FormattingEnabled = true;
            this.windowCombo.Location = new System.Drawing.Point(238, 99);
            this.windowCombo.Name = "windowCombo";
            this.windowCombo.Size = new System.Drawing.Size(179, 20);
            this.windowCombo.TabIndex = 8;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(118, 168);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 9;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(245, 168);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // targetAreaPanel
            // 
            this.targetAreaPanel.Controls.Add(this.sizeRadio);
            this.targetAreaPanel.Controls.Add(this.windowRadio);
            this.targetAreaPanel.Location = new System.Drawing.Point(138, 69);
            this.targetAreaPanel.Name = "targetAreaPanel";
            this.targetAreaPanel.Size = new System.Drawing.Size(94, 50);
            this.targetAreaPanel.TabIndex = 11;
            // 
            // areaTypePanel
            // 
            this.areaTypePanel.Controls.Add(this.clientAreaRadio);
            this.areaTypePanel.Controls.Add(this.windowAreaRadio);
            this.areaTypePanel.Location = new System.Drawing.Point(239, 124);
            this.areaTypePanel.Name = "areaTypePanel";
            this.areaTypePanel.Size = new System.Drawing.Size(188, 27);
            this.areaTypePanel.TabIndex = 12;
            // 
            // clientAreaRadio
            // 
            this.clientAreaRadio.AutoSize = true;
            this.clientAreaRadio.Location = new System.Drawing.Point(94, 0);
            this.clientAreaRadio.Name = "clientAreaRadio";
            this.clientAreaRadio.Size = new System.Drawing.Size(98, 16);
            this.clientAreaRadio.TabIndex = 6;
            this.clientAreaRadio.Text = "クライアント領域";
            this.clientAreaRadio.UseVisualStyleBackColor = true;
            // 
            // windowAreaRadio
            // 
            this.windowAreaRadio.AutoSize = true;
            this.windowAreaRadio.Location = new System.Drawing.Point(0, 0);
            this.windowAreaRadio.Name = "windowAreaRadio";
            this.windowAreaRadio.Size = new System.Drawing.Size(90, 16);
            this.windowAreaRadio.TabIndex = 5;
            this.windowAreaRadio.Text = "ウィンドウ全体";
            this.windowAreaRadio.UseVisualStyleBackColor = true;
            // 
            // CustomGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 206);
            this.Controls.Add(this.areaTypePanel);
            this.Controls.Add(this.targetAreaPanel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.windowCombo);
            this.Controls.Add(this.xLabel);
            this.Controls.Add(this.heightText);
            this.Controls.Add(this.widthText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.identifierText);
            this.Controls.Add(this.indentifierLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "カスタム設定";
            this.Load += new System.EventHandler(this.CustomGameForm_Load);
            this.targetAreaPanel.ResumeLayout(false);
            this.targetAreaPanel.PerformLayout();
            this.areaTypePanel.ResumeLayout(false);
            this.areaTypePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label indentifierLabel;
        private System.Windows.Forms.TextBox identifierText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton windowRadio;
        private System.Windows.Forms.RadioButton sizeRadio;
        private System.Windows.Forms.TextBox widthText;
        private System.Windows.Forms.TextBox heightText;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.ComboBox windowCombo;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Panel targetAreaPanel;
        private System.Windows.Forms.Panel areaTypePanel;
        private System.Windows.Forms.RadioButton clientAreaRadio;
        private System.Windows.Forms.RadioButton windowAreaRadio;
    }
}