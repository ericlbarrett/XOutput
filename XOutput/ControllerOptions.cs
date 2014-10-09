using System;
using System.Linq;
using System.Windows.Forms;

namespace XOutput
{
    public partial class ControllerOptions : Form
    {
        ControllerDevice dev;


        public ControllerOptions(ControllerDevice device)
        {
            InitializeComponent();
            dev = device;
            int buttons = dev.joystick.Capabilities.ButtonCount;
            int dpads = dev.joystick.Capabilities.PovCount;
            int ind = 0;

            foreach (MultiLevelComboBox m in this.Controls.OfType<MultiLevelComboBox>())
            {
                m.Items[0] = getBindingText(ind);

                m.addMenu("Axes");
                m.addMenu("Buttons");
                m.addMenu("D-Pads");
                m.addMenu("Axes", "Inverted Axes");
                m.addMenu("Axes", "Half Axes");
                m.addMenu("Axes", "Inverted Half Axes");
                for (int i = 1; i <= buttons; i++)
                {
                    m.addOption("Buttons", "Button " + i.ToString(), new byte[] { 0, (byte)(i - 1), (byte)ind });
                }
                for (int i = 1; i <= dpads; i++)
                {
                    m.addOption("D-Pads", "D-Pad " + i.ToString() + " Up", new byte[] { 32, (byte)(i - 1), (byte)ind });
                    m.addOption("D-Pads", "D-Pad " + i.ToString() + " Down", new byte[] { 33, (byte)(i - 1), (byte)ind });
                    m.addOption("D-Pads", "D-Pad " + i.ToString() + " Left", new byte[] { 34, (byte)(i - 1), (byte)ind });
                    m.addOption("D-Pads", "D-Pad " + i.ToString() + " Right", new byte[] { 35, (byte)(i - 1), (byte)ind });
                }
                for (int i = 1; i <= 24; i++)
                {
                    m.addOption("Axes", "Axis " + i.ToString(), new byte[] { 16, (byte)(i - 1), (byte)ind });
                    m.addOption("Axes", "Inverted Axes", "IAxis " + i.ToString(), new byte[] { 17, (byte)(i - 1), (byte)ind });
                    m.addOption("Axes", "Half Axes", "HAxis" + i.ToString(), new byte[] { 18, (byte)(i - 1), (byte)ind });
                    m.addOption("Axes", "Inverted Half Axes", "IHAxis" + i.ToString(), new byte[] { 19, (byte)(i - 1), (byte)ind });
                }
                m.SelectionChangeCommitted += new System.EventHandler(SelectionChanged);
                ind++;
            }
        }

        private string getBindingText(int i)
        {
            byte subtype = (byte)(dev.mapping[i * 2] & 0x0F);
            byte type = (byte)((dev.mapping[i * 2] & 0xF0) >> 4);
            byte num = (byte)(dev.mapping[(i * 2) + 1] + 1);
            string s = "";

            switch (type)
            {
                case 0:
                    return "Button " + num.ToString();
                case 1:
                    s = "Axis " + num.ToString();
                    switch (subtype)
                    {
                        case 1:
                            return "I" + s;
                        case 2:
                            return "H" + s;
                        case 3:
                            return "IH" + s;
                    }
                    break;
                case 2:
                    s = "D-Pad " + num.ToString();
                    switch (subtype)
                    {
                        case 0:
                            return s + " Up";
                        case 1:
                            return s + " Down";
                        case 2:
                            return s + " Left";
                        case 3:
                            return s + " Right";
                    }
                    break;
            }
            return s;
        }

        private void SelectionChanged(object sender, EventArgs e)
        {
            MLCBEventArgs evt = (MLCBEventArgs)e;
            ToolStripMenuItem i = evt.Selection;
            byte[] b = (byte[])i.Tag;
            dev.mapping[b[2] * 2] = b[0];
            dev.mapping[(b[2] * 2) + 1] = b[1];
            dev.Save();
        }

        private void onClose(object sender, EventArgs e)
        {
            dev.Save();
        }





    }
}
