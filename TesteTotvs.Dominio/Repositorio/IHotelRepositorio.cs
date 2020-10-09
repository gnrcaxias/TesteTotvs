using TesteTotvs.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteTotvs.Dominio.Repositorio
{
    public interface IHotelRepositorio
    {
        Hotel Selecionar(int id);

        List<Hotel> SelecionarTodos(string WifiGratis, string CafeGratis, string EstacionamentoGratis, string Piscina);
    }
}
