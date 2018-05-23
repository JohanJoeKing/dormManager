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
    public partial class Form_alterDorm_student : Form
    {
        public Form_alterDorm_student()
        {
            InitializeComponent();
            textBox1.Enabled = false;
            textBox3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string did = textBox1.Text.ToString();
            string sid = textBox2.Text.ToString();
            string bednum = textBox3.Text.ToString();
            string constr = "server=localhost;User Id=root;password=20153178;Database=dormmanager";
            MySqlConnection mycon = new MySqlConnection(constr);
            mycon.Open();
            MySqlCommand mycmd = new MySqlCommand("update dorm_student set bednum=" + bednum + ", did='" + did + "' where sid ='" + sid + "'", mycon);
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox3.Enabled = true;
        }
    }
}
