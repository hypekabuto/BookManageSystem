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
    public partial class FormLogon: Form
    {
        public FormLogon()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtAgainPwd.Text == "" || txtIDCard.Text == "" || txtName.Text == "" || txtTel.Text == "" || txtPwd.Text == "" || cobSex.Text == "")
            {
                MessageBox.Show("有空项", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } else if(txtPwd.Text != txtAgainPwd.Text) {
                MessageBox.Show("两次密码不一致", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                Dao dao = new Dao();
                dao.connect();
                string sql = "select MAX(Uid) from T_User";
                SqlDataReader reader = dao.read(sql);
                reader.Read();
                int id = int.Parse(reader[0].ToString());
                string name = txtName.Text;
                string idCard = txtIDCard.Text;
                string tel = txtTel.Text;
                string sex = cobSex.Text;
                string pwd = txtPwd.Text;
                string sqlInsert = $"insert into T_User values('{id + 1}','{name}','{pwd}','{sex}','{idCard}','{tel}','1')";
                if (dao.Execute(sqlInsert) > 0)
                {
                    MessageBox.Show("注册成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                    MessageBox.Show("注册失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                reader.Close();
                dao.DaoClose();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
