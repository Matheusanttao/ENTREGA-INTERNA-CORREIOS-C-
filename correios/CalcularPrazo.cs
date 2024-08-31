using System;
using System.Drawing;
using System.Windows.Forms;

namespace correios
{
    public partial class CalcularPrazo : Form
    {
        public CalcularPrazo()
        {
            InitializeComponent();
        }
        
        private void btnpesquisar_Click(object sender, EventArgs e)
        {
            // Verifica se algum radio button foi selecionado
            if (!rb7dias.Checked && !rb20dias.Checked && !rb30dias.Checked && !rb90dias.Checked)
            {
                MessageBox.Show("Por favor, selecione um prazo de entrega.");
                return;
            }

            // Verifica se o campo de data de entrada está preenchido
            if (txtbDataEntrada.Text.Trim() == "")
            {
                MessageBox.Show("Por favor, insira uma data de entrada válida.");
                return;
            }

            DateTime dataEntrada;
            if (!DateTime.TryParse(txtbDataEntrada.Text, out dataEntrada))
            {
                MessageBox.Show("Formato de data inválido. Por favor, insira uma data válida.");
                return;
            }

            int dias = 0;

            // Determina o número de dias com base no radio button selecionado
            if (rb7dias.Checked)
                dias = 7;
            else if (rb20dias.Checked)
                dias = 20;
            else if (rb30dias.Checked)
                dias = 30;
            else if (rb90dias.Checked)
            {

                dias = 90;
            }

            DateTime dataPrevistaClienteRetirar = dataEntrada.AddDays(dias - 1);
            // Calcula a data prevista para entrega
            // Define uma nova fonte para a mensagem do MessageBox
            DateTime dataPrevista = dataEntrada.AddDays(dias);
            MessageBox.Show($"Data prevista para o cliente retirar: {dataPrevistaClienteRetirar.ToShortDateString()} \nData prevista para devolver no sara: {dataPrevista.ToShortDateString()}");
        }


        private void btnvoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtbDataEntrada_TextChanged(object sender, EventArgs e)
        {
            // Se desejar alguma validação adicional ou formatação da entrada de data
        }

        // Métodos para lidar com a seleção dos radio buttons (se necessário)
        private void rb7dias_CheckedChanged(object sender, EventArgs e)
        {
            // Implemente lógica específica se necessário
        }

        private void rb20dias_CheckedChanged(object sender, EventArgs e)
        {
            // Implemente lógica específica se necessário
        }

        private void rb30dias_CheckedChanged(object sender, EventArgs e)
        {
            // Implemente lógica específica se necessário
        }

        private void rb90dias_CheckedChanged(object sender, EventArgs e)
        {
            // Implemente lógica específica se necessário
        }

        private void btnpesqusar_Click(object sender, EventArgs e)
        {
            // Chama o método de pesquisa ao clicar no botão "Pesquisar"
            btnpesquisar_Click(sender, e);
        }
    }
}
