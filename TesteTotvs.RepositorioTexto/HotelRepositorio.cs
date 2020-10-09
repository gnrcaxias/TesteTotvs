using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TesteTotvs.Dominio.Entidade;
using TesteTotvs.Dominio.Repositorio;
using TesteTotvs.Utilitarios;

namespace TesteTotvs.RepositorioTexto
{
    public class HotelRepositorio : IHotelRepositorio
    {
        public string caminhoArquivoHoteis = $@"{AppDomain.CurrentDomain.GetData("DataDirectory").ToString()}\Hoteis.csv";

        public Hotel Selecionar(int id)
        {
            return SelecionarTodos()?.Where(st => st.Id == id).FirstOrDefault();
        }

        public List<Hotel> SelecionarTodos(string WifiGratis, string CafeGratis, string EstacionamentoGratis, string Piscina)
        {
            var listaHoteis = new List<Hotel>();

            try
            {
                using (var reader = new StreamReader(caminhoArquivoHoteis))
                {
                    if (!reader.EndOfStream)
                    {
                        listaHoteis = new List<Hotel>();
                        reader.ReadLine();
                    }

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');
                        var hotel = PreencherCampos(values);

                        if (!string.IsNullOrWhiteSpace(WifiGratis) 
                            && !string.IsNullOrWhiteSpace(CafeGratis)
                            && !string.IsNullOrWhiteSpace(EstacionamentoGratis)
                            && !string.IsNullOrWhiteSpace(Piscina))
                        {
                            if (((WifiGratis.ToBool() && WifiGratis.ToBool() == hotel.WifiGratis)
                                || (CafeGratis.ToBool() && hotel.CafeDaManhaGratis == CafeGratis.ToBool())
                                || (EstacionamentoGratis.ToBool() && hotel.EstacionamentoGratis == EstacionamentoGratis.ToBool())
                                || (Piscina.ToBool() && hotel.Piscina == Piscina.ToBool()))
                                || (!WifiGratis.ToBool() && !CafeGratis.ToBool() && !EstacionamentoGratis.ToBool() && !Piscina.ToBool()))
                            {
                                listaHoteis.Add(hotel);
                            }
                        }
                        else
                            listaHoteis.Add(hotel);
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new NotImplementedException($"Erro genérico: {Ex.Message}");
            }

            return listaHoteis;
        }

        public List<Hotel> SelecionarTodos()
        {
            var listaHoteis = new List<Hotel>();

            try
            {
                using (var reader = new StreamReader(caminhoArquivoHoteis))
                {
                    if (!reader.EndOfStream)
                    {
                        listaHoteis = new List<Hotel>();
                        reader.ReadLine();
                    }

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');
                        var hotel = PreencherCampos(values);

                        listaHoteis.Add(hotel);
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new NotImplementedException($"Erro genérico: {Ex.Message}");
            }

            return listaHoteis;
        }

        public Hotel PreencherCampos(string[] line)
        {
            Hotel hotel = new Hotel()
            {
                Id = line[HotelColumns.Id.ToInt32()].ToInt32(),
                NomeHotel = line[HotelColumns.NomeHotel.ToInt32()],
                Cidade = line[HotelColumns.Cidade.ToInt32()],
                Bairro = line[HotelColumns.Bairro.ToInt32()],
                WifiGratis = line[HotelColumns.WifiGratis.ToInt32()].ToBool(),
                CafeDaManhaGratis = line[HotelColumns.CafeDaManhaGratis.ToInt32()].ToBool(),
                EstacionamentoGratis = line[HotelColumns.EstacionamentoGratis.ToInt32()].ToBool(),
                Piscina = line[HotelColumns.Piscina.ToInt32()].ToBool(),
                QuantidadeEstrelas = line[HotelColumns.QuantidadeEstrelas.ToInt32()].ToInt32()
            };

            return hotel;
        }
    }
}
