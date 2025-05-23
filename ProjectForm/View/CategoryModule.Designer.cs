﻿namespace ProjectForm
{
    partial class CategoryModule
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
            panel1 = new Panel();
            label1 = new Label();
            picboxClose = new PictureBox();
            txtCategoryName = new TextBox();
            btnSave = new Button();
            label2 = new Label();
            btnClear = new Button();
            showMessageLabel = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picboxClose).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(121, 85, 72);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(picboxClose);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(881, 50);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(143, 18);
            label1.TabIndex = 1;
            label1.Text = "Category  Module";
            // 
            // picboxClose
            // 
            picboxClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picboxClose.BackColor = Color.FromArgb(255, 128, 128);
            picboxClose.Image = Properties.Resources.close1;
            picboxClose.Location = new Point(830, 12);
            picboxClose.Name = "picboxClose";
            picboxClose.Size = new Size(39, 33);
            picboxClose.SizeMode = PictureBoxSizeMode.Zoom;
            picboxClose.TabIndex = 0;
            picboxClose.TabStop = false;
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(183, 102);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(642, 25);
            txtCategoryName.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.BackColor = Color.Peru;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Location = new Point(590, 185);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(107, 46);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 105);
            label2.Name = "label2";
            label2.Size = new Size(135, 20);
            label2.TabIndex = 3;
            label2.Text = "Category Name :";
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClear.BackColor = Color.MistyRose;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Location = new Point(718, 185);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(107, 46);
            btnClear.TabIndex = 4;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // showMessageLabel
            // 
            showMessageLabel.AutoSize = true;
            showMessageLabel.Location = new Point(183, 140);
            showMessageLabel.Name = "showMessageLabel";
            showMessageLabel.Size = new Size(0, 20);
            showMessageLabel.TabIndex = 6;
            // 
            // CategoryModule
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(881, 243);
            Controls.Add(showMessageLabel);
            Controls.Add(btnClear);
            Controls.Add(label2);
            Controls.Add(btnSave);
            Controls.Add(txtCategoryName);
            Controls.Add(panel1);
            Font = new Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "CategoryModule";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CategoryModule";
            Load += CategoryModule_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picboxClose).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox picboxClose;
        private Label label1;
        private TextBox txtCategoryName;
        private Button btnSave;
        private Label label2;
        private Button btnClear;
        private Label showMessageLabel;
    }
}