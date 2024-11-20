namespace Task9
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Label labelCharacterCount;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.labelCharacterCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxInput
            // 
            this.textBoxInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInput.Location = new System.Drawing.Point(12, 12);
            this.textBoxInput.MaxLength = 160;
            this.textBoxInput.Multiline = true;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(449, 100);
            this.textBoxInput.TabIndex = 0;
            this.textBoxInput.TextChanged += new System.EventHandler(this.textBoxInput_TextChanged);
            // 
            // labelCharacterCount
            // 
            this.labelCharacterCount.AutoSize = true;
            this.labelCharacterCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCharacterCount.Location = new System.Drawing.Point(12, 120);
            this.labelCharacterCount.Name = "labelCharacterCount";
            this.labelCharacterCount.Size = new System.Drawing.Size(168, 24);
            this.labelCharacterCount.TabIndex = 1;
            this.labelCharacterCount.Text = "Characters left: 160";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(473, 181);
            this.Controls.Add(this.labelCharacterCount);
            this.Controls.Add(this.textBoxInput);
            this.Name = "Form1";
            this.Text = "Character Limit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
