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
    public partial class Form_alterStudent : Form
    {
        public Form_alterStudent()
        {
            InitializeComponent();
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sid = textBox1.Text.ToString();
            string name = textBox2.Text.ToString();
            string class1 = textBox3.Text.ToString();
            string age = textBox4.Text.ToString();
            string school = textBox5.Text.ToString();
            string major = textBox6.Text.ToString();
            string phone = textBox7.Text.ToString();
            string constr = "server=localhost;User Id=root;password=20153178;Database=dormmanager";
            MySqlConnection mycon = new MySqlConnection(constr);
            mycon.Open();
            MySqlCommand mycmd = new MySqlCommand("update student set class='" + class1 + "', age ='" + age + "', phone ='" + phone + "' , major ='" + major + "', school ='" + school + "', name = '" + name + "' where sid = '" + sid + "'", mycon);
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
