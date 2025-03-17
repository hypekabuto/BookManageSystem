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
    public partial class FormFeedBack: Form
    {
        public FormFeedBack()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.txtFeedBack.Text == "")
            {
                MessageBox.Show("反馈内容不能为空", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Dao dao = new Dao();
                dao.connect();
                DateTime nowTime = DateTime.Now;
                string sql = $"INSERT INTO T_FeedBack (Uid, FeedBack,Date) VALUES ({Form1.id}, '{this.txtFeedBack.Text}','{nowTime}')";
                int result = dao.Execute(sql);
                if (result == 0)
                {
                    MessageBox.Show("反馈失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("反馈成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                dao.DaoClose();
            }
        }
    }
}
