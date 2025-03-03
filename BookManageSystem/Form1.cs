using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManageSystem
{
    public partial class Form1: Form
    {
        public static int id;
        public static string name;

        //管理员登录的方法
        private void AdminLogin() { 
            int id = int.Parse(txtId.Text);
            string pwd = txtPassword.Text;
            Dao dao = new Dao();
            dao.connect();
            string sql = $"select * from T_Admin where AdminID = {id} and Pwd = {pwd}";
            SqlDataReader reader = dao.read(sql);
            if (reader.Read() == true)
            {
                Form1.id = id;
                string selectNameSql = $"Select Name from T_Admin where AdminID = {id} ";
                SqlDataReader readerName = dao.read(selectNameSql);
                readerName.Read();
                Form1.name = readerName[0].ToString();
                txtId.Text = "";
                txtPassword.Text = "";
                FormAdmin formAdmin = new FormAdmin();
                formAdmin.ShowDialog();
                reader.Close();
                readerName.Close();
                dao.DaoClose();
            }
            else {
                MessageBox.Show("账号或密码错误", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void UserLogin() {
            int id = int.Parse(txtId.Text);
            string pwd = txtPassword.Text;
            Dao dao = new Dao();
            dao.connect();
            string sql = $"select * from T_User where Uid = {id} and Pwd = {pwd} and Used = 1";
            SqlDataReader reader = dao.read(sql);
            if (reader.Read() == true)
            {
                Form1.id = id;
                string selectNameSql = $"Select Uname from T_User where Uid = {id}  and Used = 1 ";
                SqlDataReader readerName = dao.read(selectNameSql);
                readerName.Read();
                Form1.name = readerName[0].ToString();
                txtId.Text = "";
                txtPassword.Text = "";
                FormUser formUser = new FormUser();
                formUser.ShowDialog();
                reader.Close();
                readerName.Close();
                dao.DaoClose();
            }
            else
            {
                MessageBox.Show("账号或密码错误", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radiorbtnUserButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogon_Click(object sender, EventArgs e)
        {
            FormLogon form = new FormLogon();
            form.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("退出确认退出吗？", "消息", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) { 
                //退出
                this.Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //判断文本框是否为空
            if (txtId.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("有空项", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if(rbtnAdmin.Checked == true)
            {
                //管理员在登陆
                this.AdminLogin();
            }
            else if (rbtnUser.Checked == true)
            {
                //普通用户在登陆
                this.UserLogin();
            }

        }
    }
}
