using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace lodandpass
{
    public partial class FormProducts : Form
    {
        DateBase db;

        private int selectedCategory = 1;
        public List<int> list;
        private ListItem[] listItems;

        private int totalEntries, totalEntries1;

        public FormProducts()
        {
            InitializeComponent();
        }

        private void FormProducts_Load(object sender, EventArgs e)
        {
            //сколько всего записей в таблице товары
            SqlCommand сommand = new("SELECT COUNT(*) as count FROM [Товары]", db.getConnection());
            db.openConnection();
            totalEntries = Convert.ToInt32(сommand.ExecuteScalar().ToString());

            //сколько всего категорий в таблице категории
            SqlCommand сommand1 = new("SELECT COUNT(*) as count FROM [Категории]", db.getConnection());
            int cKat = Convert.ToInt32(сommand1.ExecuteScalar().ToString());
            for (int i = 1; i <= cKat; i++)
            {
                //Вывод всех категорий в comboBox1
                SqlCommand сommand2 = new($"SELECT [Название категории] FROM [Категории] WHERE [id] = {i}", db.getConnection());
                string s = сommand2.ExecuteScalar().ToString();
                comboBox1.Items.Add(s);
            }
        }

        private void PopulateItems()
        {
            if (selectedCategory > 0)
            {
                listItems = new ListItem[totalEntries1];
                int j = 0;
                for (int i = 1; i <= totalEntries; i++)
                {
                    if (list.Contains(i))
                    {
                        string query1 = string.Format($"SELECT [Наименование товара] FROM [Товары] WHERE [ID] = {i} and [ID_Категории] = {selectedCategory}");
                        SqlCommand сommand1 = new(query1, db.getConnection());
                        string query2 = string.Format($"SELECT [Описание] FROM [Товары] WHERE [ID] = {i} and [ID_Категории] = {selectedCategory}");
                        SqlCommand сommand2 = new(query2, db.getConnection());
                        string query3 = string.Format($"SELECT ([Статус] + [Количество товара]) FROM [Товары] WHERE [ID] = {i} and [ID_Категории] = {selectedCategory}");
                        SqlCommand сommand3 = new(query3, db.getConnection());
                        string query4 = string.Format($"SELECT [Стоимость] FROM [Товары] WHERE [ID] = {i} and [ID_Категории] = {selectedCategory}");
                        SqlCommand сommand4 = new(query4, db.getConnection());

                        listItems[j] = new ListItem
                        {
                            IconBackground = Color.Silver,
                            Width = flowLayoutPanel1.Width,

                            NameInv = сommand1.ExecuteScalar().ToString(),
                            Info = сommand2.ExecuteScalar().ToString(),
                            Stock = сommand3.ExecuteScalar().ToString(),
                            Price = сommand4.ExecuteScalar().ToString(),
                            IdItem = i
                        };


                        if (flowLayoutPanel1.Controls.Count < 0)
                        {
                            flowLayoutPanel1.Controls.Clear();
                        }
                        else
                            flowLayoutPanel1.Controls.Add(listItems[j]);
                        j++;
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            list = new List<int>();

            selectedCategory = comboBox1.SelectedIndex + 1;

            //Сколько всего записей в таблице у выбранной категории
            SqlCommand сommand = new($"SELECT COUNT(*) as count FROM [Товары] WHERE [ID_Категории] = {selectedCategory}", db.getConnection());
            totalEntries1 = Convert.ToInt32(сommand.ExecuteScalar().ToString());

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(flowLayoutPanel2);

            for (int i = 1; i <= totalEntries; i++)
            {
                SqlCommand сommand1 = new($"SELECT [ID] FROM [Товары] WHERE [ID] = {i} and [ID_Категории] = {selectedCategory}", db.getConnection());
                var scalar = сommand1.ExecuteScalar();
                if (scalar != null)
                {
                    list.Add(Convert.ToInt32(scalar));
                }

            }
            PopulateItems();
        }

    }
}
