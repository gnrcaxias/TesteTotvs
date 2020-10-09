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
    public class QuartoAplicacao
    {
        private IQuartoRepositorio _quartoRepositorio;

        public QuartoAplicacao(IQuartoRepositorio quartoRepositorio)
        {
            this._quartoRepositorio = quartoRepositorio;
        }

        public QuartoDTO Selecionar(int id)
        {
            if (id == 0)
            {
                throw new ApplicationException("Id não informado");
            }

            Quarto hotel = this._quartoRepositorio.Selecionar(id);

            return QuartoAdapter.ParaDTO(hotel);
        }

        public List<QuartoDTO> SelecionarTodos(string PrecoInicial, string PrecoFinal,
                                            string Frigobar, string Tv, string Banheiro,
                                            string Telefone, string Ventilador)
        {
            return QuartoAdapter.ListParaDTO(_quartoRepositorio.SelecionarTodos(PrecoInicial, PrecoFinal, Frigobar, Tv, Banheiro, Telefone, Ventilador));
        }
    }
}
