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
    public partial class FormUpdateBook: Form
    {
        public FormUpdateBook()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(txtAuthor.Text == "" || txtBName.Text == "" || txtPublisher.Text == "" || txtType.Text == "" || txtPrice.Text == "" || txtNum.Text == "" || txtIntroduce.Text == "" || pdData.Text == "")
            {
                MessageBox.Show("请填写完整信息", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                Dao dao = new Dao();
                dao.connect();
                string sql = string.Format($"update T_Book set Bid = '{txtBid.Text}', Bname = '{txtBName.Text}', Author = '{txtAuthor.Text}', Publisher = '{txtPublisher.Text}', PbDate = '{pdData.Value}', Type = '{txtType.Text}', Price = '{float.Parse(txtPrice.Text)}', Num = '{int.Parse(txtNum.Text)}', Introduce = '{txtIntroduce.Text}' where Bid = '{FormManage.Bid}' and status = 1");
                if (dao.Execute(sql) > 0)
                {
                    MessageBox.Show("修改成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dao.DaoClose();
                    this.Close();
                }
                else
                {
                    dao.DaoClose();
                    MessageBox.Show("修改失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormUpdateBook_Load(object sender, EventArgs e)
        {
            txtAuthor.Text = FormManage.Author;
            txtBid.Text = FormManage.Bid.ToString();
            txtBName.Text = FormManage.Bname;
            txtPublisher.Text = FormManage.Publisher;
            txtType.Text = FormManage.Type;
            txtPrice.Text = FormManage.Price.ToString();
            txtNum.Text = FormManage.Num.ToString();
            txtIntroduce.Text = FormManage.Introduce;
            pdData.Value = DateTime.Parse(FormManage.PubDate);
        }
    }
}
