using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace correios
{
    public partial class Menu : Form
    {
        public string tipoEntrega;
        public Menu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string mensagem = "A versão atual do programa é a 7.0. \nOs prazos de entrega fornecidos são apenas uma referência e podem não ser precisos. Recomenda-se verificar se todas as datas estão corretas para evitar a perda de prazo.\n\n" +
                           "Atenciosamente,\n" +
                             "Matheus Antão";

            MessageBox.Show(mensagem, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            CadastroEntrega cadastroEntrega = new CadastroEntrega();
            cadastroEntrega.ShowDialog();

        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            Listarentregas listarentregas = new Listarentregas();
            listarentregas.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja sair realmente do programa?", "Confirmação de Saída", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            BaixarEntregas baixarEntregas = new BaixarEntregas();
            baixarEntregas.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
              
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                DialogResult result = folderBrowserDialog.ShowDialog();

   
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    string diretorioOrigem = @"C:\correios";
                    string diretorioDestino = folderBrowserDialog.SelectedPath; 

                    if (Directory.Exists(diretorioOrigem))
                    {
                        
                        if (!Directory.Exists(diretorioDestino))
                        {
                            Directory.CreateDirectory(diretorioDestino);
                        }

                       
                        CopyDirectory(diretorioOrigem, diretorioDestino);

                        MessageBox.Show("Cópia da pasta 'correios' criada com sucesso em '" + diretorioDestino + "'.");
                    }
                    else
                    {
                        MessageBox.Show("O diretório de origem não existe.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao criar a cópia da pasta 'correios': " + ex.Message);
            }
        }

        
        private void CopyDirectory(string sourceDir, string targetDir)
        {
            
            string[] subDirs = Directory.GetDirectories(sourceDir);

        
            foreach (string file in Directory.GetFiles(sourceDir))
            {
                string dest = Path.Combine(targetDir, Path.GetFileName(file));
                File.Copy(file, dest, true);
            }

           
            foreach (string subDir in subDirs)
            {
                string destSubDir = Path.Combine(targetDir, Path.GetFileName(subDir));
                CopyDirectory(subDir, destSubDir);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EditarEntrega editarEntrega = new EditarEntrega();
            editarEntrega.ShowDialog();
        }

        private List<CadastroEntregaProxy> CarregarEntregasBaixadas()
        {
            List<CadastroEntregaProxy> entregasBaixadas = new List<CadastroEntregaProxy>();

            string caminhoArquivo = @"C:\correios\EntregasBaixadas\EntregasBaixadas.xml";

            try
            {
                if (File.Exists(caminhoArquivo))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<CadastroEntregaProxy>));

                    using (StreamReader reader = new StreamReader(caminhoArquivo))
                    {
                        entregasBaixadas = (List<CadastroEntregaProxy>)serializer.Deserialize(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao carregar as entregas baixadas: {ex.Message}");
            }

            return entregasBaixadas;
        }

        public class RelatorioDiario
        {
            public DateTime Data { get; set; }
            public int EncomendasCadastradasHoje { get; set; }
            public int EncomendasBaixadasHoje { get; set; }
            public int EncomendasBaixadasHojeCadastradasHoje { get; set; }
        }

     
        public class RelatorioMensal
        {
            public List<RelatorioDiario> RelatoriosDiarios { get; set; } = new List<RelatorioDiario>();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            
            string url = "https://srointranet.correios.com.br/";

     
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e) 
        {
            
            string url = "https://srointranet.correios.com.br/rastreamento?opcao=SIGLAS";

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            CalcularPrazo calcularPrazo = new CalcularPrazo();
            calcularPrazo.ShowDialog();
        }

      
        private void RELATÓRIODIÁRIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
              }

        private RelatorioMensal CarregarRelatorioMensal()
        {
            RelatorioMensal relatorioMensal = new RelatorioMensal();
            string caminhoArquivo = @"C:\correios\RelatorioDiario.xml";

            try
            {
                if (File.Exists(caminhoArquivo))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(RelatorioMensal));

                    using (StreamReader reader = new StreamReader(caminhoArquivo))
                    {
                        relatorioMensal = (RelatorioMensal)serializer.Deserialize(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao carregar o relatório mensal: {ex.Message}");
            }

            return relatorioMensal;
        }

        private void SalvarRelatorioMensal(RelatorioMensal relatorioMensal)
        {
            string caminhoArquivo = @"C:\correios\RelatorioDiario.xml";

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(RelatorioMensal));

                using (StreamWriter writer = new StreamWriter(caminhoArquivo))
                {
                    serializer.Serialize(writer, relatorioMensal);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao salvar o relatório mensal: {ex.Message}");
            }
        }

       
        private void rELATORIODIARIOToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
          
            List<CadastroEntregaProxy> entregasCadastradas = EntregaManager.Instance.GetEntregas();


            List<CadastroEntregaProxy> entregasBaixadas = CarregarEntregasBaixadas();

            if (entregasCadastradas == null || entregasBaixadas == null)
            {
                MessageBox.Show("Não foi possível obter a lista de entregas.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        
            DateTime hoje = DateTime.Today;

        
            int encomendasCadastradasHoje = 0;
            int encomendasBaixadasHoje = 0;
            int encomendasBaixadasHojeCadastradasHoje = 0;

           
            foreach (var entrega in entregasCadastradas)
            {
                if (entrega.DataEntrada.Date == hoje)
                {
                    encomendasCadastradasHoje++;
                }
            }

       
            foreach (var entrega in entregasBaixadas)
            {
                if (entrega.DataBaixa.HasValue && entrega.DataBaixa.Value.Date == hoje)
                {
                    encomendasBaixadasHoje++;

                 
                    if (entrega.DataEntrada.Date == hoje)
                    {
                        encomendasBaixadasHojeCadastradasHoje++;
                    }
                }
            }

           
            RelatorioDiario relatorioDiario = new RelatorioDiario
            {
                Data = hoje,
                EncomendasCadastradasHoje = encomendasCadastradasHoje,
                EncomendasBaixadasHoje = encomendasBaixadasHoje,
                EncomendasBaixadasHojeCadastradasHoje = encomendasBaixadasHojeCadastradasHoje
            };

            
            RelatorioMensal relatorioMensal = CarregarRelatorioMensal();

          
            var relatorioExistente = relatorioMensal.RelatoriosDiarios
                .FirstOrDefault(r => r.Data.Date == hoje);

            if (relatorioExistente != null)
            {
              
                relatorioExistente.EncomendasCadastradasHoje = encomendasCadastradasHoje;
                relatorioExistente.EncomendasBaixadasHoje = encomendasBaixadasHoje;
                relatorioExistente.EncomendasBaixadasHojeCadastradasHoje = encomendasBaixadasHojeCadastradasHoje;
            }
            else
            {
              
                relatorioMensal.RelatoriosDiarios.Add(relatorioDiario);
            }

           
            SalvarRelatorioMensal(relatorioMensal);

          
            MessageBox.Show($"Relatório de hoje: \nCadastradas: {encomendasCadastradasHoje + encomendasBaixadasHojeCadastradasHoje} encomendas.\nBaixadas: {encomendasBaixadasHoje} encomendas.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void rELATORIOCOMPLETOToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Relatoriotodosdias relatoriotodosdias = new Relatoriotodosdias();
            relatoriotodosdias.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ExcluirLançamento excluirLançamento = new ExcluirLançamento();
            excluirLançamento.ShowDialog();
        }
    }

}
