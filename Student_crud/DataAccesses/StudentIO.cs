using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Student_crud.Business;

namespace Student_crud.DataAccesses
{
   public static class StudentIO
    {
        private static string filePath = Application.StartupPath + @"\Student.dat";
        private static string filetemp = Application.StartupPath + @"\Temp.dat";

        public static void SaveRecord(Student stud)
        {
            StreamWriter streamWriter = new StreamWriter(filePath, true);
            streamWriter.WriteLine(stud.StudentID + "," + stud.FirstName + "," + stud.LastName
                + "," + stud.PhoneNumber);
            streamWriter.Close();
            MessageBox.Show("Student data has been saved !");

        }
        public static void ListStudents(ListView listViewStudent)
        {
            StreamReader streamReader = new StreamReader(filePath);
            listViewStudent.Items.Clear();
            string line = streamReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(",");
                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);
                item.SubItems.Add(fields[2]);
                item.SubItems.Add(fields[3]);
                listViewStudent.Items.Add(item);
                line = streamReader.ReadLine();//now rea next line
            }
            streamReader.Close();
        }
        public static List<Student> ListStudent()
        {
            List<Student> listc = new List<Student>();
            StreamReader streamReader = new StreamReader(filePath);
            string line = streamReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(",");
                Student stud = new Student();
                stud.StudentID = Convert.ToInt32(fields[0]);
                stud.FirstName = fields[1];
                stud.LastName = fields[2];
                stud.PhoneNumber = fields[3];
                listc.Add(stud);
                line = streamReader.ReadLine();//read next line

            }

            streamReader.Close();

            return listc;
        }
        public static Student Search(int studID)
        {
            Student stud = new Student();
            StreamReader streamReader = new StreamReader(filePath);
            string line = streamReader.ReadLine();
            while (line != null)

            {
                string[] fields = line.Split(",");
                if (studID == Convert.ToInt32(fields[0]))
                {
                    stud.StudentID = Convert.ToInt32(fields[0]);
                    stud.FirstName = fields[1];
                    stud.LastName = fields[2];
                    stud.PhoneNumber = fields[3];
                    return stud;
                }

                line = streamReader.ReadLine();
            }
            streamReader.Close();
            return null;
        }
        public static void Delete(int studID)
        {
            StreamReader streamReader = new StreamReader(filePath);
            StreamWriter streamWriter = new StreamWriter(filetemp);
            string line = streamReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(",");
                if (studID != Convert.ToInt32(fields[0]))
                {
                    streamWriter.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3]);

                }
                line = streamReader.ReadLine();


            }
            streamReader.Close();
            streamWriter.Close();
            File.Delete(filePath);
            File.Move(filetemp, filePath);
        }
       

    }
}
