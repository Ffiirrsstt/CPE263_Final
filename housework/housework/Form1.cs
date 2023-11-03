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

        //เปิดเพลง
        async Task openSound()
        {
            turnoffTheMusic();
            await Task.Delay(200); //หน่วงเวลา 200 มิลลิวินาที
            audioFile = new AudioFileReader(files[playlist.SelectedIndex]);
            audioSound = new WaveOutEvent();
            audioSound.Init(audioFile);
            pitch(); //ปรับระดับเสียง
            audioSound.Play();
            btnRUNAndSTOP.ImageLocation = Application.StartupPath + "/run.png";

            audioSound.PlaybackStopped += (s, args) =>
            {
                turnoffTheMusic();
            };
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
                files = openFile.FileNames;

                //แสดงรายละเอียดรายการที่เลือกขึ้นบน listData
                for (int count = 0; count < files.Length; count++)
                {
                    playlist.Items.Add(files[count]);
                }
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

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
