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
    public partial class Form_addStudent : Form
    {
        public Form_addStudent()
        {
            InitializeComponent();
            setAddDormAvailable(false);
        }

        // 设置添加宿舍信息区域的控件的可用性
        private void setAddDormAvailable(bool flag)
        {
            d_id.Enabled = flag;
            Dflour.Enabled = flag;
            amount.Enabled = flag;
            empty.Enabled = flag;
            tijiao_d.Enabled = flag;
            reset2.Enabled = flag;
        }

        // 设置添加学生信息区域的控件的可用性
        private void setAddStudentAvailable(bool flag)
        {
            name.Enabled = flag;
            sid.Enabled = flag;
            sclass.Enabled = flag;
            age.Enabled = flag;
            bednum.Enabled = flag;
            major.Enabled = flag;
            school.Enabled = flag;
            did.Enabled = flag;
            flour.Enabled = flag;
            phone.Enabled = flag;
            button1.Enabled = flag;
            reset1.Enabled = flag;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s_name = name.Text;
            string s_sid = sid.Text;
            string s_class = sclass.Text;
            string s_age = age.Text;
            string s_school = school.Text;
            string s_phone = phone.Text;
            string s_major = major.Text;
            string s_did = did.Text;
            string s_bednum = bednum.Text;
            string s_flour = flour.Text;

            //插入学生表
            string constr = "server=localhost;User Id=root;password=20153178;Database=dormmanager";
            MySqlConnection mycon = new MySqlConnection(constr);
            mycon.Open();
            string sql = string.Format("insert into student values('{0}','{1}','{2}',{3},'{4}','{5}','{6}')", s_name, s_sid, s_class, s_age, s_phone, s_major, s_school);
            MySqlCommand mycmd = new MySqlCommand(sql, mycon);
            if (mycmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("学生信息数据录入成功！");
            }
            else
            {
                MessageBox.Show("学生信息数据录入失败！");
            }

            //插入学生-宿舍表
            sql = string.Format("insert into dorm_student values('{0}','{1}',{2})", s_did, s_sid, s_bednum);
            MySqlCommand mycmd2 = new MySqlCommand(sql, mycon);
            if (mycmd2.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("学生入住数据登记成功！");
            }
            else
            {
                MessageBox.Show("学生入住数据登记失败！");
            }

            mycon.Close();
            this.Close();
        }

        private void reset1_Click(object sender, EventArgs e)
        {
            name.Clear();
            sid.Clear();
            sclass.Clear();
            school.Clear();
            age.Clear();
            phone.Clear();
            major.Clear();
            did.Clear();
            bednum.Clear();
        }

        private void reset2_Click(object sender, EventArgs e)
        {
            d_id.Clear();
            amount.Clear();
        }

        private void tijiao_d_Click(object sender, EventArgs e)
        {
            string d_did = d_id.Text;
            string d_flour = Dflour.Text;
            string d_amount = amount.Text;
            string d_empty = empty.Text;

            // 插入到宿舍表
            string constr = "server=localhost;User Id=root;password=20153178;Database=dormmanager";
            MySqlConnection mycon = new MySqlConnection(constr);
            mycon.Open();
            string sql = string.Format("insert into dorm values('{0}',{1},{2},{3})", d_did, d_flour, d_amount, d_empty);
            MySqlCommand mycmd = new MySqlCommand(sql, mycon);
            if (mycmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("宿舍信息数据录入成功！");
            }
            else
            {
                MessageBox.Show("学生信息数据录入失败！");
            }
            mycon.Close();
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            setAddDormAvailable(false);
            setAddStudentAvailable(true);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            setAddDormAvailable(true);
            setAddStudentAvailable(false);
        }
    }
}
