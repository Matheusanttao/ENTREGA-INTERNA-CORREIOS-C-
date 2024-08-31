using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace correios
{
    public partial class Listarentregas : Form
    {
        private List<CadastroEntregaProxy> entregas; // Lista de entregas como campo privado
        private List<CadastroEntregaProxy> entregasSelecionadas; // Lista para armazenar entregas selecionadas

        public Listarentregas()
        {
            InitializeComponent();
            // Configurar DataGridView
            ConfigureDataGridView();
        }

        private void Listarentregas_Load(object sender, EventArgs e)
        {
            // Carregar as entregas do arquivo XML
            entregas = CarregarEntregas();

            // Ordenar as entregas por data de devolução (em ordem crescente)
            entregas = entregas.OrderBy(entrega => entrega.PrazoDevolucao).ToList();

            // Exibir as entregas no DataGridView
            ExibirEntregas(entregas);
        }

        private void ConfigureDataGridView()
        {
            // Limpar as colunas existentes para garantir que apenas as colunas desejadas sejam configuradas
            dgvListarEntregas.Columns.Clear();

            // Adicionar as colunas desejadas
            dgvListarEntregas.ColumnCount = 6; // Número de colunas desejadas

            // Definir nomes das colunas
            dgvListarEntregas.Columns[0].Name = "N°"; // Nova coluna para números
            dgvListarEntregas.Columns[1].Name = "Código";
            dgvListarEntregas.Columns[2].Name = "Nome";
            dgvListarEntregas.Columns[3].Name = "Tipo";
            dgvListarEntregas.Columns[4].Name = "Entrada";
            dgvListarEntregas.Columns[5].Name = "Devolução";

            // Definir larguras específicas para cada coluna
            dgvListarEntregas.Columns[0].Width = 50; // Número
            dgvListarEntregas.Columns[1].Width = 180; // Código
            dgvListarEntregas.Columns[2].Width = 200; 
            dgvListarEntregas.Columns[3].Width = 70; // Tipo de Entrega
            dgvListarEntregas.Columns[4].Width = 150; // Data de Entrada
            dgvListarEntregas.Columns[5].Width = 150; // Prazo de Devolução

            // Ajustar o tamanho da fonte das células do DataGridView
            dgvListarEntregas.DefaultCellStyle.Font = new Font("Arial", 15); // Define a fonte e o tamanho desejados
            dgvListarEntregas.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 16, FontStyle.Bold); // Define o cabeçalho com fonte maior e em negrito
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
                entrega.Codigo.ToLower().Contains(termoPesquisa) ||
                entrega.Nome.ToLower().Contains(termoPesquisa) ||
                entrega.TipoEntrega.ToLower().Contains(termoPesquisa) ||
                entrega.PrazoDevolucao.ToString("dd/MM/yyyy").Contains(termoPesquisa))
                .ToList();

            // Exibe as entregas filtradas no DataGridView
            ExibirEntregas(entregasSelecionadas); // Exibir apenas as entregas selecionadas ou filtradas
        }

        private List<CadastroEntregaProxy> CarregarEntregas()
        {
            // Verificar se o arquivo existe
            if (!File.Exists(@"C:\correios\Arquivo.xml"))
            {
                MessageBox.Show("O arquivo de entregas não foi encontrado.");
                return new List<CadastroEntregaProxy>();
            }

            try
            {
                // Desserializar as entregas do arquivo XML
                XmlSerializer serializer = new XmlSerializer(typeof(List<CadastroEntregaProxy>));
                using (FileStream fileStream = new FileStream(@"C:\correios\Arquivo.xml", FileMode.Open))
                {
                    return (List<CadastroEntregaProxy>)serializer.Deserialize(fileStream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar as entregas: " + ex.Message);
                return new List<CadastroEntregaProxy>();
            }
        }

        private void ExibirEntregas(List<CadastroEntregaProxy> entregas)
        {
            // Limpar o DataGridView antes de adicionar as novas entregas
            dgvListarEntregas.Rows.Clear();

            // Adicionar cada entrega ao DataGridView
            for (int i = 0; i < entregas.Count; i++)
            {
                var entrega = entregas[i];
                dgvListarEntregas.Rows.Add(
                    (i + 1).ToString(), // Número da entrega
                    entrega.Codigo,
                    entrega.Nome,
                    entrega.TipoEntrega,
                    entrega.DataEntrada.ToString("dd/MM/yyyy"),
                    entrega.PrazoDevolucao.ToString("dd/MM/yyyy")
                );
            }
        }

        private void dgvListarEntregas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Aqui você pode adicionar o código para lidar com a seleção de um item no DataGridView, se necessário
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //IMPRIMIR
        // IMPRIMIR
        // IMPRIMIR
        private void ImprimirEntregas()
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;
            ppd.ShowDialog();
        }

        private void botaoparaimprimir(object sender, EventArgs e)
        {
            ImprimirEntregas();
        }

        private int paginaAtual = 0; // Variável para controlar a página atual
        private int entregaAtual = 0; // Variável para controlar a entrega atual
        private DateTime? dataAtual = null; // Variável para controlar a data atual

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font fonteTitulo = new Font("Arial", 18, FontStyle.Bold); // Fonte para o título
            Font fonte = new Font("Arial", 14);
            Brush pincel = Brushes.Black;

            // Definir margens menores
            float margemEsquerda = 50;
            float margemSuperior = 50;
            float margemInferior = e.PageBounds.Height - 50;

            float alturaLinha = fonte.GetHeight(e.Graphics);

            // Título centralizado
            string titulo = "ENTREGAS A SEREM DEVOLVIDAS\n";
            float larguraTitulo = e.Graphics.MeasureString(titulo, fonteTitulo).Width;
            float posXTitulo = (e.PageBounds.Width - larguraTitulo) / 2;
            e.Graphics.DrawString(titulo, fonteTitulo, pincel, posXTitulo, margemSuperior);

            margemSuperior += fonteTitulo.GetHeight() + 10; // Pular uma linha após o título

            // Verificar se há entregas selecionadas
            if (entregasSelecionadas == null || entregasSelecionadas.Count == 0)
            {
                MessageBox.Show("Nenhuma entrega selecionada para imprimir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.HasMorePages = false;
                return;
            }

            // Agrupar entregas por data de entrada
            var gruposPorDataEntrada = entregasSelecionadas.GroupBy(entrega => entrega.DataEntrada.Date).ToList();

            for (int g = paginaAtual; g < gruposPorDataEntrada.Count; g++)
            {
                var grupo = gruposPorDataEntrada[g];
                var entregasDoGrupo = grupo.OrderBy(entrega => entrega.Nome).ToList();

                if (dataAtual != grupo.Key)
                {
                    dataAtual = grupo.Key;
                    entregaAtual = 0;
                    e.Graphics.DrawString(dataAtual.Value.ToString("dd/MM/yyyy"), fonte, pincel, margemEsquerda, margemSuperior);
                    margemSuperior += alturaLinha;
                }

                // Calcular o número de entregas que cabem na página
                int entregasPorPagina = (int)((margemInferior - margemSuperior) / alturaLinha);

                for (int i = entregaAtual; i < entregasDoGrupo.Count; i++)
                {
                    var entrega = entregasDoGrupo[i];
                    string textoEntrega = $"{i + 1}° \t{entrega.Codigo} \t{entrega.Nome}";
                    e.Graphics.DrawString(textoEntrega, fonte, pincel, margemEsquerda, margemSuperior);
                    margemSuperior += alturaLinha;

                    // Verificar se precisa de uma nova página
                    if (margemSuperior + alturaLinha > margemInferior)
                    {
                        e.HasMorePages = true;
                        entregaAtual = i + 1;
                        paginaAtual = g;
                        return;
                    }
                }

                dataAtual = null;
            }

            // Adicionar rodapé com a página atual
            string rodape = $"Página {paginaAtual + 1}";
            float larguraRodape = e.Graphics.MeasureString(rodape, fonte).Width;
            float posXRodape = (e.PageBounds.Width - larguraRodape) / 2;
            e.Graphics.DrawString(rodape, fonte, pincel, posXRodape, margemInferior + alturaLinha);

            // Resetar estado
            e.HasMorePages = false;
            paginaAtual = 0;
            entregaAtual = 0;
            dataAtual = null;
        }

        // IMPRIMIR

        //IMPRIMIR
        private void button3_Click(object sender, EventArgs e)
        {
            Listarentregasbaixadas listarentregasbaixadas = new Listarentregasbaixadas();
            listarentregasbaixadas.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

