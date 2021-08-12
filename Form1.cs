using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;
using System.Configuration;
using System.Collections.Specialized;

namespace WarframeDailyLogin
{
    enum State
    {
        SETUP,
        RUNNING,
        STOPPING,
        STOPPED,
        UNDEFINED
    }
    public partial class Form1 : Form
    {
        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int WM_APPCOMMAND = 0x319;
        private State state;
        List<DateTime> datesLogggedIn;
        string logFileName;
        public static readonly Color LIGHTGREY = Color.FromArgb(45, 45, 45);
        public static readonly Color DARKGREY = Color.FromArgb(28, 28, 28);
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        public Form1()
        {
            InitializeComponent();
            customTabControl1.Appearance = TabAppearance.FlatButtons; customTabControl1.ItemSize = new Size(0, 1); customTabControl1.SizeMode = TabSizeMode.Fixed;
            logFileName = "Warframe_Daily_Login.log";
            tbPassword.PasswordChar = '*';
            this.state = State.SETUP;
            SetStateLabel();
            datesLogggedIn = new List<DateTime>();
            this.tbGamePath.Text = ConfigurationManager.AppSettings.Get("GamePath");
            this.tbPassword.Text = "";
            tbLauncherX.Text = ConfigurationManager.AppSettings.Get("LauncherX");
            tbLauncherY.Text = ConfigurationManager.AppSettings.Get("LauncherY");
            tbGetMouseDelay.Text = ConfigurationManager.AppSettings.Get("GetMouseDelay");
            tbLauncherLoadTime.Text = ConfigurationManager.AppSettings.Get("LauncherLoadTime");
            tbGameLoadTime.Text = ConfigurationManager.AppSettings.Get("GameLoadTime");
            tbExitWaitTime.Text = ConfigurationManager.AppSettings.Get("ExitWaitTime");
            tbLoginTimeHours.Text = ConfigurationManager.AppSettings.Get("LoginTimeHours");
            tbLoginTimeMinutes.Text = ConfigurationManager.AppSettings.Get("LoginTimeMinutes");
            tbLoginTimeSeconds.Text = ConfigurationManager.AppSettings.Get("LoginTimeSeconds");
            tbLoginCheckHours.Text = ConfigurationManager.AppSettings.Get("LoginCheckHours");
            tbLoginCheckMinutes.Text = ConfigurationManager.AppSettings.Get("LoginCheckMinutes");
            tbLoginCheckSeconds.Text = ConfigurationManager.AppSettings.Get("LoginCheckSeconds");

        }
        private void UpdateLoggedDatesListBox()
        {
            lbLoggedDates.Items.Clear();
            foreach (DateTime date in datesLogggedIn)
            {
                lbLoggedDates.Items.Add(date.ToString());
            }
        }
        private async void btnRun_Click(object sender, EventArgs e)
        {
            this.btnRun.Enabled = false;
            UpdateScheduledLoginLabel();
            this.state = State.RUNNING;
            SetStateLabel();
            // run once on startup if required.
            if (cbLoginOnStart.Checked)
            {
                Login();
            }
            ReadLogFile();
            UpdateLoggedDatesListBox();
            TimeSpan loginCheckDuration = GetLoginCheckDuration();
            while (this.state == State.RUNNING)
            {
                await Task.Delay(loginCheckDuration);
                TimeSpan loginTime = GetLoginTime();
                TimeSpan timeOfDay = DateTime.Now.TimeOfDay;
                DateTime today = DateTime.Today.Date;
                if ((timeOfDay > loginTime) & (!datesLogggedIn.Contains(today)))
                {
                    Login();
                    datesLogggedIn.Add(today);
                    using (StreamWriter writer = new StreamWriter(logFileName))
                    {
                        writer.WriteLine(today.ToString() + " - Successful Login");
                    }
                    UpdateLoggedDatesListBox();
                }
            }
            this.state = State.STOPPED;
            SetStateLabel();
            this.btnRun.Enabled = true;
        }
        private void ReadLogFile()
        {
            if (File.Exists(logFileName))
            {
                using (StreamReader reader = new StreamReader(logFileName))
                {
                    string line;
                    string dateString;
                    DateTime date;
                    while ((line = reader.ReadLine()) != null)
                    {
                        dateString = line.Split('-').First().Trim();
                        date = DateTime.Parse(dateString);
                        datesLogggedIn.Add(date);
                    }
                }
            }
        }
        private void SetStateLabel()
        {
            switch (this.state)
            {
                case State.SETUP:
                    labelStatus.Text = "SETUP";
                    labelStatus.ForeColor = Color.CornflowerBlue;
                    break;
                case State.RUNNING:
                    labelStatus.Text = "RUNNING";
                    labelStatus.ForeColor = Color.LimeGreen;
                    break;
                case State.STOPPING:
                    labelStatus.Text = "STOPPING";
                    labelStatus.ForeColor = Color.Yellow;
                    break;
                case State.STOPPED:
                    labelStatus.Text = "STOPPED";
                    labelStatus.ForeColor = Color.Red;
                    break;
                case State.UNDEFINED:
                    labelStatus.Text = "UNDEFINED";
                    labelStatus.ForeColor = Color.Red;
                    break;
            }
        }
        private void Login()
        {
            Process warframe = new Process();
            warframe.StartInfo.FileName = this.tbGamePath.Text;
            warframe.EnableRaisingEvents = true;
            warframe.Start();
            bool launcherPass = int.TryParse(tbLauncherLoadTime.Text, out int launcherDelaySeconds);
            bool gamePass = int.TryParse(tbGameLoadTime.Text, out int GameDelaySeconds);
            bool exitPass = int.TryParse(tbExitWaitTime.Text, out int ExitDelaySeconds);
            if (!(launcherPass & gamePass & exitPass))
            {
                MessageBox.Show("One or more wait times are invalid.", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int launcherDelayMili = launcherDelaySeconds * 1000;
            int GameDelayMili = GameDelaySeconds * 1000;
            int ExitDelayMili = ExitDelaySeconds * 1000;
            Thread.Sleep(launcherDelayMili);
            // mute system sound
            if (cbMute.Checked)
            {
                SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMMAND_VOLUME_MUTE);
            }
            ClickStart();
            Thread.Sleep(GameDelayMili);
            SendPassword();
            Thread.Sleep(ExitDelayMili);
            warframe.Close();
            KillGame();
            //unmute system sound
            if (cbMute.Checked)
            {
                SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMMAND_VOLUME_MUTE);
            }
        }
        private async void btnGetMousePoint_Click(object sender, EventArgs e)
        {
            bool pass = int.TryParse(tbGetMouseDelay.Text, out int waitTimeSeconds);
            if (pass)
            {
                int waitTimeMili = waitTimeSeconds * 1000;
                await Task.Delay(waitTimeMili);
                MouseOperations mouseOperations = new MouseOperations();
                MouseOperations.MousePoint mousePoint = MouseOperations.GetCursorPosition();
                tbLauncherX.Text = mousePoint.X.ToString();
                tbLauncherY.Text = mousePoint.Y.ToString();
                //Console.WriteLine(mousePoint.X + " " + mousePoint.Y);
            }
            else
            {
                MessageBox.Show("Mouse Pointer Delay Time Invalid.", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SendPassword()
        {
            SendKeys.Send(this.tbPassword.Text);
            Keyboard k = new Keyboard();
            k.Send(Keyboard.ScanCodeShort.RETURN);
            //SendKeys.Send("{ENTER}"); //blocked?
        }
        private void ClickStart()
        {
            bool xPass = int.TryParse(tbLauncherX.Text, out int x);
            bool yPass = int.TryParse(tbLauncherY.Text, out int y);
            if (xPass & yPass)
            {
                MouseOperations.SetCursorPosition(x, y);
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            }
            else
            {
                MessageBox.Show("Launcher Start Location invalid.","Invalid Mouse Location", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private TimeSpan GetLoginTime()
        {
            TimeSpan time = new TimeSpan();
            bool hourPass = int.TryParse(tbLoginTimeHours.Text, out int hours);
            bool minutePass = int.TryParse(tbLoginTimeMinutes.Text, out int minutes);
            bool secondPass = int.TryParse(tbLoginTimeSeconds.Text, out int seconds);
            if (hourPass & minutePass & secondPass)
            {
                time = new TimeSpan(hours, minutes, seconds);
            }

            return time;
        }
        private TimeSpan GetLoginCheckDuration()
        {
            TimeSpan time = new TimeSpan();
            bool hourPass = int.TryParse(tbLoginCheckHours.Text, out int hours);
            bool minutePass = int.TryParse(tbLoginCheckMinutes.Text, out int minutes);
            bool secondPass = int.TryParse(tbLoginCheckSeconds.Text, out int seconds);
            if (hourPass & minutePass & secondPass)
            {
                time = new TimeSpan(hours, minutes, seconds);
            }

            return time;
        }
        private void KillGame()
        {
            Process game = Process.GetProcessesByName("Warframe.x64").FirstOrDefault();
            if (game != null)
            {
                game.Kill();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.state = State.STOPPING;
            SetStateLabel();
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["LoginTimeSeconds"].Value = tbLoginTimeSeconds.Text;
            config.AppSettings.Settings["GamePath"].Value = tbGamePath.Text;
            config.AppSettings.Settings["LauncherX"].Value = tbLauncherX.Text;
            config.AppSettings.Settings["LauncherY"].Value = tbLauncherY.Text;
            config.AppSettings.Settings["GetMouseDelay"].Value = tbGetMouseDelay.Text;
            config.AppSettings.Settings["LauncherLoadTime"].Value = tbLauncherLoadTime.Text;
            config.AppSettings.Settings["GameLoadTime"].Value = tbGameLoadTime.Text;
            config.AppSettings.Settings["ExitWaitTime"].Value = tbExitWaitTime.Text;
            config.AppSettings.Settings["LoginTimeHours"].Value = tbLoginTimeHours.Text;
            config.AppSettings.Settings["LoginTimeMinutes"].Value = tbLoginTimeMinutes.Text;
            config.AppSettings.Settings["LoginTimeSeconds"].Value = tbLoginTimeSeconds.Text;
            config.AppSettings.Settings["LoginCheckHours"].Value = tbLoginCheckHours.Text;
            config.AppSettings.Settings["LoginCheckMinutes"].Value = tbLoginCheckMinutes.Text;
            config.AppSettings.Settings["LoginCheckSeconds"].Value = tbLoginCheckSeconds.Text;

            config.Save(ConfigurationSaveMode.Modified);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            PnlNav.Height = btnDashboard.Height;
            PnlNav.Top = btnDashboard.Top;
            PnlNav.Left = btnDashboard.Left;
            customTabControl1.SelectedTab = tabDashboard;
            btnDashboard.BackColor = DARKGREY;
            btnHistory.BackColor = LIGHTGREY;
            btnSettings.BackColor = LIGHTGREY;
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            PnlNav.Height = btnHistory.Height;
            PnlNav.Top = btnHistory.Top;
            PnlNav.Left = btnHistory.Left;
            customTabControl1.SelectedTab = tabHistory;
            btnDashboard.BackColor = LIGHTGREY;
            btnHistory.BackColor = DARKGREY;
            btnSettings.BackColor = LIGHTGREY;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            PnlNav.Height = btnSettings.Height;
            PnlNav.Top = btnSettings.Top;
            PnlNav.Left = btnSettings.Left;
            customTabControl1.SelectedTab = tabSettings;
            btnHistory.BackColor = LIGHTGREY;
            btnDashboard.BackColor = LIGHTGREY;
            btnSettings.BackColor = DARKGREY;
        }
        private void btnDashboard_Leave(object sender, EventArgs e)
        {
            btnDashboard.BackColor = LIGHTGREY;
        }

        private void btnHistory_Leave(object sender, EventArgs e)
        {
            btnHistory.BackColor = LIGHTGREY;
        }

        private void btnBrowseGamePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    this.tbGamePath.Text = openFileDialog.FileName;
                }
            }
        }
        private void UpdateScheduledLoginLabel()
        {
            TimeSpan loginTime = GetLoginTime();
            labelScheduledLoginTime.Text = "Scheduled login time: " + loginTime.ToString();
        }
    }
}

