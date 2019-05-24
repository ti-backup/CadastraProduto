using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastraProduto
{
    public partial class Form1 : Form
    {
        List<Produto> lista;
        List<Produto> filtro;

        public Form1()
        {
            InitializeComponent();
            lista = new List<Produto>();
            filtro = new List<Produto>();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Produto prod = new Produto();
            prod.Nome = txtNome.Text;
            prod.Descricao = txtDescricao.Text;
            prod.Preco = Convert.ToSingle(nudPreco.Value);
            prod.Periodo = Convert.ToByte(nudPeriodo.Value);

            lista.Add(prod);
            ExibeRegistros();
            LimpaCampos();
        }

        private void LimpaCampos()
        {
            txtNome.Clear();
            txtDescricao.Clear();
            nudPreco.Value = 0;
            nudPeriodo.Value = 1;

            txtNome.Focus();
        }

        private void ExibeRegistros()
        {
            ExibeRegistros("");
        }

        private void ExibeRegistros(String consulta)
        {
            filtro.Clear();
            foreach (Produto temp in lista)
            {
                if (temp.Nome.Contains(consulta))
                {
                    filtro.Add(temp);
                }
            }

            dgvResultados.DataSource = null;
            dgvResultados.DataSource = filtro;
        }

        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {
            ExibeRegistros(txtConsulta.Text);
        }

        private void Navegacao(object sender, KeyEventArgs e)
        {
            // COMPARA O CODIGO DA TECLA PRESSIONA
            // COM O CODIGO DA TECLA ENTER
            if (e.KeyCode == Keys.Enter)
            {
                // SIMULA ENTRADA DE DADOS PELO TECLADO
                // SIMULA O PRESSIONAMENTO DA TECLA TAB
                SendKeys.Send("{TAB}");
            }
        }
    }
}
