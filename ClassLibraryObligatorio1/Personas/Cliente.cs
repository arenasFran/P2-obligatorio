namespace BibliotecaClases.Personas
{
    public class Cliente : Usuario
    {
        private double _saldo;

        public Cliente(string nombre, string apellido, string email, string contraseña, double saldo)
        : base(nombre, apellido, email, contraseña, "Cliente")
        {
            Saldo = saldo;
        }

        public double Saldo
        {
            get { return _saldo; }
            set { _saldo = value; }
        }

        public Boolean TieneSaldo(double cantidad) {
            return Saldo - cantidad >= 0;
        }

        public void SumarSaldo(double cantidad) {
            Saldo += cantidad;
        }

        public void RestarSaldo(double cantidad) {
            if(!TieneSaldo(cantidad)) {
                throw new Exception("Saldo insuficiente.");
            }

            Saldo -= cantidad;
        }

        public override string ToString()
        {
            return $"{Nombre} {Apellido} - {Email} - ${Saldo}";
        }

        public override void Validar()
        {
            base.Validar();

            if (Saldo < 0) throw new Exception("El saldo no puede ser negativo.");
            
        }
    }
}
