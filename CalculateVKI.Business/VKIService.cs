using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VKIApplication.Data;

/*  {
 *      ad : "melih",
 *      boy : 1,89,
 *      kilo : 105
 * }
 * 
 * [
 *      {
     *      ad : "melih",      //JSON işlemlerini yaparken objeyi gönderme ve alma.
     *      boy : 1,89,
     *      kilo : 105
 *      },
 *      {
     *      ad : mehmet,
     *      boy : 1,68,
     *      kilo : 88
 *      }
 * ]
 */




namespace CalculateVKI.Business
{
    public class VKIService
    {
        private static List<VKI> list = new List<VKI>();

        public static void SavePatientVKI(VKI y)
        {
            GetVKIList();
            list.Add(y);

            //JSON Serialize
            
            //JsonSerializerOptions options = new JsonSerializerOptions(); 
            //options.IncludeFields= true; // listedeki objedeki değişkenleri dahil ettik.
            //string json = JsonSerializer.Serialize(list, options);

            string json = JsonSerializer.Serialize(list, new JsonSerializerOptions { IncludeFields = true}); //daha kısa yazdık

            FileOperations.Write(json);  //Dosyayı taşımak için JSON methodu kullanıyoruz
        }


        public static IReadOnlyCollection<VKI> GetVKIList()
        {
            string json = FileOperations.Read();

            list = JsonSerializer.Deserialize<List<VKI>>(json, new JsonSerializerOptions { IncludeFields = true });

            return list.AsReadOnly();
        }

        public static IReadOnlyCollection<VKI> SearchWithPatientName(string ad)
        {
            GetVKIList();

            var sonuc = list.Where(q => q.ad == ad).ToList(); // en kısa yol.
            return sonuc.AsReadOnly();


           // var sonuc = (from q in list
             //           where q.ad == ad     // farklı yöntem
               //         select q).ToList();


            //var sonuc = new List<VKI>();
            //foreach(var item in list)
            //{
              //  if (item.ad == ad) 
              //    sonuc.Add(item);        //farklı bir yöntem daha
            //}

            //return sonuc.AsReadOnly();
        }

        public static void RemovePatientByName(string name)
        {
            list = list.Where(q => q.ad != name).ToList();
            string json = JsonSerializer.Serialize(list, new JsonSerializerOptions { IncludeFields = true });
            FileOperations.Write(json);           
            
        }
        
    }
}


