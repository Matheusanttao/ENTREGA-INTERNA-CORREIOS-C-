namespace correios
{
    partial class ExcluirLançamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcluirLançamento));
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtbDataEntrada = new System.Windows.Forms.TextBox();
            this.rb90dias = new System.Windows.Forms.RadioButton();
            this.rb30dias = new System.Windows.Forms.RadioButton();
            this.rb20dias = new System.Windows.Forms.RadioButton();
            this.rb7dias = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbNomepuxar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbcodigopuxar = new System.Windows.Forms.TextBox();
            this.txtbCodigoPesquisa = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnvoltar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = global::correios.Properties.Resources.procura;
            this.btnPesquisar.Location = new System.Drawing.Point(710, 121);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(36, 29);
            this.btnPesquisar.TabIndex = 49;
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
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
            this.groupBox1.Controls.Add(this.txtbNomepuxar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtbcodigopuxar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(63, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(684, 233);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "EDITAR";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(14, 133);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(231, 25);
            this.label5.TabIndex = 47;
            this.label5.Text = "DATA DE ENTRADA:";
            // 
            // txtbDataEntrada
            // 
            this.txtbDataEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtbDataEntrada.Location = new System.Drawing.Point(334, 133);
            this.txtbDataEntrada.Margin = new System.Windows.Forms.Padding(2);
            this.txtbDataEntrada.Name = "txtbDataEntrada";
            this.txtbDataEntrada.ReadOnly = true;
            this.txtbDataEntrada.Size = new System.Drawing.Size(336, 31);
            this.txtbDataEntrada.TabIndex = 4;
            // 
            // rb90dias
            // 
            this.rb90dias.AutoSize = true;
            this.rb90dias.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.rb90dias.Location = new System.Drawing.Point(557, 185);
            this.rb90dias.Name = "rb90dias";
            this.rb90dias.Size = new System.Drawing.Size(115, 29);
            this.rb90dias.TabIndex = 8;
            this.rb90dias.TabStop = true;
            this.rb90dias.Text = "90 DIAS";
            this.rb90dias.UseVisualStyleBackColor = true;
            // 
            // rb30dias
            // 
            this.rb30dias.AutoSize = true;
            this.rb30dias.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.rb30dias.Location = new System.Drawing.Point(403, 185);
            this.rb30dias.Name = "rb30dias";
            this.rb30dias.Size = new System.Drawing.Size(115, 29);
            this.rb30dias.TabIndex = 7;
            this.rb30dias.TabStop = true;
            this.rb30dias.Text = "30 DIAS";
            this.rb30dias.UseVisualStyleBackColor = true;
            // 
            // rb20dias
            // 
            this.rb20dias.AutoSize = true;
            this.rb20dias.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.rb20dias.Location = new System.Drawing.Point(263, 187);
            this.rb20dias.Name = "rb20dias";
            this.rb20dias.Size = new System.Drawing.Size(115, 29);
            this.rb20dias.TabIndex = 6;
            this.rb20dias.TabStop = true;
            this.rb20dias.Text = "20 DIAS";
            this.rb20dias.UseVisualStyleBackColor = true;
            // 
            // rb7dias
            // 
            this.rb7dias.AutoSize = true;
            this.rb7dias.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.rb7dias.Location = new System.Drawing.Point(138, 189);
            this.rb7dias.Name = "rb7dias";
            this.rb7dias.Size = new System.Drawing.Size(102, 29);
            this.rb7dias.TabIndex = 5;
            this.rb7dias.TabStop = true;
            this.rb7dias.Text = "7 DIAS";
            this.rb7dias.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(14, 189);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 25);
            this.label3.TabIndex = 41;
            this.label3.Text = "PRAZO:";
            // 
            // txtbNomepuxar
            // 
            this.txtbNomepuxar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtbNomepuxar.Location = new System.Drawing.Point(334, 77);
            this.txtbNomepuxar.Margin = new System.Windows.Forms.Padding(2);
            this.txtbNomepuxar.Name = "txtbNomepuxar";
            this.txtbNomepuxar.ReadOnly = true;
            this.txtbNomepuxar.Size = new System.Drawing.Size(336, 31);
            this.txtbNomepuxar.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 25);
            this.label2.TabIndex = 40;
            this.label2.Text = "NOME DO DESTINATARIO:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 24);
            this.label1.TabIndex = 39;
            this.label1.Text = "CODIGO DE RASTREAMENTO:";
            // 
            // txtbcodigopuxar
            // 
            this.txtbcodigopuxar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbcodigopuxar.Location = new System.Drawing.Point(334, 26);
            this.txtbcodigopuxar.Margin = new System.Windows.Forms.Padding(2);
            this.txtbcodigopuxar.Name = "txtbcodigopuxar";
            this.txtbcodigopuxar.ReadOnly = true;
            this.txtbcodigopuxar.Size = new System.Drawing.Size(336, 29);
            this.txtbcodigopuxar.TabIndex = 2;
            // 
            // txtbCodigoPesquisa
            // 
            this.txtbCodigoPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCodigoPesquisa.Location = new System.Drawing.Point(397, 121);
            this.txtbCodigoPesquisa.Margin = new System.Windows.Forms.Padding(2);
            this.txtbCodigoPesquisa.Name = "txtbCodigoPesquisa";
            this.txtbCodigoPesquisa.Size = new System.Drawing.Size(295, 29);
            this.txtbCodigoPesquisa.TabIndex = 48;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(258, 40);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(307, 29);
            this.label6.TabIndex = 53;
            this.label6.Text = "EXCLUIR LANÇAMENTO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(69, 125);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(313, 24);
            this.label4.TabIndex = 52;
            this.label4.Text = "DIGITE O CODIGO (RASTREIO):";
            // 
            // btnvoltar
            // 
            this.btnvoltar.BackColor = System.Drawing.Color.White;
            this.btnvoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnvoltar.Location = new System.Drawing.Point(173, 420);
            this.btnvoltar.Margin = new System.Windows.Forms.Padding(2);
            this.btnvoltar.Name = "btnvoltar";
            this.btnvoltar.Size = new System.Drawing.Size(200, 50);
            this.btnvoltar.TabIndex = 51;
            this.btnvoltar.Text = "VOLTAR";
            this.btnvoltar.UseVisualStyleBackColor = false;
            this.btnvoltar.Click += new System.EventHandler(this.btnvoltar_Click_1);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.White;
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnExcluir.Location = new System.Drawing.Point(434, 420);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(2);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(197, 50);
            this.btnExcluir.TabIndex = 50;
            this.btnExcluir.Text = "EXCLUIR";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click_1);
            // 
            // ExcluirLançamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 529);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtbCodigoPesquisa);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnvoltar);
            this.Controls.Add(this.btnExcluir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ExcluirLançamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EXCLUIR LANÇAMENTO";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtbDataEntrada;
        private System.Windows.Forms.RadioButton rb90dias;
        private System.Windows.Forms.RadioButton rb30dias;
        private System.Windows.Forms.RadioButton rb20dias;
        private System.Windows.Forms.RadioButton rb7dias;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbNomepuxar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbcodigopuxar;
        private System.Windows.Forms.TextBox txtbCodigoPesquisa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnvoltar;
        private System.Windows.Forms.Button btnExcluir;
    }
}