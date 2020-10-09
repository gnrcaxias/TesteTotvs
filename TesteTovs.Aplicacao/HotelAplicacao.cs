using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTotvs.Dominio.Entidade;
using TesteTotvs.Dominio.Repositorio;
using TesteTovs.Aplicacao.Adapter;
using TesteTovs.Aplicacao.DTO;

namespace TesteTovs.Aplicacao
{
    public class HotelAplicacao
    {
        private IHotelRepositorio _hotelRepositorio;

        public HotelAplicacao(IHotelRepositorio hotelRepositorio)
        {
            this._hotelRepositorio = hotelRepositorio;
        }

        public HotelDTO Selecionar(int id)
        {
            if (id == 0)
            {
                throw new ApplicationException("Id não informado");
            }

            Hotel hotel = this._hotelRepositorio.Selecionar(id);

            return HotelAdapter.ParaDTO(hotel);
        }

        public List<HotelDTO> SelecionarTodos(string WifiGratis, string CafeGratis, string EstacionamentoGratis, string Piscina)
        {
            return HotelAdapter.ListParaDTO(_hotelRepositorio.SelecionarTodos(WifiGratis, CafeGratis, EstacionamentoGratis, Piscina));
        }
    }
}
