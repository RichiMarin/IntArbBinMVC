// Views/ConsolaView.cs
using IntArbBinMVC.Models;

namespace IntArbBinMVC.Views
{
    public class ConsolaView
    {
        public void Titulo(string texto)
        {
            Console.WriteLine("\n=================================");
            Console.WriteLine(texto);
            Console.WriteLine("=================================");
        }

        public void Mensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
        }

        public void MostrarBusqueda(
            string nombre,
            bool encontrado,
            int comparaciones)
        {
            Console.WriteLine(
                $"{nombre} -> " +
                $"{(encontrado ? "Hallado" : "No hallado")} " +
                $"| Comparaciones: {comparaciones}");
        }

        public void MostrarRecorrido(
            string nombre,
            List<string> recorrido)
        {
            Console.WriteLine(
                $"{nombre}: {string.Join(", ", recorrido)}");
        }

        public void ImprimirArbol(
            Nodo nodo,
            string prefijo = "",
            bool esUltimo = true)
        {
            if (nodo == null)
                return;

            Console.WriteLine(
                prefijo +
                (esUltimo ? "└── " : "├── ") +
                nodo.Nombre +
                (nodo.EsCarpeta
                    ? " [Carpeta]"
                    : " [Archivo]"));

            string nuevoPrefijo =
                prefijo + (esUltimo ? "    " : "│   ");

            bool tieneDerecho = nodo.Derecho != null;

            if (nodo.Izquierdo != null)
            {
                ImprimirArbol(
                    nodo.Izquierdo,
                    nuevoPrefijo,
                    !tieneDerecho);
            }

            if (nodo.Derecho != null)
            {
                ImprimirArbol(
                    nodo.Derecho,
                    nuevoPrefijo,
                    true);
            }
        }
    }
}