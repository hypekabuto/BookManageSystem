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
    public partial class FormUser: Form
    {
        public FormUser()
        {
            InitializeComponent();
        }
        //test
        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确认注销当前账号吗？", "消息", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                int id = Form1.id;
                Dao dao = new Dao();
                dao.connect();
                string updateSql = $"UPDATE T_User SET Used = 0 WHERE Uid = {id}";
                int sqlResult = dao.Execute(updateSql);
                if (sqlResult == 0)
                {
                    MessageBox.Show("注销失败，联系管理员", "消息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    dao.DaoClose();
                }
                else {
                    MessageBox.Show("注销成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form1.id = 0;
                    Form1.name = "";
                    dao.DaoClose();
                    this.Close();
                }  
            }
        }

        private void 退出登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("退出确认退出吗？", "消息", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                this.Close();
            }
        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            this.label1.Text = "用户" + Form1.name + ":" + Form1.id;
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUpdatePwd_User formUpdatePwdUser = new FormUpdatePwd_User();
            formUpdatePwdUser.ShowDialog();
        }

        private void 租借图书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBorrowBook formBorrowBook = new FormBorrowBook();
            formBorrowBook.ShowDialog();
        }

        private void 归还图书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReturnBook formReturnBook = new FormReturnBook();
            formReturnBook.ShowDialog();
        }
    }
}
