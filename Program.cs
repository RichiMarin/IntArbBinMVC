using IntArbBinMVC.Controllers;

namespace IntArbBinMVC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArbolController controller = new ArbolController();

            controller.Ejecutar();
        }
    }
}