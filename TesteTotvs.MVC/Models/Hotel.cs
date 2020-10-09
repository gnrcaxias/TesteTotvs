using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TesteTotvs.MVC.Models
{
    public class Hotel: Base
    {
        [DisplayName("Nome do Hotel")]
        public string NomeHotel { get; set; }

        [DisplayName("Cidade")]
        public string Cidade { get; set; }

        [DisplayName("Bairro")]
        public string Bairro { get; set; }

        [DisplayName("Wifi Grátis")]
        public bool WifiGratis { get; set; }

        [DisplayName("Café da Manhã Grátis")]
        public bool CafeDaManhaGratis { get; set; }

        [DisplayName("Estacionamento Grátis")]
        public bool EstacionamentoGratis { get; set; }

        [DisplayName("Piscina")]
        public bool Piscina { get; set; }

        [DisplayName("Quantidade de Estrelas")]
        public int QuantidadeEstrelas { get; set; }
    }
}