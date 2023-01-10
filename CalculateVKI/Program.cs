namespace CalculateVKI
{
    public class Program
    {
        public static void Main()
        {
            TeshisEt();
        }
        static (double boy, double kilo) HastaBilgileriniAl()
        {
            Console.Clear();
            Console.WriteLine("Lütfen boy ve kilo değerlerinizi metre ve kg ölçüleri ile giriniz ");
            Console.Write(" Boy : ");
            double boy = Convert.ToDouble(Console.ReadLine());
            Console.Write(" Kilo : ");
            double kilo = Convert.ToDouble(Console.ReadLine());
            return(boy, kilo);
        }
        static double CalculateVKI(double boy,double kilo)
        {
            
            double VKI = kilo / (boy * boy);
            return(VKI);
        }

        static void TeshisEt()
        {
            var bilgiler = HastaBilgileriniAl();
            double VKI = CalculateVKI(bilgiler.boy, bilgiler.kilo);

            if (VKI < 18.49)
            {
                Console.WriteLine($"Hastanın boyu {bilgiler.boy}, kilosu {bilgiler.kilo} , vücut kitle indeksi {VKI}, teşhisi : ZAYIF ");
            }
            else if (VKI >= 18.49 && VKI < 24.99)
            {
                Console.WriteLine($"Hastanın boyu {bilgiler.boy}, kilosu {bilgiler.kilo} , vücut kitle indeksi {VKI}, teşhisi : İDEAL ");
            }
            else if (VKI >= 24.99 && VKI < 29.99)
            {
                Console.WriteLine($"Hastanın boyu {bilgiler.boy}, kilosu {bilgiler.kilo} , vücut kitle indeksi {VKI}, teşhisi : HAFİF KİLOLU ");
            }
            else
            {
                Console.WriteLine($"Hastanın boyu {bilgiler.boy}, kilosu {bilgiler.kilo} , vücut kitle indeksi {VKI}, teşhisi : OBEZ ");
            }
            BaskaHesaplamaSecimi();
        }

        static void BaskaHesaplamaSecimi()
        {
            Console.WriteLine("Başka işlem yapmak ister misiniz? (E/H)");
            string secim = Console.ReadLine();

            switch ( secim )
            {
                case "E":
                case "e":
                    TeshisEt();
                break;
                case "H":
                case "h":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}