
namespace CalculateVKI.Business
{
    public class VKI
    {
        public double boy;
        public double kilo;
        public string ad;

        public double FindVKI()
        {
            return kilo / (boy * boy);
           
        }
        public static string Diagnosis(VKI x)
        {
            double index = x.kilo / (x.boy * x.boy);
            string diagnosis = " ";
            
            if(index < 18.49 )
            {
                diagnosis = "ZAYIF";
            }
            else if(index >= 18.49 && index < 24.99)
            {
                diagnosis = "İDEAL KİLODA";
            }
            else if(index>=24.99 && index <29.99)
            {
                diagnosis = "HAFİF KİLOLU";
            }
            else
            {
                diagnosis = "OBEZ";
            }
            return diagnosis;
        }
    }
}