using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteTotvs.MVC.Models
{
    public class Quarto : Base
    {

        public int IdHotel { get; set; }
        public decimal Preco { get; set; }
        public decimal PrecoPromocional { get; set; }
        public decimal PrecoFinal { get; set; }

        public bool Banheiro { get; set; }
        public bool Frigobar { get; set; }
        public bool Telefone { get; set; }
        public bool Tv { get; set; }
        public bool Ventilador { get; set; }

        public string Foto1 { get; set; }
        public string Foto2 { get; set; }
        public string Foto3 { get; set; }

        public Hotel Hotel { get; set; }

    }
}