using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteTotvs.Dominio.Repositorio;
using TesteTotvs.MVC.Models;
using TesteTotvs.RepositorioTexto;
using TesteTotvs.Utilitarios;
using TesteTovs.Aplicacao;
using TesteTovs.Aplicacao.DTO;

namespace TesteTotvs.MVC.Controllers
{
    public class PesquisaHoteisController : Controller
    {        
        public ActionResult Index(string WifiGratis, string CafeGratis, string EstacionamentoGratis, string Piscina, string PrecoInicial, string PrecoFinal)
        {
            //IHotelRepositorio repositorio = new HotelRepositorio();
            //HotelAplicacao aplicacao = new HotelAplicacao(repositorio);

            //List<Hotel> Hoteis = aplicacao.SelecionarTodos().Select(hotel => HotelDTOParaModel(hotel)).ToList();
            ////List<Hotel> Hoteis = new List<Hotel>();

            //if (EstacionamentoGratis.ToBool())
            //    Hoteis = Hoteis.Where(h => h.EstacionamentoGratis).ToList();


            //List<Hotel> Hoteis = aplicacao.SelecionarTodos().Select(hotel => HotelDTOParaModel(hotel)).ToList();

                //ViewBag.Hoteis = Hoteis;

            //return View(Hoteis);
            return View();
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

        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Produto produto = db.Produtos.Find(id);
        //    if (produto == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    ViewBag.Categoria = db.Categorias.Find(produto.CategoriaId).CategoriaNome;
        //    return View(produto);
        //}

        public ActionResult Detalhe(int id)
        {
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Produto produto = db.Produtos.Find(id);
        //    if (produto == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    ViewBag.Categoria = db.Categorias.Find(produto.CategoriaId).CategoriaNome;
            return View();
        }

    }
}