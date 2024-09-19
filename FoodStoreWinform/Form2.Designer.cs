namespace FoodStoreWinform
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txt_quantity = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btn_xacnhan = new Button();
            cb_productid = new ComboBox();
            SuspendLayout();
            // 
            // txt_quantity
            // 
            txt_quantity.Location = new Point(148, 68);
            txt_quantity.Name = "txt_quantity";
            txt_quantity.Size = new Size(135, 23);
            txt_quantity.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 76);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 3;
            label1.Text = "quantity";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(54, 119);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 4;
            label2.Text = "productName";
            // 
            // btn_xacnhan
            // 
            btn_xacnhan.Location = new Point(351, 106);
            btn_xacnhan.Name = "btn_xacnhan";
            btn_xacnhan.Size = new Size(152, 47);
            btn_xacnhan.TabIndex = 6;
            btn_xacnhan.Text = "Xác Nhận Thêm";
            btn_xacnhan.UseVisualStyleBackColor = true;
            btn_xacnhan.Click += btn_xacnhan_Click;
            // 
            // cb_productid
            // 
            cb_productid.FormattingEnabled = true;
            cb_productid.Location = new Point(153, 117);
            cb_productid.Name = "cb_productid";
            cb_productid.Size = new Size(121, 23);
            cb_productid.TabIndex = 7;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(571, 315);
            Controls.Add(cb_productid);
            Controls.Add(btn_xacnhan);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txt_quantity);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_quantity;
        private Label label1;
        private Label label2;
        private Button btn_xacnhan;
        private ComboBox cb_productid;
    }
}