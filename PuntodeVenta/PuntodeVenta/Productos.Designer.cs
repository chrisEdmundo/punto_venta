namespace PuntodeVenta
{
    partial class Productos
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddProducts = new System.Windows.Forms.Button();
            this.btnSaveProducts = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Elephant", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(120, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "Productos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Elephant", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(260, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "|| Ingreso de productos";
            // 
            // btnAddProducts
            // 
            this.btnAddProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAddProducts.FlatAppearance.BorderSize = 0;
            this.btnAddProducts.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnAddProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProducts.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProducts.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddProducts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddProducts.Location = new System.Drawing.Point(214, 479);
            this.btnAddProducts.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddProducts.Name = "btnAddProducts";
            this.btnAddProducts.Size = new System.Drawing.Size(174, 37);
            this.btnAddProducts.TabIndex = 3;
            this.btnAddProducts.Text = "AGREGAR PRODUCTO";
            this.btnAddProducts.UseVisualStyleBackColor = false;
            // 
            // btnSaveProducts
            // 
            this.btnSaveProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSaveProducts.FlatAppearance.BorderSize = 0;
            this.btnSaveProducts.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSaveProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveProducts.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveProducts.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveProducts.Image = global::PuntodeVenta.Properties.Resources.folder_add_icon_icons_com_52433;
            this.btnSaveProducts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveProducts.Location = new System.Drawing.Point(654, 215);
            this.btnSaveProducts.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSaveProducts.Name = "btnSaveProducts";
            this.btnSaveProducts.Size = new System.Drawing.Size(213, 61);
            this.btnSaveProducts.TabIndex = 4;
            this.btnSaveProducts.Text = "        GUARDAR         PRODUCTOS";
            this.btnSaveProducts.UseVisualStyleBackColor = false;
            // 
            // Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 619);
            this.Controls.Add(this.btnSaveProducts);
            this.Controls.Add(this.btnAddProducts);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Productos";
            this.Text = "Productos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddProducts;
        private System.Windows.Forms.Button btnSaveProducts;
    }
}