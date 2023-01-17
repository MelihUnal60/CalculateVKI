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

        private static void Search()
        {
            Console.Write("Aranacak hasta adını girin : ");
            string filterKey = Console.ReadLine();
            var data = VKIService.SearchWithPatientName(filterKey);

            WriteFromPatientList(data);
        }

        private static void Delete()
        {
            Console.Write("Silinecek hasta adını girin : ");
            string filterKey = Console.ReadLine();
            VKIService.RemovePatientByName(filterKey);
        }

        private static void CreatePatientVKI()
        {
            VKI newVKI = new VKI();
            Console.Write("Lütfen hasta adını yazınız : ");
            newVKI.ad = Console.ReadLine();
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
            while(true) {
                Console.WriteLine("Başka bir hasta teşhisi için E'yi, teşhis konulan hastaların listesi için L'yi,listede arama yapmak için S'yi,Listeden hasta adıyla silmek için D'yi tuşlayınız,Çıkmak için X");
                string choose = Console.ReadLine();
                if (choose == "E" || choose == "e")
                {
                    CreatePatientVKI();
                }
                else if (choose == "L" || choose == "l")
                {
                    PatientVKIList();
                }
                else if (choose == "S" || choose == "s")
                {
                    Search();
                }
                else if (choose == "D" || choose == "d")
                {
                    Delete();
                }
                else if (choose == "X" || choose == "x")
                {
                    Environment.Exit(0);
                    //break;
                }
                else
                {
                    Console.WriteLine("Hatalı tuşlama yaptınız,devam etmek için ENTER tuşuna basın");
                    Console.ReadLine();
                    //Again();
                }
            }
            
        }

        private static void WriteFromPatientList(IReadOnlyCollection<VKI> list)
        {
            foreach (VKI x in list) 
            {
                WriteVKIToScreen(x);
            }
        }

        static void WriteVKIToScreen(VKI x)
        {
            Console.WriteLine($"Hastanın adı : {x.ad}, Hastanın boyu : {x.boy}, Hastanın kilosu : {x.kilo}, Vücut kitle indeksi : {x.kilo / (x.boy * x.boy)} , Teşhis : {VKI.Diagnosis(x)}");
        }
        static void PatientVKIList()
        {
            var patientList = VKIService.GetVKIList();

            WriteFromPatientList(patientList);
        }
    }
}   
