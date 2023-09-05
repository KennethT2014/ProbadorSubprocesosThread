using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productor_Consumidor
{
    public class Consumidor
    {
        private Buffer ubicacionCompartida;
        private Random tiempoInactividadAleatorio;

        public Consumidor(Buffer compartido, Random aleatorio)
        {
            ubicacionCompartida = compartido;
            tiempoInactividadAleatorio = aleatorio;
        }

        public void Consumir()
        {
            int suma = 0;

            for(int cuenta = 1; cuenta <= 10; cuenta++)
            {
                Thread.Sleep(tiempoInactividadAleatorio.Next(1, 3001));
                suma += ubicacionCompartida.Bufer;
            }

            Console.WriteLine(Thread.CurrentThread.Name+" leyó valores para un total de: "+suma);
        }
    }
}
