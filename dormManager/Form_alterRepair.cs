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
    public partial class Form_alterRepair : Form
    {
        public Form_alterRepair()
        {
            InitializeComponent();
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rid = textBox1.Text;
            string constr = "server=localhost;User Id=root;password=20153178;Database=dormmanager";
            MySqlConnection mycon = new MySqlConnection(constr);
            mycon.Open();
            string sql = string.Format("select * from repair where rid={0}", rid);
            MySqlCommand mycmd = new MySqlCommand(sql, mycon);
            MySqlDataReader reader = null;
            reader = mycmd.ExecuteReader();
            string ifpaied = "", state = "";
            while (reader.Read())
            {
                textBox2.Text = reader[0].ToString();
                textBox3.Text = reader[2].ToString();
                textBox4.Text = reader[3].ToString();
                textBox5.Text = reader[4].ToString();
                textBox6.Text = reader[5].ToString();
                ifpaied = reader[6].ToString();
                state = reader[7].ToString();
            }
            if (ifpaied == "是")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }
            if(state == "未施工")
            {
                radioButton3.Checked = true;
                radioButton4.Checked = false;
            }
            else
            {
                radioButton3.Checked = false;
                radioButton4.Checked = true;
            }
            reader.Close();
            mycon.Close();

            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Enabled == false || textBox2.Text == "")
            {
                MessageBox.Show("请先输入正确单号");
            }
            else
            {
                string did = textBox2.Text;
                string rid = textBox1.Text;
                string content = textBox3.Text;
                string sdate = textBox4.Text;
                string needpay = textBox5.Text;
                string paied = textBox6.Text;
                string ifpaied = "";
                string state = "";
                string sta = "";
                if (radioButton1.Checked == true)
                {
                    ifpaied = "是";
                }
                else
                {
                    ifpaied = "否";
                }
                if (radioButton3.Checked == true)
                {
                    ifpaied = "未施工";
                    sta = "0";
                }
                else
                {
                    ifpaied = "已完成";
                    sta = "1";
                }

                string constr = "server=localhost;User Id=root;password=20153178;Database=dormmanager";
                MySqlConnection mycon = new MySqlConnection(constr);
                mycon.Open();
                string sql = string.Format("update repair set did='{0}', content='{1}', sdate='{2}', needpay={3}, paied={4}, ifpaied='{5}', state='{6}', sta={7} where rid={8}", did, content, sdate, needpay, paied, ifpaied, state, sta, rid);
                MySqlCommand mycmd = new MySqlCommand(sql, mycon);
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
}
