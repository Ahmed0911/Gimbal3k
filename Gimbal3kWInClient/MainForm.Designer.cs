
namespace Gimbal3kWInClient
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.textBoxIPAddress = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMainLoopCounter = new System.Windows.Forms.TextBox();
            this.timerPeriodic = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPositionPan = new System.Windows.Forms.TextBox();
            this.textBoxPositionTilt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxIPAddress
            // 
            this.textBoxIPAddress.Location = new System.Drawing.Point(47, 30);
            this.textBoxIPAddress.Name = "textBoxIPAddress";
            this.textBoxIPAddress.Size = new System.Drawing.Size(125, 26);
            this.textBoxIPAddress.TabIndex = 0;
            this.textBoxIPAddress.Text = "192.168.0.101";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(178, 24);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(90, 37);
            this.buttonConnect.TabIndex = 1;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Counter:";
            // 
            // textBoxMainLoopCounter
            // 
            this.textBoxMainLoopCounter.Location = new System.Drawing.Point(89, 73);
            this.textBoxMainLoopCounter.Name = "textBoxMainLoopCounter";
            this.textBoxMainLoopCounter.ReadOnly = true;
            this.textBoxMainLoopCounter.Size = new System.Drawing.Size(125, 26);
            this.textBoxMainLoopCounter.TabIndex = 4;
            // 
            // timerPeriodic
            // 
            this.timerPeriodic.Tick += new System.EventHandler(this.timerPeriodic_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Position Pan:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Position Tilt:";
            // 
            // textBoxPositionPan
            // 
            this.textBoxPositionPan.Location = new System.Drawing.Point(120, 125);
            this.textBoxPositionPan.Name = "textBoxPositionPan";
            this.textBoxPositionPan.ReadOnly = true;
            this.textBoxPositionPan.Size = new System.Drawing.Size(125, 26);
            this.textBoxPositionPan.TabIndex = 7;
            // 
            // textBoxPositionTilt
            // 
            this.textBoxPositionTilt.Location = new System.Drawing.Point(120, 159);
            this.textBoxPositionTilt.Name = "textBoxPositionTilt";
            this.textBoxPositionTilt.ReadOnly = true;
            this.textBoxPositionTilt.Size = new System.Drawing.Size(125, 26);
            this.textBoxPositionTilt.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 261);
            this.Controls.Add(this.textBoxPositionTilt);
            this.Controls.Add(this.textBoxPositionPan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxMainLoopCounter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.textBoxIPAddress);
            this.Name = "MainForm";
            this.Text = "Gimbal3k Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxIPAddress;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxMainLoopCounter;
        private System.Windows.Forms.Timer timerPeriodic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPositionPan;
        private System.Windows.Forms.TextBox textBoxPositionTilt;
    }
}

