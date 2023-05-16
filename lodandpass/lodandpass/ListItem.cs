using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Forms;

namespace lodandpass
{
    public partial class ListItem : UserControl
    {
        public ListItem()
        {
            InitializeComponent();
        }

        #region Properties

        private bool _compare;
        private Color _iconBack;
        private string _nameInv;
        private string _info;
        private string _stock;
        private string _price;
        private Image _icon;
        private int _idItem;

        [Category("Custom Props")]
        public int IdItem
        {
            get { return _idItem; }
            set { _idItem = value;}
        }

        [Category("Custom Props")]
        public bool Compare
        {
            get { return _compare; }
            set { _compare = value; compareCheckBox.Checked = value; }
        }

        [Category("Custom Props")]
        public Color IconBackground
        {
            get { return _iconBack; }
            set { _iconBack = value; panel1.BackColor = value; }
        }

        [Category("Custom Props")]
        public string NameInv
        {
            get { return _nameInv; }
            set { _nameInv = value; nameLabel.Text = value; }
        }

        [Category("Custom Props")]
        public string Info
        {
            get { return _info; }
            set { _info = value; infoLabel.Text = value; }
        }

        [Category("Custom Props")]
        public string Stock
        {
            get { return _stock; }
            set { _stock = value; stockLabel.Text = value; }
        }

        [Category("Custom Props")]
        public string Price
        {
            get { return _price; }
            set { _price = value; priceLabel.Text = value; }
        }

        [Category("Custom Props")]
        public Image Icon
        {
            get { return _icon; }
            set { _icon = value; pictureBox1.Image = value; }
        }


        #endregion

        private void ListItem_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
        }

        private void ListItem_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        public void Alert(string msg, FormAlert.enmType type)
        {
            FormAlert frm = new FormAlert();
            frm.showAlert(msg, type);
        }

        private void compareCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!_compare) 
            {
                this.Alert("Добавлено в сравнение", FormAlert.enmType.Warning);                
            }
            else
                this.Alert("Удалено из сравнения", FormAlert.enmType.Warning);
            _compare = !_compare;
        }

        private void favoritesIconPictureBox_Click(object sender, EventArgs e)
        {
            this.Alert("Добавлено в избранное", FormAlert.enmType.Warning);
        }
    }
}
