using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productor_Consumidor
{
    public class PruebaBuferSincronizado
    {
        static void Main(string[] args)
        {
            BuferSincronizado compartido = new BuferSincronizado();

            Random aleatorio = new Random();

            Console.WriteLine("{0,-35}{1,-9}{2}\n","Operación","Búfer","Cuenta ocupado");
            compartido.MostrarEstado("Estado inicial");

            Productor productor = new Productor(compartido,aleatorio);
            Consumidor consumidor = new Consumidor(compartido, aleatorio);

            Thread subprocesoProductor = new Thread(new ThreadStart(productor.Producir));
            subprocesoProductor.Name = "Productor";

            Thread subprocesoConsumidor = new Thread(new ThreadStart(consumidor.Consumir));
            subprocesoProductor.Name = "Consumidor";

            subprocesoProductor.Start();
            subprocesoConsumidor.Start();
        }
    }
}
