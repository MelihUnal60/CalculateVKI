using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculateVKI.Business;

namespace CalculateVKI
{
    public class Program
    {
        public static void Main()
        {
            CreatePatientVKI();
        }

        private static void CreatePatientVKI()
        {
            VKI newVKI = new VKI();

            Console.Write("Lütfen boyunuzu metre cinsinden giriniz : ");
            newVKI.boy = Convert.ToDouble(Console.ReadLine());
            Console.Write("Lütfen kilonuzu kg cinsinden giriniz : ");
            newVKI.kilo = Convert.ToDouble(Console.ReadLine());

            VKIService.SavePatientVKI(newVKI);

            WriteVKIToScreen(newVKI);

            Again();

        }

        private static void Again()
        {
            Console.WriteLine("Başka bir hasta teşhisi için E'yi, teşhis konulan hastaların listesi için L'yi tuşlayınız");
            string choose = Console.ReadLine();
            if(choose == "E" || choose == "e")
            {
                CreatePatientVKI();
            }
            else if (choose == "L" || choose == "l")
            {
                PatientVKIList();
            }
            else
            {
                Console.WriteLine("Hatalı tuşlama yaptınız,devam etmek için ENTER tuşuna basın");
              Console.ReadLine();
              Again();
            }
            
        }

        static void WriteVKIToScreen(VKI x)
        {
            Console.WriteLine($"Hastanın boyu : {x.boy}, Hastanın kilosu : {x.kilo}, Vücut kitle indeksi : {x.kilo / (x.boy * x.boy)} , Teşhis : {VKI.Diagnosis(x)}");
        }
        static void PatientVKIList()
        {
            var patientList = VKIService.GetVKIList();

            foreach(var item in patientList ) 
            {
                WriteVKIToScreen(item);
            }
        }
    }
}
