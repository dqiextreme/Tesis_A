namespace Tesis_A.Control
{
    partial class New_SL2
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.Guardar = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            this.Generar_Grid = new System.Windows.Forms.Button();
            this.Cb_Dimension = new System.Windows.Forms.ComboBox();
            this.Cb_Nivel = new System.Windows.Forms.ComboBox();
            this.Add_Palabra = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Guardar);
            this.panel2.Controls.Add(this.Reset);
            this.panel2.Controls.Add(this.Generar_Grid);
            this.panel2.Controls.Add(this.Cb_Dimension);
            this.panel2.Controls.Add(this.Cb_Nivel);
            this.panel2.Controls.Add(this.Add_Palabra);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(392, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(105, 305);
            this.panel2.TabIndex = 1;
            // 
            // Guardar
            // 
            this.Guardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Guardar.Location = new System.Drawing.Point(14, 174);
            this.Guardar.Name = "Guardar";
            this.Guardar.Size = new System.Drawing.Size(75, 23);
            this.Guardar.TabIndex = 6;
            this.Guardar.Text = "Guardar";
            this.Guardar.UseVisualStyleBackColor = true;
            this.Guardar.Click += new System.EventHandler(this.button4_Click);
            // 
            // Reset
            // 
            this.Reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Reset.Location = new System.Drawing.Point(14, 145);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(75, 23);
            this.Reset.TabIndex = 5;
            this.Reset.Text = "Reiniciar";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.button3_Click);
            // 
            // Generar_Grid
            // 
            this.Generar_Grid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Generar_Grid.Enabled = false;
            this.Generar_Grid.Location = new System.Drawing.Point(14, 60);
            this.Generar_Grid.Name = "Generar_Grid";
            this.Generar_Grid.Size = new System.Drawing.Size(75, 23);
            this.Generar_Grid.TabIndex = 4;
            this.Generar_Grid.Text = "Generar";
            this.Generar_Grid.UseVisualStyleBackColor = true;
            this.Generar_Grid.Click += new System.EventHandler(this.button2_Click);
            // 
            // Cb_Dimension
            // 
            this.Cb_Dimension.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Cb_Dimension.FormattingEnabled = true;
            this.Cb_Dimension.Location = new System.Drawing.Point(2, 33);
            this.Cb_Dimension.Name = "Cb_Dimension";
            this.Cb_Dimension.Size = new System.Drawing.Size(98, 21);
            this.Cb_Dimension.TabIndex = 3;
            this.Cb_Dimension.SelectedIndexChanged += new System.EventHandler(this.Cb_Dimension_SelectedIndexChanged);
            // 
            // Cb_Nivel
            // 
            this.Cb_Nivel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Cb_Nivel.FormattingEnabled = true;
            this.Cb_Nivel.Location = new System.Drawing.Point(2, 6);
            this.Cb_Nivel.Name = "Cb_Nivel";
            this.Cb_Nivel.Size = new System.Drawing.Size(98, 21);
            this.Cb_Nivel.TabIndex = 2;
            // 
            // Add_Palabra
            // 
            this.Add_Palabra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Add_Palabra.Enabled = false;
            this.Add_Palabra.Location = new System.Drawing.Point(14, 116);
            this.Add_Palabra.Name = "Add_Palabra";
            this.Add_Palabra.Size = new System.Drawing.Size(75, 23);
            this.Add_Palabra.TabIndex = 1;
            this.Add_Palabra.Text = "Añadir";
            this.Add_Palabra.UseVisualStyleBackColor = true;
            this.Add_Palabra.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(2, 90);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 305);
            this.panel1.TabIndex = 2;
            // 
            // New_SL2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "New_SL2";
            this.Size = new System.Drawing.Size(497, 305);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Add_Palabra;
        private System.Windows.Forms.ComboBox Cb_Dimension;
        private System.Windows.Forms.ComboBox Cb_Nivel;
        private System.Windows.Forms.Button Generar_Grid;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button Guardar;
    }
}
