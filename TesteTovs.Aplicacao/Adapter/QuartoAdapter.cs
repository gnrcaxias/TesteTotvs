using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTotvs.Dominio.Entidade;
using TesteTovs.Aplicacao.DTO;

namespace TesteTovs.Aplicacao.Adapter
{
    public class QuartoAdapter
    {

        public static Quarto ParaDomain(QuartoDTO quarto)
        {
            if (quarto != null)
            {
                return new Quarto()
                {
                    Id = quarto.Id,
                    Banheiro = quarto.Banheiro,
                    Foto1 = quarto.Foto1,
                    Foto2 = quarto.Foto2,
                    Foto3 = quarto.Foto3,
                    Frigobar = quarto.Frigobar,
                    IdHotel = quarto.IdHotel,
                    Preco = quarto.Preco,
                    PrecoPromocional = quarto.PrecoPromocional,
                    Telefone = quarto.Telefone,
                    Tv = quarto.Tv,
                    Ventilador = quarto.Ventilador
                };
            }
            else
                return null;
        }

        public static QuartoDTO ParaDTO(Quarto quarto)
        {
            return new QuartoDTO()
            {
                Id = quarto.Id,
                Banheiro = quarto.Banheiro,
                Foto1 = quarto.Foto1,
                Foto2 = quarto.Foto2,
                Foto3 = quarto.Foto3,
                Frigobar = quarto.Frigobar,
                IdHotel = quarto.IdHotel,
                Preco = quarto.Preco,
                PrecoPromocional = quarto.PrecoPromocional,
                Telefone = quarto.Telefone,
                Tv = quarto.Tv,
                Ventilador = quarto.Ventilador
            };
        }

        public static List<Quarto> ListParaDomain(List<QuartoDTO> listaQuartoDTO)
        {
            List<Quarto> listaQuarto = new List<Quarto>();

            foreach (QuartoDTO item in listaQuartoDTO)
            {
                listaQuarto.Add(QuartoAdapter.ParaDomain(item));
            }

            return listaQuarto;
        }

        public static List<QuartoDTO> ListParaDTO(List<Quarto> listaQuarto)
        {
            List<QuartoDTO> listaQuartoDTO = new List<QuartoDTO>();

            foreach (Quarto item in listaQuarto)
            {
                listaQuartoDTO.Add(QuartoAdapter.ParaDTO(item));
            }

            return listaQuartoDTO;
        }

    }
}
