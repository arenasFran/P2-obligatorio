namespace BibliotecaClases.Personas
{
    internal class GeneradorUsuario
    {
        public static List<Usuario> GenerarUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            // Generar y agregar clientes
            List<Cliente> clientes = GenerarClientes();
            usuarios.AddRange(clientes);

            // Generar y agregar administradores
            List<Administrador> administradores = GenerarAdministradores();
            usuarios.AddRange(administradores);

            return usuarios;
        }

        private static List<Cliente> GenerarClientes()
        {
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente("Ashe", "Frostarcher", "ashe.frost@example.com", "arrow123", 350.50),
                new Cliente("Draven", "Executioner", "draven.exec@example.com", "whirlingaxe", 450.75),
                new Cliente("Ariana", "Grande", "ariana.grande@example.com", "popstar789", 1200.00),
                new Cliente("Kanye", "West", "kanye.west@example.com", "yeezy321", 999.99),
                new Cliente("Leona", "Solari", "leona.solari@example.com", "sunblade777", 750.90),
                new Cliente("Taylor", "Swift", "taylor.swift@example.com", "tswizzle123", 1500.45),
                new Cliente("Ezreal", "Explorer", "ezreal.explore@example.com", "mysticshot", 1200.25),
                new Cliente("Elon", "Musk", "elon.musk@example.com", "tesla007", 10000.00),
                new Cliente("Rihanna", "Fenty", "rihanna.fenty@example.com", "umbrella999", 750.00),
                new Cliente("Jinx", "Powder", "jinx.powder@example.com", "rockettoomuch", 600.80)
            };

            foreach (Cliente cliente in clientes)
            {
                cliente.Validar();
            }

            return clientes;
        }

        private static List<Administrador> GenerarAdministradores()
        {
            List<Administrador> administradores = new List<Administrador>
            {
                new Administrador("Bruce", "Wayne", "bruce.wayne@example.com", "batman123"),
                new Administrador("Natasha", "Romanoff", "natasha.romanoff@example.com", "blackwidow007")
            };

            foreach (Administrador admin in administradores)
            {
                admin.Validar();
            }

            return administradores;
        }
    }
}
