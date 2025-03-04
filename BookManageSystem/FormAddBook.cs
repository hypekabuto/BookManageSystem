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
    public partial class FormAddBook : Form
    {
        public FormAddBook()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Trim() == "" || txtName.Text.Trim() == "" ||
                txtAuthor.Text.Trim() == "" || txtType.Text == "" ||
                txtPublisher.Text.Trim() == "" || txtPrice.Text.Trim() == "" ||
                txtNum.Text.Trim() == "" || txtIntroduce.Text.Trim() == "" ||
                dtpPublishDate.Text == "")
            {
                MessageBox.Show("请填写完整信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                Dao dao = new Dao();
                dao.connect();
                string insertBookSql = $"insert into T_Book values({int.Parse(txtId.Text)},'{txtName.Text}','{txtAuthor.Text}','{txtPublisher.Text}','{dtpPublishDate.Value}','{txtType.Text}','{txtPrice.Text}','{txtNum.Text}','{txtIntroduce.Text}','0','1')";
                if (dao.Execute(insertBookSql) > 0)
                {
                    dao.DaoClose();
                    MessageBox.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    dao.DaoClose();
                    MessageBox.Show("添加失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
