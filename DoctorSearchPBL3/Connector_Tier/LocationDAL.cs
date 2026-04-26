using DTO_Tier;
using System.Collections.Generic;
using System.Linq;

namespace DAL_Tier
{
    public class LocationDAL
    {
        private readonly AppDbContext _context;

        public LocationDAL()
        {
            _context = new AppDbContext();
        }

        // 1. Lấy danh sách tất cả các Tỉnh/Thành phố (duy nhất)
        public List<string> GetAllProvinces()
        {
            return _context.Locations
                .Select(l => l.Province)
                .Distinct()
                .OrderBy(p => p)
                .ToList();
        }

        // 2. Lấy danh sách Quận/Huyện dựa trên Tỉnh đã chọn
        public List<LocationDTO> GetLocationsByProvince(string province)
        {
            return _context.Locations
                .Where(l => l.Province == province)
                .OrderBy(l => l.LocationName)
                .ToList();
        }

        // 3. Lấy tên hiển thị đầy đủ của một Location dựa trên ID (nếu cần)
        public string GetFullLocationName(int id)
        {
            var loc = _context.Locations.Find(id);
            return loc != null ? $"{loc.LocationName}, {loc.Province}" : "N/A";
        }
    }
}