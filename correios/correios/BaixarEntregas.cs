using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace correios
{
    public partial class BaixarEntregas : Form
    {
        private string observacao = ""; // Variável para armazenar a observação

        public BaixarEntregas()
        {
            InitializeComponent();
            textBox1.KeyDown += TextBox1_KeyDown; // Associa o evento KeyDown do textBox1
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick(); // Simula o clique no botão de baixar quando Enter é pressionado
            }
        }

        private void BaixarEntregas_Load(object sender, EventArgs e)
        {
            txtbinformações.Visible = false; // Inicializa o TextBox como invisível
        }

        private void rdbOutros_CheckedChanged(object sender, EventArgs e)
        {
            txtbinformações.Visible = rdbOutros.Checked; // Ativa ou desativa o TextBox de observação personalizada
        }

        private void rdbEntregue_CheckedChanged(object sender, EventArgs e)
        {
            txtbinformações.Visible = false;
        }

        private void rbremetente_CheckedChanged(object sender, EventArgs e)
        {
            txtbinformações.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtém o código de rastreamento digitado pelo usuário
            string codigoRastreamento = textBox1.Text.ToUpper();

            // Verifica se o código de rastreamento é válido
            if (string.IsNullOrWhiteSpace(codigoRastreamento))
            {
                MessageBox.Show("Por favor, insira um código de rastreamento.");
                return;
            }

            // Obtém a entrega com base no código de rastreamento
            CadastroEntregaProxy entrega = EntregaManager.Instance.GetEntregaByCodigo(codigoRastreamento);
            if (entrega == null)
            {
                MessageBox.Show($"O código de rastreamento {codigoRastreamento} não corresponde a nenhuma entrega cadastrada.", "Erro para baixar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica qual observação foi selecionada
            if (rdbEntregue.Checked)
            {
                observacao = "Entregue";
            }
            else if (rbremetente.Checked)
            {
                observacao = "Encaminhado ao Remetente";
            }
            else if (rdbOutros.Checked)
            {
                observacao = txtbinformações.Text; // Utiliza a observação personalizada
            }
            else
            {
                observacao = ""; // Caso nenhum esteja selecionado
            }

            // Verifica se foi preenchida uma observação
            if (string.IsNullOrWhiteSpace(observacao))
            {
                MessageBox.Show("Por favor, selecione uma observação.", "Observação não selecionada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Adiciona a observação à entrega
            entrega.Observacao = observacao;

            // Adiciona a data da baixa à entrega
            entrega.DataBaixa = DateTime.Now;

            // Remove a entrega da lista de entregas cadastradas
            EntregaManager.Instance.RemoverEntrega(entrega);

            // Limpa os campos de texto
            textBox1.Text = "";
            txtbinformações.Text = "";

            // Código para salvar a entrega baixada em um arquivo XML na pasta "C:\correios\EntregasBaixadas"
            string caminhoArquivo = @"C:\correios\EntregasBaixadas\EntregasBaixadas.xml"; // Caminho completo do arquivo XML para as entregas baixadas

            try
            {
                // Cria a pasta "C:\correios\EntregasBaixadas" se ela não existir
                Directory.CreateDirectory(@"C:\correios\EntregasBaixadas");

                // Declara a variável serializer fora do bloco if
                XmlSerializer serializer = new XmlSerializer(typeof(List<CadastroEntregaProxy>));

                // Verifica se o arquivo XML existe
                List<CadastroEntregaProxy> entregasBaixadas;
                if (File.Exists(caminhoArquivo))
                {
                    // Se existir, carrega as entregas baixadas do arquivo XML
                    using (StreamReader reader = new StreamReader(caminhoArquivo))
                    {
                        entregasBaixadas = (List<CadastroEntregaProxy>)serializer.Deserialize(reader);
                    }
                }
                else
                {
                    // Se não existir, cria uma nova lista de entregas baixadas
                    entregasBaixadas = new List<CadastroEntregaProxy>();
                }

                // Adiciona a entrega baixada à lista de entregas baixadas
                entregasBaixadas.Add(entrega);

                // Serializa a lista de entregas baixadas para o arquivo XML
                using (StreamWriter writer = new StreamWriter(caminhoArquivo))
                {
                    serializer.Serialize(writer, entregasBaixadas);
                }

                // Exibe uma mensagem de sucesso
                MessageBox.Show($"Entrega baixada com sucesso!");

                // Retorna o foco para o textBox1
                textBox1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao salvar a entrega baixada: {ex.Message}");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtbinformações_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
