using System;


namespace kursyNBP
{
    class Program
    {
        public static void Main(string[] args)
        {
          

            string currencyValid = string.Empty;
            string dataFromValid = string.Empty;
            string dataToValid = string.Empty;

            try
            {

                var currency = args[0];
                currencyValid = currency;
                var dataFrom = args[1];
                dataFromValid = dataFrom;
                var dataTo = args[2];
                dataToValid = dataTo;

            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            NBP nbp = new NBP ();
            var wynik = nbp.document();
        }
    }
}

