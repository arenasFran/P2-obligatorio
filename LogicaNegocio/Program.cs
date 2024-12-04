using BibliotecaClases;
using BibliotecaClases.Inventario;
using BibliotecaClases.Negocio;
using BibliotecaClases.Personas;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        Sistema sistema = Sistema.Instancia;

        while (running)
        {
            Console.WriteLine("\nOpciones del Menu:");
            Console.WriteLine("1. Listar todos los usuarios.");
            Console.WriteLine("2. Dado un nombre de categoría, listar todos los artículos de esa categoría.");
            Console.WriteLine("3. Alta de artículo.");
            Console.WriteLine("4. Dadas dos fechas, listar las publicaciones entre esas fechas.");
            Console.WriteLine("5. Salir.");

            string? choice = Console.ReadLine();
            if (choice == null)
            {
                Console.WriteLine("El input no debe ser vacío, por favor intente de nuevo.");
                continue;
            }

            switch (choice)
            {
                case "1":
                    Program.ListarUsuarios(sistema);
                    break;
                case "2":
                    Program.ListarArticulosPorCategoria(sistema);
                    break;
                case "3":
                    Program.AltaArticulo(sistema);
                    break;
                case "4":
                    Program.ListarPublicacionesPorFechas(sistema);
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        }
    }

    protected static void ListarUsuarios(Sistema sistema)
    {
        Console.WriteLine("Listando usuarios:");

        if (sistema.Usuarios.Count == 0)
        {
            Console.WriteLine("La lista de usuarios está vacía.");
            return;
        }

        foreach (Usuario usuario in sistema.Usuarios)
        {
            Console.WriteLine(usuario.ToString());
        }
    }

    // Lista las categorías y solicita al usuario que seleccione una. Devuelve una CategoriaArticulo según selección.
    protected static CategoriaArticulo ObtenerCategoriaDesdeEntrada()
    {
        Console.WriteLine("Seleccione la categoría:");
        Sistema.ListarCategorias();

        CategoriaArticulo? categoriaArticulo = null;

        while (categoriaArticulo == null)
        {
            try
            {
                string? input = Console.ReadLine() ?? throw new Exception();

                categoriaArticulo = (CategoriaArticulo)Enum.Parse(typeof(CategoriaArticulo), input);
            }
            catch (Exception)
            {
                Console.WriteLine("El input debe ser un nombre de categoría. Las categorías disponibles son:");
                Sistema.ListarCategorias();
            }
        }

        Console.WriteLine($"Categoría seleccionada: {categoriaArticulo}.");

        return (CategoriaArticulo)categoriaArticulo;
    }

    protected static void ListarArticulosPorCategoria(Sistema sistema)
    {
        CategoriaArticulo categoriaArticulo = ObtenerCategoriaDesdeEntrada();

        bool hayArticulos = false;
        foreach (Articulo articulo in sistema.Articulos)
        {
            if (articulo.Categoria == categoriaArticulo)
            {
                Console.WriteLine(articulo.ToString());
                hayArticulos = true;
            }
        }

        if (!hayArticulos)
        {
            Console.WriteLine("No se encontraron artículos para esta categoría.");
        }
    }

    protected static void AltaArticulo(Sistema sistema)
    {
        string? nombreArticulo = null;
        CategoriaArticulo? categoriaArticulo = null;
        float? precioArticulo = null;

        // Loop hasta que se ingresen todos los datos necesarios, validando cada uno.
        while (nombreArticulo == null || categoriaArticulo == null || precioArticulo == null)
        {
            if (nombreArticulo == null)
            {
                Console.WriteLine("Ingrese el nombre del artículo:");
                try
                {
                    string? input = Console.ReadLine() ?? throw new Exception("El input no debe ser null.");
                    Articulo.VerificarNombre(input);
                    nombreArticulo = input;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (categoriaArticulo == null)
            {
                categoriaArticulo = ObtenerCategoriaDesdeEntrada();
            }
            else if (precioArticulo == null)
            {
                Console.WriteLine("Ingrese el precio del artículo:");
                try
                {
                    string? input = Console.ReadLine() ?? throw new Exception("El input no debe ser null.");
                    float precio = float.Parse(input);
                    Articulo.VerificarPrecio(precio);
                    precioArticulo = precio;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        Articulo articulo = new(nombreArticulo, categoriaArticulo.Value, precioArticulo.Value);
        sistema.AgregarArticulo(articulo);

        Console.WriteLine($"Artículo creado: {articulo}");
    }

    public static void ListarPublicacionesPorFechas(Sistema sistema)
    {
        DateTime fechaInicio;
        DateTime fechaFin;

        Console.WriteLine("Ingrese la fecha de inicio (dd/mm/yyyy):");
        while (true)
        {
            try
            {
                string? input = Console.ReadLine();
                fechaInicio = DateTime.ParseExact(input, "dd/MM/yyyy", null);
                break;
            }
            catch (Exception)
            {
                Console.WriteLine("Formato de fecha inválido. Use dd/mm/yyyy (ejemplo: 25/10/2000):");
            }
        }

        Console.WriteLine("Ingrese la fecha de fin (dd/mm/yyyy):");
        while (true)
        {
            try
            {
                string? input = Console.ReadLine();
                fechaFin = DateTime.ParseExact(input, "dd/MM/yyyy", null);
                break;
            }
            catch (Exception)
            {
                Console.WriteLine("Formato de fecha inválido. Use dd/mm/yyyy (ejemplo: 25/10/2000):");
            }
        }

        List<Publicacion> publicaciones = sistema.ListarPublicacionesPorFechas(fechaInicio, fechaFin);

        bool hayPublicaciones = false;
        Console.WriteLine("Publicaciones encontradas:");
        foreach (Publicacion publicacion in publicaciones)
        {
            Console.WriteLine(publicacion);
            hayPublicaciones = true;
        }
        if (!hayPublicaciones)
        {
            Console.WriteLine("No se encontraron publicaciones en el rango de fechas especificado.");
        }
    }
}
