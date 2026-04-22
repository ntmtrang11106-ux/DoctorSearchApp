using DAL_Tier;
using DTO_Tier;
using System.Collections.Generic;

namespace BUS_Tier
{
    public class LocationBUS
    {
        private readonly LocationDAL _locationDAL = new LocationDAL();

        public List<string> GetProvinces()
        {
            return _locationDAL.GetAllProvinces();
        }

        public List<LocationDTO> GetDistricts(string province)
        {
            if (string.IsNullOrEmpty(province)) return new List<LocationDTO>();
            return _locationDAL.GetLocationsByProvince(province);
        }
    }
}