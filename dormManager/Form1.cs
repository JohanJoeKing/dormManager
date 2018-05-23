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
    public partial class Form1 : Form
    {
        private Form_login login;

        public Form1()
        {
            Form_login login = new Form_login();
            login.Show();
            login.getMain(this);

            InitializeComponent();
            //init();
        }

        // 初始化
        public void init()
        {
            GetMessage();
            int i = 0;
            for(i = 1;i <= 80;i++)
            {
                comboBox1.Items.Add(i + 100);
            }
        }

        private DataTable GetMessage()
        {
            string P_Str_ConnectionStr = string.Format("server={0};user id = {1};port = {2};database=dormmanager;pooling = false;password = {3}", "localhost", "root", 3306, "20153178");
            string sql = "select did as '宿舍号', rid as '维修编号',";
            sql += "content as '报修内容', sdate as '报修日期',";
            sql += "needpay as '需缴纳', paied as '已缴纳',";
            sql += "ifpaied as '是否已缴纳', state as '进度' ";
            sql += "from repair";
            string P_Str_SqlStr = string.Format(sql);
            MySqlDataAdapter adapter = new MySqlDataAdapter(P_Str_SqlStr, P_Str_ConnectionStr);
            DataTable P_dt = new DataTable();
            adapter.Fill(P_dt);
            this.dataGridView1.DataSource = P_dt;
            return P_dt;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void 报修表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string P_Str_ConnectionStr = string.Format("server={0};user id = {1};port = {2};database=dormmanager;pooling = false;password = {3}", "localhost", "root", 3306, "20153178");
            string sql = "select did as '宿舍号', rid as '维修编号',";
            sql += "content as '报修内容', sdate as '报修日期',";
            sql += "needpay as '需缴纳', paied as '已缴纳',";
            sql += "ifpaied as '是否已缴纳', state as '进度' ";
            sql += "from repair";
            string P_Str_SqlStr = string.Format(sql);
            MySqlDataAdapter adapter = new MySqlDataAdapter(P_Str_SqlStr, P_Str_ConnectionStr);
            DataTable P_dt = new DataTable();
            adapter.Fill(P_dt);
            this.dataGridView1.DataSource = P_dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Form_addRepair Far = new Form_addRepair();
            Far.Show();
        }

        private void 添加报修信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_addRepair Far = new Form_addRepair();
            Far.Show();
        }

        private void 关于软件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_aboutus Fau = new Form_aboutus();
            Fau.Show();
        }

        private void 工作人员信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string P_Str_ConnectionStr = string.Format("server={0};user id = {1};port = {2};database=dormmanager;pooling = false;password = {3}", "localhost", "root", 3306, "20153178");
            string P_Str_SqlStr = string.Format("select name as '姓名',id as '工号', position as '职位', phone as '手机' from staff");
            MySqlDataAdapter adapter = new MySqlDataAdapter(P_Str_SqlStr, P_Str_ConnectionStr);
            DataTable P_dt = new DataTable();
            adapter.Fill(P_dt);
            this.dataGridView1.DataSource = P_dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("你确定要关闭吗！", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                e.Cancel = false;  //点击OK   
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            int i = 0;
            for (i = 1; i <= 80; i++)
            {
                comboBox1.Items.Add(i + 100);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            int i = 0;
            for (i = 1; i <= 80; i++)
            {
                comboBox1.Items.Add(i + 200);
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            int i = 0;
            for (i = 1; i <= 80; i++)
            {
                comboBox1.Items.Add(i + 300);
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            int i = 0;
            for (i = 1; i <= 80; i++)
            {
                comboBox1.Items.Add(i + 400);
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            int i = 0;
            for (i = 1; i <= 80; i++)
            {
                comboBox1.Items.Add(i + 500);
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            int i = 0;
            for (i = 1; i <= 80; i++)
            {
                comboBox1.Items.Add(i + 600);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sdid = comboBox1.Text;
            if (sdid != "")
            {
                setStudentInfo(sdid);
                setRepair(sdid);
            }
            else
            {
                return;
            }
        }

        private void setStudentInfo(string did)
        {
            string P_Str_ConnectionStr = string.Format("server={0};user id = {1};port = {2};database=dormmanager;pooling = false;password = {3}", "localhost", "root", 3306, "20153178");
            string P_Str_SqlStr = string.Format("select name as '姓名', class as '班级', phone as '手机' from student ss join dorm_student ds on ss.sid=ds.sid where did={0}", did);
            MySqlDataAdapter adapter = new MySqlDataAdapter(P_Str_SqlStr, P_Str_ConnectionStr);
            DataTable P_dt = new DataTable();
            adapter.Fill(P_dt);
            this.dataGridView2.DataSource = P_dt;
        }

        private void setRepair(string did)
        {
            string P_Str_ConnectionStr = string.Format("server={0};user id = {1};port = {2};database=dormmanager;pooling = false;password = {3}", "localhost", "root", 3306, "20153178");
            string P_Str_SqlStr = string.Format("select content as '报修内容', needpay as '需缴费', paied as '已缴费', state as '进度' from repair where did={0}", did);
            MySqlDataAdapter adapter = new MySqlDataAdapter(P_Str_SqlStr, P_Str_ConnectionStr);
            DataTable P_dt = new DataTable();
            adapter.Fill(P_dt);
            this.dataGridView3.DataSource = P_dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string aimState = "未施工";
            if(radioButton8.Checked == true)
            {
                aimState = "已完成";
            }
            setStateRepair(aimState);
        }

        private void setStateRepair(string aimState)
        {
            string P_Str_ConnectionStr = string.Format("server={0};user id = {1};port = {2};database=dormmanager;pooling = false;password = {3}", "localhost", "root", 3306, "20153178");
            string sql = "select did as '宿舍号',";
            sql += "content as '报修内容', sdate as '报修日期',";
            sql += "state as '进度' ";
            sql += "from repair where state='";
            sql += aimState.ToString() + "'";
            string P_Str_SqlStr = string.Format(sql);
            MySqlDataAdapter adapter = new MySqlDataAdapter(P_Str_SqlStr, P_Str_ConnectionStr);
            DataTable P_dt = new DataTable();
            adapter.Fill(P_dt);
            this.dataGridView4.DataSource = P_dt;
        }

        private void 查看空位ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string P_Str_ConnectionStr = string.Format("server={0};user id = {1};port = {2};database=dormmanager;pooling = false;password = {3}", "localhost", "root", 3306, "20153178");
            string sql = "select did as '宿舍号', flour as '楼层', amount as '床位数', empty as '空床位数' from dorm where empty>0";
            string P_Str_SqlStr = string.Format(sql);
            MySqlDataAdapter adapter = new MySqlDataAdapter(P_Str_SqlStr, P_Str_ConnectionStr);
            DataTable P_dt = new DataTable();
            adapter.Fill(P_dt);
            this.dataGridView1.DataSource = P_dt;
        }

        private void 学生入住情况ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_dorm_student Fds = new Form_dorm_student();
            Fds.Show();
        }

        private void 报修表项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_deleteRepair Fdr = new Form_deleteRepair();
            Fdr.Show();
        }

        private void 学生ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form_deleteStudent Fdst = new Form_deleteStudent();
            Fdst.Show();
        }

        private void 修改报修信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_alterRepair Far = new Form_alterRepair();
            Far.Show();
        }

        private void 学生ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_alterDorm_student Fads = new Form_alterDorm_student();
            Fads.Show();
        }

        private void 修改宿舍信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_alterDorm Fa = new Form_alterDorm();
            Fa.Show();
        }

        private void 学生ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form_alterStudent Fas = new Form_alterStudent();
            Fas.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string P_Str_ConnectionStr = string.Format("server={0};user id = {1};port = {2};database=dormmanager;pooling = false;password = {3}", "localhost", "root", 3306, "20153178");
            string sql = "select did as '宿舍号', rid as '维修编号',";
            sql += "content as '报修内容', sdate as '报修日期',";
            sql += "needpay as '需缴纳', paied as '已缴纳',";
            sql += "ifpaied as '是否已缴纳', state as '进度' ";
            sql += "from repair";
            string P_Str_SqlStr = string.Format(sql);
            MySqlDataAdapter adapter = new MySqlDataAdapter(P_Str_SqlStr, P_Str_ConnectionStr);
            DataTable P_dt = new DataTable();
            adapter.Fill(P_dt);
            this.dataGridView1.DataSource = P_dt;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            string P_Str_ConnectionStr = string.Format("server={0};user id = {1};port = {2};database=dormmanager;pooling = false;password = {3}", "localhost", "root", 3306, "20153178");
            string sql = "select did as '宿舍号', bednum as '床铺号', name as '姓名', s.sid as '学号', class as '班级', major as '专业', school as '学院', phone as '手机', age as '年龄' from student s join dorm_student ds on s.sid=ds.sid";
            string P_Str_SqlStr = string.Format(sql);
            MySqlDataAdapter adapter = new MySqlDataAdapter(P_Str_SqlStr, P_Str_ConnectionStr);
            DataTable P_dt = new DataTable();
            adapter.Fill(P_dt);
            this.dataGridView1.DataSource = P_dt;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Form_repairOver Fro = new Form_repairOver();
            Fro.Show();
        }

        private void 学生ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_addStudent Fas = new Form_addStudent();
            Fas.Show();
        }

        private void 添加入住学生ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_addStudent Fas = new Form_addStudent();
            Fas.Show();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            Form_addStudent Fas = new Form_addStudent();
            Fas.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Form_findStudent Ffs = new Form_findStudent();
            Ffs.Show();
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void 搜索学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_findStudent Ffs = new Form_findStudent();
            Ffs.Show();
        }
    }
}
