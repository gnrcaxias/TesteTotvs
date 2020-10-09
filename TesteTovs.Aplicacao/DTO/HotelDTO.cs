using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteTovs.Aplicacao.DTO
{
    public class HotelDTO: Base
    {
        public string NomeHotel { get; set; }

        public string Cidade { get; set; }
        public string Bairro { get; set; }

        public bool WifiGratis { get; set; }
        public bool CafeDaManhaGratis { get; set; }
        public bool EstacionamentoGratis { get; set; }
        public bool Piscina { get; set; }

        public int QuantidadeEstrelas { get; set; }

    }
}
