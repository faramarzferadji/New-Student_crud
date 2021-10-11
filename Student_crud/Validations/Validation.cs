using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Student_crud.Business;
using Student_crud.DataAccesses;
using Student_crud.Gui;

namespace Student_crud.Validations
{
   public class Validation
    {
        public static bool IsvalidID(string input)
        {
            int tempID;
            if (input.Length != 7 )
            { 
            MessageBox.Show("Invalid ID, ID must have 7 digits");
            return false;
             }
            return true;
        }
        public static bool IsvalidName(TextBox text)
        {

            for(int i=0; i<text.TextLength; i++)
            {
                if(char.IsDigit(text.Text, i) || (char.IsWhiteSpace(text.Text, i)))
                {
                    MessageBox.Show("Invalid name , please enter the valid name");
                    text.Clear();
                    text.Focus();
                    return false;
                }
            }
            return true;
        }
        
    }
}
