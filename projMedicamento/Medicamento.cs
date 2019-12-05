using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projMedicamento
{
    public class Medicamento
    {
        private int id;
        private string nome, laboratorio;
        private Queue<Lote> lotes;

        public int Id {
            get { return id; }
        }

        public string Nome { get => nome; }
        public string Laboratorio { get => laboratorio; }

        public Queue<Lote> Lotes
        {
            get
            {
                return lotes;
            }

        }

        public Medicamento() {
            lotes = new Queue<Lote>();
        }

        public Medicamento(int id, string nome, string laboratorio)
        {
            this.id = id;
            this.nome = nome;
            this.laboratorio = laboratorio;
            lotes = new Queue<Lote>();

        }

        public int qtdeDisponivel()
        {
            int qtdeTotal=0;
            foreach(Lote l in lotes)
            {
                qtdeTotal += l.Qtde;
            }
            return qtdeTotal;
        }

        public void comprar(Lote lote)
        {
            lotes.Enqueue(lote);
        }

        public bool vender(int qtde) 
        {
            if (qtde <= this.qtdeDisponivel())
            {
                int tirarDaFila = 0;

                foreach (Lote l in lotes)
                {
                    if (qtde >= l.Qtde)
                    {
                        qtde -= l.Qtde;
                        l.Qtde = 0;
                        tirarDaFila++;
                    }

                    else
                    {
                        l.Qtde -= qtde;

                    }
                }

                for(int i=0;i<tirarDaFila; i++)
                {
                    lotes.Dequeue();
                }

                return true;

            }

            

            return false;
        }

        public override string ToString()
        {
            return id + "-" +Nome + "-" +Laboratorio + "-" + qtdeDisponivel();
        }

        public override bool Equals(object obj)
        {
            Medicamento mednObj = obj as Medicamento;

            return id.Equals(mednObj.id);
        }

    }
}
