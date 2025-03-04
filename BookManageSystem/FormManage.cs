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
    public partial class FormManage: Form
    {
        public static int Bid;
        public static string Bname;
        public static string Author;
        public static string Publisher;
        public static string PubDate;
        public static string Type;
        public static float Price;
        public static int Num;
        public static string Introduce;
        public FormManage()
        {
            InitializeComponent();
        }
        private void loadBook()
        {
            Dao dao = new Dao();
            dao.connect();
            string sql = "select * from T_Book where status = 1";
            SqlDataReader bookList = dao.read(sql);
            while (bookList.Read()) { 
                dgv.Rows.Add(bookList[0].ToString(), bookList[1].ToString(), bookList[2].ToString(), bookList[3].ToString(), 
                    bookList[4].ToString(), bookList[5].ToString(), bookList[6].ToString(), bookList[7].ToString(), 
                    bookList[8].ToString(), bookList[9].ToString());
            }
            bookList.Close();
            dao.DaoClose();
        }

        private void FormManage_Load(object sender, EventArgs e)
        {
            this.loadBook();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.CurrentRow == null || dgv.CurrentRow.Cells[0].Value == null)
            {
                MessageBox.Show("选中了无效的数据", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else { 
                string id = dgv.CurrentRow.Cells[0].Value.ToString();
                string name = dgv.CurrentRow.Cells[1].Value.ToString();
                lblBookId.Text = id;
                lblBookName.Text = name;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dgv.Rows.Clear();
            this.loadBook();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (lblBookName.Text == "")
            {
                MessageBox.Show("没有选中任何书籍", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else {
                Dao dao = new Dao();
                dao.connect();
                String selectIntroduceSql = $"select Introduce from T_Book where Bid = {lblBookId.Text} and status = 1";
                SqlDataReader introduce = dao.read(selectIntroduceSql);
                introduce.Read();
                string introduceStr = introduce[0].ToString();
                MessageBox.Show(introduceStr, $"{lblBookName}简介", MessageBoxButtons.OK, MessageBoxIcon.Information);
                introduce.Close();
                dao.DaoClose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string key = txtInputKey.Text.Trim();
            Dao dao = new Dao();
            dao.connect();
            String selectChoosebookSql = $"select * from T_Book where Bname like '%{key}%' and status = 1 or Author like '%{key}%'";
            SqlDataReader bookList = dao.read(selectChoosebookSql);
            dgv.Rows.Clear();
            while (bookList.Read())
            {
                dgv.Rows.Add(bookList[0].ToString(), bookList[1].ToString(), bookList[2].ToString(), bookList[3].ToString(),
                    bookList[4].ToString(), bookList[5].ToString(), bookList[6].ToString(), bookList[7].ToString(),
                    bookList[8].ToString(), bookList[9].ToString());
            }
            bookList.Close();
            dao.DaoClose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(lblBookId.Text == "NULL")
            {
                MessageBox.Show("没有选中任何书籍", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                Dao dao = new Dao();
                dao.connect();
                string updateBookStatusSql = $"update T_Book set status = 0 where Bid = {lblBookId.Text}";
                int sqlResult = dao.Execute(updateBookStatusSql);
                if (sqlResult == 0)
                {
                    MessageBox.Show("下架失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dao.DaoClose();
                }
                else
                {
                    MessageBox.Show("下架成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.lblBookId.Text = "NULL";
                    this.lblBookName.Text = "NULL";
                    dao.DaoClose();
                    dgv.Rows.Clear();
                    this.loadBook();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormUpdateBook formUpdateBook = new FormUpdateBook();
            formUpdateBook.ShowDialog();
        }
    }
}
