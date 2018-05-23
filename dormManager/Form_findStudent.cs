using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace dormManager
{
    public partial class Form_findStudent : Form
    {
        public Form_findStudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            if (radioButton1.Checked == true)
            {
                findByName(str);
            }
            else if (radioButton2.Checked == true)
            {
                findById(str);
            }
        }

        // 按姓名
        private void findByName(string name)
        {
            string P_Str_ConnectionStr = string.Format("server={0};user id = {1};port = {2};database=dormmanager;pooling = false;password = {3}", "localhost", "root", 3306, "20153178");
            string sql = "select did as '宿舍号', bednum as '床铺号', name as '姓名', s.sid as '学号', class as '班级', major as '专业', school as '学院', phone as '手机', age as '年龄' from student s join dorm_student ds on s.sid=ds.sid where name='";
            sql += name + "'";
            string P_Str_SqlStr = string.Format(sql);
            MySqlDataAdapter adapter = new MySqlDataAdapter(P_Str_SqlStr, P_Str_ConnectionStr);
            DataTable P_dt = new DataTable();
            adapter.Fill(P_dt);
            this.dataGridView1.DataSource = P_dt;
        }

        // 按学号
        private void findById(string id)
        {
            string P_Str_ConnectionStr = string.Format("server={0};user id = {1};port = {2};database=dormmanager;pooling = false;password = {3}", "localhost", "root", 3306, "20153178");
            string sql = "select did as '宿舍号', bednum as '床铺号', name as '姓名', s.sid as '学号', class as '班级', major as '专业', school as '学院', phone as '手机', age as '年龄' from student s join dorm_student ds on s.sid=ds.sid where s.sid='";
            sql += id + "'";
            string P_Str_SqlStr = string.Format(sql);
            MySqlDataAdapter adapter = new MySqlDataAdapter(P_Str_SqlStr, P_Str_ConnectionStr);
            DataTable P_dt = new DataTable();
            adapter.Fill(P_dt);
            this.dataGridView1.DataSource = P_dt;
        }
    }
}
