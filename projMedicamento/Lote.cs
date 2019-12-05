using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projMedicamento
{
    public class Lote
    {
        private int id, qtde;
        private DateTime venc;

        public Lote()
        {

        }

        public Lote(int id, int qtde, DateTime venc)
        {
            this.id = id;
            this.qtde = qtde;
            this.venc = venc;
        }

        public int Id { get => id;  }
        public int Qtde { get { return qtde; } set { qtde = value; } }
        public DateTime Venc { get => venc;  }

        public override string ToString()
        {
            return this.Id + "-"+this.Qtde+"-"+this.Venc.ToShortDateString() ;
        }


    }
}
