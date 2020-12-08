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
    public partial class FrmSchoolEdit : Form
    {
        private readonly SchoolBLO schoolBLO;
        public FrmSchoolEdit()
        {
            InitializeComponent();
            schoolBLO = new SchoolBLO();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                School newSchool = new School(txtEmail.Text, txtName.Text, txtContact.Text);
                schoolBLO.Save(newSchool);
                MessageBox.Show
                (
                    "Save done !",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (TypingException ex)
            {
                foreach(var error in ex.Erros)
                {
                    foreach(Control control in this.Controls)
                    {
                        if (control.Name.Contains(error.Key) && !control.Name.Contains("Error"))
                        {
                            control.BackColor = Color.Pink;
                        }
                        if (control.Name.Contains(error.Key) && control.Name.Contains("lblError"))
                        {
                            control.Text = error.Value;
                            control.Visible = true;
                        }
                    }
                }
            }
            catch (DuplicateNameException ex)
            {
                MessageBox.Show
                (
                    ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch(Exception)
            {
                MessageBox.Show
                (
                    "An error occured. Please try again later",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }            
        }
    }
}
