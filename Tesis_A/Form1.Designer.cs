namespace Tesis_A
{
    partial class Form1
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.TabControl_1 = new System.Windows.Forms.TabControl();
            this.Juego_Selec = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Bt_Memoria = new System.Windows.Forms.Button();
            this.Bt_Laberinto = new System.Windows.Forms.Button();
            this.Juego_G = new System.Windows.Forms.TabPage();
            this.Juego_Res = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.Res_Laberinto = new System.Windows.Forms.TabPage();
            this.Laberinto_Dg = new System.Windows.Forms.DataGridView();
            this.Res_Memoria = new System.Windows.Forms.TabPage();
            this.Memoria_Dg = new System.Windows.Forms.DataGridView();
            this.Juego_Admin = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Adm_Laberinto = new System.Windows.Forms.TabPage();
            this.adm_Laberinto1 = new Tesis_A.Control.Adm_Laberinto();
            this.Sopa_Letras = new System.Windows.Forms.TabPage();
            this.new_SL21 = new Tesis_A.Control.New_SL2();
            this.TabControl_1.SuspendLayout();
            this.Juego_Selec.SuspendLayout();
            this.Juego_Res.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.Res_Laberinto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Laberinto_Dg)).BeginInit();
            this.Res_Memoria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Memoria_Dg)).BeginInit();
            this.Juego_Admin.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Adm_Laberinto.SuspendLayout();
            this.Sopa_Letras.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl_1
            // 
            this.TabControl_1.Controls.Add(this.Juego_Selec);
            this.TabControl_1.Controls.Add(this.Juego_G);
            this.TabControl_1.Controls.Add(this.Juego_Res);
            this.TabControl_1.Controls.Add(this.Juego_Admin);
            this.TabControl_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl_1.Location = new System.Drawing.Point(0, 0);
            this.TabControl_1.Name = "TabControl_1";
            this.TabControl_1.SelectedIndex = 0;
            this.TabControl_1.Size = new System.Drawing.Size(584, 562);
            this.TabControl_1.TabIndex = 0;
            // 
            // Juego_Selec
            // 
            this.Juego_Selec.Controls.Add(this.button5);
            this.Juego_Selec.Controls.Add(this.button4);
            this.Juego_Selec.Controls.Add(this.button3);
            this.Juego_Selec.Controls.Add(this.Bt_Memoria);
            this.Juego_Selec.Controls.Add(this.Bt_Laberinto);
            this.Juego_Selec.Location = new System.Drawing.Point(4, 22);
            this.Juego_Selec.Name = "Juego_Selec";
            this.Juego_Selec.Padding = new System.Windows.Forms.Padding(3);
            this.Juego_Selec.Size = new System.Drawing.Size(576, 536);
            this.Juego_Selec.TabIndex = 0;
            this.Juego_Selec.Text = "Seleccionar Juego";
            this.Juego_Selec.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(455, 223);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(90, 90);
            this.button5.TabIndex = 5;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(349, 223);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 90);
            this.button4.TabIndex = 4;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(243, 223);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 90);
            this.button3.TabIndex = 3;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Bt_Memoria
            // 
            this.Bt_Memoria.Location = new System.Drawing.Point(137, 223);
            this.Bt_Memoria.Name = "Bt_Memoria";
            this.Bt_Memoria.Size = new System.Drawing.Size(90, 90);
            this.Bt_Memoria.TabIndex = 2;
            this.Bt_Memoria.Text = "Memoria";
            this.Bt_Memoria.UseVisualStyleBackColor = true;
            this.Bt_Memoria.Click += new System.EventHandler(this.button2_Click);
            // 
            // Bt_Laberinto
            // 
            this.Bt_Laberinto.Location = new System.Drawing.Point(31, 223);
            this.Bt_Laberinto.Name = "Bt_Laberinto";
            this.Bt_Laberinto.Size = new System.Drawing.Size(90, 90);
            this.Bt_Laberinto.TabIndex = 1;
            this.Bt_Laberinto.Text = "Laberinto";
            this.Bt_Laberinto.UseVisualStyleBackColor = true;
            this.Bt_Laberinto.Click += new System.EventHandler(this.button1_Click);
            // 
            // Juego_G
            // 
            this.Juego_G.Location = new System.Drawing.Point(4, 22);
            this.Juego_G.Name = "Juego_G";
            this.Juego_G.Padding = new System.Windows.Forms.Padding(3);
            this.Juego_G.Size = new System.Drawing.Size(576, 536);
            this.Juego_G.TabIndex = 1;
            this.Juego_G.Text = "Juego";
            this.Juego_G.UseVisualStyleBackColor = true;
            // 
            // Juego_Res
            // 
            this.Juego_Res.Controls.Add(this.tabControl2);
            this.Juego_Res.Location = new System.Drawing.Point(4, 22);
            this.Juego_Res.Name = "Juego_Res";
            this.Juego_Res.Padding = new System.Windows.Forms.Padding(3);
            this.Juego_Res.Size = new System.Drawing.Size(576, 536);
            this.Juego_Res.TabIndex = 2;
            this.Juego_Res.Text = "Resultados";
            this.Juego_Res.UseVisualStyleBackColor = true;
            this.Juego_Res.Enter += new System.EventHandler(this.Res_Lab);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.Res_Laberinto);
            this.tabControl2.Controls.Add(this.Res_Memoria);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(570, 530);
            this.tabControl2.TabIndex = 0;
            // 
            // Res_Laberinto
            // 
            this.Res_Laberinto.Controls.Add(this.Laberinto_Dg);
            this.Res_Laberinto.Location = new System.Drawing.Point(4, 22);
            this.Res_Laberinto.Name = "Res_Laberinto";
            this.Res_Laberinto.Padding = new System.Windows.Forms.Padding(3);
            this.Res_Laberinto.Size = new System.Drawing.Size(562, 504);
            this.Res_Laberinto.TabIndex = 0;
            this.Res_Laberinto.Text = "Laberinto";
            this.Res_Laberinto.UseVisualStyleBackColor = true;
            this.Res_Laberinto.Enter += new System.EventHandler(this.Res_Lab);
            // 
            // Laberinto_Dg
            // 
            this.Laberinto_Dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Laberinto_Dg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Laberinto_Dg.Location = new System.Drawing.Point(3, 3);
            this.Laberinto_Dg.Name = "Laberinto_Dg";
            this.Laberinto_Dg.Size = new System.Drawing.Size(556, 498);
            this.Laberinto_Dg.TabIndex = 0;
            // 
            // Res_Memoria
            // 
            this.Res_Memoria.Controls.Add(this.Memoria_Dg);
            this.Res_Memoria.Location = new System.Drawing.Point(4, 22);
            this.Res_Memoria.Name = "Res_Memoria";
            this.Res_Memoria.Padding = new System.Windows.Forms.Padding(3);
            this.Res_Memoria.Size = new System.Drawing.Size(562, 504);
            this.Res_Memoria.TabIndex = 1;
            this.Res_Memoria.Text = "Memoria";
            this.Res_Memoria.UseVisualStyleBackColor = true;
            this.Res_Memoria.Enter += new System.EventHandler(this.Res_Mem);
            // 
            // Memoria_Dg
            // 
            this.Memoria_Dg.AllowUserToAddRows = false;
            this.Memoria_Dg.AllowUserToDeleteRows = false;
            this.Memoria_Dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Memoria_Dg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Memoria_Dg.Location = new System.Drawing.Point(3, 3);
            this.Memoria_Dg.Name = "Memoria_Dg";
            this.Memoria_Dg.ReadOnly = true;
            this.Memoria_Dg.Size = new System.Drawing.Size(556, 498);
            this.Memoria_Dg.TabIndex = 0;
            // 
            // Juego_Admin
            // 
            this.Juego_Admin.Controls.Add(this.tabControl1);
            this.Juego_Admin.Location = new System.Drawing.Point(4, 22);
            this.Juego_Admin.Name = "Juego_Admin";
            this.Juego_Admin.Padding = new System.Windows.Forms.Padding(3);
            this.Juego_Admin.Size = new System.Drawing.Size(576, 536);
            this.Juego_Admin.TabIndex = 3;
            this.Juego_Admin.Text = "Administracion";
            this.Juego_Admin.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Adm_Laberinto);
            this.tabControl1.Controls.Add(this.Sopa_Letras);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(570, 530);
            this.tabControl1.TabIndex = 0;
            // 
            // Adm_Laberinto
            // 
            this.Adm_Laberinto.Controls.Add(this.adm_Laberinto1);
            this.Adm_Laberinto.Location = new System.Drawing.Point(4, 22);
            this.Adm_Laberinto.Name = "Adm_Laberinto";
            this.Adm_Laberinto.Padding = new System.Windows.Forms.Padding(3);
            this.Adm_Laberinto.Size = new System.Drawing.Size(562, 504);
            this.Adm_Laberinto.TabIndex = 0;
            this.Adm_Laberinto.Text = "Laberinto";
            this.Adm_Laberinto.UseVisualStyleBackColor = true;
            // 
            // adm_Laberinto1
            // 
            this.adm_Laberinto1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adm_Laberinto1.Location = new System.Drawing.Point(3, 3);
            this.adm_Laberinto1.Name = "adm_Laberinto1";
            this.adm_Laberinto1.Size = new System.Drawing.Size(556, 498);
            this.adm_Laberinto1.TabIndex = 0;
            // 
            // Sopa_Letras
            // 
            this.Sopa_Letras.Controls.Add(this.new_SL21);
            this.Sopa_Letras.Location = new System.Drawing.Point(4, 22);
            this.Sopa_Letras.Name = "Sopa_Letras";
            this.Sopa_Letras.Padding = new System.Windows.Forms.Padding(3);
            this.Sopa_Letras.Size = new System.Drawing.Size(562, 504);
            this.Sopa_Letras.TabIndex = 1;
            this.Sopa_Letras.Text = "Sopa Letras";
            this.Sopa_Letras.UseVisualStyleBackColor = true;
            // 
            // new_SL21
            // 
            this.new_SL21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.new_SL21.Location = new System.Drawing.Point(3, 3);
            this.new_SL21.Name = "new_SL21";
            this.new_SL21.Size = new System.Drawing.Size(556, 498);
            this.new_SL21.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.TabControl_1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Juegos Didacticos";
            this.TabControl_1.ResumeLayout(false);
            this.Juego_Selec.ResumeLayout(false);
            this.Juego_Res.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.Res_Laberinto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Laberinto_Dg)).EndInit();
            this.Res_Memoria.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Memoria_Dg)).EndInit();
            this.Juego_Admin.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.Adm_Laberinto.ResumeLayout(false);
            this.Sopa_Letras.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl_1;
        private System.Windows.Forms.TabPage Juego_G;
        private System.Windows.Forms.TabPage Juego_Res;
        private System.Windows.Forms.TabPage Juego_Selec;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button Bt_Memoria;
        private System.Windows.Forms.Button Bt_Laberinto;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage Res_Laberinto;
        private System.Windows.Forms.TabPage Res_Memoria;
        private System.Windows.Forms.DataGridView Laberinto_Dg;
        private System.Windows.Forms.TabPage Juego_Admin;
        private System.Windows.Forms.DataGridView Memoria_Dg;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Adm_Laberinto;
        private Control.Adm_Laberinto adm_Laberinto1;
        private System.Windows.Forms.TabPage Sopa_Letras;
        private Control.New_SL2 new_SL21;
    }
}

