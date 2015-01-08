using SlimDX.DirectInput;
using System;
using System.Windows.Forms;

namespace XOutput
{
    public partial class XOut : Form
    {

        public XOut()
        {
            InitializeComponent();
            this.moveOneDown.Click += (sender, e) => Swap(1, 2);
            this.moveTwoUp.Click += (sender, e) => Swap(2, 1);
            this.moveTwoDown.Click += (sender, e) => Swap(2, 3);
            this.moveThreeUp.Click += (sender, e) => Swap(3, 2);
            this.moveThreeDown.Click += (sender, e) => Swap(3, 4);
            this.moveFourUp.Click += (sender, e) => Swap(4, 3);
            this.enabledOne.CheckedChanged += (sender, e) => enabledChanged(0);
            this.enabledTwo.CheckedChanged += (sender, e) => enabledChanged(1);
            this.enabledThree.CheckedChanged += (sender, e) => enabledChanged(2);
            this.enabledFour.CheckedChanged += (sender, e) => enabledChanged(3);
            this.optionsOne.Click += (sender, e) => openOptions(0);
            this.optionsTwo.Click += (sender, e) => openOptions(1);
            this.optionsThree.Click += (sender, e) => openOptions(2);
            this.optionsFour.Click += (sender, e) => openOptions(3);

            boxes = new System.Windows.Forms.GroupBox[4] { controllerBoxOne, controllerBoxTwo, controllerBoxThree, controllerBoxFour };
            checks = new System.Windows.Forms.CheckBox[4] { enabledOne, enabledTwo, enabledThree, enabledFour };
            options = new System.Windows.Forms.Button[4] { optionsOne, optionsTwo, optionsThree, optionsFour };
        }

        private void XOut_Load(object sender, EventArgs e)
        {
            controllerManager = new ControllerManager(this);
        }

        private void XOut_Shown(object sender, EventArgs e)
        {
            UpdateInfo(controllerManager.detectControllers());
        }

        private void XOut_Closing(object sender, FormClosingEventArgs e)
        {
            if (controllerManager.IsActive)
            {
                controllerManager.Stop();
            }
        }

        private void StartStopBtn_Click(object sender, EventArgs e)
        {
            if (StartStopBtn.Text == "Start")
            {
                if (optionsWindow != null)
                {
                    System.Media.SystemSounds.Asterisk.Play();
                    optionsWindow.Focus();
                    return;
                }
                if (controllerManager.Start())
                {
                    StartStopBtn.Text = "Stop";
                    for (int i = 0; i < 4; i++)
                    {
                        checks[i].Enabled = false;
                        isExclusive.Enabled = false;
                        foreach (Control con in boxes[i].Controls)
                        {
                            con.Enabled = false;
                        }
                    }
                }
            }
            else
            {
                if (controllerManager.Stop())
                {
                    StartStopBtn.Text = "Start";
                    for (int i = 0; i < 4; i++)
                    {
                        checks[i].Enabled = true;
                        isExclusive.Enabled = true;
                        foreach (Control con in boxes[i].Controls)
                        {
                            con.Enabled = true;
                        }
                    }
                }
            }
        }

        private void UpdateInfo(ControllerDevice[] dev)
        {
            for (int i = 0; i < 4; i++)
            {
                if (dev[i] != null)
                {
                    boxes[i].Visible = true;
                    boxes[i].Text = (i + 1).ToString() + ": " + dev[i].name;
                    checks[i].Visible = true;
                }
                else
                {
                    boxes[i].Visible = false;
                    checks[i].Visible = false;
                }
            }
        }

        private void Swap(int i, int p)
        {
            bool s = checks[i - 1].Checked;
            checks[i- 1].Checked = checks[p - 1].Checked;
            checks[p - 1].Checked = s;
            controllerManager.Swap(i, p);
            
            UpdateInfo(controllerManager.detectControllers());
        }



        private void enabledChanged(int i)
        {
            boxes[i].Enabled = checks[i].Checked;
            controllerManager.setControllerEnable(i, checks[i].Checked);
        }

        private void openOptions(int i)
        {
            if (optionsWindow == null)
            {
                optionsWindow = new ControllerOptions(controllerManager.getController(i));
                optionsWindow.Show();
                optionsWindow.Activate();
                optionsWindow.FormClosed += (sender, e) => { optionsWindow = null; };
            }
            else
            {
                System.Media.SystemSounds.Asterisk.Play();
                optionsWindow.Focus();
            }
        }

        protected override void WndProc(ref Message m)
        {
            try
            {
                if (m.Msg == 0x0219)
                {
                    lock (this)
                    {
                        UpdateInfo(controllerManager.detectControllers());
                    }
                }
            }
            catch { }

            base.WndProc(ref m);
        }

        private void isExclusive_CheckedChanged(object sender, EventArgs e)
        {
            controllerManager.changeExclusive(!controllerManager.isExclusive);
        }


    }
}
