namespace Activity2
{
    partial class Form1
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
            this.comboBoxPizzaSize = new System.Windows.Forms.ComboBox();
            this.checkBoxCheese = new System.Windows.Forms.CheckBox();
            this.checkBoxPepperoni = new System.Windows.Forms.CheckBox();
            this.checkBoxMushrooms = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonThinCrust = new System.Windows.Forms.RadioButton();
            this.radioButtonThickCrust = new System.Windows.Forms.RadioButton();
            this.buttonPlaceOrder = new System.Windows.Forms.Button();
            this.labelOrderSummary = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxPizzaSize
            // 
            this.comboBoxPizzaSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPizzaSize.FormattingEnabled = true;
            this.comboBoxPizzaSize.Items.AddRange(new object[] {
            "Small ",
            "Medium",
            "Large"});
            this.comboBoxPizzaSize.Location = new System.Drawing.Point(320, 127);
            this.comboBoxPizzaSize.Name = "comboBoxPizzaSize";
            this.comboBoxPizzaSize.Size = new System.Drawing.Size(164, 32);
            this.comboBoxPizzaSize.TabIndex = 0;
            // 
            // checkBoxCheese
            // 
            this.checkBoxCheese.AutoSize = true;
            this.checkBoxCheese.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxCheese.Location = new System.Drawing.Point(320, 19);
            this.checkBoxCheese.Name = "checkBoxCheese";
            this.checkBoxCheese.Size = new System.Drawing.Size(73, 28);
            this.checkBoxCheese.TabIndex = 1;
            this.checkBoxCheese.Text = "Pizza";
            this.checkBoxCheese.UseVisualStyleBackColor = true;
            // 
            // checkBoxPepperoni
            // 
            this.checkBoxPepperoni.AutoSize = true;
            this.checkBoxPepperoni.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxPepperoni.Location = new System.Drawing.Point(320, 52);
            this.checkBoxPepperoni.Name = "checkBoxPepperoni";
            this.checkBoxPepperoni.Size = new System.Drawing.Size(117, 28);
            this.checkBoxPepperoni.TabIndex = 2;
            this.checkBoxPepperoni.Text = "Pepperoni";
            this.checkBoxPepperoni.UseVisualStyleBackColor = true;
            // 
            // checkBoxMushrooms
            // 
            this.checkBoxMushrooms.AutoSize = true;
            this.checkBoxMushrooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxMushrooms.Location = new System.Drawing.Point(320, 86);
            this.checkBoxMushrooms.Name = "checkBoxMushrooms";
            this.checkBoxMushrooms.Size = new System.Drawing.Size(129, 28);
            this.checkBoxMushrooms.TabIndex = 3;
            this.checkBoxMushrooms.Text = "Mushrooms";
            this.checkBoxMushrooms.UseVisualStyleBackColor = true;
            this.checkBoxMushrooms.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonThinCrust);
            this.groupBox1.Controls.Add(this.radioButtonThickCrust);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(320, 190);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Crust Type:";
            // 
            // radioButtonThinCrust
            // 
            this.radioButtonThinCrust.AutoSize = true;
            this.radioButtonThinCrust.Location = new System.Drawing.Point(44, 28);
            this.radioButtonThinCrust.Name = "radioButtonThinCrust";
            this.radioButtonThinCrust.Size = new System.Drawing.Size(114, 28);
            this.radioButtonThinCrust.TabIndex = 5;
            this.radioButtonThinCrust.TabStop = true;
            this.radioButtonThinCrust.Text = "Thin Crust";
            this.radioButtonThinCrust.UseVisualStyleBackColor = true;
            // 
            // radioButtonThickCrust
            // 
            this.radioButtonThickCrust.AutoSize = true;
            this.radioButtonThickCrust.Location = new System.Drawing.Point(44, 60);
            this.radioButtonThickCrust.Name = "radioButtonThickCrust";
            this.radioButtonThickCrust.Size = new System.Drawing.Size(114, 28);
            this.radioButtonThickCrust.TabIndex = 6;
            this.radioButtonThickCrust.TabStop = true;
            this.radioButtonThickCrust.Text = "Thin Crust";
            this.radioButtonThickCrust.UseVisualStyleBackColor = true;
            // 
            // buttonPlaceOrder
            // 
            this.buttonPlaceOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlaceOrder.Location = new System.Drawing.Point(346, 323);
            this.buttonPlaceOrder.Name = "buttonPlaceOrder";
            this.buttonPlaceOrder.Size = new System.Drawing.Size(122, 33);
            this.buttonPlaceOrder.TabIndex = 7;
            this.buttonPlaceOrder.Text = "Place Order";
            this.buttonPlaceOrder.UseVisualStyleBackColor = true;
            this.buttonPlaceOrder.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelOrderSummary
            // 
            this.labelOrderSummary.AutoSize = true;
            this.labelOrderSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrderSummary.Location = new System.Drawing.Point(575, 323);
            this.labelOrderSummary.Name = "labelOrderSummary";
            this.labelOrderSummary.Size = new System.Drawing.Size(149, 24);
            this.labelOrderSummary.TabIndex = 8;
            this.labelOrderSummary.Text = "Order Summary:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(110, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 22);
            this.label2.TabIndex = 9;
            this.label2.Text = "Pizza Size:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(110, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 22);
            this.label3.TabIndex = 10;
            this.label3.Text = "Toppings:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelOrderSummary);
            this.Controls.Add(this.buttonPlaceOrder);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBoxMushrooms);
            this.Controls.Add(this.checkBoxPepperoni);
            this.Controls.Add(this.checkBoxCheese);
            this.Controls.Add(this.comboBoxPizzaSize);
            this.Name = "Form1";
            this.Text = "Pizza Shop";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxPizzaSize;
        private System.Windows.Forms.CheckBox checkBoxCheese;
        private System.Windows.Forms.CheckBox checkBoxPepperoni;
        private System.Windows.Forms.CheckBox checkBoxMushrooms;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonThinCrust;
        private System.Windows.Forms.RadioButton radioButtonThickCrust;
        private System.Windows.Forms.Button buttonPlaceOrder;
        private System.Windows.Forms.Label labelOrderSummary;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

