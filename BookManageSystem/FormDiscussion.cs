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
            string sql = $"SELECT Bid FROM T_Discussion where Uid = {Form1.id}";
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
                DateTime time = DateTime.Now;
                string score = cobScore.Text;
                int key = 0;
                Dao dao = new Dao();
                dao.connect();
                string keySql = $"select [key] from T_Discussion where [key] = {key}";

            }
        }
    }
}
