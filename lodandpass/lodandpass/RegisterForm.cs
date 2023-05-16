using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace lodandpass
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (isUserExists())
            {
                return;
            }
            if (txtUsername.Text == "" && txtMail.Text == "" && txtPassword.Text == "" && txtComPassword.Text == "")
            {
                MessageBox.Show("���� ��� ������������ � ������ �����", "������ �����������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPassword.Text == txtComPassword.Text)
            {
                DateBase db = new DateBase();
                string query = "INSERT INTO [����������] ([���], [����������� �����], [������]) VALUES ('" + txtUsername.Text + "','"
                                                                                                        + txtMail.Text + "','"
                                                                                                        + txtPassword.Text + "')";
                SqlCommand command = new SqlCommand(query, db.getConnection());
                db.openConnection();

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("������� ��� ������");
                }

                db.closeConnection();
                Close();
                new Thread(() => { Application.Run(new MainMenu()); }).Start();
            }
            else
            {
                MessageBox.Show("�������� ������", "������ �����������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtComPassword.Text = "";
                txtPassword.Focus();
            }
        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPas.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtComPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtComPassword.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtComPassword.Text = "";
            txtMail.Text = "";
            txtUsername.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Hide();
        }

        public bool isUserExists()        
        {
            DateBase db = new DateBase();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand �ommand = new SqlCommand("SELECT * FROM [����������] Where [����������� �����] = @uL", db.getConnection());
            �ommand.Parameters.Add("@uL", SqlDbType.VarChar).Value = txtMail.Text;

            adapter.SelectCommand = �ommand;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("������ ����� ��� ������������");
                return true;
            }
            else
                return false;
        }
    }
}