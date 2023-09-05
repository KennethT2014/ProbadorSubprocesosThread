using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productor_Consumidor
{
    public class BuferSinSincronizacion : Buffer
    {
        public int Buffer = -1;

        public int Bufer
        {
            get 
            { 
                Console.WriteLine(Thread.CurrentThread.Name + " lee " + Bufer);
                return Bufer;
            }
            set
            {
                Console.WriteLine(Thread.CurrentThread.Name, value);
                Bufer = value;
            }
        }
    }
}
