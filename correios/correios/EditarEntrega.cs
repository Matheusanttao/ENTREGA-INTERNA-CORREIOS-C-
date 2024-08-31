using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace correios
{
    public partial class EditarEntrega : Form
    {
        public EditarEntrega()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string codigo = txtbCodigoPesquisa.Text.ToUpper();
            var entrega = EntregaManager.Instance.GetEntregaByCodigo(codigo);

            if (entrega != null)
            {
                txtbcodigopuxar.Text = entrega.Codigo;
                txtbNomepuxar.Text = entrega.Nome;
                txtbDataEntrada.Text = entrega.DataEntrada.ToString("dd/MM/yyyy");

               
                switch (entrega.TipoEntrega)
                {
                    case "N":
                        rb7dias.Checked = true;
                        break;
                    case "I":
                        rb20dias.Checked = true;
                        break;
                    case "CP":
                        rb30dias.Checked = true;
                        break;
                    case "R":
                        rb90dias.Checked = true;
                        break;
                }
            }
            else
            {
                MessageBox.Show("Código de rastreamento não encontrado.", "Erro de Pesquisa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetTipoEntrega()
        {
            if (rb7dias.Checked)
                return "N";
            if (rb20dias.Checked)
                return "I";
            if (rb30dias.Checked)
                return "CP";
            if (rb90dias.Checked)
                return "R";
            return null;
        }

        private bool ValidaCodigo(string codigo)
        {
            return Regex.IsMatch(codigo, "^[A-Za-z]{2}\\d{9}[A-Za-z]{2}$");
        }

        private DateTime CalcularPrazoDevolucao(DateTime dataEntrada, string tipoEntrega)
        {
            switch (tipoEntrega.ToUpper())
            {
                case "CP":
                    return dataEntrada.AddDays(30);
                case "I":
                    return dataEntrada.AddDays(20);
                case "R":
                    return dataEntrada.AddDays(90);
                default:
                    return dataEntrada.AddDays(7);
            }
        }

        private void btnsalvar_Click(object sender, EventArgs e)
        {
            string codigo = txtbcodigopuxar.Text.ToUpper();
            string nome = txtbNomepuxar.Text.ToUpper();
            string tipoEntrega = GetTipoEntrega();

           
            DateTime dataEntrada;
            if (!DateTime.TryParseExact(txtbDataEntrada.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataEntrada))
            {
                MessageBox.Show("Por favor, insira uma data de entrada válida no formato dd/MM/yyyy.");
                txtbDataEntrada.Focus();
                return;
            }

          
            if (string.IsNullOrWhiteSpace(codigo) || !ValidaCodigo(codigo))
            {
                MessageBox.Show("Por favor, insira um código de rastreamento válido.");
                txtbcodigopuxar.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Por favor, insira o nome do destinatário.");
                txtbNomepuxar.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tipoEntrega))
            {
                MessageBox.Show("Por favor, selecione um tipo de entrega válido.", "Erro de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var entrega = EntregaManager.Instance.GetEntregaByCodigo(codigo);
            if (entrega != null)
            {
                entrega.Nome = nome;
                entrega.TipoEntrega = tipoEntrega;
                entrega.DataEntrada = dataEntrada;

          
                entrega.PrazoDevolucao = CalcularPrazoDevolucao(dataEntrada, tipoEntrega);

              
                EntregaManager.Instance.SerializarEntregas();

                MessageBox.Show("Entrega atualizada com sucesso!");
                txtbCodigoPesquisa.Text = "";
                txtbcodigopuxar.Text = "";
                txtbNomepuxar.Text = "";
                groupBox1.Text = "";
                txtbDataEntrada.Text = "";
                rb7dias.Checked = false;
                rb20dias.Checked = false;
                rb30dias.Checked = false;
                rb90dias.Checked = false;
            }
            else
            {
                MessageBox.Show("Erro ao atualizar a entrega. Código de rastreamento não encontrado.", "Erro de Atualização", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnvoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
