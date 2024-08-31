using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace correios
{
    public partial class Relatorio : Form
    {
        public Relatorio()
        {
            InitializeComponent();
        }

        private void Relatorio_Load(object sender, EventArgs e)
        {
            // Configurar o DataGridView no evento Load para definir as colunas e o estilo
            ConfigureDataGridView();

            // Carregar o XML e exibir no DataGridView
            var relatorioMensal = CarregarRelatorioMensal("C:\\correios\\RelatorioDiario.xml");
            if (relatorioMensal != null)
            {
                ExibirRelatorioNoDataGridView(relatorioMensal);
            }
            else
            {
                MessageBox.Show("Não foi possível carregar o relatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private RelatorioMensal CarregarRelatorioMensal(string caminhoArquivo)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(RelatorioMensal));
                using (var stream = new FileStream(caminhoArquivo, FileMode.Open))
                {
                    return (RelatorioMensal)serializer.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar o arquivo XML: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void ExibirRelatorioNoDataGridView(RelatorioMensal relatorioMensal)
        {
            // Definir a fonte de dados
            dgvListarRelatorio.DataSource = relatorioMensal.RelatoriosDiarios;
        }

        private void ConfigureDataGridView()
        {
            // Limpar as colunas existentes
            dgvListarRelatorio.Columns.Clear();

            // Adicionar e configurar as colunas
            dgvListarRelatorio.AutoGenerateColumns = false; // Evita a geração automática de colunas

            dgvListarRelatorio.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Data",
                DataPropertyName = "Data",
                HeaderText = "DATA",
                Width = 150
            });

            dgvListarRelatorio.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CadastradasHoje",
                DataPropertyName = "EncomendasCadastradasHoje",
                HeaderText = "CADASTRO",
                Width = 180
            });

            dgvListarRelatorio.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Baixadas",
                DataPropertyName = "EncomendasBaixadasHoje",
                HeaderText = "BAIXADA",
                Width = 180
            });

            dgvListarRelatorio.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "BaixadasCadastradasHoje",
                DataPropertyName = "EncomendasBaixadasHojeCadastradasHoje",
                HeaderText = "CADASTRADA BAIXADA NO DIA",
                Width = 250
            });

            // Configurar a aparência das células e dos cabeçalhos
            ConfigureHeaderStyles();
            ConfigureCellStyles();
        }

        private void ConfigureHeaderStyles()
        {
            // Aplicar estilo de cabeçalhos
            dgvListarRelatorio.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 18, FontStyle.Bold);
            dgvListarRelatorio.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Reaplicar os estilos para cada cabeçalho individualmente
            foreach (DataGridViewColumn column in dgvListarRelatorio.Columns)
            {
                column.HeaderCell.Style.Font = new Font("Arial", 18, FontStyle.Bold);
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void ConfigureCellStyles()
        {
            // Configurar estilo das células
            dgvListarRelatorio.DefaultCellStyle.Font = new Font("Arial", 14);
            dgvListarRelatorio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvListarRelatorio_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvListarRelatorio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    [XmlRoot("RelatorioMensal")]
    public class RelatorioMensal
    {
        [XmlArray("RelatoriosDiarios")]
        [XmlArrayItem("RelatorioDiario")]
        public List<RelatorioDiario> RelatoriosDiarios { get; set; }
    }

    public class RelatorioDiario
    {
        public DateTime Data { get; set; }
        public int EncomendasCadastradasHoje { get; set; }
        public int EncomendasBaixadasHoje { get; set; }
        public int EncomendasBaixadasHojeCadastradasHoje { get; set; }
    }
}
