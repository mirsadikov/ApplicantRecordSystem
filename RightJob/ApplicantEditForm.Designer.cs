
namespace RightJob
{
    partial class ApplicantEditForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblScore = new System.Windows.Forms.Label();
            this.nudScore = new System.Windows.Forms.NumericUpDown();
            this.lblTests = new System.Windows.Forms.Label();
            this.tbxTestsTaken = new System.Windows.Forms.TextBox();
            this.chbxEnable = new System.Windows.Forms.CheckBox();
            this.lblWarning = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudScore)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(200, 34);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(150, 20);
            this.tbxName.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(324, 188);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 35);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(423, 188);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 35);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(141, 66);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(38, 13);
            this.lblScore.TabIndex = 1;
            this.lblScore.Text = "Score:";
            this.lblScore.Visible = false;
            // 
            // nudScore
            // 
            this.nudScore.Enabled = false;
            this.nudScore.Location = new System.Drawing.Point(200, 64);
            this.nudScore.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudScore.Name = "nudScore";
            this.nudScore.Size = new System.Drawing.Size(150, 20);
            this.nudScore.TabIndex = 5;
            this.nudScore.Visible = false;
            // 
            // lblTests
            // 
            this.lblTests.AutoSize = true;
            this.lblTests.Location = new System.Drawing.Point(40, 95);
            this.lblTests.Name = "lblTests";
            this.lblTests.Size = new System.Drawing.Size(139, 13);
            this.lblTests.TabIndex = 2;
            this.lblTests.Text = "Tests taken (can be empty):";
            this.lblTests.Visible = false;
            // 
            // tbxTestsTaken
            // 
            this.tbxTestsTaken.Enabled = false;
            this.tbxTestsTaken.Location = new System.Drawing.Point(200, 92);
            this.tbxTestsTaken.Name = "tbxTestsTaken";
            this.tbxTestsTaken.Size = new System.Drawing.Size(150, 20);
            this.tbxTestsTaken.TabIndex = 2;
            this.tbxTestsTaken.Visible = false;
            // 
            // chbxEnable
            // 
            this.chbxEnable.AutoSize = true;
            this.chbxEnable.Location = new System.Drawing.Point(414, 142);
            this.chbxEnable.Name = "chbxEnable";
            this.chbxEnable.Size = new System.Drawing.Size(93, 17);
            this.chbxEnable.TabIndex = 6;
            this.chbxEnable.Text = "Enable editing";
            this.chbxEnable.UseVisualStyleBackColor = true;
            this.chbxEnable.Visible = false;
            this.chbxEnable.CheckedChanged += new System.EventHandler(this.chbxEnable_CheckedChanged);
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.Location = new System.Drawing.Point(356, 95);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(151, 13);
            this.lblWarning.TabIndex = 7;
            this.lblWarning.Text = "Not valid name will be ignored!";
            this.lblWarning.Visible = false;
            // 
            // ApplicantEditForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(527, 235);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.chbxEnable);
            this.Controls.Add(this.nudScore);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbxTestsTaken);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.lblTests);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.label1);
            this.Name = "ApplicantEditForm";
            this.Text = "Applicant";
            ((System.ComponentModel.ISupportInitialize)(this.nudScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.NumericUpDown nudScore;
        private System.Windows.Forms.Label lblTests;
        private System.Windows.Forms.TextBox tbxTestsTaken;
        private System.Windows.Forms.CheckBox chbxEnable;
        private System.Windows.Forms.Label lblWarning;
    }
}