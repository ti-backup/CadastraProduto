using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastraProduto
{
    class Produto
    {
        public String Nome { set; get; }
        public String Descricao { set; get; }
        public Single Preco { set; get; }
        public DateTime Validade { private set; get; }

        private Byte periodo;
        public Byte Periodo {
            set
            {
                periodo = value;
                CalculaValidade();
            }
            get { return periodo; }
        }
        
        private void CalculaValidade()
        {
            DateTime hoje = DateTime.Now;
            Validade = hoje.AddMonths(Periodo);
        }
    }
}
