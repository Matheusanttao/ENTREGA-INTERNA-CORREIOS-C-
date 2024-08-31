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
        private List<CadastroEntregaProxy> entregas; 
        private List<CadastroEntregaProxy> entregasSelecionadas; 

        public Listarentregas()
        {
            InitializeComponent();
            ConfigureDataGridView();
        }

        private void Listarentregas_Load(object sender, EventArgs e)
        {
          
            entregas = CarregarEntregas();
            entregas = entregas.OrderBy(entrega => entrega.PrazoDevolucao).ToList();
            ExibirEntregas(entregas);
        }

        private void ConfigureDataGridView()
        {

            dgvListarEntregas.Columns.Clear();

            
            dgvListarEntregas.ColumnCount = 6; 

            dgvListarEntregas.Columns[0].Name = "N°"; 
            dgvListarEntregas.Columns[1].Name = "Código";
            dgvListarEntregas.Columns[2].Name = "Nome";
            dgvListarEntregas.Columns[3].Name = "Tipo";
            dgvListarEntregas.Columns[4].Name = "Entrada";
            dgvListarEntregas.Columns[5].Name = "Devolução";

           
            dgvListarEntregas.Columns[0].Width = 50; 
            dgvListarEntregas.Columns[1].Width = 180;
            dgvListarEntregas.Columns[2].Width = 200;
            dgvListarEntregas.Columns[3].Width = 70; 
            dgvListarEntregas.Columns[4].Width = 150; 
            dgvListarEntregas.Columns[5].Width = 150; 

            dgvListarEntregas.DefaultCellStyle.Font = new Font("Arial", 15); 
            dgvListarEntregas.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 16, FontStyle.Bold); 
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
            if (entregas == null)
                return;

          
            string termoPesquisa = textBox1.Text.ToLower();

            
            entregasSelecionadas = entregas.Where(entrega =>
                entrega.Codigo.ToLower().Contains(termoPesquisa) ||
                entrega.Nome.ToLower().Contains(termoPesquisa) ||
                entrega.TipoEntrega.ToLower().Contains(termoPesquisa) ||
                entrega.PrazoDevolucao.ToString("dd/MM/yyyy").Contains(termoPesquisa))
                .ToList();

           
            ExibirEntregas(entregasSelecionadas); 
        }

        private List<CadastroEntregaProxy> CarregarEntregas()
        {
            
            if (!File.Exists(@"C:\correios\Arquivo.xml"))
            {
                MessageBox.Show("O arquivo de entregas não foi encontrado.");
                return new List<CadastroEntregaProxy>();
            }

            try
            {
               
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
           
            dgvListarEntregas.Rows.Clear();

            for (int i = 0; i < entregas.Count; i++)
            {
                var entrega = entregas[i];
                dgvListarEntregas.Rows.Add(
                    (i + 1).ToString(), 
                    entrega.Codigo,
                    entrega.Nome,
                    entrega.TipoEntrega,
                    entrega.DataEntrada.ToString("dd/MM/yyyy"),
                    entrega.PrazoDevolucao.ToString("dd/MM/yyyy")
                );
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


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

        private int paginaAtual = 0;
        private int entregaAtual = 0; 
        private DateTime? dataAtual = null; 
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font fonteTitulo = new Font("Arial", 18, FontStyle.Bold);
            Font fonte = new Font("Arial", 14);
            Brush pincel = Brushes.Black;

            float margemEsquerda = 50;
            float margemSuperior = 50;
            float margemInferior = e.PageBounds.Height - 50;

            float alturaLinha = fonte.GetHeight(e.Graphics);

         
            string titulo = "ENTREGAS A SEREM DEVOLVIDAS\n";
            float larguraTitulo = e.Graphics.MeasureString(titulo, fonteTitulo).Width;
            float posXTitulo = (e.PageBounds.Width - larguraTitulo) / 2;
            e.Graphics.DrawString(titulo, fonteTitulo, pincel, posXTitulo, margemSuperior);

            margemSuperior += fonteTitulo.GetHeight() + 10;
      
            if (entregasSelecionadas == null || entregasSelecionadas.Count == 0)
            {
                MessageBox.Show("Nenhuma entrega selecionada para imprimir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.HasMorePages = false;
                return;
            }

           
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

            
                int entregasPorPagina = (int)((margemInferior - margemSuperior) / alturaLinha);

                for (int i = entregaAtual; i < entregasDoGrupo.Count; i++)
                {
                    var entrega = entregasDoGrupo[i];
                    string textoEntrega = $"{i + 1}° \t{entrega.Codigo} \t{entrega.Nome}";
                    e.Graphics.DrawString(textoEntrega, fonte, pincel, margemEsquerda, margemSuperior);
                    margemSuperior += alturaLinha;

                  
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

          
            string rodape = $"Página {paginaAtual + 1}";
            float larguraRodape = e.Graphics.MeasureString(rodape, fonte).Width;
            float posXRodape = (e.PageBounds.Width - larguraRodape) / 2;
            e.Graphics.DrawString(rodape, fonte, pincel, posXRodape, margemInferior + alturaLinha);

            e.HasMorePages = false;
            paginaAtual = 0;
            entregaAtual = 0;
            dataAtual = null;
        }

      
        private void button3_Click(object sender, EventArgs e)
        {
            Listarentregasbaixadas listarentregasbaixadas = new Listarentregasbaixadas();
            listarentregasbaixadas.ShowDialog();
        }

        
    }
}

