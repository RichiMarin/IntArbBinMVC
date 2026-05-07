// Controllers/ArbolController.cs
using IntArbBinMVC.Models;
using IntArbBinMVC.Views;

namespace IntArbBinMVC.Controllers
{
    public class ArbolController
    {
        private readonly ArbolBinario arbol;
        private readonly ConsolaView view;

        public ArbolController()
        {
            arbol = new ArbolBinario();
            view = new ConsolaView();
        }

        public void Ejecutar()
        {
            ConstruccionArbol();

            Busquedas();

            Actualizaciones();

            Eliminaciones();

            Recorridos();

            view.Titulo("ALTURA FINAL");

            view.Mensaje(
                $"Altura del árbol: {arbol.Altura()}");
        }

        private void ConstruccionArbol()
        {
            view.Titulo("CONSTRUCCIÓN DEL ÁRBOL");

            List<(string nombre, bool esCarpeta)> datos =
                new List<(string, bool)>
                {
                    ("MDocumentos", true),
                    ("Facturas", true),
                    ("Contratos", true),
                    ("Imagenes", true),
                    ("Videos", true),
                    ("Audios", true),
                    ("Reportes", true),
                    ("Balance.xlsx", false),
                    ("Nomina.pdf", false),
                    ("Manual.docx", false),
                    ("Foto.png", false),
                    ("Backup.zip", false),
                    ("Proyecto", true),
                    ("Logs", true)
                };

            foreach (var item in datos)
            {
                int comparaciones;

                bool insertado = arbol.Insertar(
                    item.nombre,
                    item.esCarpeta,
                    out comparaciones);

                if (insertado)
                {
                    view.Mensaje(
                        $"Insertado: {item.nombre} " +
                        $"| Comparaciones: {comparaciones}");
                }
                else
                {
                    view.Mensaje(
                        $"Duplicado rechazado: {item.nombre}");
                }
            }

            view.Titulo("ÁRBOL INICIAL");

            view.ImprimirArbol(arbol.Raiz);
        }

        private void Busquedas()
        {
            view.Titulo("BÚSQUEDAS");

            List<string> busquedas =
                new List<string>
                {
                    "Facturas",
                    "Contratos",
                    "Videos",
                    "Reportes",
                    "Inexistente1",
                    "Inexistente2"
                };

            foreach (string nombre in busquedas)
            {
                ResultadoBusqueda resultado =
                    arbol.Buscar(nombre);

                view.MostrarBusqueda(
                    nombre,
                    resultado.Encontrado,
                    resultado.Comparaciones);
            }
        }

        private void Actualizaciones()
        {
            view.Titulo("ACTUALIZACIÓN HOJA");

            arbol.Actualizar(
                "Foto.png",
                "FotoNueva.png");

            view.ImprimirArbol(arbol.Raiz);

            view.Titulo(
                "ACTUALIZACIÓN NODO CON UN HIJO");

            arbol.Actualizar(
                "Logs",
                "LogsSistema");

            view.ImprimirArbol(arbol.Raiz);

            view.Titulo(
                "ACTUALIZACIÓN RAÍZ");

            arbol.Actualizar(
                "MDocumentos",
                "RepositorioCentral");

            view.ImprimirArbol(arbol.Raiz);
        }

        private void Eliminaciones()
        {
            view.Titulo("ELIMINAR HOJA");

            arbol.Eliminar("Manual.docx");

            view.ImprimirArbol(arbol.Raiz);

            view.Titulo(
                "ELIMINAR NODO CON UN HIJO");

            arbol.Eliminar("Proyecto");

            view.ImprimirArbol(arbol.Raiz);

            view.Titulo(
                "ELIMINAR RAÍZ");

            arbol.Eliminar("RepositorioCentral");

            view.ImprimirArbol(arbol.Raiz);
        }

        private void Recorridos()
        {
            view.Titulo("RECORRIDOS");

            view.MostrarRecorrido(
                "Preorden",
                arbol.Preorden());

            view.MostrarRecorrido(
                "Inorden",
                arbol.Inorden());

            view.MostrarRecorrido(
                "Postorden",
                arbol.Postorden());

            view.MostrarRecorrido(
                "Por niveles",
                arbol.PorNiveles());
        }
    }
}