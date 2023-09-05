class ProbadorSubprocesos
{
    static void Main(string[] args)
    {
        ImpresoraMensajes impresora1 = new ImpresoraMensajes();
        Thread subproceso1 = new Thread(new ThreadStart(impresora1.Imprimir));
        subproceso1.Name = "subproceso1";

        ImpresoraMensajes impresora2 = new ImpresoraMensajes();
        Thread subproceso2 = new Thread(new ThreadStart(impresora2.Imprimir));
        subproceso2.Name = "subproceso2";
        
        ImpresoraMensajes impresora3 = new ImpresoraMensajes();
        Thread subproceso3 = new Thread(new ThreadStart(impresora3.Imprimir));
        subproceso3.Name = "subproceso1";

        Console.WriteLine("Iniciando subprocesos");

        subproceso1.Start();
        subproceso2.Start();
        subproceso3.Start();

        Console.WriteLine("Subprocesos inciandos \n");
    }
}

class ImpresoraMensajes
{
    private int tiempoInactividad;
    private static Random aleatorio = new Random();

    public ImpresoraMensajes()
    {
        tiempoInactividad = aleatorio.Next(5001);
    }
    public void Imprimir()
    {
        Thread actual = Thread.CurrentThread;

        Console.WriteLine(actual.Name + " va a estar inactivo durante " + tiempoInactividad + " milisegundos");
        Thread.Sleep(tiempoInactividad);

        Console.WriteLine(actual.Name + " dejó de estar inactivo ");
    }
}