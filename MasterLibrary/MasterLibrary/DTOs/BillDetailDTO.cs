using MasterLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterLibrary.DTOs
{
    public class BillDetailDTO
    {
        public int MaHD { get; set; }
        public int MaSach { get; set; }
        public int SoLuong { get; set; }
        public decimal GiaMoiCai { get; set; }
        public string GiaMoiCaiStr
        {
            get { return Helper.FormatVNMoney(GiaMoiCai); }

        }
        public decimal TongGiaMoiCai { get; set; }
        public string TongGiaMoiCaiStr
        {
            get { return Helper.FormatVNMoney(TongGiaMoiCai); }
        }
        public string TenSach { get; set; }
        public DateTime NGMuaHang { get; set; }
    }
}
