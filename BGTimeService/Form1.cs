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
using System.Net;

namespace BGTimeService
{
    public partial class MainForm : Form
    {

        
        AudioPlaybackEngine playbackEngine;
        Mp3FileReader startMp3File;
        Control[] settingControlsToLock;

        TimeServiceState state;

        TimeHttpServer httpServer;

        public MainForm()
        {
            InitializeComponent();

            state = new TimeServiceState();
            lastSecondCalled = 0;
            httpServer = new TimeHttpServer();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            startTimePicker.Value = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0);

            UpdateOnOffButtonView(checkServiceActive);
            UpdateOnOffButtonView(checkHttpActive);

            
            playbackEngine = new AudioPlaybackEngine(44100, 2);
            startMp3File = null;

            settingControlsToLock = new Control[] { startTimePicker, numStartInterval,
                numFirstTeamNumber, numMaxTeamNumber, txtAudioFilesDir, bChooseAudioFilesDir };

            state.IsServiceActive = false;
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

        private void UpdateOnOffButtonView(CheckBox button)
        {
            button.Font = new Font(button.Font, !button.Checked ? FontStyle.Bold : FontStyle.Regular);
            if (button.Checked)
            {
                button.Text = "Отключить";
            }
            else
            {
                button.Text = "Включить";
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
            UpdateOverallState();
            UpdateHttpServerContent();
        }

        private void UpdateClock()
        {
            DateTime time = DateTime.Now;
            string timeText = DateTime.Now.ToString("HH:mm:ss");
            lblCurrentTime.Text = timeText;
            state.CurrentTimeText = timeText;
        }

        private void UpdateOverallState()
        {
            state.IsServiceActive = checkServiceActive.Checked;
        }

        private void UpdateHttpServerContent()
        {
            string content = state.ToJson();
            httpServer.Content = content;
        }

        private int? GetTeamNumber(DateTime currentDateTime, DateTime firstStart, int intervalMin, out bool intervalBeginsNow, out int secondsTillNextInterval)
        {
            firstStart = firstStart.AddMinutes(-intervalMin);
            if (currentDateTime < firstStart)
            {
                intervalBeginsNow = false;
                secondsTillNextInterval = 0;
                return null;
            }

            TimeSpan timeInterval = currentDateTime - firstStart;
            int minutes = (int)Math.Floor(timeInterval.TotalMinutes);

            if(minutes % intervalMin != 0 || currentDateTime.Second != 0)
            {
                intervalBeginsNow = false;
            } else
            {
                intervalBeginsNow = true;
            }

            int teamNumber = minutes / intervalMin;

            TimeSpan timeFromStart = currentDateTime - firstStart.AddMinutes(intervalMin * teamNumber);
            secondsTillNextInterval = intervalMin * 60 - (int)Math.Floor(timeFromStart.TotalSeconds);

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
            /*
            if(datetime.Second%10==0)
                playbackEngine.PlaySound(GetSoundFullPath("start.mp3"));
            return;
            */

            TimeSpan waitBeforeWelcomeSound = new TimeSpan(0, 0, 2);
            TimeSpan addToStartSound = new TimeSpan(0, 0, 1);

            DateTime firstStart = startTimePicker.Value;
            int intervalMin = (int)numStartInterval.Value;
            int teamMin = (int)numFirstTeamNumber.Value;
            int teamMax = (int)numMaxTeamNumber.Value;


            bool startingNow;
            int secondsTillNextStart;
            int? startingTeamNumberPure = GetTeamNumber(datetime - new TimeSpan(0, 0, 1), firstStart, intervalMin, out startingNow, out secondsTillNextStart);
            secondsTillNextStart = secondsTillNextStart - 1;
            state.CurrentStartingTeam = startingTeamNumberPure;
            state.SecondsToStart = secondsTillNextStart;
            state.IsStartingNow = (secondsTillNextStart == 0);

            Debug.WriteLine(string.Format("{4} Starting team: {0}{1} in {2}:{3}", startingTeamNumberPure, startingNow ? " NOW" : "", secondsTillNextStart / 60, secondsTillNextStart % 60, DateTime.Now.ToLongTimeString()));

            int? startingTeamNumber = GetTeamNumber(datetime - waitBeforeWelcomeSound, firstStart, intervalMin, out startingNow, out secondsTillNextStart);
            if(startingTeamNumber.HasValue && startingNow)
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
                int? startingAfterTeamNumber = GetTeamNumber(datetime + countdownLength.Value - addToStartSound, firstStart, intervalMin, out startingNow, out secondsTillNextStart);
                if(startingAfterTeamNumber.HasValue && startingNow && startingAfterTeamNumber.Value != 0)
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
            UpdateOnOffButtonView(checkServiceActive);
            if(checkServiceActive.Checked)
            {
                checkLockSettings.Checked = true;
                LoadStartSound(GetSoundFullPath("start.mp3"));
            }
        }

        private void checkHttpActive_CheckedChanged(object sender, EventArgs e)
        {
            UpdateOnOffButtonView(checkHttpActive);

            try
            {
                if (checkHttpActive.Checked)
                {
                    httpServer.Start(txtHttpSubpath.Text, (int)numHttpPort.Value);
                }
                else
                {
                    httpServer.Stop();
                }
            } catch(HttpListenerException exc)
            {
                MessageBox.Show("Ошибка при запуске сервера: "+exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            checkHttpActive.Checked = httpServer.IsActive;

            bool httpPropertiesActive = !checkHttpActive.Checked;
            txtHttpSubpath.Enabled = httpPropertiesActive;
            numHttpPort.Enabled = httpPropertiesActive;
        }
    }
}
