using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TesteTotvs.Dominio.Repositorio;
using TesteTotvs.MVC.Models;
using TesteTotvs.RepositorioTexto;
using TesteTovs.Aplicacao;
using TesteTovs.Aplicacao.DTO;

namespace TesteTotvs.MVC.Controllers
{
    public class PesquisaController : Controller
    {
        // GET: Pesquisa
        public ActionResult Index(string PrecoInicial, string PrecoFinal, 
                                string WifiGratis, string CafeGratis, string EstacionamentoGratis, 
                                string Piscina, string Frigobar, string Tv, string Banheiro, 
                                string Telefone, string Ventilador)
        {
            IQuartoRepositorio repositorio = new QuartoRepositorio();
            QuartoAplicacao aplicacao = new QuartoAplicacao(repositorio);

            IHotelRepositorio hotelTepositorio = new HotelRepositorio();
            HotelAplicacao aplicacaoHotel = new HotelAplicacao(hotelTepositorio);
           
            List<Hotel> Hoteis = aplicacaoHotel.SelecionarTodos(WifiGratis, CafeGratis, EstacionamentoGratis, Piscina).Select(hotel => HotelDTOParaModel(hotel)).ToList();
            List<Quarto> Quartos = aplicacao.SelecionarTodos(PrecoInicial, PrecoFinal, Frigobar, Tv, Banheiro, Telefone, Ventilador).Where(st => Hoteis.Any(h => h.Id == st.IdHotel)).Select(quarto => QuartoDTOParaModel(quarto)).ToList();

            return View(Quartos.OrderBy(q => q.PrecoFinal));
        }

        public ActionResult RetornaDiferenciaisQuarto(int idQuarto)
        {
            StringBuilder sbDiferenciais = new StringBuilder();
            IQuartoRepositorio repositorio = new QuartoRepositorio();
            QuartoAplicacao aplicacao = new QuartoAplicacao(repositorio);

            QuartoDTO quartoDTO = aplicacao.Selecionar(idQuarto);

            if (quartoDTO != null)
            {
                Quarto Quarto = QuartoDTOParaModel(quartoDTO);

                if (Quarto.Banheiro)
                    sbDiferenciais.Append("Banheiro <br />");

                if (Quarto.Frigobar)
                    sbDiferenciais.Append("Frigobar <br />");

                if (Quarto.Telefone)
                    sbDiferenciais.Append("Telefone <br />");

                if (Quarto.Tv)
                    sbDiferenciais.Append("Tv <br />");

                if (Quarto.Ventilador)
                    sbDiferenciais.Append("Ventilador <br />");
            }

            return Content(sbDiferenciais.ToString());
        }

        public ActionResult RetornaDiferenciaisHotel(int idHotel)
        {
            StringBuilder sbDiferenciais = new StringBuilder();
            IHotelRepositorio repositorio = new HotelRepositorio();
            HotelAplicacao aplicacao = new HotelAplicacao(repositorio);

            HotelDTO hotelDTO = aplicacao.Selecionar(idHotel);

            if (hotelDTO != null)
            {
                Hotel Hotel = HotelDTOParaModel(hotelDTO);

                if (Hotel.CafeDaManhaGratis)
                    sbDiferenciais.Append("Café da Manhã Grátis <br />");

                if (Hotel.EstacionamentoGratis)
                    sbDiferenciais.Append("Estacionamento Grátis <br />");

                if (Hotel.Piscina)
                    sbDiferenciais.Append("Piscina <br />");

                if (Hotel.WifiGratis)
                    sbDiferenciais.Append("Wifi Grátis <br />");

                if (Hotel.QuantidadeEstrelas > 0)
                    sbDiferenciais.Append($"{Hotel.QuantidadeEstrelas.ToString()} estrelas <br />");
            }

            return Content(sbDiferenciais.ToString());
        }

        [NonAction]
        public static Hotel HotelDTOParaModel(HotelDTO hotel)
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

        [NonAction]
        public static Quarto QuartoDTOParaModel(QuartoDTO quarto)
        {
            IHotelRepositorio hotelTepositorio = new HotelRepositorio();
            HotelAplicacao aplicacao = new HotelAplicacao(hotelTepositorio);

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
                Ventilador = quarto.Ventilador,
                Hotel = HotelDTOParaModel(aplicacao.Selecionar(quarto.IdHotel)),
                PrecoFinal = (quarto.PrecoPromocional > 0 ? quarto.PrecoPromocional : quarto.Preco)
            };
        }
    }
}