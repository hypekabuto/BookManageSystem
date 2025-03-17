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
    public partial class FormDiscussion: Form
    {
        public FormDiscussion()
        {
            InitializeComponent();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void LoadDiscussion() {
            this.dgv.Rows.Clear();
            Dao dao = new Dao();
            dao.connect();
            string sql = $"SELECT * FROM T_Discussion";
            SqlDataReader selectBorrowInformation = dao.read(sql);
            while (selectBorrowInformation.Read())
            {
                dgv.Rows.Add(selectBorrowInformation[0].ToString(), selectBorrowInformation[1].ToString(), selectBorrowInformation[2].ToString(), selectBorrowInformation[3].ToString(), selectBorrowInformation[4].ToString(),
                    selectBorrowInformation[5].ToString(), selectBorrowInformation[6].ToString(), selectBorrowInformation[7].ToString());
            }
            selectBorrowInformation.Close();
            dao.DaoClose();
        }
        private void LoadMyBook()
        {
            Dao dao = new Dao();
            dao.connect();
            string sql = $"SELECT Bid FROM T_Borrow where Uid = {Form1.id}";
            SqlDataReader selectBorrowInformation = dao.read(sql);
            while (selectBorrowInformation.Read())
            {
                cobID.Items.Add(selectBorrowInformation[0].ToString());
            }
            selectBorrowInformation.Close();
            dao.DaoClose();
        }
        private void FormDiscussion_Load(object sender, EventArgs e)
        {
            if (Form1.id.ToString().Length == 8)
            {
                //是用户
                btnDelete.Visible = false;

            }
            else { 
                //是管理员
                btnSend.Visible = false;

            }
            this.LoadDiscussion();
            this.LoadMyBook();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (lblName.Text == "NULL" || txtPWords.Text == "" || cobID.Text == "" || cobScore.Text == "")
            {
                MessageBox.Show("有空项", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else { 
                int Bid = int.Parse(cobID.Text);
                string Bname = lblName.Text;
                int id = Form1.id;
                string Uname = Form1.name;
                string Pwords = txtPWords.Text;
                DateTime nowTime = DateTime.Now;
                string score = cobScore.Text;
                int key = 0;
                Dao dao = new Dao();
                dao.connect();
                string keySql = $"select [key] from T_Discussion where [key] = {key}";
                SqlDataReader keyReader = dao.read(keySql);
                while (true) {
                    key++;
                    string selectsql = $"select [key] from T_Discussion where [key] = {key}";
                    SqlDataReader circlereader = dao.read(selectsql);
                    circlereader.Read();
                    if (!circlereader.HasRows)
                    {
                        break;
                        circlereader.Close();
                    }
                    else {
                        circlereader.Close();
                    }
                }
                string insertSql = $"insert into T_Discussion values('{key}','{Bid}','{Bname}','{id}','{Uname}','{Pwords}','{nowTime}','{score}')";
                int result = dao.Execute(insertSql);
                if (result > 0)
                {
                    MessageBox.Show("添加成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                    MessageBox.Show("发表失败，联系管理员", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                this.LoadDiscussion();
                keyReader.Close();
                dao.DaoClose();
            }
        }

        private void cobID_TextChanged(object sender, EventArgs e)
        {
            int id = int.Parse(cobID.Text);
            Dao dao = new Dao();
            dao.connect();
            string selectSql = $"select Bname from T_Book where Bid = {id}";
            SqlDataReader reader = dao.read(selectSql);
            reader.Read();
            string name = reader[0].ToString();
            lblName.Text = name;
            reader.Close();
            dao.DaoClose();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow.Cells[0].Value == null) {
                MessageBox.Show("选中了无效数据", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else{
                Dao dao = new Dao();
                dao.connect();
                string deletedSql = $"delete T_Discussion where [key] = {int.Parse(dgv.CurrentRow.Cells[0].Value.ToString())}";
                if(dao.Execute(deletedSql) > 0)
                {
                    MessageBox.Show("删除成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("删除失败，联系管理员", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                this.LoadDiscussion();
                dao.DaoClose(); 
            }
        }
    }
}
