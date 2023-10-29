using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyClasskha
{
    internal class Electricalappliance
    {
        public string Brand;
        public string Electrictype;
        public string Lifetime;
        public string SaveelectricityNo;

        public string BrandElect
        {
            get
            {
                return Brand;
            }
            set
            {
                Brand = value;
            }
        }
        public string ElectrictypeElect
        {
            get
            {
                return Electrictype;
            }
            set
            {
                Electrictype = value;
            }
        }

        public string LifetimeElect
        {
            get
            {
                return Lifetime;
            }
            set
            {
                Lifetime = value;
            }
        }

        public string SaveelectricityNoElect
        {
            get
            {
                return SaveelectricityNo;
            }
            set
            {
                SaveelectricityNo = value;
            }
        }

        public void Working(string data)
        {
            if (data == "ON")
                MessageBox.Show("อุปกรณ์กำลังทำงาน");
            else if (data == "OFF")
                MessageBox.Show("อุปกรณ์หยุดทำงาน");
            else
                MessageBox.Show("กรุณากรอกเป็น \"ON\" หรือ \"OFF\" เท่านั้น");
        }
    }
}
