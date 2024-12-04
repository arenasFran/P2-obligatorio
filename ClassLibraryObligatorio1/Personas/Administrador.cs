namespace BibliotecaClases.Personas
{
    public class Administrador : Usuario
    {
        public Administrador(string nombre, string apellido, string email, string contraseña)
            : base(nombre, apellido, email, contraseña, "Admin")
        { }
    }
}