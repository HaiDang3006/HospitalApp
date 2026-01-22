using System;

namespace BenhVienS.Models
{
    public class Medicine
    {
        public int Id { get; set; }                 // MaThuoc
        public string Name { get; set; }            // TenThuoc
        public string ActiveIngredient { get; set; } // HoatChat
        public string Dosage { get; set; }          // HamLuong
        public string Unit { get; set; }            // DonViTinh
        public string Usage { get; set; }           // CachDung
        public string MedicineType { get; set; }    // LoaiThuoc
        public string Manufacturer { get; set; }    // NhaSanXuat
        public string CountryOfOrigin { get; set; } // NuocSanXuat
        public decimal ImportPrice { get; set; }    // GiaNhap
        public decimal SalePrice { get; set; }      // GiaBan
        public bool IsCoveredByInsurance { get; set; } // ApDungBHYT
        public DateTime ExpiryDate { get; set; }    // HanSuDung
        public string Status { get; set; }          // TrangThai

        // Parameterless constructor
        public Medicine()
        {
        }

        // Full constructor
        public Medicine(
            int id,
            string name,
            string activeIngredient,
            string dosage,
            string unit,
            string usage,
            string medicineType,
            string manufacturer,
            string countryOfOrigin,
            decimal importPrice,
            decimal salePrice,
            bool isCoveredByInsurance,
            DateTime expiryDate,
            string status)
        {
            Id = id;
            Name = name;
            ActiveIngredient = activeIngredient;
            Dosage = dosage;
            Unit = unit;
            Usage = usage;
            MedicineType = medicineType;
            Manufacturer = manufacturer;
            CountryOfOrigin = countryOfOrigin;
            ImportPrice = importPrice;
            SalePrice = salePrice;
            IsCoveredByInsurance = isCoveredByInsurance;
            ExpiryDate = expiryDate;
            Status = status;
        }
    }
}
