namespace Tools
{
    public sealed class Log
    {
        private static Log _instancia = null!;
        private string _path;
        private static object _protect = new object();

        // Método para obtener la instancia. Si no hay una instancia creada, se crea una nueva.
        public static Log GetInstancia(string path)
        {
            // Utilizo el lock para proteger el hilo de mi instancia.
            lock (_protect)
            {
                if (_instancia == null)
                {
                    _instancia = new Log(path);
                }
            }

            return _instancia;
        }

        // Constructor con el que se obtiene por parametro el path donde se va a guardar el Log.
        private Log(string path)
        {
            _path = path;
        }

        // Método para guardar mi Log.
        public void Guardar(string mensaje)
        {
            File.AppendAllText(_path, mensaje + Environment.NewLine);
        }
    }
}