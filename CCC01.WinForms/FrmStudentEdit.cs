using CCC01.BLL;
using CCC01.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCC01.WinForms
{
    public partial class FrmStudentEdit : Form
    {
        private readonly SchoolBLO schoolBLO;
        public FrmStudentEdit()
        {
            InitializeComponent();

            schoolBLO = new SchoolBLO();
        }

        private void FrmStudentEdit_Load(object sender, EventArgs e)
        {
            var schools = schoolBLO.GetAllSchool();
            cbSchool.DataSource = schools;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            School school = cbSchool.SelectedItem as School;

            if (school != null)
                MessageBox.Show(school.Id.ToString());
        }
    }
}
