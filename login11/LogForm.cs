using login11.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login11
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                var attempts = context.LoginAttempts.ToList();

                dataGridView1.DataSource = attempts;
            }
        }
    }
}
