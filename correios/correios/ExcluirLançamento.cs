using System;
using System.Windows.Forms;

namespace correios
{
    public partial class ExcluirLançamento : Form
    {
        public ExcluirLançamento()
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

        
        private void LimparCampos()
        {
            txtbcodigopuxar.Clear();
            txtbNomepuxar.Clear();
            txtbDataEntrada.Clear();
            rb7dias.Checked = false;
            rb20dias.Checked = false;
            rb30dias.Checked = false;
            rb90dias.Checked = false;
        }

       
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            string codigo = txtbcodigopuxar.Text.ToUpper();

            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("Por favor, insira um código de rastreamento válido.");
                txtbcodigopuxar.Focus();
                return;
            }

            var entrega = EntregaManager.Instance.GetEntregaByCodigo(codigo);

            if (entrega != null)
            {
                var confirmResult = MessageBox.Show("Tem certeza que deseja excluir esta entrega?",
                                                     "Confirmar Exclusão",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {

                    EntregaManager.Instance.RemoverEntrega(entrega);
                    EntregaManager.Instance.SerializarEntregas();

                    MessageBox.Show("Entrega excluída com sucesso!");

                    LimparCampos();
                }
            }
            else
            {
                MessageBox.Show("Erro ao excluir a entrega. Código de rastreamento não encontrado.", "Erro de Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnvoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
