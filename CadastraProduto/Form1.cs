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
    }
}
