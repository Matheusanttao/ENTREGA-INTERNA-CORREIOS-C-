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
            textBox2.KeyDown += new KeyEventHandler(TextBox2_KeyDown); 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
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
                e.SuppressKeyPress = true; 
                button1.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string codigo = textBox1.Text.ToUpper();
            string nome = textBox2.Text.ToUpper();
            string tipoEntrega = GetTipoEntrega(); 
            DateTime dataEntrada = DateTime.Now;

            if (string.IsNullOrWhiteSpace(codigo) || !ValidaCodigo(codigo))
            {
                MessageBox.Show("Por favor, insira um código de rastreamento válido.", "Erro de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();  
                return;
            }

            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Por favor, insira o nome do destinatário.", "Erro de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus(); 
                return;
            }

            if (string.IsNullOrWhiteSpace(tipoEntrega))
            {
                MessageBox.Show("Por favor, selecione um tipo de entrega válido.", "Erro de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

       
            if (EntregaManager.Instance.GetEntregaByCodigo(codigo) != null)
            {
                MessageBox.Show($"O código de rastreamento '{codigo}' já foi inserido antes. Por favor, reveja o código inserido.", "Erro de Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus(); 
                return;
            }


            DateTime prazoDevolucao = CalcularPrazoDevolucao(dataEntrada, tipoEntrega);

      
            CadastroEntregaProxy entregaProxy = new CadastroEntregaProxy
            {
                Codigo = codigo,
                Nome = nome,
                DataEntrada = dataEntrada,
                TipoEntrega = tipoEntrega,
                PrazoDevolucao = prazoDevolucao
            };

            
            EntregaManager.Instance.AdicionarEntrega(entregaProxy);


            textBox1.Text = "";
            textBox2.Text = "";


          
            MessageBox.Show("Entrega cadastrada com sucesso!");

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
            entregas.Remove(entrega); 
            SerializarEntregas();
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
            
            if (DriveInfo.GetDrives().Any(drive => drive.Name == @"C:\" && drive.IsReady))
            {
                string pastaCorreios = @"C:\correios";

                if (!Directory.Exists(pastaCorreios))
                {
                    try
                    {
                      
                        Directory.CreateDirectory(pastaCorreios);
                        MessageBox.Show("Pasta criada com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao criar pasta: {ex.Message}");
                    }
                }

                try
                {
                    string arquivoXml = Path.Combine(pastaCorreios, "Arquivo.xml");

                  
                    if (!File.Exists(arquivoXml))
                    {
                        return new List<CadastroEntregaProxy>();
                    }

                  
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
                return new List<CadastroEntregaProxy>();
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