using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productor_Consumidor
{
    public class Productor
    {
        private Buffer ubicacionCompartida;
        private Random tiempoInactividadAleatorio;

        public Productor(Buffer compartido, Random aleatorio)
        {
            ubicacionCompartida = compartido;
            tiempoInactividadAleatorio = aleatorio;
        }

        public void Producir()
        {
            for(int cuenta = 1; cuenta <= 10; cuenta++)
            {
                Thread.Sleep(tiempoInactividadAleatorio.Next(1, 3001));
                ubicacionCompartida.Bufer = cuenta;
            }

            Console.WriteLine(Thread.CurrentThread.Name + " terminó de producir.\nTerminando");
        }
    }
}
