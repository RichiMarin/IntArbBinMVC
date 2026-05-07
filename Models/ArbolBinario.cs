// Models/ArbolBinario.cs
using System.Collections.Generic;

namespace IntArbBinMVC.Models
{
    public class ArbolBinario
    {
        public Nodo Raiz { get; private set; }

        private readonly StringComparer comparador =
            StringComparer.OrdinalIgnoreCase;

        public bool Insertar(string nombre, bool esCarpeta, out int comparaciones)
        {
            comparaciones = 0;

            if (string.IsNullOrWhiteSpace(nombre))
                return false;

            Nodo nuevo = new Nodo(nombre, esCarpeta);

            if (Raiz == null)
            {
                Raiz = nuevo;
                return true;
            }

            Nodo actual = Raiz;

            while (true)
            {
                comparaciones++;

                int cmp = comparador.Compare(nombre, actual.Nombre);

                if (cmp == 0)
                    return false;

                if (cmp < 0)
                {
                    if (actual.Izquierdo == null)
                    {
                        actual.Izquierdo = nuevo;
                        return true;
                    }

                    actual = actual.Izquierdo;
                }
                else
                {
                    if (actual.Derecho == null)
                    {
                        actual.Derecho = nuevo;
                        return true;
                    }

                    actual = actual.Derecho;
                }
            }
        }

        public ResultadoBusqueda Buscar(string nombre)
        {
            int comparaciones = 0;

            Nodo actual = Raiz;

            while (actual != null)
            {
                comparaciones++;

                int cmp = comparador.Compare(nombre, actual.Nombre);

                if (cmp == 0)
                {
                    return new ResultadoBusqueda
                    {
                        Nodo = actual,
                        Comparaciones = comparaciones
                    };
                }

                actual = cmp < 0
                    ? actual.Izquierdo
                    : actual.Derecho;
            }

            return new ResultadoBusqueda
            {
                Nodo = null,
                Comparaciones = comparaciones
            };
        }

        public bool Actualizar(string viejo, string nuevo)
        {
            ResultadoBusqueda busquedaViejo = Buscar(viejo);

            if (!busquedaViejo.Encontrado)
                return false;

            ResultadoBusqueda busquedaNuevo = Buscar(nuevo);

            if (busquedaNuevo.Encontrado)
                return false;

            bool esCarpeta = busquedaViejo.Nodo.EsCarpeta;

            Eliminar(viejo);

            int comparaciones;
            return Insertar(nuevo, esCarpeta, out comparaciones);
        }

        public bool Eliminar(string nombre)
        {
            bool eliminado;

            Raiz = EliminarRecursivo(Raiz, nombre, out eliminado);

            return eliminado;
        }

        private Nodo EliminarRecursivo(
            Nodo nodo,
            string nombre,
            out bool eliminado)
        {
            eliminado = false;

            if (nodo == null)
                return null;

            int cmp = comparador.Compare(nombre, nodo.Nombre);

            if (cmp < 0)
            {
                nodo.Izquierdo = EliminarRecursivo(
                    nodo.Izquierdo,
                    nombre,
                    out eliminado);

                return nodo;
            }

            if (cmp > 0)
            {
                nodo.Derecho = EliminarRecursivo(
                    nodo.Derecho,
                    nombre,
                    out eliminado);

                return nodo;
            }

            eliminado = true;

            // hoja
            if (nodo.Izquierdo == null &&
                nodo.Derecho == null)
            {
                return null;
            }

            // un hijo
            if (nodo.Izquierdo == null)
                return nodo.Derecho;

            if (nodo.Derecho == null)
                return nodo.Izquierdo;

            // dos hijos
            Nodo sucesor = ObtenerMinimo(nodo.Derecho);

            nodo.Nombre = sucesor.Nombre;
            nodo.EsCarpeta = sucesor.EsCarpeta;

            bool eliminadoInterno;

            nodo.Derecho = EliminarRecursivo(
                nodo.Derecho,
                sucesor.Nombre,
                out eliminadoInterno);

            return nodo;
        }

        private Nodo ObtenerMinimo(Nodo nodo)
        {
            while (nodo.Izquierdo != null)
            {
                nodo = nodo.Izquierdo;
            }

            return nodo;
        }

        public List<string> Inorden()
        {
            List<string> lista = new List<string>();

            InordenRec(Raiz, lista);

            return lista;
        }

        private void InordenRec(
            Nodo nodo,
            List<string> lista)
        {
            if (nodo == null)
                return;

            InordenRec(nodo.Izquierdo, lista);

            lista.Add(nodo.Nombre);

            InordenRec(nodo.Derecho, lista);
        }

        public List<string> Preorden()
        {
            List<string> lista = new List<string>();

            PreordenRec(Raiz, lista);

            return lista;
        }

        private void PreordenRec(
            Nodo nodo,
            List<string> lista)
        {
            if (nodo == null)
                return;

            lista.Add(nodo.Nombre);

            PreordenRec(nodo.Izquierdo, lista);

            PreordenRec(nodo.Derecho, lista);
        }

        public List<string> Postorden()
        {
            List<string> lista = new List<string>();

            PostordenRec(Raiz, lista);

            return lista;
        }

        private void PostordenRec(
            Nodo nodo,
            List<string> lista)
        {
            if (nodo == null)
                return;

            PostordenRec(nodo.Izquierdo, lista);

            PostordenRec(nodo.Derecho, lista);

            lista.Add(nodo.Nombre);
        }

        public List<string> PorNiveles()
        {
            List<string> lista = new List<string>();

            if (Raiz == null)
                return lista;

            Queue<Nodo> cola = new Queue<Nodo>();

            cola.Enqueue(Raiz);

            while (cola.Count > 0)
            {
                Nodo actual = cola.Dequeue();

                lista.Add(actual.Nombre);

                if (actual.Izquierdo != null)
                    cola.Enqueue(actual.Izquierdo);

                if (actual.Derecho != null)
                    cola.Enqueue(actual.Derecho);
            }

            return lista;
        }

        public int Altura()
        {
            return AlturaRec(Raiz);
        }

        private int AlturaRec(Nodo nodo)
        {
            if (nodo == null)
                return 0;

            int izquierda = AlturaRec(nodo.Izquierdo);
            int derecha = AlturaRec(nodo.Derecho);

            return Math.Max(izquierda, derecha) + 1;
        }
    }
}