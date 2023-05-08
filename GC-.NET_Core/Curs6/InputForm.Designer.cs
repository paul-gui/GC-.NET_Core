namespace Curs6
{
    partial class InputForm
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
            this.pcbInputBox = new System.Windows.Forms.PictureBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcbInputBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbInputBox
            // 
            this.pcbInputBox.BackColor = System.Drawing.Color.White;
            this.pcbInputBox.Location = new System.Drawing.Point(12, 12);
            this.pcbInputBox.Name = "pcbInputBox";
            this.pcbInputBox.Size = new System.Drawing.Size(776, 426);
            this.pcbInputBox.TabIndex = 0;
            this.pcbInputBox.TabStop = false;
            this.pcbInputBox.Click += new System.EventHandler(this.pcbInputBox_Click);
            this.pcbInputBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcbInputBox_MouseMove);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(319, 444);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(88, 36);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDone
            // 
            this.btnDone.Enabled = false;
            this.btnDone.Location = new System.Drawing.Point(413, 444);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(88, 36);
            this.btnDone.TabIndex = 1;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 489);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.pcbInputBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 528);
            this.MinimumSize = new System.Drawing.Size(816, 528);
            this.Name = "InputForm";
            this.Text = "Input";
            ((System.ComponentModel.ISupportInitialize)(this.pcbInputBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pcbInputBox;
        private Button btnClear;
        private Button btnDone;
    }
}