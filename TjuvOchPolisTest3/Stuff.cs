namespace TjuvOchPolisTest3
{
    internal class Stuff
    {
        public string[] stuff = { "Money", "Keys", "Cellphone", "Watch" };
        static int robbed = 0;
        static int arrested = 0;



        public void StealItem(List<string> belongings, List<string>stolen)
        {
            Random rnd = new Random();
            if (belongings.Count != 0)
            {
                int steal = rnd.Next(0, (belongings.Count));
                string taken = belongings[steal];
                stolen.Add(taken);
                belongings.RemoveAt(steal);
                robbed++;
            }
        }
        public void TakeAllItems(List<string> stolen, List<string> retaken)
        {
            retaken.AddRange(stolen);
            stolen.Clear();
            arrested++;
        }

    }
}
