using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace PickNTour.Models
{
    public class Country
    {
        public List<string> CountryList;
        public Country ()
        {
            CountryList = new List<string>();
            CultureInfo[] CInfoList = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo CInfo in CInfoList)
            {
                RegionInfo R = new RegionInfo(CInfo.LCID);
                if (!(CountryList.Contains(R.EnglishName)))
                    CountryList.Add(R.EnglishName);
            }

            CountryList.Sort();
        }

        public IEnumerable<string> GetCountries ()
        {
            return CountryList;
        }
    }
}
