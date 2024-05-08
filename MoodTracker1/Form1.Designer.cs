namespace MoodTracker1
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
            this.btnBad = new System.Windows.Forms.Button();
            this.btnGood = new System.Windows.Forms.Button();
            this.btnVeryG = new System.Windows.Forms.Button();
            this.lblMood = new System.Windows.Forms.Label();
            this.lblVeryG = new System.Windows.Forms.Label();
            this.lblGood = new System.Windows.Forms.Label();
            this.lblBad = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBad
            // 
            this.btnBad.Location = new System.Drawing.Point(206, 143);
            this.btnBad.Name = "btnBad";
            this.btnBad.Size = new System.Drawing.Size(75, 23);
            this.btnBad.TabIndex = 0;
            this.btnBad.Text = "BAD";
            this.btnBad.UseVisualStyleBackColor = true;
            this.btnBad.Click += new System.EventHandler(this.btnBad_Click_1);
            // 
            // btnGood
            // 
            this.btnGood.Location = new System.Drawing.Point(287, 143);
            this.btnGood.Name = "btnGood";
            this.btnGood.Size = new System.Drawing.Size(75, 23);
            this.btnGood.TabIndex = 1;
            this.btnGood.Text = "GOOD";
            this.btnGood.UseVisualStyleBackColor = true;
            this.btnGood.Click += new System.EventHandler(this.btnGood_Click_1);
            // 
            // btnVeryG
            // 
            this.btnVeryG.Location = new System.Drawing.Point(368, 143);
            this.btnVeryG.Name = "btnVeryG";
            this.btnVeryG.Size = new System.Drawing.Size(89, 23);
            this.btnVeryG.TabIndex = 2;
            this.btnVeryG.Text = "VeryGood";
            this.btnVeryG.UseVisualStyleBackColor = true;
            this.btnVeryG.Click += new System.EventHandler(this.btnVeryG_Click_1);
            // 
            // lblMood
            // 
            this.lblMood.AutoSize = true;
            this.lblMood.Location = new System.Drawing.Point(309, 224);
            this.lblMood.Name = "lblMood";
            this.lblMood.Size = new System.Drawing.Size(44, 16);
            this.lblMood.TabIndex = 3;
            this.lblMood.Text = "label1";
            // 
            // lblVeryG
            // 
            this.lblVeryG.AutoSize = true;
            this.lblVeryG.Location = new System.Drawing.Point(365, 276);
            this.lblVeryG.Name = "lblVeryG";
            this.lblVeryG.Size = new System.Drawing.Size(44, 16);
            this.lblVeryG.TabIndex = 4;
            this.lblVeryG.Text = "label1";
            // 
            // lblGood
            // 
            this.lblGood.AutoSize = true;
            this.lblGood.Location = new System.Drawing.Point(284, 276);
            this.lblGood.Name = "lblGood";
            this.lblGood.Size = new System.Drawing.Size(44, 16);
            this.lblGood.TabIndex = 5;
            this.lblGood.Text = "label1";
            // 
            // lblBad
            // 
            this.lblBad.AutoSize = true;
            this.lblBad.Location = new System.Drawing.Point(203, 276);
            this.lblBad.Name = "lblBad";
            this.lblBad.Size = new System.Drawing.Size(44, 16);
            this.lblBad.TabIndex = 6;
            this.lblBad.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblBad);
            this.Controls.Add(this.lblGood);
            this.Controls.Add(this.lblVeryG);
            this.Controls.Add(this.lblMood);
            this.Controls.Add(this.btnVeryG);
            this.Controls.Add(this.btnGood);
            this.Controls.Add(this.btnBad);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBad;
        private System.Windows.Forms.Button btnGood;
        private System.Windows.Forms.Button btnVeryG;
        private System.Windows.Forms.Label lblMood;
        private System.Windows.Forms.Label lblVeryG;
        private System.Windows.Forms.Label lblGood;
        private System.Windows.Forms.Label lblBad;
    }
}

