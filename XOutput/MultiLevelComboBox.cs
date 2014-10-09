using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace XOutput
{
    public class MLCBEventArgs : EventArgs
    {
        private ToolStripMenuItem menu;
        public MLCBEventArgs(ToolStripMenuItem _myData)
        {
            menu = _myData;
        }
        public ToolStripMenuItem Selection { get { return menu; } }
    }

    class MultiLevelComboBox : ComboBox
    {
        ContextMenuStrip menu;

        public new event EventHandler DropDown;
        public new event EventHandler DropDownClosed;
        public new event EventHandler ItemClicked;
        public new event EventHandler SelectionChangeCommitted;

        private bool m_bDroppedDown;

        public MultiLevelComboBox()
            : base()
        {
            base.DropDownStyle = ComboBoxStyle.DropDownList;
            menu = new ContextMenuStrip();
            base.Items.Add("");
            base.SelectedItem = "";
        }

        public bool addMenu(string name)
        {
            ToolStripMenuItem p = new ToolStripMenuItem();
            p.Text = name;
            p.Click += (sender, e) => { m_bDroppedDown = false; };
            menu.Items.Add(p);
            return true;
        }

        public bool addMenu(string category, string name)
        {
            foreach (ToolStripMenuItem m in menu.Items)
            {
                if (m.Text == category)
                {
                    ToolStripMenuItem p = new ToolStripMenuItem();
                    p.Text = name;
                    p.Click += (sender, e) => { m_bDroppedDown = false; };
                    m.DropDownItems.Add(p);
                    return true;
                }
            }
            return false;
        }

        public bool addOption(string category, string name, object tag)
        {
            foreach (ToolStripMenuItem m in menu.Items)
            {
                if (m.Text == category)
                {
                    ToolStripMenuItem p = new ToolStripMenuItem();
                    p.Text = name;
                    p.Tag = tag;
                    p.Click += (sender, e) => selectValue(p);
                    m.DropDownItems.Add(p);
                    return true;
                }
            }
            return false;
        }

        public bool addOption(string category, string category2, string name, object tag)
        {
            foreach (ToolStripMenuItem m in menu.Items)
            {
                if (m.Text == category)
                {
                    foreach (ToolStripMenuItem g in m.DropDownItems)
                    {
                        if (g.Text == category2)
                        {
                            ToolStripMenuItem p = new ToolStripMenuItem();
                            p.Text = name;
                            p.Click += (sender, e) => selectValue(p);
                            p.Tag = tag;
                            g.DropDownItems.Add(p);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        protected void selectValue(ToolStripMenuItem m)
        {
            base.Items[0] = m.Text;
            m_bDroppedDown = false;
            EventHandler eventHandler = this.ItemClicked;
            if (eventHandler != null)
                this.ItemClicked(this, EventArgs.Empty);

            EventHandler eventHandler1 = this.SelectionChangeCommitted;
            if (eventHandler1 != null)
                this.SelectionChangeCommitted(this, new MLCBEventArgs(m));
        }

        public void showDropDown()
        {
            menu.Show(this, new Point(0, this.Height));
            menu.AutoSize = false;
            menu.Width = this.Width;
            m_bDroppedDown = true;
            EventHandler eventHandler = this.DropDown;
            if (eventHandler != null)
                this.DropDown(this, EventArgs.Empty);

        }

        public void hideDropDown()
        {
            menu.Hide();
            m_bDroppedDown = false;
            EventHandler eventHandler = this.DropDownClosed;
            if (eventHandler != null)
                this.DropDownClosed(this, EventArgs.Empty);
        }

        public void autoDropDown()
        {
            if (this.IsDroppedDown)
            {
                hideDropDown();
            }
            else
            {
                showDropDown();
            }
        }


        public override bool PreProcessMessage(ref Message msg)
        {
            int WM_SYSKEYDOWN = 0x104;

            bool handled = false;

            if (msg.Msg == WM_SYSKEYDOWN)
            {
                Keys keyCode = (Keys)msg.WParam & Keys.KeyCode;

                switch (keyCode)
                {
                    case Keys.Down:
                        handled = true;
                        break;
                }
            }


            if (false == handled)
                handled = base.PreProcessMessage(ref msg);

            return handled;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 135:
                    autoDropDown();
                    break;

                case 0x201:
                case 0x203:
                    autoDropDown();
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }


        /// <summary>
        /// Indicates if drop-down is currently shown.
        /// </summary>
        [Browsable(false)]
        public bool IsDroppedDown
        {
            get { return this.m_bDroppedDown; }
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
