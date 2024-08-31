using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace correios
{
    public partial class CadastroEntrega : Form
    {
        public CadastroEntrega()
        {
            InitializeComponent();
            textBox1.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            textBox2.KeyDown += new KeyEventHandler(TextBox2_KeyDown); // Adicionado aqui


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evitar o som de "beep" e outros efeitos padrão
                Control nextControl = GetNextControl((Control)sender, true);
                if (nextControl != null && nextControl.CanFocus)
                {
                    nextControl.Focus();
                }
            }
        }
        private void TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evitar o som de "beep" e outros efeitos padrão
                button1.Focus(); // Focar no botão de cadastro
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string codigo = textBox1.Text.ToUpper();
            string nome = textBox2.Text.ToUpper();
            string tipoEntrega = GetTipoEntrega(); // Novo método para obter o tipo de entrega
            DateTime dataEntrada = DateTime.Now;

            // Validar entrada
            if (string.IsNullOrWhiteSpace(codigo) || !ValidaCodigo(codigo))
            {
                MessageBox.Show("Por favor, insira um código de rastreamento válido.", "Erro de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();  // Coloca o foco no textBox1
                return;
            }

            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Por favor, insira o nome do destinatário.", "Erro de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();  // Coloca o foco no textBox2
                return;
            }

            if (string.IsNullOrWhiteSpace(tipoEntrega))
            {
                MessageBox.Show("Por favor, selecione um tipo de entrega válido.", "Erro de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar se o código de rastreamento já existe
            if (EntregaManager.Instance.GetEntregaByCodigo(codigo) != null)
            {
                MessageBox.Show($"O código de rastreamento '{codigo}' já foi inserido antes. Por favor, reveja o código inserido.", "Erro de Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();  // Coloca o foco no textBox1
                return;
            }

            // Calcular prazo de devolução
            DateTime prazoDevolucao = CalcularPrazoDevolucao(dataEntrada, tipoEntrega);

            // Criar instância de CadastroEntregaProxy
            CadastroEntregaProxy entregaProxy = new CadastroEntregaProxy
            {
                Codigo = codigo,
                Nome = nome,
                DataEntrada = dataEntrada,
                TipoEntrega = tipoEntrega,
                PrazoDevolucao = prazoDevolucao
            };

            // Adicionar à lista de entregas gerenciada pelo EntregaManager
            EntregaManager.Instance.AdicionarEntrega(entregaProxy);

            // Limpar campos após o cadastro
            textBox1.Text = "";
            textBox2.Text = "";
           

            // Exibir mensagem de sucesso
            MessageBox.Show("Entrega cadastrada com sucesso!");

            // Focar no próximo controle, por exemplo, textBox1
            textBox1.Focus();
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

        private void rb7dias_CheckedChanged(object sender, EventArgs e)
        {

        }
    }

    public class CadastroEntregaProxy
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string TipoEntrega { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime PrazoDevolucao { get; set; }
        public string Observacao { get; set; }
        public DateTime? DataBaixa { get; set; }


    }

    public class EntregaManager
    {
        private static EntregaManager instance;
        private List<CadastroEntregaProxy> entregas;

        private EntregaManager()
        {
            // Carregar entregas existentes ao ser inicializado
            entregas = CarregarEntregas();
        }

        public static EntregaManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EntregaManager();
                }
                
                return instance;
            }
        }
       

        public List<CadastroEntregaProxy> GetEntregas()
        {
            return entregas;
        }
        public List<CadastroEntregaProxy> GetEntregasBaixadas()
        {
            return entregas.Where(entrega => entrega.DataBaixa.HasValue).ToList();
        }
        public void RemoverEntrega(CadastroEntregaProxy entrega)
        {
            entregas.Remove(entrega); // Remove a entrega da lista
            SerializarEntregas(); // Salva as entregas atualizadas
        }
        public void AdicionarEntrega(CadastroEntregaProxy entrega)
        {
            entregas.Add(entrega);
            SerializarEntregas();
        }

        public CadastroEntregaProxy GetEntregaByCodigo(string codigoRastreamento)
        {
            return entregas.FirstOrDefault(entrega => entrega.Codigo == codigoRastreamento);
        }

        private List<CadastroEntregaProxy> CarregarEntregas()
        {
            // Verificar se o diretório raiz está disponível
            if (DriveInfo.GetDrives().Any(drive => drive.Name == @"C:\" && drive.IsReady))
            {
                string pastaCorreios = @"C:\correios";

                // Verificar se o diretório existe
                if (!Directory.Exists(pastaCorreios))
                {
                    try
                    {
                        // Cria o diretório se não existir
                        Directory.CreateDirectory(pastaCorreios);
                        MessageBox.Show("Pasta criada com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao criar pasta: {ex.Message}");
                    }
                }

                // Agora que o diretório existe, podemos carregar as entregas do arquivo XML
                try
                {
                    string arquivoXml = Path.Combine(pastaCorreios, "Arquivo.xml");

                    // Verificar se o arquivo existe
                    if (!File.Exists(arquivoXml))
                    {
                        return new List<CadastroEntregaProxy>();
                    }

                    // Desserializar as entregas do arquivo XML
                    XmlSerializer serializer = new XmlSerializer(typeof(List<CadastroEntregaProxy>));
                    using (FileStream fileStream = new FileStream(arquivoXml, FileMode.Open))
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
            else
            {
                MessageBox.Show("O disco D não está disponível.");
                return new List<CadastroEntregaProxy>(); // Retorna uma lista vazia se o disco não estiver disponível
            }
        }
       



        public void SerializarEntregas()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<CadastroEntregaProxy>));
            using (TextWriter writer = new StreamWriter(@"C:\correios\Arquivo.xml"))
            {
                serializer.Serialize(writer, entregas);
            }
        }

       
    }

}