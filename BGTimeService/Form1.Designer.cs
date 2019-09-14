namespace BGTimeService
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
            this.lblCurrentTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAudioFilesDir = new System.Windows.Forms.TextBox();
            this.bChooseAudioFilesDir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numStartInterval = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numFirstTeamNumber = new System.Windows.Forms.NumericUpDown();
            this.checkServiceActive = new System.Windows.Forms.CheckBox();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.numMaxTeamNumber = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatusMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.checkLockSettings = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numHttpPort = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.txtHttpSubpath = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.checkHttpActive = new System.Windows.Forms.CheckBox();
            this.groupHttpServer = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numStartInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFirstTeamNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxTeamNumber)).BeginInit();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHttpPort)).BeginInit();
            this.groupHttpServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.AutoSize = true;
            this.lblCurrentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCurrentTime.Location = new System.Drawing.Point(321, 9);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(212, 55);
            this.lblCurrentTime.TabIndex = 0;
            this.lblCurrentTime.Text = "00:00:00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Каталог аудиозаписей:";
            // 
            // txtAudioFilesDir
            // 
            this.txtAudioFilesDir.Location = new System.Drawing.Point(143, 90);
            this.txtAudioFilesDir.Name = "txtAudioFilesDir";
            this.txtAudioFilesDir.Size = new System.Drawing.Size(175, 20);
            this.txtAudioFilesDir.TabIndex = 2;
            // 
            // bChooseAudioFilesDir
            // 
            this.bChooseAudioFilesDir.Location = new System.Drawing.Point(324, 88);
            this.bChooseAudioFilesDir.Name = "bChooseAudioFilesDir";
            this.bChooseAudioFilesDir.Size = new System.Drawing.Size(75, 23);
            this.bChooseAudioFilesDir.TabIndex = 3;
            this.bChooseAudioFilesDir.Text = "Выбрать";
            this.bChooseAudioFilesDir.UseVisualStyleBackColor = true;
            this.bChooseAudioFilesDir.Click += new System.EventHandler(this.bChooseAudioFilesDir_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(521, 35);
            this.label3.TabIndex = 4;
            this.label3.Text = "Файлы с номерами команд должны иметь имена 00.mp3, 01.mp3 и т.д., файл с отсчетом" +
    " старта должен иметь имя start.mp3";
            // 
            // startTimePicker
            // 
            this.startTimePicker.CustomFormat = "HH:mm - d.MM.yyyy";
            this.startTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startTimePicker.Location = new System.Drawing.Point(145, 177);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.ShowUpDown = true;
            this.startTimePicker.Size = new System.Drawing.Size(234, 29);
            this.startTimePicker.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Старт первой команды:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Интервал между командами, мин:";
            // 
            // numStartInterval
            // 
            this.numStartInterval.Location = new System.Drawing.Point(200, 224);
            this.numStartInterval.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numStartInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStartInterval.Name = "numStartInterval";
            this.numStartInterval.Size = new System.Drawing.Size(65, 20);
            this.numStartInterval.TabIndex = 8;
            this.numStartInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Номер первой команды:";
            // 
            // numFirstTeamNumber
            // 
            this.numFirstTeamNumber.Location = new System.Drawing.Point(200, 251);
            this.numFirstTeamNumber.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numFirstTeamNumber.Name = "numFirstTeamNumber";
            this.numFirstTeamNumber.Size = new System.Drawing.Size(65, 20);
            this.numFirstTeamNumber.TabIndex = 10;
            // 
            // checkServiceActive
            // 
            this.checkServiceActive.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkServiceActive.Location = new System.Drawing.Point(189, 315);
            this.checkServiceActive.Name = "checkServiceActive";
            this.checkServiceActive.Size = new System.Drawing.Size(150, 38);
            this.checkServiceActive.TabIndex = 11;
            this.checkServiceActive.Text = "Включить";
            this.checkServiceActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkServiceActive.UseVisualStyleBackColor = true;
            this.checkServiceActive.CheckedChanged += new System.EventHandler(this.checkServiceActive_CheckedChanged);
            // 
            // mainTimer
            // 
            this.mainTimer.Enabled = true;
            this.mainTimer.Interval = 250;
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // numMaxTeamNumber
            // 
            this.numMaxTeamNumber.Location = new System.Drawing.Point(200, 277);
            this.numMaxTeamNumber.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numMaxTeamNumber.Name = "numMaxTeamNumber";
            this.numMaxTeamNumber.Size = new System.Drawing.Size(65, 20);
            this.numMaxTeamNumber.TabIndex = 13;
            this.numMaxTeamNumber.Value = new decimal(new int[] {
            99,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Номер последней команды:";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusMsg});
            this.statusStrip.Location = new System.Drawing.Point(0, 421);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(544, 22);
            this.statusStrip.TabIndex = 14;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblStatusMsg
            // 
            this.lblStatusMsg.Name = "lblStatusMsg";
            this.lblStatusMsg.Size = new System.Drawing.Size(0, 17);
            // 
            // checkLockSettings
            // 
            this.checkLockSettings.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkLockSettings.Location = new System.Drawing.Point(366, 228);
            this.checkLockSettings.Name = "checkLockSettings";
            this.checkLockSettings.Size = new System.Drawing.Size(150, 26);
            this.checkLockSettings.TabIndex = 15;
            this.checkLockSettings.Text = "Блокировка настроек";
            this.checkLockSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkLockSettings.UseVisualStyleBackColor = true;
            this.checkLockSettings.CheckedChanged += new System.EventHandler(this.checkLockSettings_CheckedChanged);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "http://+:";
            // 
            // numHttpPort
            // 
            this.numHttpPort.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numHttpPort.Location = new System.Drawing.Point(59, 19);
            this.numHttpPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numHttpPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHttpPort.Name = "numHttpPort";
            this.numHttpPort.Size = new System.Drawing.Size(62, 20);
            this.numHttpPort.TabIndex = 18;
            this.numHttpPort.Value = new decimal(new int[] {
            8082,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(124, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "/";
            // 
            // txtHttpSubpath
            // 
            this.txtHttpSubpath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtHttpSubpath.Location = new System.Drawing.Point(142, 18);
            this.txtHttpSubpath.Name = "txtHttpSubpath";
            this.txtHttpSubpath.Size = new System.Drawing.Size(88, 20);
            this.txtHttpSubpath.TabIndex = 20;
            this.txtHttpSubpath.Text = "runcitytime";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(236, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(12, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "/";
            // 
            // checkHttpActive
            // 
            this.checkHttpActive.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkHttpActive.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkHttpActive.Location = new System.Drawing.Point(391, 15);
            this.checkHttpActive.Name = "checkHttpActive";
            this.checkHttpActive.Size = new System.Drawing.Size(110, 25);
            this.checkHttpActive.TabIndex = 22;
            this.checkHttpActive.Text = "Включить";
            this.checkHttpActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkHttpActive.UseVisualStyleBackColor = true;
            this.checkHttpActive.CheckedChanged += new System.EventHandler(this.checkHttpActive_CheckedChanged);
            // 
            // groupHttpServer
            // 
            this.groupHttpServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupHttpServer.Controls.Add(this.numHttpPort);
            this.groupHttpServer.Controls.Add(this.checkHttpActive);
            this.groupHttpServer.Controls.Add(this.label8);
            this.groupHttpServer.Controls.Add(this.label10);
            this.groupHttpServer.Controls.Add(this.label9);
            this.groupHttpServer.Controls.Add(this.txtHttpSubpath);
            this.groupHttpServer.Location = new System.Drawing.Point(15, 359);
            this.groupHttpServer.Name = "groupHttpServer";
            this.groupHttpServer.Size = new System.Drawing.Size(518, 51);
            this.groupHttpServer.TabIndex = 23;
            this.groupHttpServer.TabStop = false;
            this.groupHttpServer.Text = "Веб-сервер";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 443);
            this.Controls.Add(this.groupHttpServer);
            this.Controls.Add(this.checkLockSettings);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.numMaxTeamNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkServiceActive);
            this.Controls.Add(this.numFirstTeamNumber);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numStartInterval);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.startTimePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bChooseAudioFilesDir);
            this.Controls.Add(this.txtAudioFilesDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCurrentTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Служба времени";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numStartInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFirstTeamNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxTeamNumber)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHttpPort)).EndInit();
            this.groupHttpServer.ResumeLayout(false);
            this.groupHttpServer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCurrentTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAudioFilesDir;
        private System.Windows.Forms.Button bChooseAudioFilesDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numStartInterval;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numFirstTeamNumber;
        private System.Windows.Forms.CheckBox checkServiceActive;
        private System.Windows.Forms.Timer mainTimer;
        private System.Windows.Forms.NumericUpDown numMaxTeamNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusMsg;
        private System.Windows.Forms.CheckBox checkLockSettings;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numHttpPort;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtHttpSubpath;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkHttpActive;
        private System.Windows.Forms.GroupBox groupHttpServer;
    }
}

