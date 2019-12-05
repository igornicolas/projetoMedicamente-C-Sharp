using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projMedicamento
{
    public class Medicamentos
    {
        private List<Medicamento> listaMedicamentos;
        public Medicamentos() 
        {
            listaMedicamentos = new List<Medicamento>();
        }

        public List<Medicamento> ListaMedicamentos { get => listaMedicamentos; }

        public void adicionar(Medicamento medicamento)
        {
            listaMedicamentos.Add(medicamento);
        }

        public bool deletar(Medicamento medicamento)
        {
            if (medicamento.qtdeDisponivel() == 0) 
            {
            return true;

            }


            return false;
        }

        public Medicamento pesquisar(Medicamento medicamento)
        {

            foreach(Medicamento m in listaMedicamentos)
            {
                if (m.Equals(medicamento))
                {
                    return m;
                }
                
            }
            return null;
        }
    }
}
