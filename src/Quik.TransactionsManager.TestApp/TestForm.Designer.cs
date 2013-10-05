namespace Quik.TransactionsManager.TestApp
{
    partial class TestForm
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
			this.btnStartGen = new System.Windows.Forms.Button();
			this.btnChooseTRO = new System.Windows.Forms.Button();
			this.tbTROPath = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnChooseTRI = new System.Windows.Forms.Button();
			this.tbTRIPath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.rtbLog = new System.Windows.Forms.RichTextBox();
			this.btnStop = new System.Windows.Forms.Button();
			this.btnStart = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// btnStartGen
			// 
			this.btnStartGen.Location = new System.Drawing.Point(9, 64);
			this.btnStartGen.Name = "btnStartGen";
			this.btnStartGen.Size = new System.Drawing.Size(291, 23);
			this.btnStartGen.TabIndex = 19;
			this.btnStartGen.Text = "Start Message Generator";
			this.btnStartGen.UseVisualStyleBackColor = true;
			this.btnStartGen.Click += new System.EventHandler(this.btnStartGen_Click);
			// 
			// btnChooseTRO
			// 
			this.btnChooseTRO.Location = new System.Drawing.Point(188, 36);
			this.btnChooseTRO.Name = "btnChooseTRO";
			this.btnChooseTRO.Size = new System.Drawing.Size(111, 23);
			this.btnChooseTRO.TabIndex = 18;
			this.btnChooseTRO.Text = "Choose";
			this.btnChooseTRO.UseVisualStyleBackColor = true;
			this.btnChooseTRO.Click += new System.EventHandler(this.btnChooseTRO_Click);
			// 
			// tbTROPath
			// 
			this.tbTROPath.Location = new System.Drawing.Point(38, 38);
			this.tbTROPath.Name = "tbTROPath";
			this.tbTROPath.Size = new System.Drawing.Size(145, 20);
			this.tbTROPath.TabIndex = 17;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 13);
			this.label2.TabIndex = 16;
			this.label2.Text = "TRO";
			// 
			// btnChooseTRI
			// 
			this.btnChooseTRI.Location = new System.Drawing.Point(188, 10);
			this.btnChooseTRI.Name = "btnChooseTRI";
			this.btnChooseTRI.Size = new System.Drawing.Size(111, 23);
			this.btnChooseTRI.TabIndex = 15;
			this.btnChooseTRI.Text = "Choose";
			this.btnChooseTRI.UseVisualStyleBackColor = true;
			this.btnChooseTRI.Click += new System.EventHandler(this.btnChooseTRI_Click);
			// 
			// tbTRIPath
			// 
			this.tbTRIPath.Location = new System.Drawing.Point(38, 12);
			this.tbTRIPath.Name = "tbTRIPath";
			this.tbTRIPath.Size = new System.Drawing.Size(145, 20);
			this.tbTRIPath.TabIndex = 14;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(25, 13);
			this.label1.TabIndex = 13;
			this.label1.Text = "TRI";
			// 
			// rtbLog
			// 
			this.rtbLog.Location = new System.Drawing.Point(9, 121);
			this.rtbLog.Name = "rtbLog";
			this.rtbLog.Size = new System.Drawing.Size(290, 381);
			this.rtbLog.TabIndex = 12;
			this.rtbLog.Text = "";
			// 
			// btnStop
			// 
			this.btnStop.Location = new System.Drawing.Point(158, 92);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(142, 23);
			this.btnStop.TabIndex = 11;
			this.btnStop.Text = "Stop";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(9, 92);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(142, 23);
			this.btnStart.TabIndex = 10;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// TestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(315, 514);
			this.Controls.Add(this.btnStartGen);
			this.Controls.Add(this.btnChooseTRO);
			this.Controls.Add(this.tbTROPath);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnChooseTRI);
			this.Controls.Add(this.tbTRIPath);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.rtbLog);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.btnStart);
			this.Name = "TestForm";
			this.Text = "TestForm";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartGen;
        private System.Windows.Forms.Button btnChooseTRO;
        private System.Windows.Forms.TextBox tbTROPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChooseTRI;
        private System.Windows.Forms.TextBox tbTRIPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

