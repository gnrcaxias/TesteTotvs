namespace TesteTotvs.RepositorioTexto
{
    public enum HotelColumns
    {
        Id = 0,
        NomeHotel = 1,
        Cidade = 2,
        Bairro = 3,
        WifiGratis = 4,
        CafeDaManhaGratis = 5,
        EstacionamentoGratis = 6,
        Piscina = 7,
        QuantidadeEstrelas = 8
    }

    public enum QuartoColumns
    {
        Id = 0,
        IdHotel = 1,
        Preco = 2,
        PrecoPromocional = 3,
        Banheiro = 4,
        Frigobar = 5,
        Telefone = 6,
        Tv = 7,
        Ventilador = 8,
        Foto1 = 9,
        Foto2 = 10,
        Foto3 = 11
    }
}
