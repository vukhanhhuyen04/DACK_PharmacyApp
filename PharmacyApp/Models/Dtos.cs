using System;
using System.Collections.Generic;

namespace PharmacyApp.Models
{
    public class PosItemDto
    {
        public string MaThuoc { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal VATPercent { get; set; }

        public PosItemDto() { }
        public PosItemDto(string maThuoc, int soLuong, decimal donGia, decimal vatPercent)
        { MaThuoc = maThuoc; SoLuong = soLuong; DonGia = donGia; VATPercent = vatPercent; }
    }

    public class InvoiceDto
    {
        public int? MaKH { get; set; }
        public string PaymentMethod { get; set; } = "Cash";
        public decimal Tong { get; set; }
        public decimal VAT { get; set; }
        public decimal GiamGia { get; set; }
        public List<PosItemDto> Items { get; set; } = new List<PosItemDto>();
    }
}
