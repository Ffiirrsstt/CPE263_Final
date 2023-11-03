namespace housework
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpenFiles = new System.Windows.Forms.Button();
            this.playlist = new System.Windows.Forms.ListBox();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.btnRUNAndSTOP = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRUNAndSTOP)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenFiles
            // 
            this.btnOpenFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOpenFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenFiles.ForeColor = System.Drawing.Color.Lime;
            this.btnOpenFiles.Location = new System.Drawing.Point(589, 13);
            this.btnOpenFiles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOpenFiles.Name = "btnOpenFiles";
            this.btnOpenFiles.Size = new System.Drawing.Size(418, 106);
            this.btnOpenFiles.TabIndex = 0;
            this.btnOpenFiles.Text = "นำเข้าไฟล์เพลง";
            this.btnOpenFiles.UseVisualStyleBackColor = false;
            this.btnOpenFiles.Click += new System.EventHandler(this.OpenFiles_Click);
            // 
            // playlist
            // 
            this.playlist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.playlist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.playlist.ForeColor = System.Drawing.Color.Lime;
            this.playlist.FormattingEnabled = true;
            this.playlist.ItemHeight = 29;
            this.playlist.Location = new System.Drawing.Point(466, 126);
            this.playlist.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.playlist.Name = "playlist";
            this.playlist.Size = new System.Drawing.Size(541, 439);
            this.playlist.TabIndex = 1;
            this.playlist.SelectedIndexChanged += new System.EventHandler(this.listData_SelectedIndexChanged);
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(405, 13);
            this.trackBar.Maximum = 100;
            this.trackBar.Name = "trackBar";
            this.trackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar.Size = new System.Drawing.Size(56, 552);
            this.trackBar.TabIndex = 2;
            this.trackBar.Value = 50;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // btnRUNAndSTOP
            // 
            this.btnRUNAndSTOP.BackColor = System.Drawing.Color.White;
            this.btnRUNAndSTOP.Image = global::housework.Properties.Resources.OIP;
            this.btnRUNAndSTOP.Location = new System.Drawing.Point(467, 13);
            this.btnRUNAndSTOP.Name = "btnRUNAndSTOP";
            this.btnRUNAndSTOP.Size = new System.Drawing.Size(116, 106);
            this.btnRUNAndSTOP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRUNAndSTOP.TabIndex = 3;
            this.btnRUNAndSTOP.TabStop = false;
            this.btnRUNAndSTOP.Click += new System.EventHandler(this.btnRUNAndStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1019, 581);
            this.Controls.Add(this.btnRUNAndSTOP);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.playlist);
            this.Controls.Add(this.btnOpenFiles);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRUNAndSTOP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOpenFiles;
        private System.Windows.Forms.ListBox playlist;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.PictureBox btnRUNAndSTOP;
    }
}

