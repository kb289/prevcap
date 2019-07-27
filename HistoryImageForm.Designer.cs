namespace PrevCap
{
    partial class HistoryImageForm
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
            this.imageListGrid = new System.Windows.Forms.DataGridView();
            this.selectedImage = new System.Windows.Forms.PictureBox();
            this.timestampLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.noImageLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageListGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // imageListGrid
            // 
            this.imageListGrid.AllowUserToAddRows = false;
            this.imageListGrid.AllowUserToDeleteRows = false;
            this.imageListGrid.AllowUserToResizeColumns = false;
            this.imageListGrid.AllowUserToResizeRows = false;
            this.imageListGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.imageListGrid.ColumnHeadersVisible = false;
            this.imageListGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.imageListGrid.Location = new System.Drawing.Point(0, 0);
            this.imageListGrid.MultiSelect = false;
            this.imageListGrid.Name = "imageListGrid";
            this.imageListGrid.RowHeadersVisible = false;
            this.imageListGrid.RowTemplate.Height = 21;
            this.imageListGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.imageListGrid.Size = new System.Drawing.Size(344, 646);
            this.imageListGrid.TabIndex = 2;
            this.imageListGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.imageListGrid_KeyDown);
            // 
            // selectedImage
            // 
            this.selectedImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedImage.Location = new System.Drawing.Point(344, 0);
            this.selectedImage.Name = "selectedImage";
            this.selectedImage.Size = new System.Drawing.Size(675, 646);
            this.selectedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.selectedImage.TabIndex = 3;
            this.selectedImage.TabStop = false;
            // 
            // timestampLabel
            // 
            this.timestampLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.timestampLabel.AutoSize = true;
            this.timestampLabel.BackColor = System.Drawing.Color.Snow;
            this.timestampLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.timestampLabel.Location = new System.Drawing.Point(860, 621);
            this.timestampLabel.Name = "timestampLabel";
            this.timestampLabel.Size = new System.Drawing.Size(147, 16);
            this.timestampLabel.TabIndex = 4;
            this.timestampLabel.Text = "2000/01/01 12:34:56";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.saveButton.Location = new System.Drawing.Point(932, 565);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 46);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "保存";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // noImageLabel
            // 
            this.noImageLabel.AutoSize = true;
            this.noImageLabel.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.noImageLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.noImageLabel.Location = new System.Drawing.Point(633, 313);
            this.noImageLabel.Name = "noImageLabel";
            this.noImageLabel.Size = new System.Drawing.Size(96, 21);
            this.noImageLabel.TabIndex = 6;
            this.noImageLabel.Text = "no image";
            this.noImageLabel.Visible = false;
            // 
            // HistoryImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 646);
            this.Controls.Add(this.noImageLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.timestampLabel);
            this.Controls.Add(this.selectedImage);
            this.Controls.Add(this.imageListGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HistoryImageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "過去画像";
            this.Load += new System.EventHandler(this.HistoryImageFrom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageListGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView imageListGrid;
        private System.Windows.Forms.PictureBox selectedImage;
        private System.Windows.Forms.Label timestampLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label noImageLabel;
    }
}