using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateVKI.Business
{
    public class VKIService
    {
        private static List<VKI> list = new List<VKI>();

        public static void SavePatientVKI(VKI y)
        {
            list.Add(y);
        }
        public static IReadOnlyCollection<VKI> GetVKIList()
        {
            return list.AsReadOnly();
        }
    }
}
