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
    public partial class Form_deleteStudent : Form
    {
        public Form_deleteStudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sid = textBox1.Text.ToString();
            string constr = "server=localhost;User Id=root;password=20153178;Database=dormmanager";
            MySqlConnection mycon = new MySqlConnection(constr);
            mycon.Open();
            MySqlConnection mycon1 = new MySqlConnection(constr);
            mycon1.Open();
            MySqlCommand mycmd = new MySqlCommand("delete  from dorm_student where sid = '" + sid + "'", mycon);
            if (mycmd.ExecuteNonQuery() > 0)
            {
                MySqlCommand mycmd1 = new MySqlCommand("delete from student where sid = '" + sid + "'", mycon1);
                if (mycmd1.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("学生信息删除成功！");
                }
                else
                {
                    MessageBox.Show("不存在该学生！");
                }
            }
            else
            {
                MessageBox.Show("不存在该学生！");
            }
            mycon.Close();
            mycon1.Close();
            this.Close();
        }
    }
}
