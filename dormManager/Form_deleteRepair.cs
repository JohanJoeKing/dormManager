using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Configuration;

namespace dormManager
{
    public partial class Form_deleteRepair : Form
    {
        public Form_deleteRepair()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rid = textBox2.Text.ToString();
            string constr = "server=localhost;User Id=root;password=20153178;Database=dormmanager";
            MySqlConnection mycon = new MySqlConnection(constr);
            mycon.Open();
            MySqlCommand mycmd = new MySqlCommand("delete from repair where rid = '" + rid + "'", mycon);
            if (mycmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("数据删除成功！");
            }
            else
            {
                MessageBox.Show("数据删除失败！");
            }
            mycon.Close();
            this.Close();
        }
    }
}
