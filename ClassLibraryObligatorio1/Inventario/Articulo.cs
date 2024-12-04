    namespace BibliotecaClases.Inventario
    {
        public class Articulo
        {
            private static int _ultimoId = 1;
            private int _id;
            private string _nombre;
            private double _precio;

            private CategoriaArticulo _categoria;

            public Articulo(string nombre, CategoriaArticulo categoria, float precio)
            {
                _id = ++_ultimoId;
                _nombre = nombre;
                Categoria = categoria;
                _precio = precio;
            }

            public int Id
            {
                get { return _id; }
                set { _id = value; }
            }

            public string Nombre
            {
                get
                {
                    return _nombre;
                }
                set
                {
                    _nombre = value;
                }
            }

            public CategoriaArticulo Categoria
            {
                get { return _categoria; }
                set { _categoria = value; }
            }

            public double Precio
            {
                get { return _precio; }
                set { _precio = value; }
            }

            public override string ToString()
            {
                return $"{Nombre} - ${Precio} - {Categoria}";
            }

        public static void VerificarNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre) || nombre.Length < 3)
            {
                throw new Exception("El nombre no debe ser vacío y debe tener al menos 2 caracteres.");
            }
        }

        public static void VerificarPrecio(double precio)
        {
            if (precio < 0)
            {
                throw new Exception("El precio no puede ser negativo.");
            }
        }
    }
}
