using Avalonia.Controls.Mixins;
using MasterLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterLibrary.Models.DataProvider
{
    public class BillDetailServices
    {
        private static BillDetailServices _ins;
        public static BillDetailServices Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new BillDetailServices();
                }
                return _ins;
            }
            private set => _ins = value;
        }

        public async Task<List<BillDetailDTO>> GetAllProduct(int _mahd)
        {
            try
            {
                using (var context = new MasterlibraryEntities())
                {
                    var ProductList = context.CTHDs.Where(ct => ct.MAHD == _mahd)
                        .Join(
                            context.HOADONs,
                            s => s.MAHD,
                            c => c.MAHD,
                            (s, c) => new BillDetailDTO
                            {
                                MaHD = s.MAHD,
                                MaSach = s.MASACH,
                                TenSach = s.SACH.TENSACH,
                                NGMuaHang = c.NGHD,
                                SoLuong = (int)s.SOLUONG,
                                GiaMoiCai = (decimal)s.SACH.GIA,
                                TongGiaMoiCai = (decimal)(s.SACH.GIA * s.SOLUONG)
                            }
                        ).ToList();

                    return ProductList;
                }
            }
            catch (Exception e) 
            {
                throw e;
            }
        }
    }
}
