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
            int ind = 0;

            foreach (MultiLevelComboBox m in this.Controls.OfType<MultiLevelComboBox>()) {
                //Tag structure: [Type, Number, Index]
                m.Items[0] = getBindingText(ind); //Change combobox text according to saved binding
                m.addOption("None",
                    tag: new byte[] { 255, 0, (byte)ind });
                m.addOption("Detect",
                    tag: new byte[] { 254, 0, (byte)ind });
                ToolStripMenuItem axes = m.addMenu("Axes");
                ToolStripMenuItem buttons = m.addMenu("Buttons");
                ToolStripMenuItem dpads = m.addMenu("D-Pads");
                ToolStripMenuItem iaxes = m.addMenu("Inverted Axes", axes);
                ToolStripMenuItem haxes = m.addMenu("Half Axes", axes);
                ToolStripMenuItem ihaxes = m.addMenu("Inverted Half Axes", axes);
                for (int i = 1; i <= dev.joystick.Capabilities.ButtonCount; i++)
                {
                    m.addOption("Button " + i.ToString(), buttons,
                        new byte[] { 0, (byte)(i - 1), (byte)ind });
                }
                for (int i = 1; i <= dev.joystick.Capabilities.PovCount; i++)
                {
                    m.addOption("D-Pad " + i.ToString() + " Up", dpads,
                        new byte[] { 32, (byte)(i - 1), (byte)ind });
                    m.addOption("D-Pad " + i.ToString() + " Down", dpads,
                        new byte[] { 33, (byte)(i - 1), (byte)ind });
                    m.addOption("D-Pad " + i.ToString() + " Left", dpads,
                        new byte[] { 34, (byte)(i - 1), (byte)ind });
                    m.addOption("D-Pad " + i.ToString() + " Right", dpads,
                        new byte[] { 35, (byte)(i - 1), (byte)ind });
                }
                for (int i = 1; i <= dev.joystick.Capabilities.AxesCount; i++)
                {
                    m.addOption("Axis " + i.ToString(), axes,
                        new byte[] { 16, (byte)(i - 1), (byte)ind });
                    m.addOption("IAxis " + i.ToString(), iaxes,
                        new byte[] { 17, (byte)(i - 1), (byte)ind });
                    m.addOption("HAxis" + i.ToString(), haxes,
                        new byte[] { 18, (byte)(i - 1), (byte)ind });
                    m.addOption("IHAxis" + i.ToString(), ihaxes,
                        new byte[] { 19, (byte)(i - 1), (byte)ind });
                }
                m.SelectionChangeCommitted += new System.EventHandler(SelectionChanged);
                ind++;
            }
        }

        private string getBindingText(int i)
        {
            if (dev.mapping[i * 2] == 255) {
                return "None";
            }
            byte subtype = (byte)(dev.mapping[i * 2] & 0x0F);
            byte type = (byte)((dev.mapping[i * 2] & 0xF0) >> 4);
            byte num = (byte)(dev.mapping[(i * 2) + 1] + 1);
            string s = "";

            switch (type) {
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

        private void SelectionChanged(object sender, EventArgs e) {
            ToolStripMenuItem i = (ToolStripMenuItem)sender;
            byte[] b = (byte[])i.Tag;
            if (b[0] == 254) {
                
            }
            dev.mapping[b[2] * 2] = b[0];
            dev.mapping[(b[2] * 2) + 1] = b[1];
            dev.Save();
        }

        private void onClose(object sender, EventArgs e) {
            dev.Save();
        }

    }
}
