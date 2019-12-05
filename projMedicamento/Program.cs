using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projMedicamento
{
    public class Program
    {
       
        static void Main(string[] args)
        {
            int opc = 1;

            Medicamentos medicamentos = new Medicamentos();

            while (opc != 0)
            {
                Console.WriteLine("0. Finalizar processo");
                Console.WriteLine("1. Cadastrar medicamento");
                Console.WriteLine("2. Consultar medicamento (sintetico)");
                Console.WriteLine("3. Consultar medicamento (analitico)");
                Console.WriteLine("4. Comprar medicamento (cadastrar lote)");
                Console.WriteLine("5. Vender medicamento");
                Console.WriteLine("6. Listar medicamentos");
                opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 0:
                Console.WriteLine("tchau");

                        break;


                    case 1:

                        Console.WriteLine("Id do medicamento que deseja cadastrar");
                        int idNovoMedicamento = int.Parse(Console.ReadLine());

                        Console.WriteLine("Nome do medicamento que deseja cadastrar");
                        string nomeNovoMedicamento = Console.ReadLine();

                        Console.WriteLine("Laboratorio do medicamento que deseja cadastrar");
                        string laboratorioNovoMedicamento = Console.ReadLine();

                        Medicamento novoMedicamento = new Medicamento(idNovoMedicamento, nomeNovoMedicamento, laboratorioNovoMedicamento);

                        medicamentos.adicionar(novoMedicamento);
                        break;


                    case 2:
                        Console.WriteLine("Id do medicamento que deseja pesquisar");
                        int idPesquisa = int.Parse(Console.ReadLine());

                        Medicamento medicamentoAchado = medicamentos.pesquisar(new Medicamento(idPesquisa, "", ""));

                        if (medicamentoAchado == null)
                        {
                            Console.WriteLine("Medicamento nao encontrado");
                            break;
                        }
                        Console.WriteLine(medicamentoAchado.ToString());



                        break;

                    case 3:

                        Console.WriteLine("Id do medicamento que deseja pesquisar");
                         idPesquisa = int.Parse(Console.ReadLine());

                         medicamentoAchado = medicamentos.pesquisar(new Medicamento(idPesquisa, "", ""));

                        if (medicamentoAchado == null)
                        {
                            Console.WriteLine("Medicamento nao encontrado");
                            break;
                        }
                        Console.WriteLine(medicamentoAchado.ToString());
                        foreach (Lote l in medicamentoAchado.Lotes)
                        {
                            Console.WriteLine(l.ToString());


                        }


                        break;


                    case 4:
                        Console.WriteLine("Id do medicamento que deseja pesquisar");
                         idPesquisa = int.Parse(Console.ReadLine());

                         medicamentoAchado = medicamentos.pesquisar(new Medicamento(idPesquisa, "", ""));


                        if (medicamentoAchado == null)
                        {
                            Console.WriteLine("Medicamento nao encontrado");
                            break;
                        }


                        Console.WriteLine("Id do lote que deseja cadastrar");
                        int idNovoLote = int.Parse(Console.ReadLine());

                        Console.WriteLine("qual a quantidade do lote que deseja cadastrar");
                        int qtdeNovoLote = int.Parse(Console.ReadLine());

                        Boolean condicao = false;
                        DateTime vencNovoLote = DateTime.MinValue;

                        do
                        {
                            condicao = false;
                        Console.WriteLine("qual a validade do lote que deseja cadastrar? (dd/MM/yyyy) ");

                       try
                         {
                            vencNovoLote = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.CurrentCulture);
                                


                                if (DateTime.Now.CompareTo(vencNovoLote.Date) > 0)
                                {
                                    Console.WriteLine("Data de vencimento tem que ser maior que a data atual!");

                                    condicao = true;
                                }
                         }

                       catch (Exception)
                          {
                           Console.WriteLine("aaaa");
                                condicao = true;
                          }
                        } while (condicao);

                        medicamentoAchado.comprar(new Lote(idNovoLote, qtdeNovoLote, vencNovoLote));

                       
                        Console.WriteLine(medicamentoAchado.qtdeDisponivel());
                        break;


                    case 5:
                        Console.WriteLine("Id do medicamento que deseja vender?");
                        idPesquisa = int.Parse(Console.ReadLine());

                        Console.WriteLine("Qual a quantidade que deseja vender?");
                        int qtdeVenda= int.Parse(Console.ReadLine());

                        medicamentoAchado = medicamentos.pesquisar(new Medicamento(idPesquisa, "", ""));

                        if (medicamentoAchado == null)
                        {
                            Console.WriteLine("medicamento nao encontrado");
                            break;
                        }

                       condicao = medicamentoAchado.vender(qtdeVenda);

                        if (condicao)
                        {

                            Console.WriteLine("Venda realizada com sucesso!");

                            Console.WriteLine(medicamentoAchado.qtdeDisponivel());

                        }

                        else
                        {

                            Console.WriteLine("Venda não reazlizada quantidade pedida é maior que a disponível");

                        }


                        break;

                    case 6:
                        foreach(Medicamento m in medicamentos.ListaMedicamentos)
                        {
                            Console.WriteLine(m.ToString());
                        }
                            
                        break;
                }
            }

        }
    }
}
