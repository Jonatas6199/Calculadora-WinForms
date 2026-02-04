using System.Diagnostics;
using System.Security.Policy;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Calculadora
{
    public partial class FormCalculadora : Form
    {
        private double primeiroValor;
        private string operacao;

        public FormCalculadora()
        {
            InitializeComponent();
            txtResultado.Text = "0";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            EscreverNumero("1");
        }
        

        private void btn2_Click(object sender, EventArgs e)
        {
            EscreverNumero("2");
        }
        
        private void btn3_Click(object sender, EventArgs e)
        {
            EscreverNumero("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            EscreverNumero("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            EscreverNumero("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            EscreverNumero("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            EscreverNumero("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            EscreverNumero("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            EscreverNumero("9");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            EscreverNumero("0");
        }

        private void EscreverNumero(string numero)
        {
            //Se já tem algum valor na calculadora, pode concatenar
            if (txtResultado.Text != "0")
                txtResultado.Text += numero;
            else
                //se não tem nenhum valor, a calculadora está esperando um valor
                //então eu vou substituir totalmente o estado inicial (0) pelo novo valor
                txtResultado.Text = numero;
        }

        private void btnSomar_Click(object sender, EventArgs e)
        {
            SelecionarOperacao("+");
        }

        private void btnSubtrair_Click(object sender, EventArgs e)
        {
            SelecionarOperacao("-");
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            SelecionarOperacao("*");
        }

        private void btnDividir_Click(object sender, EventArgs e)
        {
            SelecionarOperacao("/");
        }
        private void SelecionarOperacao(string operacao_selecionada)
        {
            primeiroValor = Convert.ToDouble(txtResultado.Text);
            txtResultado.Text = "0";
            operacao = operacao_selecionada;
        }
        private double RealizarOperacao(double valor1, double valor2)
        {
            double resultado = 0;
            switch (operacao)
            {
                case "+":
                    resultado = valor1 + valor2;
                    break;
                case "-":
                    resultado = valor1 - valor2;
                    break;
                case "*":
                    resultado = valor1 * valor2;
                    break;
                case "/":
                    if (valor2 != 0)
                        resultado = valor1 / valor2;
                    break;
            }
            return resultado;
        }

        private void btnResultado_Click(object sender, EventArgs e)
        {
            double segundoValor = Convert.ToDouble(txtResultado.Text);
            double resultado = RealizarOperacao(primeiroValor, segundoValor);
            txtResultado.Text = resultado.ToString();
            primeiroValor = 0;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "0";
            primeiroValor = 0;
        }
      
        private void btnVirgula_Click(object sender, EventArgs e)
        {
            if(!txtResultado.Text.Contains(","))
            {
                txtResultado.Text += ",";
            }
        }
    }
}
