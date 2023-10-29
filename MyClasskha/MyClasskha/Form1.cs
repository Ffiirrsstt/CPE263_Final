using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyClasskha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Electricalappliance objectforElect;
        TV objectforTV;

        //set data Elect
        void setDataElect() { 
            objectforElect.BrandElect = comp.Text;
            objectforElect.ElectrictypeElect = type.Text;
            objectforElect.LifetimeElect = life.Text;
            objectforElect.SaveelectricityNoElect = forNo.Text;
        }

        //set data TV
        void setDataTV()
        {
            objectforTV.TypeTV = typeforTV.Text;
            objectforTV.ScreenTV = screenforTV.Text;
            objectforTV.SaveNoTV = saveNoforTV.Text;
        }

        //เปิดช่องการกรอกรายการทีวี
        void openBtnforTVShow()
        {
            dataTV.Enabled = true;
            dayTV.Enabled = true;
            timeTV.Enabled = true;
        }

        //ปิดช่องทีวี
        void EnabledBtnTV()
        {
            typeforTV.Enabled = false;
            screenforTV.Enabled = false;
            saveNoforTV.Enabled = false;
        }

        //แสดงผลข้อมูล
        void DataElectOutput()
        {
            MessageBox.Show("บริษัท : "+objectforElect.Brand
                +"\nชนิด : "+ objectforElect.Electrictype
                +"\nอายุการใช้งาน : " + objectforElect.Lifetime+" ปี"
                + "\nSave No : " + objectforElect.SaveelectricityNo);
        }

        void DataTVOutput()
        {
            MessageBox.Show("ชนิด : " + objectforTV.Type
                + "\nจอภาพ : " + objectforTV.Screen
                + "\nTV Save No : " + objectforTV.SaveNo);
        }

        //ปิดช่องกรอกข้อมูลหน้าอุปกรณ์ไฟฟ้า
        void EnabledBtnEleData()
        {
            comp.Enabled = false;
            type.Enabled = false;
            life.Enabled = false;
            forNo.Enabled = false;
        }

        //สำหรับส่วนของ Elect
        private void btnOjeectEle_Click(object sender, EventArgs e)
        {
            objectforElect = new Electricalappliance();
            setDataElect();
            DataElectOutput();

            //เปิดปุ่มการทำงานและช่องกรอกสถานะ
            ONOFF.Enabled = true;
            btnWorking.Enabled = true;

            //ปิดช่องการกรอกข้อมูลเกี่ยวกับพวกบริษัท และปิดการทำงานปุ่มสร้างออปเจ็คท์อุปกรณ์ไฟฟ้า
            btnOjeectEle.Enabled = false;
            EnabledBtnEleData();
        }

        private void btnWorking_Click(object sender, EventArgs e)
        {
            objectforElect.Working(ONOFF.Text);
        }

        //สำหรับส่วนของ TV
        private void btnCreateOjectTV_Click(object sender, EventArgs e)
        {
            objectforTV = new TV();
            setDataTV();
            DataTVOutput();

            openBtnforTVShow();
            btnforTVShow.Enabled = true;

            EnabledBtnTV();
            btnCreateOjectTV.Enabled = false;
        }

        private void btnforTVShow_Click(object sender, EventArgs e)
        {
            objectforTV.TVShow(dataTV.Text, dayTV.Text, timeTV.Text);
        }
    }
}
