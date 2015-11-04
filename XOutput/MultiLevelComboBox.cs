using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace XOutput
{
    class MultiLevelComboBox : ComboBox {
        ContextMenuStrip menu;

        public new event EventHandler DropDown;
        public new event EventHandler DropDownClosed;
        public new event EventHandler SelectionChangeCommitted;

        private bool _DroppedDown;

        public MultiLevelComboBox()
            : base()
        {
            base.DropDownStyle = ComboBoxStyle.DropDownList;
            menu = new ContextMenuStrip();
            base.Items.Add("");
            base.SelectedItem = "";
        }

        public ToolStripMenuItem addMenu(string name, ToolStripMenuItem parent = null) {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Text = name;
            if (parent != null) {
                parent.DropDownItems.Add(item);
            } else {
                menu.Items.Add(item);
            }
            return item;
        }

        public ToolStripMenuItem addOption(string name, ToolStripMenuItem parent = null, object tag = null) {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Text = name;
            item.Tag = tag;
            item.Click += (sender, e) => selectValue(item);
            if (parent != null)
            {
                parent.DropDownItems.Add(item);
            }
            else
            {
                menu.Items.Add(item);
            }
            return parent;
        }

        private void selectValue(ToolStripMenuItem m) {
            Items[0] = m.Text;
            DroppedDown = false;
            if (SelectionChangeCommitted != null)
                SelectionChangeCommitted(m, EventArgs.Empty);
        }

        private void showDropDown() {
            menu.Show(this, new Point(0, Height));
            menu.AutoSize = false;
            menu.Width = Width;
            if (DropDown != null)
                DropDown(this, EventArgs.Empty);
        }

        private void hideDropDown() {
            menu.Hide();
            if (DropDownClosed != null)
                DropDownClosed(this, EventArgs.Empty);
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x87: //WM_GETDLGCODE
                    break;//Block key down messages
                case 0x201: //WM_LBUTTONDOWN
                    DroppedDown = !DroppedDown;
                    break;
                case 0x203: //WM_LBUTTONDBLCLK
                    DroppedDown = !DroppedDown;
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        public new bool DroppedDown {
            get { return _DroppedDown;  }
            set { _DroppedDown = value;
                if (value) { showDropDown(); } else { hideDropDown(); }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false), ReadOnly(true)]
        public new ComboBoxStyle DropDownStyle
        {
            get { return base.DropDownStyle; }
            set { }
        }

    }
}
