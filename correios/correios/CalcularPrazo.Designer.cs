namespace correios
{
    partial class CalcularPrazo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalcularPrazo));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtbDataEntrada = new System.Windows.Forms.TextBox();
            this.rb90dias = new System.Windows.Forms.RadioButton();
            this.rb30dias = new System.Windows.Forms.RadioButton();
            this.rb20dias = new System.Windows.Forms.RadioButton();
            this.rb7dias = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.btnvoltar = new System.Windows.Forms.Button();
            this.btnpesqusar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtbDataEntrada);
            this.groupBox1.Controls.Add(this.rb90dias);
            this.groupBox1.Controls.Add(this.rb30dias);
            this.groupBox1.Controls.Add(this.rb20dias);
            this.groupBox1.Controls.Add(this.rb7dias);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(21, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(684, 144);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CALCULAR";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(17, 38);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(231, 25);
            this.label5.TabIndex = 47;
            this.label5.Text = "DATA DE ENTRADA:";
            // 
            // txtbDataEntrada
            // 
            this.txtbDataEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtbDataEntrada.Location = new System.Drawing.Point(337, 38);
            this.txtbDataEntrada.Margin = new System.Windows.Forms.Padding(2);
            this.txtbDataEntrada.Name = "txtbDataEntrada";
            this.txtbDataEntrada.Size = new System.Drawing.Size(336, 31);
            this.txtbDataEntrada.TabIndex = 4;
            this.txtbDataEntrada.TextChanged += new System.EventHandler(this.txtbDataEntrada_TextChanged);
            // 
            // rb90dias
            // 
            this.rb90dias.AutoSize = true;
            this.rb90dias.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.rb90dias.Location = new System.Drawing.Point(560, 90);
            this.rb90dias.Name = "rb90dias";
            this.rb90dias.Size = new System.Drawing.Size(115, 29);
            this.rb90dias.TabIndex = 8;
            this.rb90dias.TabStop = true;
            this.rb90dias.Text = "90 DIAS";
            this.rb90dias.UseVisualStyleBackColor = true;
            this.rb90dias.CheckedChanged += new System.EventHandler(this.rb90dias_CheckedChanged);
            // 
            // rb30dias
            // 
            this.rb30dias.AutoSize = true;
            this.rb30dias.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.rb30dias.Location = new System.Drawing.Point(406, 90);
            this.rb30dias.Name = "rb30dias";
            this.rb30dias.Size = new System.Drawing.Size(115, 29);
            this.rb30dias.TabIndex = 7;
            this.rb30dias.TabStop = true;
            this.rb30dias.Text = "30 DIAS";
            this.rb30dias.UseVisualStyleBackColor = true;
            this.rb30dias.CheckedChanged += new System.EventHandler(this.rb30dias_CheckedChanged);
            // 
            // rb20dias
            // 
            this.rb20dias.AutoSize = true;
            this.rb20dias.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.rb20dias.Location = new System.Drawing.Point(266, 92);
            this.rb20dias.Name = "rb20dias";
            this.rb20dias.Size = new System.Drawing.Size(115, 29);
            this.rb20dias.TabIndex = 6;
            this.rb20dias.TabStop = true;
            this.rb20dias.Text = "20 DIAS";
            this.rb20dias.UseVisualStyleBackColor = true;
            this.rb20dias.CheckedChanged += new System.EventHandler(this.rb20dias_CheckedChanged);
            // 
            // rb7dias
            // 
            this.rb7dias.AutoSize = true;
            this.rb7dias.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.rb7dias.Location = new System.Drawing.Point(141, 94);
            this.rb7dias.Name = "rb7dias";
            this.rb7dias.Size = new System.Drawing.Size(102, 29);
            this.rb7dias.TabIndex = 5;
            this.rb7dias.TabStop = true;
            this.rb7dias.Text = "7 DIAS";
            this.rb7dias.UseVisualStyleBackColor = true;
            this.rb7dias.CheckedChanged += new System.EventHandler(this.rb7dias_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(17, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 25);
            this.label3.TabIndex = 41;
            this.label3.Text = "PRAZO:";
            // 
            // btnvoltar
            // 
            this.btnvoltar.BackColor = System.Drawing.Color.White;
            this.btnvoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnvoltar.Location = new System.Drawing.Point(121, 272);
            this.btnvoltar.Margin = new System.Windows.Forms.Padding(2);
            this.btnvoltar.Name = "btnvoltar";
            this.btnvoltar.Size = new System.Drawing.Size(200, 50);
            this.btnvoltar.TabIndex = 49;
            this.btnvoltar.Text = "VOLTAR";
            this.btnvoltar.UseVisualStyleBackColor = false;
            this.btnvoltar.Click += new System.EventHandler(this.btnvoltar_Click);
            // 
            // btnpesqusar
            // 
            this.btnpesqusar.BackColor = System.Drawing.Color.White;
            this.btnpesqusar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnpesqusar.Location = new System.Drawing.Point(398, 272);
            this.btnpesqusar.Margin = new System.Windows.Forms.Padding(2);
            this.btnpesqusar.Name = "btnpesqusar";
            this.btnpesqusar.Size = new System.Drawing.Size(197, 50);
            this.btnpesqusar.TabIndex = 48;
            this.btnpesqusar.Text = "PESQUISAR";
            this.btnpesqusar.UseVisualStyleBackColor = false;
            this.btnpesqusar.Click += new System.EventHandler(this.btnpesqusar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(157, 26);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(395, 29);
            this.label6.TabIndex = 51;
            this.label6.Text = "CALCULAR PRAZO PARA AVISO";
            // 
            // CalcularPrazo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 352);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnvoltar);
            this.Controls.Add(this.btnpesqusar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CalcularPrazo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CALCULAR PRAZO DE AVISO";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtbDataEntrada;
        private System.Windows.Forms.RadioButton rb90dias;
        private System.Windows.Forms.RadioButton rb30dias;
        private System.Windows.Forms.RadioButton rb20dias;
        private System.Windows.Forms.RadioButton rb7dias;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnvoltar;
        private System.Windows.Forms.Button btnpesqusar;
        private System.Windows.Forms.Label label6;
    }
}