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

        //private static string PrintPrison(List<Robber> prison)
        //{
        //    string r = "";
        //    bool freedom = false;
        //    bool robbery = false;
        //    bool capture = false;

        //    foreach (Robber robber in prison)
        //    {
        //        r += $"Tjuven har hamnat i fänglse{Math.Round(GetPrisonTime(robber)) } sekounder \n ";
        //    }
        //    return r;
        //    foreach (Robber robber in prison)
        //    {
        //        if (GetPrisonTime(robber) >= 40)
        //        {
        //            Console.WriteLine("Tjuven lämnade fänglse");
        //            freedom = true;
        //        }
        //    }
        //    while (freedom)
        //    {
        //        freedom = false;
        //        foreach (Robber robber in prison)
        //        {
        //            if (GetPrisonTime(robber) >= 40)
        //            {
        //                SendToFreedom(robber, prison);
        //                freedom = true;
        //                break;
        //            }
        //        }
        //    }

        //}
    }
}