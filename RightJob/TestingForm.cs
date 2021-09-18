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
    public partial class TestingForm : Form
    {
        public TestingForm()
        {
            InitializeComponent();
        }

        public Test Test { get; set; }
        public Applicant Applicant { get; set; }


        private void TestingForm_Load(object sender, EventArgs e)
        {
            MdiParent = MyForms.GetForm<ParentForm>();
        }

        public void CreateForm(Applicant applicant)
        {
            Applicant = applicant;
            InitializeControls();
        }

        private void InitializeControls()
        {
            // showing only not yet taken tests
            string[] takenTests = Applicant.TestsTaken.Split(',', (char)StringSplitOptions.RemoveEmptyEntries); // get all tests first and convert to array
            var notTakenTest = new TestManager().GetAll().Where(a => !Array.Exists(takenTests, test => test.Contains(a.Name))); // filtering not yet taken tests

            if (notTakenTest.Count() == 0)
            {
                // If there are no such tests then show message and close
                MessageBox.Show("No tests available, applicant already taken all tests!");
                Close();
            } else {
                Show();
                cbxTests.DataSource = notTakenTest.ToList(); // show available tests in combobox
                ShowTestInForm();
            }
        }

        private void ShowTestInForm()
        {
            lblName.Text = Applicant.Name;

            Test = (Test)cbxTests.SelectedItem;
            lblQ1.Text = Test.Q1;
            lblQ2.Text = Test.Q2;
            lblQ3.Text = Test.Q3;
        }

        private void cbxTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            // changes questions when test changed
            Test = (Test)cbxTests.SelectedItem;
            lblQ1.Text = Test.Q1;
            lblQ2.Text = Test.Q2;
            lblQ3.Text = Test.Q3;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // answer validation, if empty shows message 
            if (string.IsNullOrWhiteSpace(tbxA1.Text) ||               
                string.IsNullOrWhiteSpace(tbxA2.Text) || 
                string.IsNullOrWhiteSpace(tbxA3.Text))
            {
                MessageBox.Show("Fill the fields!");
            } else
            {
                // comparing answers adding score to applicant score if true
                if (tbxA1.Text == Test.Q1_answer) { Applicant.Score = Applicant.Score + 1; };
                if (tbxA2.Text == Test.Q2_answer) { Applicant.Score = Applicant.Score + 1; };
                if (tbxA3.Text == Test.Q3_answer) { Applicant.Score = Applicant.Score + 1; };


                // this gets names of tests applicant already taken
                var testsTaken = Applicant.TestsTaken.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                // gets name of test taken now
                var newTest = ((Test)cbxTests.SelectedItem).Name;

                // stores IDs of all tests including new taken test to applicant's record
                Applicant.TestsTaken = new TestManager().GetIdsByNames(string.Join(", ", testsTaken.Append(newTest))); // from names to ids, stores ids of tests to ap_tests_taken_12860
                new ApplicantManager().Update(Applicant);

                MyForms.GetForm<ApplicantListForm>().LoadData();
                Close();
            }
            
        }
    }
}
