using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productor_Consumidor
{
    public class BuferSincronizado : Buffer
    {
        private int bufer = -1;
        private int cuentaBuferOcupado = 0;

        public int Bufer 
        {
            get
            {
                Monitor.Enter(this);
                if(cuentaBuferOcupado == 0)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " trata de leer.");
                    MostrarEstado("Búfer vacío. " + Thread.CurrentThread.Name + " espera.");
                    Monitor.Wait(this);
                }

                --cuentaBuferOcupado;

                MostrarEstado(Thread.CurrentThread.Name + " lee " + bufer);

                Monitor.Pulse(this);

                int copiaBufer = bufer;

                Monitor.Exit(this);
                return copiaBufer;
            }
            set
            {
                Monitor.Enter(this);

                if( cuentaBuferOcupado == 1)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " trata de escribir. ");
                    MostrarEstado("Búfer lleno. " + Thread.CurrentThread.Name + " espera.");
                    Monitor.Wait(this);
                }

                bufer = value;

                ++cuentaBuferOcupado;

                MostrarEstado(Thread.CurrentThread.Name + " escribe " + bufer);

                Monitor.Pulse(this);

                Monitor.Exit(this);
            } 
        }

        public void MostrarEstado(string operacion)
        {
            Console.WriteLine("{" + operacion + ",-35}{"+bufer+ ",-9}{" + cuentaBuferOcupado +"}");
        }
    }
}
