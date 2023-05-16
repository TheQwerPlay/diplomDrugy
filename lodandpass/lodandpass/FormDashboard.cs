using System;
using System.Collections;
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
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace lodandpass
{
    public partial class FormDashboard : Form
    {
        DateBase db;
                
        private int selectedCategory = 1;
        public List<int> list;
        private ListItem[] listItems;

        private int totalEntries, totalEntries1;


        public FormDashboard()
        {
            InitializeComponent();
            db = new DateBase();
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

                        listItems[j].Compare = GetAddItem(i, j);

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

        private bool GetAddItem(int i, int j) 
        {
            if (selectedCategory == 1)
            {
                if (DataList.selectedForComparisonListAppliances.Contains(i))
                {
                    return true;
                }
            }
            if (selectedCategory == 2)
            {
                if (DataList.selectedForComparisonListSmartphonesAndPhotoQquipment.Contains(i))
                {
                    return true;
                }
            }
            if (selectedCategory == 3)
            {
                if (DataList.selectedForComparisonListPCLaptopsPeripherals.Contains(i))
                {
                    return true;
                }
            }
            if (selectedCategory == 4)
            {
                if (DataList.selectedForComparisonListAccessoriesForPC.Contains(i))
                {
                    return true;
                }
            }
            if (selectedCategory == 5)
            {
                if (DataList.selectedForComparisonListOfficeAndFurniture.Contains(i))
                {
                    return true;
                }
            }
            if (selectedCategory == 6)
            {
                if (DataList.selectedForComparisonListAutoGoods.Contains(i))
                {
                    return true;
                }
            }
            return false;
        }

        private void FormDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataAddItemComparison();
            db.closeConnection();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
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
            DataAddItemComparison();
            PopulateItems();            
        }

        private void DataAddItemComparison()
        {
            if (selectedCategory == 1) 
            {
                if (listItems != null)
                {
                    for (int i = 0; i < listItems.Length; i++)
                    {
                        if (listItems[i].Compare == true)
                        {
                            if (!DataList.selectedForComparisonListAppliances.Contains(i))
                            {
                                DataList.selectedForComparisonListAppliances.Add(listItems[i].IdItem);
                            }
                        }
                        else
                            DataList.selectedForComparisonListAppliances.Remove(i);
                    }
                }
            }
            if (selectedCategory == 2)
            {
                if (listItems != null)
                {
                    for (int i = 0; i < listItems.Length; i++)
                    {
                        if (listItems[i].Compare == true)
                        {
                            if (!DataList.selectedForComparisonListSmartphonesAndPhotoQquipment.Contains(i))
                            {
                                DataList.selectedForComparisonListSmartphonesAndPhotoQquipment.Add(listItems[i].IdItem);
                            }
                        }
                        else
                            DataList.selectedForComparisonListSmartphonesAndPhotoQquipment.Remove(i);
                    }
                }
            }
            if (selectedCategory == 3)
            {
                if (listItems != null)
                {
                    for (int i = 0; i < listItems.Length; i++)
                    {
                        if (listItems[i].Compare == true)
                        {
                            if (!DataList.selectedForComparisonListPCLaptopsPeripherals.Contains(i))
                            {
                                DataList.selectedForComparisonListPCLaptopsPeripherals.Add(listItems[i].IdItem);
                            }
                        }
                        else
                            DataList.selectedForComparisonListPCLaptopsPeripherals.Remove(i);
                    }
                }
            }
            if (selectedCategory == 4)
            {
                if (listItems != null)
                {
                    for (int i = 0; i < listItems.Length; i++)
                    {
                        if (listItems[i].Compare == true)
                        {
                            if (!DataList.selectedForComparisonListAccessoriesForPC.Contains(i+1))
                            {
                                DataList.selectedForComparisonListAccessoriesForPC.Add(listItems[i].IdItem);
                            }
                        }
                        else
                            DataList.selectedForComparisonListAccessoriesForPC.Remove(i);
                    }
                }
            }
            if (selectedCategory == 5)
            {
                if (listItems != null)
                {
                    for (int i = 0; i < listItems.Length; i++)
                    {
                        if (listItems[i].Compare == true)
                        {
                            if (!DataList.selectedForComparisonListOfficeAndFurniture.Contains(i))
                            {
                                DataList.selectedForComparisonListOfficeAndFurniture.Add(listItems[i].IdItem);
                            }
                        }
                        else
                            DataList.selectedForComparisonListOfficeAndFurniture.Remove(i);
                    }
                }
            }
            if (selectedCategory == 6)
            {
                if (listItems != null)
                {
                    for (int i = 0; i < listItems.Length; i++)
                    {
                        if (listItems[i].Compare == true)
                        {
                            if (!DataList.selectedForComparisonListAutoGoods.Contains(i))
                            {
                                DataList.selectedForComparisonListAutoGoods.Add(listItems[i].IdItem);
                            }
                        }
                        else
                            DataList.selectedForComparisonListAutoGoods.Remove(i);
                    }
                }
            }
        }
        private void DataAddItemBasket()
        {
            if (selectedCategory == 1)
            {
                if (listItems != null)
                {
                    for (int i = 0; i < listItems.Length; i++)
                    {
                        if (listItems[i].Compare == true)
                        {
                            if (!DataList.selectedForBasketListAppliances.Contains(i))
                            {
                                DataList.selectedForBasketListAppliances.Add(listItems[i].IdItem);
                            }
                        }
                        else
                            DataList.selectedForBasketListAppliances.Remove(i);
                    }
                }
            }
            if (selectedCategory == 2)
            {
                if (listItems != null)
                {
                    for (int i = 0; i < listItems.Length; i++)
                    {
                        if (listItems[i].Compare == true)
                        {
                            if (!DataList.selectedForBasketListSmartphonesAndPhotoQquipment.Contains(i))
                            {
                                DataList.selectedForBasketListSmartphonesAndPhotoQquipment.Add(listItems[i].IdItem);
                            }
                        }
                        else
                            DataList.selectedForBasketListSmartphonesAndPhotoQquipment.Remove(i);
                    }
                }
            }
            if (selectedCategory == 3)
            {
                if (listItems != null)
                {
                    for (int i = 0; i < listItems.Length; i++)
                    {
                        if (listItems[i].Compare == true)
                        {
                            if (!DataList.selectedForBasketListPCLaptopsPeripherals.Contains(i))
                            {
                                DataList.selectedForBasketListPCLaptopsPeripherals.Add(listItems[i].IdItem);
                            }
                        }
                        else
                            DataList.selectedForBasketListPCLaptopsPeripherals.Remove(i);
                    }
                }
            }
            if (selectedCategory == 4)
            {
                if (listItems != null)
                {
                    for (int i = 0; i < listItems.Length; i++)
                    {
                        if (listItems[i].Compare == true)
                        {
                            if (!DataList.selectedForBasketListAccessoriesForPC.Contains(i))
                            {
                                DataList.selectedForBasketListAccessoriesForPC.Add(listItems[i].IdItem);
                            }
                        }
                        else
                            DataList.selectedForBasketListAccessoriesForPC.Remove(i);
                    }
                }
            }
            if (selectedCategory == 5)
            {
                if (listItems != null)
                {
                    for (int i = 0; i < listItems.Length; i++)
                    {
                        if (listItems[i].Compare == true)
                        {
                            if (!DataList.selectedForBasketListOfficeAndFurniture.Contains(i))
                            {
                                DataList.selectedForBasketListOfficeAndFurniture.Add(listItems[i].IdItem);
                            }
                        }
                        else
                            DataList.selectedForBasketListOfficeAndFurniture.Remove(i);
                    }
                }
            }
            if (selectedCategory == 6)
            {
                if (listItems != null)
                {
                    for (int i = 0; i < listItems.Length; i++)
                    {
                        if (listItems[i].Compare == true)
                        {
                            if (!DataList.selectedForBasketListAutoGoods.Contains(i))
                            {
                                DataList.selectedForBasketListAutoGoods.Add(listItems[i].IdItem);
                            }
                        }
                        else
                            DataList.selectedForBasketListAutoGoods.Remove(i);
                    }
                }
            }
        }
        private void DataAddItemFavorites()
        {
            if (selectedCategory == 1)
            {
                if (listItems != null)
                {
                    for (int i = 0; i < listItems.Length; i++)
                    {
                        if (listItems[i].Compare == true)
                        {
                            if (!DataList.selectedForFavoritesListAppliances.Contains(i))
                            {
                                DataList.selectedForFavoritesListAppliances.Add(listItems[i].IdItem);
                            }
                        }
                        else
                            DataList.selectedForFavoritesListAppliances.Remove(i);
                    }
                }
            }
            if (selectedCategory == 2)
            {
                if (listItems != null)
                {
                    for (int i = 0; i < listItems.Length; i++)
                    {
                        if (listItems[i].Compare == true)
                        {
                            if (!DataList.selectedForFavoritesListSmartphonesAndPhotoQquipment.Contains(i))
                            {
                                DataList.selectedForFavoritesListSmartphonesAndPhotoQquipment.Add(listItems[i].IdItem);
                            }
                        }
                        else
                            DataList.selectedForFavoritesListSmartphonesAndPhotoQquipment.Remove(i);
                    }
                }
            }
            if (selectedCategory == 3)
            {
                if (listItems != null)
                {
                    for (int i = 0; i < listItems.Length; i++)
                    {
                        if (listItems[i].Compare == true)
                        {
                            if (!DataList.selectedForFavoritesListPCLaptopsPeripherals.Contains(i))
                            {
                                DataList.selectedForFavoritesListPCLaptopsPeripherals.Add(listItems[i].IdItem);
                            }
                        }
                        else
                            DataList.selectedForFavoritesListPCLaptopsPeripherals.Remove(i);
                    }
                }
            }
            if (selectedCategory == 4)
            {
                if (listItems != null)
                {
                    for (int i = 0; i < listItems.Length; i++)
                    {
                        if (listItems[i].Compare == true)
                        {
                            if (!DataList.selectedForFavoritesListAccessoriesForPC.Contains(i))
                            {
                                DataList.selectedForFavoritesListAccessoriesForPC.Add(listItems[i].IdItem);
                            }
                        }
                        else
                            DataList.selectedForFavoritesListAccessoriesForPC.Remove(i);
                    }
                }
            }
            if (selectedCategory == 5)
            {
                if (listItems != null)
                {
                    for (int i = 0; i < listItems.Length; i++)
                    {
                        if (listItems[i].Compare == true)
                        {
                            if (!DataList.selectedForFavoritesListOfficeAndFurniture.Contains(i))
                            {
                                DataList.selectedForFavoritesListOfficeAndFurniture.Add(listItems[i].IdItem);
                            }
                        }
                        else
                            DataList.selectedForFavoritesListOfficeAndFurniture.Remove(i);
                    }
                }
            }
            if (selectedCategory == 6)
            {
                if (listItems != null)
                {
                    for (int i = 0; i < listItems.Length; i++)
                    {
                        if (listItems[i].Compare == true)
                        {
                            if (!DataList.selectedForFavoritesListAutoGoods.Contains(i))
                            {
                                DataList.selectedForFavoritesListAutoGoods.Add(listItems[i].IdItem);
                            }
                        }
                        else
                            DataList.selectedForFavoritesListAutoGoods.Remove(i);
                    }
                }
            }
        }

    }
}
