using System.Runtime.CompilerServices;

namespace TjuvOchPolisTest3
{
    internal class Program
    {
        static void Main(string[] args)
        {           

            City city = new City();
            city.Start();


            
        }
        //private static void SendToPreison(Robber robber, List<Robber> prison)
        //{
        //    robber.TimeOfCapture = DateTime.Now;
        //    prison.Add(robber);
        //    robber.InPrison = true;
        //}

        //private static void SendToFreedom(Robber robber, List<Robber> prison)
        //{
        //    prison.Remove(robber);
        //    robber.InPrison = false;
        //}

        //private static double GetPrisonTime(Robber robber)
        //{
        //    return (DateTime.Now- robber.TimeOfCapture).TotalSeconds;
        //}

 
    }
}