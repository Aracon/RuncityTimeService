using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using NAudio;
using NAudio.Wave;
using System.IO;

namespace BGTimeService
{
    public partial class MainForm : Form
    {

        
        AudioPlaybackEngine playbackEngine;
        Mp3FileReader startMp3File;
        Control[] settingControlsToLock;

        public MainForm()
        {
            InitializeComponent();

            lastSecondCalled = 0;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            startTimePicker.Value = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0);

            UpdateOnOffButtonView();
            
            playbackEngine = new AudioPlaybackEngine();
            startMp3File = null;

            settingControlsToLock = new Control[] { startTimePicker, numStartInterval,
                numFirstTeamNumber, numMaxTeamNumber, txtAudioFilesDir, bChooseAudioFilesDir };
        }

        private void LockSettings(bool locked)
        {
            foreach(Control ctr in settingControlsToLock)
            {
                ctr.Enabled = !locked;
            }
        }

        private void AddLogMessage(string msg)
        {
            lblStatusMsg.Text = msg;
        }

        private void UpdateOnOffButtonView()
        {
            checkServiceActive.Font = new Font(checkServiceActive.Font, !checkServiceActive.Checked ? FontStyle.Bold : FontStyle.Regular);
            if (checkServiceActive.Checked)
            {
                checkServiceActive.Text = "Работает";
            }
            else
            {
                checkServiceActive.Text = "Отключен";
            }
        }

        private void bChooseAudioFilesDir_Click(object sender, EventArgs e)
        {
            using(FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = Application.StartupPath;
                if(fbd.ShowDialog() == DialogResult.OK)
                {
                    txtAudioFilesDir.Text = fbd.SelectedPath;
                }
            }
        }

        private Int32 GetUnixTimestamp(DateTime dt)
        {
            return (Int32)(dt.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        int lastSecondCalled;
        private void mainTimer_Tick(object sender, EventArgs e)
        {
            UpdateClock();
            int currentSecond = GetUnixTimestamp(DateTime.Now);
            if(currentSecond != lastSecondCalled)
            {
                lastSecondCalled = currentSecond;
                if (checkServiceActive.Checked)
                {
                    OnNewSecond(DateTime.Now);
                }
            }
        }

        private void UpdateClock()
        {
            DateTime time = DateTime.Now;
            lblCurrentTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private int? GetTeamNumber(DateTime currentDateTime, DateTime firstStart, int intervalMin)
        {
            if (currentDateTime.Second != 0)
            {
                return null;
            }
            firstStart = firstStart.AddMinutes(-intervalMin);
            if (currentDateTime < firstStart)
            {
                return null;
            }            
            TimeSpan timeInterval = currentDateTime - firstStart;
            int minutes = (int)Math.Floor(timeInterval.TotalMinutes);

            if(minutes % intervalMin != 0)
            {
                return null;
            }

            int teamNumber = minutes / intervalMin;
            return teamNumber; 
            
        }

        private TimeSpan? GetStartSoundDuration()
        {
            if(startMp3File == null)
            {
                return null;
            }
            return startMp3File.TotalTime;
        }

        private string GetSoundFullPath(string filename)
        {
            string soundsCatalog = txtAudioFilesDir.Text;
            return  soundsCatalog + "/" + filename;
        }

        private void LoadStartSound(string fullFileName)
        {
            if(startMp3File != null)
            {
                startMp3File.Dispose();
                startMp3File = null;
            }
            try
            {
                startMp3File = new Mp3FileReader(fullFileName);
            }
            catch (Exception exc)
            {
                AddLogMessage(string.Format("Loading countdown mp3 - Errror: {0} ({1})", exc.Message, exc.GetType().ToString()));
            }
        }

        private void PlayTeamSound(int teamNumber)
        {
            string soundFileName = teamNumber.ToString("D2") + ".mp3";
            string fullFileName = GetSoundFullPath(soundFileName);

            if (!File.Exists(fullFileName))
            {
                AddLogMessage(string.Format("Audio file {0} not found", fullFileName));
                Debug.WriteLine(string.Format("Audio file {0} not found", fullFileName));
                return;
            }

            Debug.WriteLine(string.Format("Playing file {0}", fullFileName));

            try
            {
                playbackEngine.PlaySound(fullFileName);
            }
            catch (Exception exc)
            {
                AddLogMessage(string.Format("Play error: {0} ({1})", exc.Message, exc.GetType().ToString()));
            }
        }

        private void PlayCountdownSound()
        {
            if(startMp3File == null)
            {
                AddLogMessage("Countdown - no mp3 loaded");
                return;
            }
            try
            {
                playbackEngine.PlaySound(GetSoundFullPath("start.mp3"));
            }
            catch (Exception exc)
            {
                AddLogMessage(string.Format("Play error: {0} ({1})", exc.Message, exc.GetType().ToString()));
            }
        }

        private void OnNewSecond(DateTime datetime)
        {
            TimeSpan waitBeforeWelcomeSound = new TimeSpan(0, 0, 2);

            DateTime firstStart = startTimePicker.Value;
            int intervalMin = (int)numStartInterval.Value;
            int teamMin = (int)numFirstTeamNumber.Value;
            int teamMax = (int)numMaxTeamNumber.Value;

            int? startingTeamNumber = GetTeamNumber(datetime - waitBeforeWelcomeSound, firstStart, intervalMin);
            if(startingTeamNumber.HasValue)
            {
                if(startingTeamNumber.Value >= teamMin && startingTeamNumber.Value <= teamMax)
                {
                    // Запустить аудио
                    Debug.WriteLine(string.Format("Team {0} starts at {1}", startingTeamNumber.Value, datetime));
                    PlayTeamSound(startingTeamNumber.Value);
                }
            }

            // Обратный отсчёт
            TimeSpan? countdownLength = GetStartSoundDuration();
            if (countdownLength.HasValue)
            {
                int? startingAfterTeamNumber = GetTeamNumber(datetime + countdownLength.Value, firstStart, intervalMin);
                if(startingAfterTeamNumber.HasValue && startingAfterTeamNumber.Value != 0)
                {
                    if (startingAfterTeamNumber.Value >= teamMin && startingAfterTeamNumber.Value <= teamMax)
                    {
                        // Запустить аудио
                        Debug.WriteLine(string.Format("Countdown for team {0} (will start at {1}, countdown at {2})",
                            startingAfterTeamNumber.Value, datetime + countdownLength.Value, datetime));
                        PlayCountdownSound();
                    }
                }
            }


        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void checkLockSettings_CheckedChanged(object sender, EventArgs e)
        {
            LockSettings(checkLockSettings.Checked);
        }

        private void checkServiceActive_CheckedChanged(object sender, EventArgs e)
        {
            UpdateOnOffButtonView();
            if(checkServiceActive.Checked)
            {
                checkLockSettings.Checked = true;
                LoadStartSound(GetSoundFullPath("start.mp3"));
            }
        }
    }
}
