using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace correios
{
    public partial class Listarentregasbaixadas : Form
    {
        private List<CadastroEntregaProxy> entregas;
        private List<CadastroEntregaProxy> entregasSelecionadas;

        public Listarentregasbaixadas()
        {
            InitializeComponent();
            dgvListarEntregasBaixadas.Font = new Font("Arial", 15); // Ajuste o tipo de fonte e o tamanho conforme necessário
            dgvListarEntregasBaixadas.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 16, FontStyle.Bold);
            CarregarEntregasBaixadas();
        }

       private void CarregarEntregasBaixadas()
        {
            string caminhoArquivo = @"C:\correios\EntregasBaixadas\EntregasBaixadas.xml";

            try
            {
                if (File.Exists(caminhoArquivo))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<CadastroEntregaProxy>));

                    using (StreamReader reader = new StreamReader(caminhoArquivo))
                    {
                        entregas = (List<CadastroEntregaProxy>)serializer.Deserialize(reader);
                    }

                    ExibirEntregas(entregas);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao carregar as entregas baixadas: {ex.Message}");
            }
        }

        private void ExibirEntregas(List<CadastroEntregaProxy> entregas)
        {
            dgvListarEntregasBaixadas.Rows.Clear();

            // Adiciona as colunas ao DataGridView
            dgvListarEntregasBaixadas.Columns.Clear();
            dgvListarEntregasBaixadas.Columns.Add("Numero", "Nº");
            dgvListarEntregasBaixadas.Columns.Add("Nome", "NOME");
            dgvListarEntregasBaixadas.Columns.Add("Codigo", "CÓDIGO");
            dgvListarEntregasBaixadas.Columns.Add("DataEntrada", "ENTRADA");
            dgvListarEntregasBaixadas.Columns.Add("DataBaixa", "BAIXA");
            dgvListarEntregasBaixadas.Columns.Add("Observacao", "OBSERVAÇÃO");

            // Ajuste das larguras das colunas
            dgvListarEntregasBaixadas.Columns["Numero"].Width = 70; // Largura da coluna Nº
            dgvListarEntregasBaixadas.Columns["Nome"].Width = 200; // Largura da coluna NOME
            dgvListarEntregasBaixadas.Columns["Codigo"].Width = 200; // Largura da coluna CÓDIGO
            dgvListarEntregasBaixadas.Columns["DataEntrada"].Width = 170; // Largura da coluna ENTRADA
            dgvListarEntregasBaixadas.Columns["DataBaixa"].Width = 170; // Largura da coluna BAIXA
            dgvListarEntregasBaixadas.Columns["Observacao"].Width = 200; // Largura da coluna OBSERVAÇÃO

            int contador = 1;
            foreach (var entrega in entregas)
            {
                string numero = contador.ToString();
                string nome = entrega.Nome;
                string codigo = entrega.Codigo;
                string dataEntrada = entrega.DataEntrada.ToString("dd/MM/yyyy");
                string dataBaixa = entrega.DataBaixa?.ToString("dd/MM/yyyy") ?? "";
                string observacao = entrega.Observacao ?? "";

                dgvListarEntregasBaixadas.Rows.Add(numero, nome, codigo, dataEntrada, dataBaixa, observacao);

                contador++;
            }
        }

        private void dgvListarEntregasBaixadas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Exemplo: obter os valores da linha clicada
                DataGridViewRow row = dgvListarEntregasBaixadas.Rows[e.RowIndex];
                string numero = row.Cells["Numero"].Value.ToString();
                string nome = row.Cells["Nome"].Value.ToString();
                string codigo = row.Cells["Codigo"].Value.ToString();
                string dataEntrada = row.Cells["DataEntrada"].Value.ToString();
                string dataBaixa = row.Cells["DataBaixa"].Value.ToString();
                string observacao = row.Cells["Observacao"].Value.ToString();

                // Exemplo de exibição dos dados
                MessageBox.Show($"Número: {numero}\nNome: {nome}\nCódigo: {codigo}\nData Entrada: {dataEntrada}\nData Baixa: {dataBaixa}\nObservação: {observacao}");
            }
        }

        private void button2_Click(object sender, EventArgs e) // Botão de imprimir
        {
            // Implemente a lógica de impressão aqui, se necessário
        }

        private void button1_Click(object sender, EventArgs e) // Botão de sair
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Verifica se as entregas foram carregadas antes de tentar pesquisar
            if (entregas == null)
                return;

            // Obtém o termo de pesquisa do TextBox
            string termoPesquisa = textBox1.Text.ToLower();

            // Filtra as entregas com base no termo de pesquisa
            entregasSelecionadas = entregas.Where(entrega =>
                entrega.Nome.ToLower().Contains(termoPesquisa) ||
                (entrega.DataBaixa.HasValue && entrega.DataBaixa.Value.ToString("dd/MM/yyyy").Contains(termoPesquisa)) ||
                entrega.Codigo.ToLower().Contains(termoPesquisa))
                .ToList();

            // Exibe as entregas filtradas no DataGridView
            ExibirEntregas(entregasSelecionadas);
        }

        private void Listarentregasbaixadas_Load(object sender, EventArgs e)
        {

        }
    }
}
