using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProvaExer3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            string entrada = txtEntrada.Text.Trim();

            // Validação simples
            if (entrada == "" || !entrada.All(c => c == '0' || c == '1'))
            {
                MessageBox.Show("Digite um número binário válido.");
                return;
            }

            string resultado = IncrementarBinario(entrada);
            lblResultado.Text = "Resultado: " + resultado;
        }

        private string IncrementarBinario(string binario)
        {
            // Simulando a fita com um caractere B no final
            char[] fita = (binario + "B").ToCharArray();
            int i = fita.Length - 2;

            // Passo 1: mover para o último dígito
            // Passo 2: inverter 1s para 0 até achar o primeiro 0
            while (i >= 0 && fita[i] == '1')
            {
                fita[i] = '0';
                i--;
            }

            // Passo 3: Se achar 0, troca para 1
            if (i >= 0)
            {
                fita[i] = '1';
            }
            else
            {
                // Se todos eram 1, adiciona 1 no início
                fita = ("1" + new string(fita)).ToCharArray();
            }

            return new string(fita).TrimEnd('B');
        }
    }
}
