using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Student_crud.Business;
using Student_crud.DataAccesses;
using System.Windows.Forms;
using Student_crud.Validations;

namespace Student_crud.Gui
{
    public partial class Student_Formcs : Form
    {
        List<Student> listC = new List<Student>();
        public Student_Formcs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Student> listC = StudentIO.ListStudent();
            if (Validation.IsvalidID(textBoxStudentID.Text) && Validation.IsvalidName(textBoxFirstName)
                && Validation.IsvalidName(textBoxLastName)) { 
            Student astudent = new Student();
            astudent.StudentID = Convert.ToInt32(textBoxStudentID.Text);
            astudent.FirstName = textBoxFirstName.Text;
            astudent.LastName = textBoxLastName.Text;
            astudent.PhoneNumber = maskedTextBoxPhoneNumber.Text;

            StudentIO.SaveRecord(astudent);
            }

        }
        private void ClearAll()
        {
            textBoxStudentID.Clear();
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            maskedTextBoxPhoneNumber.Clear();
            textBoxStudentID.Focus();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure that you want to leave?",
              "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student stu = new Student();
            stu.StudentID = Convert.ToInt32(textBoxStudentID.Text);
            stu.FirstName = textBoxFirstName.Text;
            stu.LastName = textBoxLastName.Text;
            stu.PhoneNumber = maskedTextBoxPhoneNumber.Text;
            listC.Add(stu);
        }

        private void buttonListStudent_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            StudentIO.ListStudents(listView1);
        }

        private void buttonDElete_Click(object sender, EventArgs e)
        {
            StudentIO.Delete(Convert.ToInt32(textBoxStudentID.Text));
            MessageBox.Show("Student successfully Deleted");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int choice = comboBox1.SelectedIndex;
            switch (choice)
            {
                case 0:label6.Text = "Please enter the Student ID";
                    break;
               
                default:break;
            }

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int choice = comboBox1.SelectedIndex;
            switch (choice)
            {
                case -1:
                    MessageBox.Show("please enter your option");
                    break;
                case 0:
                    Student stu = StudentIO.Search(Convert.ToInt32(textBoxSearchBY.Text));
                    if(stu != null)
                    {
                        textBoxStudentID.Text = (stu.StudentID).ToString();
                        textBoxFirstName.Text = stu.FirstName;
                        textBoxLastName.Text = stu.LastName;
                        maskedTextBoxPhoneNumber.Text = stu.PhoneNumber;
                    }
                    else
                    {
                        MessageBox.Show("Student not found!");
                        textBoxSearchBY.Clear();
                        textBoxSearchBY.Focus();
                    }
                    textBoxSearchBY.Clear();
                    break;
                default:break;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxStudentID.Clear();
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            maskedTextBoxPhoneNumber.Clear();
            textBoxStudentID.Focus();
        }
    }
}
