namespace lodandpass
{
    partial class ListItem
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.nameLabel = new System.Windows.Forms.Label();
            this.infoLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.buyButton = new System.Windows.Forms.Button();
            this.compareCheckBox = new System.Windows.Forms.CheckBox();
            this.stockLabel = new System.Windows.Forms.Label();
            this.favoritesIconPictureBox = new FontAwesome.Sharp.IconPictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.favoritesIconPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nameLabel.Location = new System.Drawing.Point(133, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(665, 44);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Что это";
            this.nameLabel.MouseEnter += new System.EventHandler(this.ListItem_MouseEnter);
            this.nameLabel.MouseLeave += new System.EventHandler(this.ListItem_MouseLeave);
            // 
            // infoLabel
            // 
            this.infoLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.infoLabel.Location = new System.Drawing.Point(136, 44);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(662, 54);
            this.infoLabel.TabIndex = 2;
            this.infoLabel.Text = "Описание";
            this.infoLabel.MouseEnter += new System.EventHandler(this.ListItem_MouseEnter);
            this.infoLabel.MouseLeave += new System.EventHandler(this.ListItem_MouseLeave);
            // 
            // priceLabel
            // 
            this.priceLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.priceLabel.Location = new System.Drawing.Point(451, 111);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(169, 34);
            this.priceLabel.TabIndex = 3;
            this.priceLabel.Text = "Цена";
            this.priceLabel.MouseEnter += new System.EventHandler(this.ListItem_MouseEnter);
            this.priceLabel.MouseLeave += new System.EventHandler(this.ListItem_MouseLeave);
            // 
            // buyButton
            // 
            this.buyButton.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buyButton.Location = new System.Drawing.Point(682, 97);
            this.buyButton.Name = "buyButton";
            this.buyButton.Size = new System.Drawing.Size(113, 50);
            this.buyButton.TabIndex = 5;
            this.buyButton.Text = "Купить";
            this.buyButton.UseVisualStyleBackColor = true;
            this.buyButton.MouseEnter += new System.EventHandler(this.ListItem_MouseEnter);
            this.buyButton.MouseLeave += new System.EventHandler(this.ListItem_MouseLeave);
            // 
            // compareCheckBox
            // 
            this.compareCheckBox.AutoSize = true;
            this.compareCheckBox.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.compareCheckBox.Location = new System.Drawing.Point(136, 89);
            this.compareCheckBox.Name = "compareCheckBox";
            this.compareCheckBox.Size = new System.Drawing.Size(118, 32);
            this.compareCheckBox.TabIndex = 6;
            this.compareCheckBox.Text = "Сравнить";
            this.compareCheckBox.UseVisualStyleBackColor = true;
            this.compareCheckBox.CheckedChanged += new System.EventHandler(this.compareCheckBox_CheckedChanged);
            this.compareCheckBox.MouseEnter += new System.EventHandler(this.ListItem_MouseEnter);
            this.compareCheckBox.MouseLeave += new System.EventHandler(this.ListItem_MouseLeave);
            // 
            // stockLabel
            // 
            this.stockLabel.AutoSize = true;
            this.stockLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stockLabel.Location = new System.Drawing.Point(136, 124);
            this.stockLabel.Name = "stockLabel";
            this.stockLabel.Size = new System.Drawing.Size(100, 21);
            this.stockLabel.TabIndex = 7;
            this.stockLabel.Text = "В наличии: 1";
            this.stockLabel.MouseEnter += new System.EventHandler(this.ListItem_MouseEnter);
            this.stockLabel.MouseLeave += new System.EventHandler(this.ListItem_MouseLeave);
            // 
            // favoritesIconPictureBox
            // 
            this.favoritesIconPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.favoritesIconPictureBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.favoritesIconPictureBox.IconChar = FontAwesome.Sharp.IconChar.Heart;
            this.favoritesIconPictureBox.IconColor = System.Drawing.SystemColors.ControlText;
            this.favoritesIconPictureBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.favoritesIconPictureBox.IconSize = 50;
            this.favoritesIconPictureBox.Location = new System.Drawing.Point(626, 97);
            this.favoritesIconPictureBox.Name = "favoritesIconPictureBox";
            this.favoritesIconPictureBox.Size = new System.Drawing.Size(50, 50);
            this.favoritesIconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.favoritesIconPictureBox.TabIndex = 8;
            this.favoritesIconPictureBox.TabStop = false;
            this.favoritesIconPictureBox.Click += new System.EventHandler(this.favoritesIconPictureBox_Click);
            this.favoritesIconPictureBox.MouseEnter += new System.EventHandler(this.ListItem_MouseEnter);
            this.favoritesIconPictureBox.MouseLeave += new System.EventHandler(this.ListItem_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(130, 150);
            this.panel1.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(15, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Location = new System.Drawing.Point(-10, 146);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(808, 28);
            this.panel2.TabIndex = 10;
            // 
            // ListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.favoritesIconPictureBox);
            this.Controls.Add(this.stockLabel);
            this.Controls.Add(this.compareCheckBox);
            this.Controls.Add(this.buyButton);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.nameLabel);
            this.Name = "ListItem";
            this.Size = new System.Drawing.Size(798, 150);
            this.MouseEnter += new System.EventHandler(this.ListItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ListItem_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.favoritesIconPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label nameLabel;
        private Label infoLabel;
        private Label priceLabel;
        private Button buyButton;
        private CheckBox compareCheckBox;
        private Label stockLabel;
        private FontAwesome.Sharp.IconPictureBox favoritesIconPictureBox;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Panel panel2;
    }
}
