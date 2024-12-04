using BibliotecaClases.Inventario;
using BibliotecaClases.Personas;

namespace BibliotecaClases.Negocio
{
    public class Subasta : Publicacion
    {
        private List<Oferta> _ofertas;
        private Oferta? _mejorOferta;

        public Subasta(string nombre, DateTime fechaPubli, List<Articulo> articulos) : base(nombre, fechaPubli, articulos)
        {
            this._ofertas = new List<Oferta>();
            this._mejorOferta = null;  
        }

        public List<Oferta> Ofertas
        {
            get { return _ofertas; }
        }

        public Oferta? MejorOferta
        {
            get { return _mejorOferta; }
            set { _mejorOferta = value; }
        }

        public void AgregarOferta(Oferta oferta)
        {
            double ofertaMaxima = MejorOferta?.Cantidad ?? 0;
            if(oferta.Cantidad <= 0) {
                throw new Exception("La oferta debe ser mayor que cero.");
            }

            if (oferta.Cantidad <= ofertaMaxima) {
                throw new Exception($"La oferta debe ser mayor que la oferta más alta actual de {ofertaMaxima:C}.");
            }
            
            if(!oferta.OfertadoPor.TieneSaldo(oferta.Cantidad)) {
                throw new Exception("Saldo insuficiente para realizar la oferta.");
            }

            if(Estado != EstadoPublicación.Abierta) {
                throw new Exception("La subasta no está abierta.");
            }

            this._ofertas.Add(oferta);
            
            if(oferta.Cantidad > (MejorOferta?.Cantidad ?? 0)) {
                MejorOferta = oferta;
            }
        }

        public Oferta? ObtenerMejorOferta() {
            // Se busca la mejor oferta desde la mas reciente a la mas antigua, 
            // validando que el cliente tenga saldo suficiente para cubrir la oferta
            for(int i = Ofertas.Count - 1; i >= 0; i--) {
                Oferta oferta = Ofertas[i];
                if(oferta.OfertadoPor.TieneSaldo(oferta.Cantidad)) {
                    return oferta;
                }
            }
            return null;
        }

        public override void Finalizar(Usuario finalizadoPor){
            if (Estado != EstadoPublicación.Abierta) {
                throw new Exception("Esta publicación no está abierta");
            }

            Oferta? mejorOferta = ObtenerMejorOferta();

            // No hay ofertas, asi que se cancela la subasta
            if(mejorOferta == null) {
                Estado = EstadoPublicación.Cancelada;
            }

            // Si hay una mejor oferta, se resta el saldo y se finaliza la subasta
            if(mejorOferta != null) {
                mejorOferta.OfertadoPor.RestarSaldo(mejorOferta.Cantidad);
                Estado = EstadoPublicación.Cerrada;
            }

            base.Finalizar(finalizadoPor);
        }
    }
}
