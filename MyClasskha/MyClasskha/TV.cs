using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyClasskha
{
    internal class TV:Electricalappliance
    {
        public string Type;
        public string Screen;
        public string SaveNo;

        public string TypeTV
        {
            get
            {
                return Type;
            }
            set
            {
                Type = value;
            }
        }

        public string ScreenTV
        {
            get
            {
                return Screen;
            }
            set
            {
                Screen = value;
            }
        }

        public string SaveNoTV
        {
            get
            {
                return SaveNo;
            }
            set
            {
                SaveNo = value;
            }
        }

        public void TVShow(string name, string day, string minute)
        {
            MessageBox.Show("รายการ " + name + "\nออกอากาศวัน " + day + "\nเป็นเวลา " + minute + " นาที");
        }
    }
}
