using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTotvs.Dominio.Entidade;

namespace TesteTotvs.Dominio.Repositorio
{
    public interface IQuartoRepositorio
    {
        Quarto Selecionar(int id);

        List<Quarto> SelecionarTodos(string PrecoInicial, string PrecoFinal,
                                            string Frigobar, string Tv, string Banheiro,
                                            string Telefone, string Ventilador);
    }
}
