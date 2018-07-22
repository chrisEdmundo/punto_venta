namespace PuntodeVenta
{
    partial class Recibos
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.btnSaveProducts = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Elephant", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(217, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 26);
            this.label3.TabIndex = 20;
            this.label3.Text = "FOLIO:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(303, 230);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(309, 22);
            this.textBox3.TabIndex = 19;
            // 
            // btnSaveProducts
            // 
            this.btnSaveProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSaveProducts.FlatAppearance.BorderSize = 0;
            this.btnSaveProducts.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSaveProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveProducts.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveProducts.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveProducts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveProducts.Location = new System.Drawing.Point(775, 207);
            this.btnSaveProducts.Name = "btnSaveProducts";
            this.btnSaveProducts.Size = new System.Drawing.Size(249, 45);
            this.btnSaveProducts.TabIndex = 16;
            this.btnSaveProducts.Text = "BUSCAR RECIBO";
            this.btnSaveProducts.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Elephant", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(279, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(358, 33);
            this.label2.TabIndex = 14;
            this.label2.Text = "||  Buscar recibos de ventas ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Elephant", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(92, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 43);
            this.label1.TabIndex = 13;
            this.label1.Text = "Recibos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Elephant", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(203, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(278, 33);
            this.label4.TabIndex = 21;
            this.label4.Text = "Recibos encontrados:";
            // 
            // Recibos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 743);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.btnSaveProducts);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Recibos";
            this.Text = "Recibos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btnSaveProducts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}