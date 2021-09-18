using RightJob.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RightJob
{
    public partial class ApplicantEditForm : Form
    {
        public ApplicantEditForm()
        {
            InitializeComponent();
        }

        public Applicant Applicant { get; set; }

        public FormMode Mode { get; set; }

        public void CreateNewApplicant()
        {
            Mode = FormMode.CreateNew;
            Applicant = new Applicant();
            InitializeControls();
            MdiParent = MyForms.GetForm<ParentForm>();
            Show();
        }

        public void UpdateApplicant(Applicant applicant)
        {
            Mode = FormMode.Update;
            Applicant = applicant;
            InitializeControls();
            ShowApplicantInControls();
            MdiParent = MyForms.GetForm<ParentForm>();

            // adding some function to update
            lblScore.Visible = true;
            lblTests.Visible = true;
            nudScore.Visible = true;
            tbxTestsTaken.Visible = true;
            chbxEnable.Visible = true;

            Show();
        }

        private void InitializeControls()
        {

        }

        private void ShowApplicantInControls()
        {
            tbxName.Text = Applicant.Name;
            nudScore.Value = Applicant.Score;
            tbxTestsTaken.Text = Applicant.TestsTaken;
        }

        private void GrabUserInput()
        {
            Applicant.Name = tbxName.Text;
            Applicant.Score = Convert.ToInt32(nudScore.Value);
            Applicant.TestsTaken = new TestManager().GetIdsByNames(tbxTestsTaken.Text); // tests names to test ids
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                GrabUserInput();
                var manager = new ApplicantManager();
                if (Mode == FormMode.CreateNew)
                    manager.Create(Applicant);
                else
                    manager.Update(Applicant);

                MyForms.GetForm<ApplicantListForm>().LoadData();
                MessageBox.Show("Saved");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chbxEnable_CheckedChanged(object sender, EventArgs e)
        {
            // enabling disabling controls for additional feature when updating applicants
            // enable editing score, tests taken
            if (!chbxEnable.Checked)
            {
                nudScore.Enabled = false;
                tbxTestsTaken.Enabled = false;
                lblWarning.Visible = false;
            } else
            {
                nudScore.Enabled = true;
                tbxTestsTaken.Enabled= true;
                lblWarning.Visible = true;
            }
        }
    }
}
