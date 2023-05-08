namespace Curs6
{
    partial class StartForm
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
            this.btnEx1 = new System.Windows.Forms.Button();
            this.btnEx2_3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEx1
            // 
            this.btnEx1.Location = new System.Drawing.Point(12, 12);
            this.btnEx1.Name = "btnEx1";
            this.btnEx1.Size = new System.Drawing.Size(269, 95);
            this.btnEx1.TabIndex = 0;
            this.btnEx1.Text = "Exercitiul 1";
            this.btnEx1.UseVisualStyleBackColor = true;
            this.btnEx1.Click += new System.EventHandler(this.btnEx1_Click);
            // 
            // btnEx2_3
            // 
            this.btnEx2_3.Location = new System.Drawing.Point(12, 113);
            this.btnEx2_3.Name = "btnEx2_3";
            this.btnEx2_3.Size = new System.Drawing.Size(269, 95);
            this.btnEx2_3.TabIndex = 1;
            this.btnEx2_3.Text = "Exercitiul 2 si 3";
            this.btnEx2_3.UseVisualStyleBackColor = true;
            this.btnEx2_3.Click += new System.EventHandler(this.btnEx2_3_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 220);
            this.Controls.Add(this.btnEx2_3);
            this.Controls.Add(this.btnEx1);
            this.Name = "StartForm";
            this.Text = "Curs 6";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnEx1;
        private Button btnEx2_3;
    }
}