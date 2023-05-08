namespace Curs7
{
    partial class Curs7Form
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
            this.pcbDisplay = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbDisplay
            // 
            this.pcbDisplay.Location = new System.Drawing.Point(12, 12);
            this.pcbDisplay.Name = "pcbDisplay";
            this.pcbDisplay.Size = new System.Drawing.Size(867, 524);
            this.pcbDisplay.TabIndex = 0;
            this.pcbDisplay.TabStop = false;
            this.pcbDisplay.Click += new System.EventHandler(this.pcbDisplay_Click);
            // 
            // Curs7Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 548);
            this.Controls.Add(this.pcbDisplay);
            this.Name = "Curs7Form";
            this.Text = "Curs 7";
            ((System.ComponentModel.ISupportInitialize)(this.pcbDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pcbDisplay;
    }
}