using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTotvs.Dominio.Entidade;
using TesteTovs.Aplicacao.DTO;

namespace TesteTovs.Aplicacao.Adapter
{
    public class HotelAdapter
    {
        public static Hotel ParaDomain(HotelDTO hotel)
        {
            if (hotel != null)
            {
                return new Hotel()
                {
                    Id = hotel.Id,
                    Bairro = hotel.Bairro,
                    Cidade = hotel.Cidade,
                    CafeDaManhaGratis = hotel.CafeDaManhaGratis,
                    EstacionamentoGratis = hotel.EstacionamentoGratis,
                    NomeHotel = hotel.NomeHotel,
                    Piscina = hotel.Piscina,
                    QuantidadeEstrelas = hotel.QuantidadeEstrelas,
                    WifiGratis = hotel.WifiGratis
                };
            }
            else
                return null;
        }

        public static HotelDTO ParaDTO(Hotel hotel)
        {
            return new HotelDTO()
            {
                Id = hotel.Id,
                Bairro = hotel.Bairro,
                Cidade = hotel.Cidade,
                CafeDaManhaGratis = hotel.CafeDaManhaGratis,
                EstacionamentoGratis = hotel.EstacionamentoGratis,
                NomeHotel = hotel.NomeHotel,
                Piscina = hotel.Piscina,
                QuantidadeEstrelas = hotel.QuantidadeEstrelas,
                WifiGratis = hotel.WifiGratis
            };
        }

        public static List<Hotel> ListParaDomain(List<HotelDTO> listaHotelDTO)
        {
            List<Hotel> listaHotel = new List<Hotel>();

            foreach (HotelDTO item in listaHotelDTO)
            {
                listaHotel.Add(HotelAdapter.ParaDomain(item));
            }

            return listaHotel;
        }

        public static List<HotelDTO> ListParaDTO(List<Hotel> listaHotel)
        {
            List<HotelDTO> listaHotelDTO = new List<HotelDTO>();

            foreach (Hotel item in listaHotel)
            {
                listaHotelDTO.Add(HotelAdapter.ParaDTO(item));
            }

            return listaHotelDTO;
        }
    }
}
