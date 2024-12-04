namespace BibliotecaClases.Inventario
{
    internal class GeneradorArticulo
    { 
        public static List<Articulo> GenerarArticulos()
        {
            List<Articulo> articulos = new List<Articulo>
            {
                new("PlanchaVuela3000", CategoriaArticulo.Electronica, 49.99f),
                new("ZapatillasVoladoras", CategoriaArticulo.Ropa, 89.99f),
                new("CucharaEspacial", CategoriaArticulo.Alimentos, 5.99f),
                new("CalcetinesInvisibles", CategoriaArticulo.Ropa, 14.99f),
                new("Teletransportador", CategoriaArticulo.Electronica, 599.99f),
                new("BicicletaSinPedales", CategoriaArticulo.Electronica, 199.99f),
                new("CapaDeSuperhéroe", CategoriaArticulo.Ropa, 29.99f),
                new("AuricularesDelSilencio", CategoriaArticulo.Electronica, 99.99f),
                new("CamisaAutolimpiante", CategoriaArticulo.Ropa, 39.99f),
                new("TenedorInteligente", CategoriaArticulo.Alimentos, 12.99f),
                new("GorraMultifuncional", CategoriaArticulo.Ropa, 19.99f),
                new("PelotaSaltarinaInfinita", CategoriaArticulo.Electronica, 15.99f),
                new("CamisetaQueBrilla", CategoriaArticulo.Ropa, 25.99f),
                new("MicroondasPortátil", CategoriaArticulo.Electronica, 49.99f),
                new("LentesConVisiónDeRayosX", CategoriaArticulo.Electronica, 149.99f),
                new("GuantesParaTodo", CategoriaArticulo.Ropa, 24.99f),
                new("RelojQueViajaEnElTiempo", CategoriaArticulo.Electronica, 399.99f),
                new("MochilaEspacial", CategoriaArticulo.Ropa, 69.99f),
                new("CuchilloQueNuncaCorta", CategoriaArticulo.Alimentos, 3.99f),
                new("SombreroVolador", CategoriaArticulo.Ropa, 49.99f),
                new("SillaQueFlota", CategoriaArticulo.Electronica, 79.99f),
                new("PantalonesAutoreparables", CategoriaArticulo.Ropa, 29.99f),
                new("GafasQueVenElFuturo", CategoriaArticulo.Electronica, 199.99f),
                new("BolígrafoInagotable", CategoriaArticulo.Electronica, 9.99f),
                new("PijamaDeViaje", CategoriaArticulo.Ropa, 39.99f),
                new("CepilloDeDientesRobot", CategoriaArticulo.Alimentos, 19.99f),
                new("LámparaQueHabla", CategoriaArticulo.Electronica, 59.99f),
                new("ZapatosQueNuncaSeEnsucian", CategoriaArticulo.Ropa, 79.99f),
                new("SombrillaInteligente", CategoriaArticulo.Electronica, 24.99f),
                new("PantalonesFluorescentes", CategoriaArticulo.Ropa, 34.99f),
                new("DespertadorSaltador", CategoriaArticulo.Electronica, 19.99f),
                new("GorroQueLeePensamientos", CategoriaArticulo.Ropa, 99.99f),
                new("CucharaCaliente", CategoriaArticulo.Alimentos, 9.99f),
                new("CamisaQueCambiaDeColor", CategoriaArticulo.Ropa, 29.99f),
                new("LlaveroDetectorDePerdidos", CategoriaArticulo.Electronica, 14.99f),
                new("SandaliasAntigravedad", CategoriaArticulo.Ropa, 49.99f),
                new("TermoQueNuncaSeVacía", CategoriaArticulo.Alimentos, 19.99f),
                new("PantalonesConAireAcondicionado", CategoriaArticulo.Ropa, 69.99f),
                new("SombreroDeInvisibilidad", CategoriaArticulo.Ropa, 149.99f),
                new("HeladoQueNuncaSeDerrite", CategoriaArticulo.Alimentos, 4.99f),
                new("TeléfonoQueSoloLlama", CategoriaArticulo.Electronica, 9.99f),
                new("TijerasQueCortanTodo", CategoriaArticulo.Alimentos, 14.99f),
                new("FundaParaSillas", CategoriaArticulo.Ropa, 24.99f),
                new("SombreroInteligente", CategoriaArticulo.Ropa, 39.99f),
                new("ChalecoFlotador", CategoriaArticulo.Ropa, 29.99f),
                new("CamaPortátil", CategoriaArticulo.Electronica, 89.99f),
                new("RelojQueSiempreLlegaTarde", CategoriaArticulo.Electronica, 19.99f),
                new("AbrigoQueTeAbraza", CategoriaArticulo.Ropa, 59.99f),
                new("CepilloDePeloAutolavable", CategoriaArticulo.Ropa, 12.99f),
                new("CucharónDeLaSuerte", CategoriaArticulo.Alimentos, 7.99f)
            };

            return articulos;
        }
    }
}
