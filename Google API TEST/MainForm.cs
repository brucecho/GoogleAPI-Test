using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Google_API_TEST
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(this.listView1.SelectedItems[0].Text);
            if (this.listView1.SelectedItems.Count > 0)
            {
                String strSelectItem = this.listView1.SelectedItems[0].Text;
                if (strSelectItem.Equals("OAuth2.0 Test"))
                {
                    this.tabControl1.TabPages.Add(new MyTabPage(new OAuth2Test()));
                }
                else if (strSelectItem.Equals("YoutubeAPITest"))
                {
                    this.tabControl1.TabPages.Add(new MyTabPage(new YoutubeAPITest()));
                }
                else if (strSelectItem.Equals("YoutubeAnalyticsTest"))
                {
                    this.tabControl1.TabPages.Add(new MyTabPage(new YoutubeAnalyticsTest()));
                }
            }
        }
    }
}
