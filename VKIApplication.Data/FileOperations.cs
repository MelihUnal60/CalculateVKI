namespace VKIApplication.Data
{
    public class FileOperations
    {
        private const string fileRoad = "data.txt";

        public static void Write(string data)
        {
            File.WriteAllText(fileRoad, data); //dosya yoksa oluşturur, varsa üzerine yazar.
        }
        public static string Read() 
        {
            if ( File.Exists(fileRoad))
            
                return File.ReadAllText(fileRoad); // if döngüsünü kısalttık.
            
                return string.Empty;
                //return null;
                //return " ";
            
        }
        /*if ( File.Exists(fileRoad))
            {
                return File.ReadAllText(fileRoad);
            }
            else
            {
                return string.Empty;
                //return null;
                //return " ";
            } */










    }
}