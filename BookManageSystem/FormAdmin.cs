using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManageSystem
{
    public partial class FormAdmin: Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void 退出登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("退出确认退出吗？", "消息", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                this.Close();
            }
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            this.label1.Text = "管理员" + Form1.name + ":" + Form1.id;
        }

        private void 注销账号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确认注销当前账号吗？", "消息", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                int id = Form1.id;
                Dao dao = new Dao();
                dao.connect();
                string deleteSql = $"delete T_Admin where AdminID = {id}";
                int sqlResult = dao.Execute(deleteSql);
                if (sqlResult == 0)
                {
                    MessageBox.Show("注销失败，联系管理员", "消息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    dao.DaoClose();
                }
                else
                {
                    MessageBox.Show("注销成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form1.id = 0;
                    Form1.name = "";
                    dao.DaoClose();
                    this.Close();
                }

            }
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUpdatePwd_Admin updatePwdAdmin = new FormUpdatePwd_Admin();
            updatePwdAdmin.ShowDialog();
        }

        private void 添加图书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddBook formAddBook = new FormAddBook();
            formAddBook.ShowDialog();
        }

        private void 修改图书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManage formManage = new FormManage();
            formManage.ShowDialog();
        }

        private void 下架图书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManage formManage = new FormManage();
            formManage.ShowDialog();
        }

        private void 搜索图书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManage formManage = new FormManage();
            formManage.ShowDialog();
        }
    }
}
