using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTMLScreenSaver
{
    public partial class frmIdentify : Form
    {
        public frmIdentify(Rectangle Bounds, string displayName)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Bounds.X, Bounds.Y);

            lblDispaly.Text = displayName;
        }

        private void frmIdentify_Load(object sender, EventArgs e)
        {
            this.tmrTTL.Enabled = true;
            this.tmrTTL.Tick += tmrTTL_Tick;
        }

        private void tmrTTL_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}