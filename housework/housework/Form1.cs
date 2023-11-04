using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using NAudio.Wave;
using System.Reflection.Emit;
using NAudio.Utils;
using static System.Windows.Forms.LinkLabel;

namespace housework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        AudioFileReader audioFile;
        WaveOutEvent audioSound;
        string[] files;
        long positionStop = 0; // เก็บค่าตำแหน่งที่จุดกดหยุดเสียง

        //ปรับระดับเสียง
        void pitch()
        {
            float pitchValue = trackBar.Value / 100f;
            audioSound.Volume = pitchValue;
        }

        //ปิดเพลง
        void turnoffTheMusic()
        {
            if (audioFile != null && audioSound != null)
            {
                audioSound.Dispose();
                audioFile.Dispose();
                audioFile = null;
                audioSound = null;
            }
        }

        //แสดงเวลากำกับ ณ เวลาที่เพลงได้เล่นไปแล้วของไฟล์ปัจจุบัน และแสดง ProgreeBar ของการเล่นเพลง ณ ไฟล์ปัจจุบัน
        void ShowTimeAndProgreeBar()
        {
            if (audioFile != null)
            {
                //การแสดง ProgressBar
                int progressPercentage = (int)((double)audioFile.Position / audioFile.Length * progressBar.Maximum); //ทำให้เป็นอัตราส่วนของ progressBar 
                if (progressPercentage == 99) //เพลงจบแต่ ProgreeBar ไม่เต็ม
                    progressBar.Value = progressPercentage+1;
                else progressBar.Value = progressPercentage;

                //การแสดงเวลาที่ label ชื่อ timeStart
                showTimeCurrent();
            }
        }

        //แสดงเวลาที่ label ชื่อ timeStart
        void showTimeStart(int positionTimeMinutes,int positionTimeSeconds)
        {
            timeStart.Text = positionTimeMinutes + " : " + strSeconds(positionTimeSeconds);
        }

        //แปลงตำแหน่งในเสียงให้เป็นเวลาแบบนาทีและวินาที
        async Task showTimeCurrent()
        {
            int positionTimeMinutes, positionTimeSeconds , forTotalTime ,forBeforeSeconds;
            double forTime = audioFile.TotalTime.TotalMilliseconds;

            //แสดงกำกับว่าเสียงได้เล่นไปนานเท่าไหร่แล้ว
            long positionBytes = audioFile.Position;
            TimeSpan positionTime = TimeSpan.FromSeconds((double)positionBytes / audioFile.WaveFormat.AverageBytesPerSecond);
            //นาที และวินาทีของเพลง ณ ปัจจุบัน
            positionTimeMinutes = positionTime.Minutes;
            positionTimeSeconds = positionTime.Seconds;

            showTimeStart(positionTimeMinutes, positionTimeSeconds); //แสดงเวลา ณ ปัจจุบัน

            //เวลา ณ ตอนจบที่จะเอามาเทียบ
            //ทำเอาไว้กันแก้ปัญหาที่บางครั้งเพลงจบแล้ว แต่เวลาขาดไปอีก 1 วินาทีจึงจะจบลง
            forTotalTime = ((int)forTime) / 1000; //แปลงจากมิลลิวินาทีเป็นวินาที
            forBeforeSeconds = (forTotalTime % 60) -1; //ก่อนจบหนึ่งวินาที อาทิ ระยะเวลาเพลง คือ 4 : 10 , forBeforeSeconds = 9 วินาที

            if (positionTimeMinutes==(forTotalTime / 60)&& positionTimeSeconds== forBeforeSeconds)
            {
                await Task.Delay(1000); //หน่วงเวลา 1 วินาที
                showTimeStart(positionTimeMinutes, positionTimeSeconds+1);
            }
        }

        //แปลงตำแหน่งในเสียงให้เป็นเวลาแบบนาทีและวินาที
        string strTime(double forTime)
        {
            int forTotalTime = ((int)forTime) / 1000;
            int dataSeconds = forTotalTime % 60;
            return forTotalTime / 60 + " : " + strSeconds(dataSeconds);
        }

        //เช็กเลขวินาที ต้องการแบบ 0:01 ไม่ใช่ 0:1 
        string strSeconds(int dataSeconds)
        {
            return dataSeconds < 10 ? "0" + dataSeconds : dataSeconds.ToString();
        }

        //เล่นเพลง
        async Task openSound(long positionClick = 0) //ถ้าเป็นเล่นเพลงตั้งแต่ต้น เมธอด openSound ไม่ต้องระบุพารามิเตอร์
        {
            string forTimeEndValue="";

            turnoffTheMusic(); //หยุดเพลงก่อนหน้านี้
            await Task.Delay(200); //หน่วงเวลา 200 มิลลิวินาที
            audioFile = new AudioFileReader(files[playlist.SelectedIndex]);
            audioSound = new WaveOutEvent();
            audioSound.Init(audioFile);
            pitch(); //ปรับระดับเสียง
            audioSound.Play();

            //โซนตั้งค่า
            // คำนวณหาตำแหน่งสำหรับไฟล์เสียง
            long positionSound = (long)((double)positionClick / progressBar.Maximum * audioFile.Length);
            audioFile.Position = positionSound;

            btnRUNAndSTOP.ImageLocation = Application.StartupPath + "/run.png";
            ShowTimeAndProgreeBar(); //แสดงเวลาที่เพลงเล่นไปแล้ว ณ ปัจจุบันกำกับ และแสดง ProgressBar การเล่นของเพลง
            forTimeEndValue = strTime(audioFile.TotalTime.TotalMilliseconds); //เก็บค่าเวลาที่เพลงจบ(ความยาวเพลง)
            timeEnd.Text = forTimeEndValue;

            audioSound.PlaybackStopped += (s, args) =>
            {
                //timeStart.Text = forTimeEndValue;
                //progressBar.Value = 100;
                turnoffTheMusic();
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //รูปเคลื่อนไหวพื้นหลัง
            string path = Application.StartupPath + "\\imgbg.gif";
            bg.Image = Image.FromFile(path);

            btnOpenFiles.Width = 902;
            listClear.Hide();
            playlist.Hide();
        }

        //กดเลือกเสียงที่ต้องการฟังในบรรดารายการที่เลือกเข้ามา (บรรดารายการจาก listData)
        private void listData_SelectedIndexChanged(object sender, EventArgs e)
        {
            openSound();
        }

        //เปิดไฟล์เพื่อนำเข้าเสียง
        private void OpenFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Video Files|*.mp4;*.avi;*.mkv;*.wmv|Audio Files|*.mp3;*.wav;*.flac";
            openFile.Title = "เลือกรายการเพลงที่ต้องการ";
            openFile.Multiselect = true;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                playlist.Items.Clear();
                files = openFile.FileNames;

                //แสดงรายละเอียดรายการที่เลือกขึ้นบน listData
                for (int count = 0; count < files.Length; count++)
                {
                    playlist.Items.Add(files[count]);
                }

                playlist.Show();
                btnOpenFiles.Width = 597;
                listClear.Show();
            }
        }

        //trackbar สำหรับปรับระดับเสียง
        private void trackBar_Scroll(object sender, EventArgs e)
        {
            pitch();
        }

        //ปุ่มหยุดเพลงและเล่นเพลงต่อ
        private void btnRUNAndStop_Click(object sender, EventArgs e)
        {
            string PathRUN, PathStop;
            PathRUN = Application.StartupPath + "/run.png";
            PathStop = Application.StartupPath + "\\OIP.jpg";

            if(btnRUNAndSTOP.ImageLocation == PathRUN)
            {
                positionStop = audioFile.Position; //บันทึกตำแหน่งที่หยุดเอาไว้
                audioSound.Pause();
                btnRUNAndSTOP.ImageLocation = PathStop;
            }
            else
            {
                audioFile.Position = positionStop; //เล่นต่อจากที่หยุดเอาไว้
                audioSound.Play();
                btnRUNAndSTOP.ImageLocation = PathRUN;
            }
        }

        private void timer1_Tick(object sender, EventArgs e) //การคำนวณนี้ การแปลงเป็นทศนิยมสำคัญมาก
        {
            ShowTimeAndProgreeBar();
        }

        private void progressBar_Click(object sender, EventArgs e) //การคำนวณนี้ การแปลงเป็นทศนิยมสำคัญมาก
        {
            MouseEventArgs mouseEvent = e as MouseEventArgs;

            if (mouseEvent != null && mouseEvent.Button == MouseButtons.Left)
            {
                //เล่นเพลงในตำแหน่งที่คลิก pressBar
                // ดึงข้อมูลตำแหน่งที่คลิกบน progressBar
                int positionClick = (int)((double)mouseEvent.X / progressBar.Width * progressBar.Maximum);

                //ส่งข้อมูลตำแหน่งที่คลิกไปในเมธอดเพื่อเล่นเพลง
                openSound(positionClick);
            }
        }

        private void listClear_Click(object sender, EventArgs e)
        {
            playlist.Hide();
            playlist.Items.Clear();

            listClear.Hide();
            btnOpenFiles.Width = 902;
        }
    }
}
