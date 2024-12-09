using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PTPM_AI_CT3.AdressService
{
    // Định nghĩa lớp Tỉnh, Huyện, Xã
    public class Province
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public List<District> Districts { get; set; }
    }

    public class District
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public List<Ward> Wards { get; set; }
    }

    public class Ward
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class AddressService
    {
        private static readonly HttpClient client = new HttpClient();

        // Hàm lấy danh sách tỉnh
        public static async Task<List<Province>> GetAllProvincesAsync()
        {
            string apiUrl = "https://provinces.open-api.vn/api/p/";
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                List<Province> provinces = JsonConvert.DeserializeObject<List<Province>>(jsonResponse);
                return provinces;
            }
            else
            {
                throw new Exception("Cannot fetch provinces data from API");
            }
        }

        // Hàm lấy danh sách huyện theo tỉnh
        public static async Task<List<District>> GetDistrictsByProvinceAsync(string provinceCode)
        {
            string apiUrl = $"https://provinces.open-api.vn/api/p/{provinceCode}?depth=2";
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                Province province = JsonConvert.DeserializeObject<Province>(jsonResponse);
                return province.Districts;
            }
            else
            {
                throw new Exception("Cannot fetch districts data from API");
            }
        }

        // Hàm lấy danh sách xã theo huyện
        public static async Task<List<Ward>> GetWardsByDistrictAsync(string districtCode)
        {
            string apiUrl = $"https://provinces.open-api.vn/api/d/{districtCode}?depth=2";
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                District district = JsonConvert.DeserializeObject<District>(jsonResponse);
                return district.Wards;
            }
            else
            {
                throw new Exception("Cannot fetch wards data from API");
            }
        }

        // Hiển thị danh sách các huyện
        public static void DisplayDistricts(List<District> districts)
        {
            foreach (var district in districts)
            {
                Console.WriteLine("Huyện/Quận: " + district.Name);
            }
        }

        // Hiển thị danh sách các xã
        public static void DisplayWards(List<Ward> wards)
        {
            foreach (var ward in wards)
            {
                Console.WriteLine("\tXã/Phường: " + ward.Name);
            }
        }

    }
}
