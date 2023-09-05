using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productor_Consumidor
{
    public class PruebaBuferSinSincronizacion
    {
        static void Main(String[] args)
        {
            BuferSinSincronizacion compartido = new BuferSinSincronizacion();

            Random aleatorio = new Random();

            Productor productor = new Productor(compartido, aleatorio);
            Consumidor consumidor = new Consumidor(compartido, aleatorio);

            Thread subprocesoProductor = new Thread(new ThreadStart(productor.Producir));
            subprocesoProductor.Name = "Productor";

            Thread subprocesoConsumidor = new Thread(new ThreadStart(consumidor.Consumir));
            subprocesoConsumidor.Name = "Consumidor";

            subprocesoProductor.Start();
            subprocesoConsumidor.Start();
        }
    }
}
