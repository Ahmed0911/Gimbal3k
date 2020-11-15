
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
            this.textBoxPositionPanDeg = new System.Windows.Forms.TextBox();
            this.textBoxPositionTiltDeg = new System.Windows.Forms.TextBox();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.textBoxPositionPanEnco = new System.Windows.Forms.TextBox();
            this.textBoxPositionTiltEnco = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPanRef = new System.Windows.Forms.TextBox();
            this.textBoxTiltRef = new System.Windows.Forms.TextBox();
            this.buttonGO = new System.Windows.Forms.Button();
            this.radioButtonManualMode = new System.Windows.Forms.RadioButton();
            this.radioButtonAutoMode = new System.Windows.Forms.RadioButton();
            this.textBoxActiveMode = new System.Windows.Forms.TextBox();
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
            this.label4.Location = new System.Drawing.Point(12, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Position Tilt:";
            // 
            // textBoxPositionPanDeg
            // 
            this.textBoxPositionPanDeg.Location = new System.Drawing.Point(120, 125);
            this.textBoxPositionPanDeg.Name = "textBoxPositionPanDeg";
            this.textBoxPositionPanDeg.ReadOnly = true;
            this.textBoxPositionPanDeg.Size = new System.Drawing.Size(94, 26);
            this.textBoxPositionPanDeg.TabIndex = 7;
            // 
            // textBoxPositionTiltDeg
            // 
            this.textBoxPositionTiltDeg.Location = new System.Drawing.Point(120, 167);
            this.textBoxPositionTiltDeg.Name = "textBoxPositionTiltDeg";
            this.textBoxPositionTiltDeg.ReadOnly = true;
            this.textBoxPositionTiltDeg.Size = new System.Drawing.Size(94, 26);
            this.textBoxPositionTiltDeg.TabIndex = 8;
            // 
            // buttonRight
            // 
            this.buttonRight.Location = new System.Drawing.Point(170, 250);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(75, 36);
            this.buttonRight.TabIndex = 9;
            this.buttonRight.Text = "Right";
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonRight_MouseDown);
            this.buttonRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonRight_MouseUp);
            // 
            // buttonLeft
            // 
            this.buttonLeft.Location = new System.Drawing.Point(78, 250);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(75, 36);
            this.buttonLeft.TabIndex = 10;
            this.buttonLeft.Text = "Left";
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonLeft_MouseDown);
            this.buttonLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonLeft_MouseUp);
            // 
            // buttonUp
            // 
            this.buttonUp.Location = new System.Drawing.Point(130, 208);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(75, 36);
            this.buttonUp.TabIndex = 12;
            this.buttonUp.Text = "Up";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonUp_MouseDown);
            this.buttonUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonUp_MouseUp);
            // 
            // buttonDown
            // 
            this.buttonDown.Location = new System.Drawing.Point(130, 292);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(75, 36);
            this.buttonDown.TabIndex = 11;
            this.buttonDown.Text = "Down";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonDown_MouseDown);
            this.buttonDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonDown_MouseUp);
            // 
            // textBoxPositionPanEnco
            // 
            this.textBoxPositionPanEnco.Location = new System.Drawing.Point(262, 125);
            this.textBoxPositionPanEnco.Name = "textBoxPositionPanEnco";
            this.textBoxPositionPanEnco.ReadOnly = true;
            this.textBoxPositionPanEnco.Size = new System.Drawing.Size(125, 26);
            this.textBoxPositionPanEnco.TabIndex = 13;
            // 
            // textBoxPositionTiltEnco
            // 
            this.textBoxPositionTiltEnco.Location = new System.Drawing.Point(262, 167);
            this.textBoxPositionTiltEnco.Name = "textBoxPositionTiltEnco";
            this.textBoxPositionTiltEnco.ReadOnly = true;
            this.textBoxPositionTiltEnco.Size = new System.Drawing.Size(125, 26);
            this.textBoxPositionTiltEnco.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(282, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Pan Ref:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(282, 268);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Tilt Ref:";
            // 
            // textBoxPanRef
            // 
            this.textBoxPanRef.Location = new System.Drawing.Point(359, 233);
            this.textBoxPanRef.Name = "textBoxPanRef";
            this.textBoxPanRef.Size = new System.Drawing.Size(89, 26);
            this.textBoxPanRef.TabIndex = 17;
            this.textBoxPanRef.Text = "0";
            // 
            // textBoxTiltRef
            // 
            this.textBoxTiltRef.Location = new System.Drawing.Point(359, 265);
            this.textBoxTiltRef.Name = "textBoxTiltRef";
            this.textBoxTiltRef.Size = new System.Drawing.Size(89, 26);
            this.textBoxTiltRef.TabIndex = 18;
            this.textBoxTiltRef.Text = "0";
            // 
            // buttonGO
            // 
            this.buttonGO.Location = new System.Drawing.Point(358, 307);
            this.buttonGO.Name = "buttonGO";
            this.buttonGO.Size = new System.Drawing.Size(90, 37);
            this.buttonGO.TabIndex = 19;
            this.buttonGO.Text = "GO";
            this.buttonGO.UseVisualStyleBackColor = true;
            this.buttonGO.Click += new System.EventHandler(this.buttonGO_Click);
            // 
            // radioButtonManualMode
            // 
            this.radioButtonManualMode.AutoSize = true;
            this.radioButtonManualMode.Checked = true;
            this.radioButtonManualMode.Location = new System.Drawing.Point(358, 32);
            this.radioButtonManualMode.Name = "radioButtonManualMode";
            this.radioButtonManualMode.Size = new System.Drawing.Size(86, 24);
            this.radioButtonManualMode.TabIndex = 20;
            this.radioButtonManualMode.TabStop = true;
            this.radioButtonManualMode.Text = "Manual";
            this.radioButtonManualMode.UseVisualStyleBackColor = true;
            // 
            // radioButtonAutoMode
            // 
            this.radioButtonAutoMode.AutoSize = true;
            this.radioButtonAutoMode.Location = new System.Drawing.Point(358, 62);
            this.radioButtonAutoMode.Name = "radioButtonAutoMode";
            this.radioButtonAutoMode.Size = new System.Drawing.Size(68, 24);
            this.radioButtonAutoMode.TabIndex = 21;
            this.radioButtonAutoMode.Text = "Auto";
            this.radioButtonAutoMode.UseVisualStyleBackColor = true;
            // 
            // textBoxActiveMode
            // 
            this.textBoxActiveMode.Location = new System.Drawing.Point(357, 92);
            this.textBoxActiveMode.Name = "textBoxActiveMode";
            this.textBoxActiveMode.ReadOnly = true;
            this.textBoxActiveMode.Size = new System.Drawing.Size(91, 26);
            this.textBoxActiveMode.TabIndex = 22;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 367);
            this.Controls.Add(this.textBoxActiveMode);
            this.Controls.Add(this.radioButtonAutoMode);
            this.Controls.Add(this.radioButtonManualMode);
            this.Controls.Add(this.buttonGO);
            this.Controls.Add(this.textBoxTiltRef);
            this.Controls.Add(this.textBoxPanRef);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxPositionTiltEnco);
            this.Controls.Add(this.textBoxPositionPanEnco);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.textBoxPositionTiltDeg);
            this.Controls.Add(this.textBoxPositionPanDeg);
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
        private System.Windows.Forms.TextBox textBoxPositionPanDeg;
        private System.Windows.Forms.TextBox textBoxPositionTiltDeg;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.TextBox textBoxPositionPanEnco;
        private System.Windows.Forms.TextBox textBoxPositionTiltEnco;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPanRef;
        private System.Windows.Forms.TextBox textBoxTiltRef;
        private System.Windows.Forms.Button buttonGO;
        private System.Windows.Forms.RadioButton radioButtonManualMode;
        private System.Windows.Forms.RadioButton radioButtonAutoMode;
        private System.Windows.Forms.TextBox textBoxActiveMode;
    }
}

