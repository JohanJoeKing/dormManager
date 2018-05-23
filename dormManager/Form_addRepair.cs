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
    public partial class Form_addRepair : Form
    {
        public Form_addRepair()
        {
            InitializeComponent();
            textBox2.Enabled = false;
            string constr = "server=localhost;User Id=root;password=20153178;Database=dormmanager";
            MySqlConnection mycon = new MySqlConnection(constr);
            mycon.Open();
            MySqlCommand mycmd = new MySqlCommand("select MAX(rid) from repair", mycon);
            MySqlDataReader reader = null;
            reader = mycmd.ExecuteReader();
            string maxRid = "";
            while (reader.Read())
            {
                maxRid = reader[0].ToString();
            }
            reader.Close();
            mycon.Close();

            int m = Convert.ToInt32(maxRid);
            m++;
            maxRid = m.ToString();

            textBox2.Text = maxRid;
            textBox5.Text = (0).ToString();
            textBox5.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string did = textBox1.Text.ToString();
            string rid = textBox2.Text.ToString();
            string content = textBox3.Text.ToString();
            string sdateyear = comboBox1.SelectedItem.ToString();
            string sdatemonth = comboBox2.SelectedItem.ToString();
            string sdatedata = comboBox3.SelectedItem.ToString();
            string needpay = textBox4.Text.ToString();
            string paied = textBox5.Text.ToString();
            string ifpaied = "";
            string state = "";
            if (radioButton1.Checked == true)
            {
                ifpaied = "是";
            }
            else if (radioButton2.Checked == true)
            {
                ifpaied = "否";
            }
            if (radioButton3.Checked == true)
            {
                state = "未施工";
            }
            else if (radioButton4.Checked == true)
            {
                state = "已完成";
            }
            int sta = 0;
            if (state == "已完成")
            {
                sta = 1;
            }
            string constr = "server=localhost;User Id=root;password=20153178;Database=dormmanager";
            MySqlConnection mycon = new MySqlConnection(constr);
            mycon.Open();
            string ssdate = sdateyear + "-" + sdatemonth + "-" + sdatedata;
            string sql = string.Format("insert into repair values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',{8})", did, rid, content, ssdate, needpay, paied, ifpaied, state, sta);
            MySqlCommand mycmd = new MySqlCommand(sql, mycon);
            if (mycmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("添加成功！");
            }
            else
            {
                MessageBox.Show("添加失败！");
            }
            mycon.Close();
            this.Close();
        }
    }
}
