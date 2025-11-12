using System;
using PharmacyApp.Auth;
using PharmacyApp.Models;


namespace PharmacyApp.Services
{
    public class InvoiceService
    {
        private readonly IUserContext _ctx;
        public InvoiceService(IUserContext ctx) { _ctx = ctx; }


        // Skeleton: chưa nối DB — chỉ mô phỏng tạo hóa đơn thành công
        public long CreateInvoice(InvoiceDto dto)
        {
            if (!_ctx.HasPermission("BanHang", "Create"))
                throw new UnauthorizedAccessException("Không có quyền tạo hóa đơn");


            // TODO: cắm DB thật và trừ tồn theo FIFO-HSD
            // Trả về mã HĐ giả lập
            return DateTime.UtcNow.Ticks;
        }
    }
}