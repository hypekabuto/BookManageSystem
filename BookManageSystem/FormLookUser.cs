using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManageSystem
{
    public partial class FormLookUser: Form
    {
        public FormLookUser()
        {
            InitializeComponent();
        }
        private void LoadUserList()
        {
            this.dgv.Rows.Clear();
            Dao dao = new Dao();
            dao.connect();
            string selectUserListSql = "select Uid,Uname,Sex,IDCard,Tel,Used from T_User";
            SqlDataReader reader = dao.read(selectUserListSql);
            while (reader.Read())
            {
                dgv.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString());
            }
            reader.Close();
            dao.DaoClose();
        }

        private void FormLookUser_Load(object sender, EventArgs e)
        {
            this.LoadUserList();
            if (dgv.Rows.Count > 1)
            {
                lblID.Text = dgv.Rows[0].Cells[0].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.LoadUserList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lblID.Text == "NULL")
            {
                MessageBox.Show("请选择用户", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else {
                Dao dao = new Dao();
                dao.connect();
                string updateSql = $"update T_User set Used = 0 where Uid = {int.Parse(lblID.Text)}";
                if(dao.Execute(updateSql) == 1)
                {
                    MessageBox.Show("暂停使用成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LoadUserList();
                    dao.DaoClose();
                }
                else
                {
                    dao.DaoClose();
                    MessageBox.Show("操作失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (lblID.Text == "NULL")
            {
                MessageBox.Show("请选择用户", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                Dao dao = new Dao();
                dao.connect();
                string updateSql = $"update T_User set Used = 1 where Uid = {int.Parse(lblID.Text)}";
                if (dao.Execute(updateSql) == 1)
                {
                    MessageBox.Show("账号已重新使用", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LoadUserList();
                    dao.DaoClose();
                }
                else
                {
                    dao.DaoClose();
                    MessageBox.Show("操作失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.lblID.Text = dgv.CurrentRow.Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string keys = txtInputKey.Text.Trim();
            dgv.Rows.Clear();
            Dao dao = new Dao();
            dao.connect();
            string selectUserListSql = $"select Uid,Uname,Sex,IDCard,Tel,Used from T_User where Uname like '%{keys}%' or sex like '%{keys}%'" +
                $" or Used like '%{keys}%'";
            SqlDataReader reader = dao.read(selectUserListSql);
                while (reader.Read())
                {
                    dgv.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString());
                }
                reader.Close();
                dao.DaoClose();
        }
    }
}
