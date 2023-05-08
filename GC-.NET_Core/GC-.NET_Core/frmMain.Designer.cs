namespace GC_.NET_Core
{
    partial class frmMain
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
            this.btnShow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcbDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbDisplay
            // 
            this.pcbDisplay.Location = new System.Drawing.Point(12, 48);
            this.pcbDisplay.Name = "pcbDisplay";
            this.pcbDisplay.Size = new System.Drawing.Size(776, 390);
            this.pcbDisplay.TabIndex = 0;
            this.pcbDisplay.TabStop = false;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(12, 12);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(84, 23);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "Afisare";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.pcbDisplay);
            this.Name = "frmMain";
            this.Text = "Curs 4 - Invelitoare superioara si inferioara";
            ((System.ComponentModel.ISupportInitialize)(this.pcbDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pcbDisplay;
        private Button btnShow;
    }
}