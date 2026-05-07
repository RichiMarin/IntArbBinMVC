// Models/ResultadoBusqueda.cs
namespace IntArbBinMVC.Models
{
    public class ResultadoBusqueda
    {
        public Nodo Nodo { get; set; }
        public int Comparaciones { get; set; }

        public bool Encontrado => Nodo != null;
    }
}