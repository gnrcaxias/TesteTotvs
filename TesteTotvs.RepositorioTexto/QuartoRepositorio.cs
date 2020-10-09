using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TesteTotvs.Dominio.Entidade;
using TesteTotvs.Dominio.Repositorio;
using TesteTotvs.Utilitarios;

namespace TesteTotvs.RepositorioTexto
{
    public class QuartoRepositorio : IQuartoRepositorio
    {
        public string caminhoArquivoQuartos = $@"{AppDomain.CurrentDomain.GetData("DataDirectory").ToString()}\Quartos.csv";

        public Quarto Selecionar(int id)
        {
            return SelecionarTodos()?.Where(st => st.Id == id).FirstOrDefault();
        }

        public List<Quarto> SelecionarTodos(string PrecoInicial, string PrecoFinal,
                                            string Frigobar, string Tv, string Banheiro,
                                            string Telefone, string Ventilador)
        {
            var listaQuartos = new List<Quarto>();

            try
            {
                using (var reader = new StreamReader(caminhoArquivoQuartos))
                {
                    if (!reader.EndOfStream)
                    {
                        listaQuartos = new List<Quarto>();
                        reader.ReadLine();
                    }

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');
                        var quarto = PreencherCampos(values);

                        if (!string.IsNullOrWhiteSpace(Frigobar)
                            && !string.IsNullOrWhiteSpace(Tv)
                            && !string.IsNullOrWhiteSpace(Banheiro)
                            && !string.IsNullOrWhiteSpace(Telefone)
                            && !string.IsNullOrWhiteSpace(Ventilador))
                        {
                            if (((Frigobar.ToBool() && Frigobar.ToBool() == quarto.Frigobar)
                                || (Tv.ToBool() && quarto.Tv == Tv.ToBool())
                                || (Banheiro.ToBool() && quarto.Banheiro == Banheiro.ToBool())
                                || (Telefone.ToBool() && quarto.Telefone == Telefone.ToBool())
                                || (Ventilador.ToBool() && quarto.Ventilador == Ventilador.ToBool()))
                                || (!Frigobar.ToBool() && !Tv.ToBool() && !Banheiro.ToBool() && !Telefone.ToBool() && !Ventilador.ToBool()))
                            {
                                var precoQuarto = (quarto.PrecoPromocional > 0 ? quarto.PrecoPromocional : quarto.Preco);

                                if ((!string.IsNullOrWhiteSpace(PrecoInicial) && !string.IsNullOrWhiteSpace(PrecoFinal)
                                    && (PrecoInicial.ToDecimal() <= precoQuarto && PrecoFinal.ToDecimal() >= precoQuarto))
                                    || (!string.IsNullOrWhiteSpace(PrecoInicial) && string.IsNullOrWhiteSpace(PrecoFinal)
                                        && PrecoInicial.ToDecimal() <= precoQuarto)
                                    || (string.IsNullOrWhiteSpace(PrecoInicial) && !string.IsNullOrWhiteSpace(PrecoFinal)
                                        && PrecoFinal.ToDecimal() >= precoQuarto)
                                    || string.IsNullOrWhiteSpace(PrecoInicial) && string.IsNullOrWhiteSpace(PrecoFinal))
                                {
                                    listaQuartos.Add(quarto);
                                }
                            }
                        }
                        else
                            listaQuartos.Add(quarto);
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new NotImplementedException($"Erro genérico: {Ex.Message}");
            }

            return listaQuartos;
        }

        public List<Quarto> SelecionarTodos()
        {
            var listaQuartos = new List<Quarto>();

            try
            {
                using (var reader = new StreamReader(caminhoArquivoQuartos))
                {
                    if (!reader.EndOfStream)
                    {
                        listaQuartos = new List<Quarto>();
                        reader.ReadLine();
                    }

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');
                        var quarto = PreencherCampos(values);

                        listaQuartos.Add(quarto);
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new NotImplementedException($"Erro genérico: {Ex.Message}");
            }

            return listaQuartos;
        }

        public Quarto PreencherCampos(string[] line)
        {
            Quarto quarto = new Quarto()
            {
                Id = line[QuartoColumns.Id.ToInt32()].ToInt32(),
                Banheiro = line[QuartoColumns.Banheiro.ToInt32()].ToBool(),
                Foto1 = line[QuartoColumns.Foto1.ToInt32()],
                Foto2 = line[QuartoColumns.Foto2.ToInt32()],
                Foto3 = line[QuartoColumns.Foto3.ToInt32()],
                Frigobar = line[QuartoColumns.Frigobar.ToInt32()].ToBool(),
                IdHotel = line[QuartoColumns.IdHotel.ToInt32()].ToInt32(),
                Preco = line[QuartoColumns.Preco.ToInt32()].ToDecimal(),
                PrecoPromocional = line[QuartoColumns.PrecoPromocional.ToInt32()].ToDecimal(),
                Telefone = line[QuartoColumns.Telefone.ToInt32()].ToBool(),
                Tv = line[QuartoColumns.Tv.ToInt32()].ToBool(),
                Ventilador = line[QuartoColumns.Ventilador.ToInt32()].ToBool()
            };

            return quarto;
        }
    }
}
