using Avalonia.Controls;
using MasterLibrary.DTOs;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents.DocumentStructures;
using System.Windows.Media.Animation;

namespace MasterLibrary.Models.DataProvider
{
    public class BillServices
    {
        private static BillServices _ins;
        public static BillServices Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new BillServices();
                }
                return _ins;
            }
            private set => _ins = value;
        }

        public async Task<List<BillDTO>> GetAllBill()
        {
            try
            {
                using (var context = new MasterlibraryEntities())
                {
                    //var BillList = (from hoadon in context.HOADONs
                    //                select new BillDTO
                    //                {
                    //                    MAKH = (int)hoadon.MAKH,
                    //                    cusId = (int)hoadon.MAKH,
                    //                    cusName = hoadon.KHACHHANG.USERNAME,
                    //                    cusAdd = hoadon.KHACHHANG.DIACHI,
                    //                    MAHD = hoadon.MAHD,
                    //                    TRIGIA = (decimal)hoadon.TRIGIA,
                    //                    NGHD = hoadon.NGHD,
                    //                    TRANGTHAI = hoadon.TRANGTHAI
                    //                }).ToListAsync();
                    //return await BillList;

                    var BillList = context.HOADONs
                                    .Join(
                                        context.CTHDs,
                                        s => s.MAHD,
                                        c => c.MAHD,
                                        (s, c) => new BillDTO
                                        {
                                            MAKH = (int)s.MAKH,
                                            cusId = (int)s.MAKH,
                                            cusName = s.KHACHHANG.TENKH,
                                            cusAdd = s.KHACHHANG.DIACHI,
                                            MAHD = s.MAHD,
                                            TRIGIA = (decimal)s.TRIGIA,
                                            NGHD = s.NGHD,
                                            TRANGTHAI = s.TRANGTHAI,
                                            TenSach = c.SACH.TENSACH,
                                        }).ToListAsync();

                    return await BillList;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<BillDTO>> GetBillByMonth(int month, int year)
        {
            try
            {
                using (var context = new MasterlibraryEntities())
                {
                    //var BillList = (from hoadon in context.HOADONs
                    //                where hoadon.NGHD.Year == year && hoadon.NGHD.Month == month
                    //                orderby hoadon.NGHD descending
                    //                select new BillDTO
                    //                {
                    //                    MAKH = (int)hoadon.MAKH,
                    //                    cusId = (int)hoadon.MAKH,
                    //                    cusName = hoadon.KHACHHANG.TENKH,
                    //                    cusAdd = hoadon.KHACHHANG.DIACHI,
                    //                    MAHD = hoadon.MAHD,
                    //                    TRIGIA = (decimal)hoadon.TRIGIA,
                    //                    NGHD = hoadon.NGHD,
                    //                    TRANGTHAI = hoadon.TRANGTHAI
                    //                }).ToListAsync();
                    //return await BillList;

                    var BillList = context.HOADONs.Where(s => s.NGHD.Year == year && s.NGHD.Month == month)
                                    .OrderByDescending(s => s.NGHD)
                                    .Join(
                                        context.CTHDs,
                                        s => s.MAHD,
                                        c => c.MAHD,
                                        (s, c) => new BillDTO
                                        {
                                            MAKH = (int)s.MAKH,
                                            cusId = (int)s.MAKH,
                                            cusName = s.KHACHHANG.TENKH,
                                            cusAdd = s.KHACHHANG.DIACHI,
                                            MAHD = s.MAHD,
                                            TRIGIA = (decimal)s.TRIGIA,
                                            NGHD = s.NGHD,
                                            TRANGTHAI = s.TRANGTHAI,
                                            TenSach = c.SACH.TENSACH,
                                        }).ToListAsync();

                    return await BillList;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<BillDTO>> GetBillByDate(DateTime date)
        {
            try
            {
                using (var context = new MasterlibraryEntities())
                {
                    //var BillList = (from hoadon in context.HOADONs
                    //                where DbFunctions.TruncateTime(hoadon.NGHD) == date.Date
                    //                select new BillDTO
                    //                {
                    //                    MAKH = (int)hoadon.MAKH,
                    //                    cusId = (int)hoadon.MAKH,
                    //                    cusName = hoadon.KHACHHANG.TENKH,
                    //                    cusAdd = hoadon.KHACHHANG.DIACHI,
                    //                    MAHD = hoadon.MAHD,
                    //                    TRIGIA = (decimal)hoadon.TRIGIA,
                    //                    NGHD = hoadon.NGHD,
                    //                    TRANGTHAI = hoadon.TRANGTHAI
                    //                }).ToListAsync();
                    //return await BillList;

                    var BillList = context.HOADONs.Where(s => DbFunctions.TruncateTime(s.NGHD) == date.Date)
                                    .Join(
                                        context.CTHDs,
                                        s => s.MAHD,
                                        c => c.MAHD,
                                        (s, c) => new BillDTO
                                        {
                                            MAKH = (int)s.MAKH,
                                            cusId = (int)s.MAKH,
                                            cusName = s.KHACHHANG.TENKH,
                                            cusAdd = s.KHACHHANG.DIACHI,
                                            MAHD = s.MAHD,
                                            TRIGIA = (decimal)s.TRIGIA,
                                            NGHD = s.NGHD,
                                            TRANGTHAI = s.TRANGTHAI,
                                            TenSach = c.SACH.TENSACH,
                                        }).ToListAsync();

                    return await BillList;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #region xử lý bill bên đặt hàng
        public async Task<List<BillDTO>> GetAllBillByCus(int _makh)
        {
            try
            {
                using (var context = new MasterlibraryEntities())
                {
                    var BillList = context.HOADONs.Where(s => s.MAKH == _makh && s.ISRECEIVED == 0)
                        .Join(
                            context.CTHDs,
                            s => s.MAHD,
                            c => c.MAHD,
                            (s, c) => new BillDTO
                            {
                                MAKH = (int)s.MAKH,
                                cusId = (int)s.MAKH,
                                cusName = s.KHACHHANG.TENKH,
                                cusAdd = s.KHACHHANG.DIACHI,
                                MAHD = s.MAHD,
                                TRIGIA = (decimal)s.TRIGIA,
                                NGHD = s.NGHD,
                                TRANGTHAI = s.TRANGTHAI,
                                TenSach = c.SACH.TENSACH
                            }
                        ).ToList();


                    return BillList;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<BillDTO>> GetAllBillByCusByMonth(int _makh, int month, int year)
        {
            try
            {
                using (var context = new MasterlibraryEntities())
                {
                    var BillList = context.HOADONs.Where(s => s.MAKH == _makh && s.NGHD.Month == month && s.NGHD.Year == year && s.ISRECEIVED == 0)
                        .Join(
                            context.CTHDs,
                            s => s.MAHD,
                            c => c.MAHD,
                            (s, c) => new BillDTO
                            {
                                MAKH = (int)s.MAKH,
                                cusId = (int)s.MAKH,
                                cusName = s.KHACHHANG.TENKH,
                                cusAdd = s.KHACHHANG.DIACHI,
                                MAHD = s.MAHD,
                                TRIGIA = (decimal)s.TRIGIA,
                                NGHD = s.NGHD,
                                TRANGTHAI = s.TRANGTHAI,
                                TenSach = c.SACH.TENSACH
                            }
                        ).ToList();


                    return BillList;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<BillDTO>> GetAllBillFinish(int _makh)
        {
            try
            {
                using (var context = new MasterlibraryEntities())
                {
                    var billFinish = context.HOADONs.Where(s => s.MAKH == _makh && s.ISRECEIVED == 1)
                        .Join(
                            context.CTHDs,
                            s => s.MAHD,
                            c => c.MAHD,
                            (s, c) => new BillDTO
                            {
                                MAKH = (int)s.MAKH,
                                cusId = (int)s.MAKH,
                                cusName = s.KHACHHANG.TENKH,
                                cusAdd = s.KHACHHANG.DIACHI,
                                MAHD = s.MAHD,
                                TRIGIA = (decimal)s.TRIGIA,
                                NGHD = s.NGHD,
                                TRANGTHAI = s.TRANGTHAI,
                                TenSach = c.SACH.TENSACH,
                                MASACH = c.SACH.MASACH
                            }
                        ).ToList();

                    return billFinish;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<List<BillDTO>> GetAllBillFinishByMonth(int _makh, int month, int year)
        {
            try
            {
                using (var context = new MasterlibraryEntities())
                {
                    var billFinish = context.HOADONs.Where(s => s.MAKH == _makh && s.TRANGTHAI == "Giao hàng thành công" && s.NGHD.Month == month && s.NGHD.Year == year && s.ISRECEIVED == 1)
                        .Join(
                            context.CTHDs,
                            s => s.MAHD,
                            c => c.MAHD,
                            (s, c) => new BillDTO
                            {
                                MAKH = (int)s.MAKH,
                                cusId = (int)s.MAKH,
                                cusName = s.KHACHHANG.TENKH,
                                cusAdd = s.KHACHHANG.DIACHI,
                                MAHD = s.MAHD,
                                TRIGIA = (decimal)s.TRIGIA,
                                NGHD = s.NGHD,
                                TRANGTHAI = s.TRANGTHAI,
                                TenSach = c.SACH.TENSACH,
                                MASACH = c.SACH.MASACH
                            }
                        ).ToList();

                    return billFinish;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion



        //public async Task<BillDTO> GetDetail(int ID)
        //{
        //    try
        //    {
        //        using (var context = new MasterlibraryEntities())
        //        {
        //            var bill = await context.HOADONs.FindAsync(ID);
        //            var cthd = bill.CTHDs;
        //            //MessageBox.Show(cthd.First().MASACH.ToString());
        //            //var IDBook = cthd.FirstOrDefault().MASACH;
        //            //var namebook = context.SACHes.Where(p => p.MASACH == IDBook).Take(1).ToString();
        //            BillDTO billInfo = new BillDTO
        //            {
        //                MAHD = bill.MAHD,
        //                MAKH = (int)bill.MAKH,
        //                NGHD = bill.NGHD,
        //                TRIGIA = (decimal)bill.TRIGIA,
        //                cusName = bill.KHACHHANG.TENKH,
        //                cusAdd = bill.KHACHHANG.DIACHI,
        //                //bookName = namebook,
        //            };

        //            return billInfo;
        //        }
        //    }
        //    catch (Exception e) 
        //    {
        //        throw e;
        //    }
        //}

        public async Task<(bool, string)> UpdateBillConfirm(BillDTO newBill)
        {
            try
            {
                using (var context = new MasterlibraryEntities())
                {
                    var currentBill = context.HOADONs.FirstOrDefault(hd => hd.MAHD == newBill.MAHD);
                    currentBill.MAKH = (int)newBill.MAKH;
                    currentBill.MAHD = newBill.MAHD;
                    currentBill.TRIGIA = (decimal)newBill.TRIGIA;
                    currentBill.NGHD = newBill.NGHD;
                    currentBill.TRANGTHAI = newBill.TRANGTHAI;

                    context.SaveChanges();

                    return (true, "Đơn hàng đã được xác nhận thành công!");
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                return (false, "Xảy ra lỗi khi thao tác trên cơ sở dữ liệu");
            }
            catch (Exception)
            {
                return (false, "Xảy ra lỗi khi thực hiện thao tác");
            }
        }

        public async Task<(bool, string)> CancelBill(BillDTO currentBill)
        {
            try
            {
                using (var context = new MasterlibraryEntities())
                {
                    var billCancel = context.HOADONs.FirstOrDefault(s => s.MAHD == currentBill.MAHD);
                    if (billCancel != null)
                    {
                        billCancel.TRANGTHAI = currentBill.TRANGTHAI;
                        context.SaveChanges();
                    }

                    return (true, "Huỷ đơn hàng thành công");
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                return (false, "Không thể kết nối với cơ sở dữ liệu");
            }
            catch (Exception)
            {
                return (false, "Gặp lỗi trong việc huỷ đơn hàng");
            }
        }

        public async Task<(bool, string)> UpdateReceivedBook(BillDTO currentBill)
        {
            try
            {
                using (var context = new MasterlibraryEntities())
                {
                    var receivedBook = context.HOADONs.FirstOrDefault(s => s.MAHD == currentBill.MAHD);
                    if (receivedBook != null)
                    {
                        receivedBook.TRANGTHAI = currentBill.TRANGTHAI;
                        receivedBook.ISRECEIVED = currentBill.ISRECEIVED;
                        context.SaveChanges();
                    }

                    return (true, "Đơn hàng đã được nhận");
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                return (false, "Không thể kết nối với cơ sở dữ liệu");
            }
            catch (Exception)
            {
                return (false, "Có lỗi xảy ra trong cơ sở dữ liệu");
            }
        }
    }
}
