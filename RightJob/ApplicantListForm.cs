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
    public partial class ApplicantListForm : Form
    {
        public ApplicantListForm()
        {
            InitializeComponent();
        }

        private void ApplicantListForm_Load(object sender, EventArgs e)
        {
            MdiParent = MyForms.GetForm<ParentForm>();
            LoadData();
            cbxSearch.SelectedIndex = 0; // for faster search by id
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            dgvApplicants.DataMember = "";
            dgvApplicants.DataSource = null;
            dgvApplicants.DataSource = new ApplicantList().GetAllApplicants();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (cbxSort.SelectedIndex < 0)
                MessageBox.Show("Select an attribute to sort by");
            else
            {
                // sorting by attributes -- Name, Score Ascending, Score Descending
                ByAttribute selectedAttribute;
                if (cbxSort.SelectedIndex == 0)
                    selectedAttribute = ByAttribute.Name;
                else if (cbxSort.SelectedIndex == 1)
                    selectedAttribute = ByAttribute.ScoreAscending;
                else selectedAttribute = ByAttribute.ScoreDescending;

                dgvApplicants.DataMember = "";
                dgvApplicants.DataSource = null;
                dgvApplicants.DataSource = new ApplicantList().Sort(selectedAttribute);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbxSearch.SelectedIndex < 0)
                MessageBox.Show("Select an attribute to search!");
            else if (string.IsNullOrWhiteSpace(tbxSearch.Text))
                MessageBox.Show("Enter something to search!");
            else
            {
                // Searching by Id, name, score, Tests
                ByAttribute selectedAttribute;
                if (cbxSearch.SelectedIndex == 0)
                    selectedAttribute = ByAttribute.Id;
                else if (cbxSearch.SelectedIndex == 1)
                    selectedAttribute = ByAttribute.Name;
                else if (cbxSearch.SelectedIndex == 2)
                    selectedAttribute = ByAttribute.Score;
                else selectedAttribute = ByAttribute.TestsTaken;

                dgvApplicants.DataMember = "";
                dgvApplicants.DataSource = null;
                dgvApplicants.DataSource = new ApplicantList().Search(tbxSearch.Text, selectedAttribute);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new ApplicantEditForm().CreateNewApplicant();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvApplicants.SelectedRows.Count == 0)
                MessageBox.Show("Please select an applicant!");
            else
            {
                var a = (Applicant)dgvApplicants.SelectedRows[0].DataBoundItem;
                new ApplicantEditForm().UpdateApplicant(a);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvApplicants.SelectedRows.Count == 0)
                MessageBox.Show("Please select an applicant!");
            else
            {
                // confirmation before deleting
                var confirm = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    var a = (Applicant)dgvApplicants.SelectedRows[0].DataBoundItem;
                    new ApplicantManager().Delete(a.Id);
                    LoadData();
                }
                
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (dgvApplicants.SelectedRows.Count == 0)
                MessageBox.Show("Please select an applicant!");
            else
            {
                // opening testing form
                var a = (Applicant)dgvApplicants.SelectedRows[0].DataBoundItem;
                MyForms.GetForm<TestingForm>().CreateForm(a);
            }
            
        }
    }
}
