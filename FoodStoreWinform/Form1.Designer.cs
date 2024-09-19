namespace FoodStoreWinform
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tab_order = new TabPage();
            btn_orderitem = new Button();
            txt_totalamoun = new TextBox();
            label5 = new Label();
            txt_orderdate = new TextBox();
            label4 = new Label();
            btn_xoaorder = new Button();
            btn_suaorder = new Button();
            btn_themorder = new Button();
            dgv_order = new DataGridView();
            tab_product = new TabPage();
            label7 = new Label();
            label6 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btn_xoaproduct = new Button();
            btn_suaproduct = new Button();
            btn_themproduct = new Button();
            txt_stock = new TextBox();
            txt_description = new TextBox();
            txt_price = new TextBox();
            cb_categoryid = new ComboBox();
            txt_product = new TextBox();
            dgv_product = new DataGridView();
            tab_category = new TabPage();
            dgv_category = new DataGridView();
            label9 = new Label();
            label10 = new Label();
            txt_namecategory = new TextBox();
            txt_descriptioncategory = new TextBox();
            btn_xoacategory = new Button();
            btn_suacategory = new Button();
            btn_themcategory = new Button();
            tabControl1.SuspendLayout();
            tab_order.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_order).BeginInit();
            tab_product.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_product).BeginInit();
            tab_category.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_category).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tab_order);
            tabControl1.Controls.Add(tab_product);
            tabControl1.Controls.Add(tab_category);
            tabControl1.Location = new Point(4, 7);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(867, 471);
            tabControl1.TabIndex = 0;
            // 
            // tab_order
            // 
            tab_order.Controls.Add(btn_orderitem);
            tab_order.Controls.Add(txt_totalamoun);
            tab_order.Controls.Add(label5);
            tab_order.Controls.Add(txt_orderdate);
            tab_order.Controls.Add(label4);
            tab_order.Controls.Add(btn_xoaorder);
            tab_order.Controls.Add(btn_suaorder);
            tab_order.Controls.Add(btn_themorder);
            tab_order.Controls.Add(dgv_order);
            tab_order.Location = new Point(4, 24);
            tab_order.Name = "tab_order";
            tab_order.Padding = new Padding(3);
            tab_order.Size = new Size(859, 443);
            tab_order.TabIndex = 0;
            tab_order.Text = "Order";
            tab_order.UseVisualStyleBackColor = true;
            tab_order.Click += tab_order_Click;
            // 
            // btn_orderitem
            // 
            btn_orderitem.Location = new Point(327, 103);
            btn_orderitem.Name = "btn_orderitem";
            btn_orderitem.Size = new Size(75, 23);
            btn_orderitem.TabIndex = 14;
            btn_orderitem.Text = "OrderItem";
            btn_orderitem.UseVisualStyleBackColor = true;
            btn_orderitem.Click += btn_orderitem_Click;
            // 
            // txt_totalamoun
            // 
            txt_totalamoun.Location = new Point(164, 74);
            txt_totalamoun.Name = "txt_totalamoun";
            txt_totalamoun.Size = new Size(238, 23);
            txt_totalamoun.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(86, 74);
            label5.Name = "label5";
            label5.Size = new Size(79, 15);
            label5.TabIndex = 12;
            label5.Text = "TotalAmount ";
            // 
            // txt_orderdate
            // 
            txt_orderdate.Location = new Point(164, 28);
            txt_orderdate.Name = "txt_orderdate";
            txt_orderdate.Size = new Size(238, 23);
            txt_orderdate.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(89, 31);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 10;
            label4.Text = "OrderDate";
            // 
            // btn_xoaorder
            // 
            btn_xoaorder.Location = new Point(632, 126);
            btn_xoaorder.Name = "btn_xoaorder";
            btn_xoaorder.Size = new Size(135, 43);
            btn_xoaorder.TabIndex = 3;
            btn_xoaorder.Text = "Xóa";
            btn_xoaorder.UseVisualStyleBackColor = true;
            btn_xoaorder.Click += btn_xoaorder_Click;
            // 
            // btn_suaorder
            // 
            btn_suaorder.Location = new Point(632, 77);
            btn_suaorder.Name = "btn_suaorder";
            btn_suaorder.Size = new Size(135, 43);
            btn_suaorder.TabIndex = 2;
            btn_suaorder.Text = "Sửa";
            btn_suaorder.UseVisualStyleBackColor = true;
            btn_suaorder.Click += btn_suaorder_Click;
            // 
            // btn_themorder
            // 
            btn_themorder.Location = new Point(632, 28);
            btn_themorder.Name = "btn_themorder";
            btn_themorder.Size = new Size(135, 43);
            btn_themorder.TabIndex = 1;
            btn_themorder.Text = "Thêm";
            btn_themorder.UseVisualStyleBackColor = true;
            btn_themorder.Click += btn_themorder_Click;
            // 
            // dgv_order
            // 
            dgv_order.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_order.Location = new Point(7, 208);
            dgv_order.Name = "dgv_order";
            dgv_order.Size = new Size(846, 228);
            dgv_order.TabIndex = 0;
            dgv_order.CellClick += dgv_order_CellClick;
            // 
            // tab_product
            // 
            tab_product.Controls.Add(label7);
            tab_product.Controls.Add(label6);
            tab_product.Controls.Add(label3);
            tab_product.Controls.Add(label2);
            tab_product.Controls.Add(label1);
            tab_product.Controls.Add(btn_xoaproduct);
            tab_product.Controls.Add(btn_suaproduct);
            tab_product.Controls.Add(btn_themproduct);
            tab_product.Controls.Add(txt_stock);
            tab_product.Controls.Add(txt_description);
            tab_product.Controls.Add(txt_price);
            tab_product.Controls.Add(cb_categoryid);
            tab_product.Controls.Add(txt_product);
            tab_product.Controls.Add(dgv_product);
            tab_product.Location = new Point(4, 24);
            tab_product.Name = "tab_product";
            tab_product.Padding = new Padding(3);
            tab_product.Size = new Size(859, 443);
            tab_product.TabIndex = 1;
            tab_product.Text = "Product";
            tab_product.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(107, 186);
            label7.Name = "label7";
            label7.Size = new Size(35, 15);
            label7.TabIndex = 13;
            label7.Text = "stock";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(79, 148);
            label6.Name = "label6";
            label6.Size = new Size(66, 15);
            label6.TabIndex = 12;
            label6.Text = "description";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(107, 107);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 11;
            label3.Text = "price";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(107, 26);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 10;
            label2.Text = "name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 68);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 9;
            label1.Text = "category name";
            // 
            // btn_xoaproduct
            // 
            btn_xoaproduct.Location = new Point(617, 145);
            btn_xoaproduct.Name = "btn_xoaproduct";
            btn_xoaproduct.Size = new Size(178, 46);
            btn_xoaproduct.TabIndex = 8;
            btn_xoaproduct.Text = "Xóa";
            btn_xoaproduct.UseVisualStyleBackColor = true;
            btn_xoaproduct.Click += btn_xoaproduct_Click;
            // 
            // btn_suaproduct
            // 
            btn_suaproduct.Location = new Point(617, 81);
            btn_suaproduct.Name = "btn_suaproduct";
            btn_suaproduct.Size = new Size(178, 46);
            btn_suaproduct.TabIndex = 7;
            btn_suaproduct.Text = "Sửa";
            btn_suaproduct.UseVisualStyleBackColor = true;
            btn_suaproduct.Click += btn_suaproduct_Click;
            // 
            // btn_themproduct
            // 
            btn_themproduct.Location = new Point(617, 24);
            btn_themproduct.Name = "btn_themproduct";
            btn_themproduct.Size = new Size(178, 46);
            btn_themproduct.TabIndex = 6;
            btn_themproduct.Text = "Thêm";
            btn_themproduct.UseVisualStyleBackColor = true;
            btn_themproduct.Click += btn_themproduct_Click;
            // 
            // txt_stock
            // 
            txt_stock.Location = new Point(174, 183);
            txt_stock.Name = "txt_stock";
            txt_stock.Size = new Size(239, 23);
            txt_stock.TabIndex = 5;
            // 
            // txt_description
            // 
            txt_description.Location = new Point(174, 145);
            txt_description.Name = "txt_description";
            txt_description.Size = new Size(239, 23);
            txt_description.TabIndex = 4;
            // 
            // txt_price
            // 
            txt_price.Location = new Point(174, 104);
            txt_price.Name = "txt_price";
            txt_price.Size = new Size(239, 23);
            txt_price.TabIndex = 3;
            // 
            // cb_categoryid
            // 
            cb_categoryid.FormattingEnabled = true;
            cb_categoryid.Location = new Point(174, 65);
            cb_categoryid.Name = "cb_categoryid";
            cb_categoryid.Size = new Size(239, 23);
            cb_categoryid.TabIndex = 2;
            // 
            // txt_product
            // 
            txt_product.Location = new Point(174, 24);
            txt_product.Name = "txt_product";
            txt_product.Size = new Size(239, 23);
            txt_product.TabIndex = 1;
            // 
            // dgv_product
            // 
            dgv_product.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_product.Location = new Point(5, 226);
            dgv_product.Name = "dgv_product";
            dgv_product.Size = new Size(848, 210);
            dgv_product.TabIndex = 0;
            dgv_product.CellClick += dgv_product_CellClick;
            // 
            // tab_category
            // 
            tab_category.Controls.Add(btn_xoacategory);
            tab_category.Controls.Add(btn_suacategory);
            tab_category.Controls.Add(btn_themcategory);
            tab_category.Controls.Add(txt_descriptioncategory);
            tab_category.Controls.Add(txt_namecategory);
            tab_category.Controls.Add(label10);
            tab_category.Controls.Add(label9);
            tab_category.Controls.Add(dgv_category);
            tab_category.Location = new Point(4, 24);
            tab_category.Name = "tab_category";
            tab_category.Padding = new Padding(3);
            tab_category.Size = new Size(859, 443);
            tab_category.TabIndex = 2;
            tab_category.Text = "Category";
            tab_category.UseVisualStyleBackColor = true;
            // 
            // dgv_category
            // 
            dgv_category.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_category.Location = new Point(7, 207);
            dgv_category.Name = "dgv_category";
            dgv_category.Size = new Size(846, 229);
            dgv_category.TabIndex = 0;
            dgv_category.CellClick += dgv_category_CellClick;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(47, 64);
            label9.Name = "label9";
            label9.Size = new Size(37, 15);
            label9.TabIndex = 2;
            label9.Text = "name";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(41, 110);
            label10.Name = "label10";
            label10.Size = new Size(66, 15);
            label10.TabIndex = 3;
            label10.Text = "description";
            // 
            // txt_namecategory
            // 
            txt_namecategory.Location = new Point(130, 65);
            txt_namecategory.Name = "txt_namecategory";
            txt_namecategory.Size = new Size(223, 23);
            txt_namecategory.TabIndex = 4;
            // 
            // txt_descriptioncategory
            // 
            txt_descriptioncategory.Location = new Point(130, 110);
            txt_descriptioncategory.Name = "txt_descriptioncategory";
            txt_descriptioncategory.Size = new Size(223, 23);
            txt_descriptioncategory.TabIndex = 5;
            // 
            // btn_xoacategory
            // 
            btn_xoacategory.Location = new Point(593, 139);
            btn_xoacategory.Name = "btn_xoacategory";
            btn_xoacategory.Size = new Size(178, 46);
            btn_xoacategory.TabIndex = 11;
            btn_xoacategory.Text = "Xóa";
            btn_xoacategory.UseVisualStyleBackColor = true;
            btn_xoacategory.Click += btn_xoacategory_Click;
            // 
            // btn_suacategory
            // 
            btn_suacategory.Location = new Point(593, 75);
            btn_suacategory.Name = "btn_suacategory";
            btn_suacategory.Size = new Size(178, 46);
            btn_suacategory.TabIndex = 10;
            btn_suacategory.Text = "Sửa";
            btn_suacategory.UseVisualStyleBackColor = true;
            btn_suacategory.Click += btn_suacategory_Click;
            // 
            // btn_themcategory
            // 
            btn_themcategory.Location = new Point(593, 18);
            btn_themcategory.Name = "btn_themcategory";
            btn_themcategory.Size = new Size(178, 46);
            btn_themcategory.TabIndex = 9;
            btn_themcategory.Text = "Thêm";
            btn_themcategory.UseVisualStyleBackColor = true;
            btn_themcategory.Click += btn_themcategory_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(873, 479);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            tab_order.ResumeLayout(false);
            tab_order.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_order).EndInit();
            tab_product.ResumeLayout(false);
            tab_product.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_product).EndInit();
            tab_category.ResumeLayout(false);
            tab_category.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_category).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tab_order;
        private Button btn_xoaorder;
        private Button btn_suaorder;
        private Button btn_themorder;
        private DataGridView dgv_order;
        private TabPage tab_product;
        private TabPage tab_category;
        private ComboBox cb_categoryid;
        private ComboBox cb_productId;
        private TextBox txt_totalamoun;
        private Label label5;
        private TextBox txt_orderdate;
        private Label label4;
        private Button btn_orderitem;
        private TextBox txt_description;
        private TextBox txt_price;
        private TextBox txt_product;
        private DataGridView dgv_product;
        private TextBox txt_stock;
        private Label label2;
        private Label label1;
        private Button btn_xoaproduct;
        private Button btn_suaproduct;
        private Button btn_themproduct;
        private Label label7;
        private Label label6;
        private Label label3;
        private Label label10;
        private Label label9;
        private DataGridView dgv_category;
        private TextBox txt_descriptioncategory;
        private TextBox txt_namecategory;
        private Button btn_xoacategory;
        private Button btn_suacategory;
        private Button btn_themcategory;
    }
}
