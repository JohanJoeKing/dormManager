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
    public partial class Form_alterDorm : Form
    {
        public Form_alterDorm()
        {
            InitializeComponent();
            textBox2.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string did = textBox1.Text;
            string amount = textBox2.Text;
            string constr = "server=localhost;User Id=root;password=20153178;Database=dormmanager";
            MySqlConnection mycon = new MySqlConnection(constr);
            mycon.Open();
            MySqlCommand mycmd = new MySqlCommand("update dorm set amount=" + amount + " where did = " + did, mycon);
            if (mycmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("数据修改成功！");
            }
            else
            {
                MessageBox.Show("数据修改失败！");
            }
            mycon.Close();
            this.Close();
        }
    }
}
