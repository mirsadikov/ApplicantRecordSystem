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
    public partial class TestEditForm : Form
    {
        public TestEditForm()
        {
            InitializeComponent();
        }

        public Test Test { get; set; }

        public FormMode Mode { get; set; }

        public void CreateNewTest()
        {
            Mode = FormMode.CreateNew;
            Test = new Test();
            InitializeControls();
            MdiParent = MyForms.GetForm<ParentForm>();
            Show();
        }

        public void UpdateTest(Test test)
        {
            Mode = FormMode.Update;
            Test = test;
            InitializeControls();
            ShowTestInControls();
            MdiParent = MyForms.GetForm<ParentForm>();
            Show();
        }

        private void InitializeControls()
        {
        }

        private void ShowTestInControls()
        {
            tbxName.Text = Test.Name;
            tbxQ1.Text = Test.Q1;
            tbxA1.Text = Test.Q1_answer;
            tbxQ2.Text = Test.Q2;
            tbxA2.Text = Test.Q2_answer;
            tbxQ3.Text = Test.Q3;
            tbxA3.Text = Test.Q3_answer;
        }

        private void GrabUserInput()
        {
            Test.Name = tbxName.Text;
            Test.Q1 = tbxQ1.Text;
            Test.Q1_answer = tbxA1.Text;
            Test.Q2 = tbxQ2.Text;
            Test.Q2_answer = tbxA2.Text;
            Test.Q3 = tbxQ3.Text;
            Test.Q3_answer = tbxA3.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                GrabUserInput(); // first grab user inputs
                var manager = new TestManager();
                if (Mode == FormMode.CreateNew)
                    manager.Create(Test);
                else
                    manager.Update(Test);

                MyForms.GetForm<TestListForm>().LoadData();
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
    }
}
