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

namespace WarframeDailyLogin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.tbGamePath.Text = @"C:\Program Files (x86)\Steam\steamapps\common\Warframe\Tools\Launcher.exe";
            this.tbPassword.Text = "";
            tbLauncherX.Text = "1526";
            tbLauncherY.Text = "970";
            tbDelay.Text = "2";
            tbLauncherLoadTime.Text = "5";
            tbGameLoadTime.Text = "30";
            tbExitWaitTime.Text = "30";
            tbLoginTimeHours.Text = "04";
            tbLoginTimeMinutes.Text = "00";
            tbLoginTimeSeconds.Text = "00";
        }

        async private void btnRun_Click(object sender, EventArgs e)
        {
            Process warframe = new Process();
            warframe.StartInfo.FileName = this.tbGamePath.Text;
            warframe.EnableRaisingEvents = true;
            warframe.Start();
            int launcherDelaySeconds;
            int GameDelaySeconds;
            int ExitDelaySeconds;
            bool launcherPass = int.TryParse(tbLauncherLoadTime.Text, out launcherDelaySeconds);
            bool gamePass = int.TryParse(tbGameLoadTime.Text, out GameDelaySeconds);
            bool exitPass = int.TryParse(tbExitWaitTime.Text, out ExitDelaySeconds);
            if (!(launcherPass & gamePass & exitPass))
            {
                MessageBox.Show("One or more wait times are invalid.", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int launcherDelayMili = launcherDelaySeconds * 1000;
            int GameDelayMili = GameDelaySeconds * 1000;
            int ExitDelayMili = ExitDelaySeconds * 1000;
            await Task.Delay(launcherDelayMili);
            ClickStart();
            await Task.Delay(GameDelayMili);
            Login();
            await Task.Delay(ExitDelayMili);
            warframe.Close();
        }

        async private void btnGetMousePoint_Click(object sender, EventArgs e)
        {
            int waitTimeSeconds;
            bool pass = int.TryParse(tbDelay.Text, out waitTimeSeconds);
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

        private void Login()
        {
            SendKeys.Send(this.tbPassword.Text);
            SendKeys.Send("{ENTER}");
            //MouseOperations.SetCursorPosition(1526, 970);
            //MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            //MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
        }
        private void ClickStart()
        {
            int x;
            int y;
            bool xPass = int.TryParse(tbLauncherX.Text, out x);
            bool yPass = int.TryParse(tbLauncherY.Text, out y);
            if (xPass & yPass)
            {
                MouseOperations.SetCursorPosition(1526, 970);
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
    }
}
