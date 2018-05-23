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



namespace dormManager
{
    public partial class Form_login : Form
    {

        private Form1 MAIN;

        string id = "";
        string password = "";
        public Form_login()
        {
            InitializeComponent();
        }

        public void getMain(Form1 f)
        {
            MAIN = f;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            //下面这条语句需要更改，id、password改成自己的
            string constr = "server=localhost;User Id=root;password=20153178;Database=dormmanager";
            MySqlConnection mycon = new MySqlConnection(constr);
            mycon.Open();
            try
            {
                MySqlCommand mycmd = new MySqlCommand("select password from staff where id = '" + textBox1.Text + "'", mycon);
                MySqlDataAdapter adap = new MySqlDataAdapter(mycmd);
                MySqlDataReader sdr = mycmd.ExecuteReader();
                sdr.Read();
                if (textBox2.Text == sdr[0].ToString())
                {
                    //MessageBox.Show("登录成功");
                    textBox2.Clear();
                    //转到跳转界面
                    MAIN.init();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("密码错误");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("账号不存在");
            }
            mycon.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            id = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            password = textBox2.Text;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
