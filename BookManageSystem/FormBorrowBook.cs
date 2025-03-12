using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManageSystem
{
    public partial class FormBorrowBook: Form
    {
        public FormBorrowBook()
        {
            InitializeComponent();
        }

        private void LoadBoolList() { 
            this.dgv.Rows.Clear();
            Dao dao = new Dao();
            dao.connect();
            string selectBookListSql = "select * from T_Book where status = 1";
            SqlDataReader reader = dao.read(selectBookListSql);
            while (reader.Read())
            {
                dgv.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), reader[8].ToString(), reader[9].ToString());
            }
            reader.Close();
            dao.DaoClose();
        }

        private void FormBorrowBook_Load_1(object sender, EventArgs e)
        {
            this.LoadBoolList();
            cobNum.Text = "1";
            if (dgv.Rows.Count == 1)
            {
                return;
            }
            else {
                lblName.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void dgv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.CurrentRow == null || dgv.CurrentRow.Cells[0].Value == null)
            {
                MessageBox.Show("选中无效数据", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else { 
                lblName.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string name = dgv.CurrentRow.Cells[1].Value.ToString();
            int id = int.Parse(dgv.CurrentRow.Cells[0].Value.ToString());
            int num = int.Parse(cobNum.Text);
            DateTime date = DateTime.Now;
            int key = 1;
            Dao dao = new Dao();
            dao.connect();
            string selectKeySql = $"select [key] from T_Borrow where [key] = '{key}'";
            SqlDataReader reader = dao.read(selectKeySql);
            reader.Read();
            while (true)
            {
                key++;
                string selectKeySql2 = $"select [key] from T_Borrow where [key] = '{key}'";
                SqlDataReader reader2 = dao.read(selectKeySql2);
                reader2.Read();
                


                if (!reader2.HasRows) {
                    reader2.Close();
                    break;
                }
                reader2.Close();
            }
            reader.Close();
            string selectFlag = $"select Bid from T_Book where 0 <= Num - '{num}' and Bid = '{id}'";
            SqlDataReader read3 = dao.read(selectFlag);
            if (read3.Read() == false)
            {
                MessageBox.Show("库存不足", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                read3.Close();
                dao.DaoClose();
                return;
            }
            else { 
                string IsertSql = $"insert into T_Borrow values('{key}','{Form1.id}','{Form1.name}','{name}','{date}','{num}','{id}')";
                string updateSql = $"update T_Book set Num = Num - {num},BorrowCount =  BorrowCount + {num} where Bid = '{id}' and status = 1";
                if (dao.Execute(IsertSql) + dao.Execute(updateSql) >= 2)
                {
                    MessageBox.Show("租借成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dao.DaoClose();
                    read3.Close();
                    this.LoadBoolList();
                }
                else {
                    MessageBox.Show("租借失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dao.DaoClose();
                    read3.Close();
                }
            }

        }
    }
}
