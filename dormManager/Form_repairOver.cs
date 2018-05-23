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
    public partial class Form_repairOver : Form
    {
        public Form_repairOver()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string rid = textBox2.Text;
            string pay = textBox3.Text;

            string constr = "server=localhost;User Id=root;password=20153178;Database=dormmanager";
            MySqlConnection mycon = new MySqlConnection(constr);
            mycon.Open();
            string sql = string.Format("update repair set paied={0}, ifpaied='是', state='已完成', sta=1 where rid={1}", pay, rid);
            MySqlCommand mycmd = new MySqlCommand(sql, mycon);
            if (mycmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("验收成功！");
            }
            else
            {
                MessageBox.Show("验收失败！");
            }
            mycon.Close();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string did = textBox1.Text;
            string P_Str_ConnectionStr = string.Format("server={0};user id = {1};port = {2};database=dormmanager;pooling = false;password = {3}", "localhost", "root", 3306, "20153178");
            string sql = "select did as '宿舍号', rid as '单号', needpay as '应缴纳', ";
            sql += "content as '报修内容', sdate as '报修日期',";
            sql += "state as '进度' ";
            sql += "from repair where did='";
            sql += did.ToString() + "'";
            string P_Str_SqlStr = string.Format(sql);
            MySqlDataAdapter adapter = new MySqlDataAdapter(P_Str_SqlStr, P_Str_ConnectionStr);
            DataTable P_dt = new DataTable();
            adapter.Fill(P_dt);
            this.dataGridView1.DataSource = P_dt;
        }
    }
}
