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
using System.IO;

namespace btd
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.Powercfg((int)numericUpDown1.Value);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Process ps = new Process();
            StreamReader sr;
            string str;
            ps.StartInfo.FileName = "cmd";
            ps.StartInfo.Arguments = @"/c powercfg /query SCHEME_CURRENT SUB_PROCESSOR PROCTHROTTLEMAX";
            ps.StartInfo.RedirectStandardOutput = true;
            ps.StartInfo.CreateNoWindow = true;
            ps.StartInfo.UseShellExecute = false; // シェル機能を使用しない
            ps.Start();    // コマンド実行
            ps.WaitForExit();
            sr = ps.StandardOutput;
            ps.Close();

            while (sr.Peek() > -1) //結果を１行ずつ最後までread
            {
                str = sr.ReadLine();
                if (str.IndexOf(" AC ") > 0)
                {
                    int ac = Convert.ToInt32(str.Substring(str.IndexOf("0x") + 2), 16);
                    label2.Text = "AC=" + ac.ToString() + "%\n";
                }
                if (str.IndexOf(" DC ") > 0)
                {
                    int dc = Convert.ToInt32(str.Substring(str.IndexOf("0x") + 2), 16);
                    label2.Text += "DC=" + dc.ToString() + "%";
                    numericUpDown1.Value = dc;
                }
            }
        }
    }
}
