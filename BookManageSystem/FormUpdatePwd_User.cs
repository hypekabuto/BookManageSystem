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
    public partial class FormUpdatePwd_User: Form
    {
        public FormUpdatePwd_User()
        {
            InitializeComponent();
            txtNewPwd.MaxLength = 7;
            txtNewPwd.KeyPress += new KeyPressEventHandler(txtNewPwdKeyPress);
            txtNewPwd.TextChanged += new EventHandler(txtNewPwdTextChangedByCode);
        }
        private void txtNewPwdKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtNewPwdTextChangedByCode(object sender, EventArgs e)
        {
            if (txtNewPwd.Text.Length == 7)
            {
                MessageBox.Show("已达到最大输入长度6！请确认您的新密码。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNewPwd.Text = txtNewPwd.Text.Substring(0, 6);
                txtNewPwd.SelectionStart = txtNewPwd.Text.Length;
            }
        }
        private void txtNewPwdTextChangedByUI(object sender, EventArgs e)
        {
            if (txtOkPwd.Text.Length >= 7)
            {
                MessageBox.Show("已达到最大输入长度！请确认您的新密码。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOkPwd.Text = txtOkPwd.Text.Substring(0, 6);
                txtOkPwd.SelectionStart = txtOkPwd.Text.Length;
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtNewPwd.Text == "" || txtOldPwd.Text == "" || txtOkPwd.Text == "")
            {
                MessageBox.Show("有空项", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtNewPwd.Text != txtOkPwd.Text)
            {
                MessageBox.Show("两次密码不一致", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                Dao dao = new Dao();
                dao.connect();
                string selectOldPwdSql = $"select Pwd from T_User where Uid = {Form1.id} and Used = 1";
                SqlDataReader sqlDataReader = dao.read(selectOldPwdSql);
                sqlDataReader.Read();
                String databaseOldPwd = sqlDataReader[0].ToString();
                sqlDataReader.Close();
                try
                {
                    if (databaseOldPwd == txtOldPwd.Text)
                    {
                        String updatePwdSql = $"update T_User set Pwd = '{txtNewPwd.Text}' where Uid = {Form1.id} and Used = 1";
                        int changeNum = dao.Execute(updatePwdSql);
                        if (changeNum == 1)
                        {
                            dao.DaoClose();
                            MessageBox.Show("修改成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            dao.DaoClose();
                            MessageBox.Show("修改失败，请联系管理员", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        dao.DaoClose();
                        MessageBox.Show("请输入正确的原密码", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("修改失败，请联系管理员", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        
    }
}
