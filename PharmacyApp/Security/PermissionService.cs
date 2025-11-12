using System.Collections.Generic;


namespace PharmacyApp.Security
{
    public static class PermissionService
    {
        // Trả về danh sách quyền mặc định theo user (skeleton)
        // format: "Module:Action:Scope"
        public static List<string> GetDefaultPermissionsFor(string username)
        {
            var list = new List<string>();
            switch (username)
            {
                case "admin":
                    list.AddRange(new[]
                    {
"BanHang:View:All","BanHang:Create:All","BanHang:Export:All",
"NhapKho:View:All","NhapKho:Create:All","NhapKho:Update:All","NhapKho:Delete:All",
"TonKho:View:All","TonKho:Adjust:All",
"BaoCao:View:All","BaoCao:Export:All",
"Thuoc:View:All","Thuoc:Create:All","Thuoc:Update:All","Thuoc:Delete:All",
"NguoiDung:View:All","NguoiDung:Create:All","NguoiDung:Update:All","NguoiDung:Delete:All"
});
                    break;
                case "nvsale":
                    list.AddRange(new[]
                    {
"BanHang:View:Own","BanHang:Create:Own","BanHang:Export:Own",
"TonKho:View:All",
"Thuoc:View:All",
"BaoCao:View:All"
});
                    break;
                case "ketoan":
                    list.AddRange(new[]
                    {
"NhapKho:View:All","NhapKho:Create:All","NhapKho:Update:All",
"TonKho:View:All",
"BaoCao:View:All","BaoCao:Export:All"
});
                    break;
            }
            return list;
        }
    }
}