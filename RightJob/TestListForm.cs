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
    public partial class TestListForm : Form
    {
        public TestListForm()
        {
            InitializeComponent();
        }

        private void TestListForm_Load(object sender, EventArgs e)
        {
            MdiParent = MyForms.GetForm<ParentForm>();
            LoadData();
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            dgvTests.DataMember = "";
            dgvTests.DataSource = null;
            dgvTests.DataSource = new TestList().GetAllTests();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (cbxSort.SelectedIndex < 0)
                MessageBox.Show("Select an attribute to sort by");
            else
            {
                ByAttribute selectedAttribute;
                if (cbxSort.SelectedIndex == 0)
                    selectedAttribute = ByAttribute.Name;
                else selectedAttribute = ByAttribute.Name;

                dgvTests.DataMember = "";
                dgvTests.DataSource = null;
                dgvTests.DataSource = new TestList().Sort(selectedAttribute);
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
                // searching 
                ByAttribute selectedAttribute;
                if (cbxSort.SelectedIndex == 0)
                    selectedAttribute = ByAttribute.Name;
                else selectedAttribute = ByAttribute.Name;

                dgvTests.DataMember = "";
                dgvTests.DataSource = null;
                dgvTests.DataSource = new TestList().Search(tbxSearch.Text, selectedAttribute);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new TestEditForm().CreateNewTest();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvTests.SelectedRows.Count == 0)
                MessageBox.Show("Please select a test!");
            else
            {
                var t = (Test)dgvTests.SelectedRows[0].DataBoundItem;
                new TestEditForm().UpdateTest(t);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTests.SelectedRows.Count == 0)
                MessageBox.Show("Please select a test!");
            else
            {
                // confirmation before delete
                var confirm = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    var t = (Test)dgvTests.SelectedRows[0].DataBoundItem;
                    new TestManager().Delete(t.Id);
                    LoadData();
                }
            }
        }
    }
}
