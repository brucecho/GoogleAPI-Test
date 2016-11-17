using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Google_API_TEST
{
    public class MyTabPage :TabPage
    {
        private Form frm;
        public MyTabPage(MyFormPage frm_contentido)
        {
            this.frm = frm_contentido;
            this.Controls.Add(frm_contentido.pnl);
            this.Text = frm_contentido.Text;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                frm.Dispose();
            }
            base.Dispose(disposing);
            
        }
    }

    public class MyFormPage : Form
    {
        public Panel pnl;
    }
}
