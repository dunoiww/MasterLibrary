using Haley.Models;
using MasterLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents.DocumentStructures;
using System.Windows.Input;

namespace MasterLibrary.Models.DataProvider
{
    public partial class StatisticServices
    {
        private static StatisticServices _ins;
        public static StatisticServices Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new StatisticServices();
                }
                return _ins;
            }
            private set => _ins = value;
        }
        #region thu chi
        //Tính tiền thu theo năm
        public async Task<(List<decimal>, decimal)> GetRevenueByYear(int year)
        {
            decimal inputMoney = (decimal)0;
            List<decimal> revenueByMonthList = new List<decimal>(new decimal[12]);

            using (var context = new MasterlibraryEntities())
            {
                var billList = context.HOADONs.Where(b => b.NGHD.Year == year && b.ISRECEIVED == 1);

                if (billList.ToList().Count != 0)
                {
                    inputMoney = (decimal) billList.Sum(b => b.TRIGIA);
                }
                

                var revenueByMonth = billList.GroupBy(b => b.NGHD.Month).Select(gr => new { Month = gr.Key, Income = gr.Sum(b => (decimal?)b.TRIGIA) ?? 0 }).ToList();
            
                foreach (var re in revenueByMonth)
                {
                    revenueByMonthList[re.Month - 1] = decimal.Truncate(re.Income);
                }
                return (revenueByMonthList, inputMoney);
            }
        }

        //Tính tiền chi theo năm
        public async Task<(List<decimal>, decimal)> GetExpenseByYear(int year)
        {
            decimal outputMoney = 0;
            List<decimal> expenseByMonthList = new List<decimal>(new decimal[12]);

            using (var context = new MasterlibraryEntities())
            {
                var receiptList = context.NHAPKHOes.Where(b => b.NGNHAP.Year == year);

                if (receiptList.ToList().Count != 0)
                {
                    outputMoney = (decimal)receiptList.Sum(b => b.TRIGIA);
                }
               
                var receiptByMonth = receiptList.GroupBy(b => b.NGNHAP.Month).Select(gr => new { Month = gr.Key, Output = gr.Sum(b => (decimal?)(b.TRIGIA) ?? 0)}).ToList();

                foreach (var re in receiptByMonth)
                {
                    expenseByMonthList[re.Month - 1] = decimal.Truncate(re.Output);
                }

                return (expenseByMonthList, outputMoney);
            }
        }

        //tính tiền sự cố theo năm
        public async Task<(List<decimal>, decimal)> GetExpenseTroubleByYear(int year)
        {
            decimal troubleMoney = 0;
            List<decimal> expenseTroubleList = new List<decimal>(new decimal[12]);

            using (var context = new MasterlibraryEntities())
            {
                var troubleList = context.SUCOes.Where(b => b.THOIGIANBAOCAO.Year == year);

                if (troubleList.ToList().Count != 0)
                {
                    troubleMoney = (decimal)troubleList.Sum(b => b.CHIPHI);
                }

                var troubleListByMonth = troubleList.GroupBy(b => b.THOIGIANBAOCAO.Month).Select(gr => new { Month = gr.Key, Output = gr.Sum(b => (decimal?)(b.CHIPHI) ?? 0) }).ToList();

                foreach (var tr in troubleListByMonth)
                {
                    expenseTroubleList[tr.Month - 1] = decimal.Truncate(tr.Output);
                }

                return (expenseTroubleList, troubleMoney);
            }
        }

        //tính tiền khi thu sách phát sinh theo năm
        public async Task<decimal> GetRevenueCollectByYear(int year)
        {
            decimal collectMoney = 0;

            using (var context = new MasterlibraryEntities())
            {
                var collectList = context.PHIEUTHUs.Where(b => b.NGAYTHU.Year == year);

                if (collectList.ToList().Count != 0)
                {
                    collectMoney += (decimal)collectList.Sum(b => b.TONGTIEN);
                }
                return collectMoney;
            }
        }

        //tính tiền thu theo tháng
        public async Task<(List<decimal>, decimal)> GetRevenueByMonth(int year, int month)
        {
            decimal inputMoney = (decimal)0;
            int days = DateTime.DaysInMonth(year, month);
            List<decimal> revenueByDayList = new List<decimal>(new decimal[days]);

            using (var context = new MasterlibraryEntities())
            {
                var billList = context.HOADONs.Where(b => b.NGHD.Year == year && b.NGHD.Month == month && b.ISRECEIVED == 1);

                if (billList.ToList().Count != 0)
                {
                    inputMoney = (decimal)billList.Sum(b => b.TRIGIA);
                }

                var revenueByDay = billList.GroupBy(b => b.NGHD.Day).Select(gr => new { Day = gr.Key, Income = gr.Sum(b => (decimal?)b.TRIGIA) ?? 0 }).ToList();

                foreach (var re in revenueByDay)
                {
                    revenueByDayList[re.Day - 1] = decimal.Truncate(re.Income);
                }

                return (revenueByDayList, inputMoney);
            }
        }

        //tính tiền thu sách theo tháng
        public async Task<(List<decimal>, decimal)> GetExpenseByMonth(int year, int month)
        {
            decimal outputMoney = (decimal)0;
            int days = DateTime.DaysInMonth(year, month);
            List<decimal> expenseByDayList = new List<decimal>(new decimal[days]);

            using (var context = new MasterlibraryEntities())
            {
                var receiptList = context.NHAPKHOes.Where(b => b.NGNHAP.Year == year && b.NGNHAP.Month == month);

                if (receiptList.ToList().Count != 0)
                {
                    outputMoney = (decimal)receiptList.Sum(b => (b.TRIGIA));
                }

                var revenueByDay = receiptList.GroupBy(b => b.NGNHAP.Day).Select(gr => new { Day = gr.Key, Income = gr.Sum(b => (decimal?)(b.TRIGIA) ?? 0 )}).ToList();

                foreach (var re in revenueByDay)
                {
                    expenseByDayList[re.Day - 1] = decimal.Truncate(re.Income);
                }

                return (expenseByDayList, outputMoney);
            }
        }
        #endregion

        #region sự cố
        //tính tiền sự cố theo tháng
        public async Task<(List<decimal>, decimal)> GetExpenseTroubleByMonth(int year, int month)
        {
            decimal troubleMoney = 0;
            int days = DateTime.DaysInMonth(year, month);
            List<decimal> expenseTroubleListByMonth = new List<decimal>(new decimal[days]);

            using (var context = new MasterlibraryEntities())
            {
                var troubleList = context.SUCOes.Where(b => b.THOIGIANBAOCAO.Year == year && b.THOIGIANBAOCAO.Month == month);

                if (troubleList.ToList().Count != 0)
                {
                    troubleMoney = (decimal)troubleList.Sum(b => b.CHIPHI);
                }

                var troubleListByMonth = troubleList.GroupBy(b => b.THOIGIANBAOCAO.Day).Select(gr => new { Day = gr.Key, Output = gr.Sum(b => (decimal?)(b.CHIPHI) ?? 0) }).ToList();

                foreach (var tr in troubleListByMonth)
                {
                    expenseTroubleListByMonth[tr.Day - 1] = decimal.Truncate(tr.Output);
                }

                return (expenseTroubleListByMonth, troubleMoney);
            }
        }

        //tính tiền khi thu sách phát sinh theo tháng
        public async Task<decimal> GetRevenueCollectByMonth(int year, int month)
        {
            decimal collectMoney = 0;

            using (var context = new MasterlibraryEntities())
            {
                var collectList = context.PHIEUTHUs.Where(b => b.NGAYTHU.Month == month && b.NGAYTHU.Year == year);

                if (collectList.ToList().Count != 0)
                {
                    collectMoney = (decimal)collectList.Sum(b => b.TONGTIEN);
                }

                return collectMoney;
            }
        }
        #endregion

        #region khách hàng
        //Lấy ra danh sách top 5 khách hàng.
        public async Task<List<CustomerDTO>> GetTop5CustomerExpenseByYear(int year)
        {
            try
            {
                using (var context = new MasterlibraryEntities())
                {
                    var cusStatistic = await context.HOADONs.Where(b => b.NGHD.Year == year && b.MAKH != null && b.ISRECEIVED == 1)
                        .GroupBy(b => b.MAKH)
                        .Select(grC => new
                        {
                            MAKH = grC.Key,
                            Expense = grC.Sum(c => (Decimal?)(c.TRIGIA)) ?? 0
                        })
                        .OrderByDescending(b => b.Expense).Take(5)
                        .Join(
                            context.KHACHHANGs,
                            statis => statis.MAKH,
                            cus => cus.MAKH,
                            (statis, cus) => new CustomerDTO
                            {
                                MAKH = cus.MAKH,
                                TENKH = cus.TENKH,
                                Expense = statis.Expense
                            }
                        ).ToListAsync();

                    //decimal BookExpense = 0;
                    //if (cusStatistic.Count >= 1)
                    //{
                    //    string cusId = cusStatistic.First().MAKH.ToString();
                    //}

                    return (cusStatistic);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<CustomerDTO>> GetTop5CustomerExpenseByMonth(int month, int year)
        {
            try
            {
                using (var context = new MasterlibraryEntities())
                {
                    var cusStatistic = await context.HOADONs.Where(b => b.NGHD.Month == month && b.NGHD.Year == year && b.MAKH != null && b.ISRECEIVED == 1)
                        .GroupBy(b => b.MAKH)
                        .Select(grC => new
                        {
                            MAKH = grC.Key,
                            Expense = grC.Sum(c => (Decimal?)(c.TRIGIA)) ?? 0
                        })
                        .OrderByDescending(b => b.Expense).Take(5)
                        .Join(
                            context.KHACHHANGs,
                            statis => statis.MAKH,
                            cus => cus.MAKH,
                            (statis, cus) => new CustomerDTO
                            {
                                MAKH = cus.MAKH,
                                TENKH = cus.TENKH,
                                Expense = statis.Expense
                            }
                         ).ToListAsync();

                    return cusStatistic;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
        //Lấy ra danh sách top 5 sách có doanh thu cao nhất
        public async Task<List<BookDTO>> GetTop5BookByYear(int year)
        {
            try
            {
                using (var context = new MasterlibraryEntities())
                {
                    var bookStatis = context.CTHDs.Where(s => s.HOADON.NGHD.Year == year && s.HOADON.ISRECEIVED == 1)
                        .GroupBy(s => s.MASACH)
                        .Select(gr => new
                        {
                            MASACH = gr.Key,
                            Revenue = gr.Sum(s => s.SACH.GIA),
                            soluong = gr.Sum(b => b.SOLUONG)
                        })
                        .OrderByDescending(m => m.Revenue).Take(5)
                        .Join(
                            context.SACHes,
                            statis => statis.MASACH,
                            sach => sach.MASACH,
                            (statis, sach) => new BookDTO
                            {
                                TenSach = sach.TENSACH,
                                //tonggiaban = (decimal)statis.Revenue,
                                tonggiaban = (decimal)(statis.soluong * sach.GIA),
                                soluongban = (int)statis.soluong
                            }
                         ).ToList();
                        
                   

                        return bookStatis;
                }
            }
            catch (Exception e) { throw e; }

        }

        public async Task<List<BookDTO>> GetTop5BookByMonth(int month, int year)
        {
            try
            {
                using (var context = new MasterlibraryEntities())
                {
                    var bookStatis = context.CTHDs.Where(s => s.HOADON.NGHD.Month == month && s.HOADON.NGHD.Year == year && s.HOADON.ISRECEIVED == 1)
                        .GroupBy(s => s.MASACH)
                        .Select(gr => new
                        {
                            MASACH = gr.Key,
                            Revenue = gr.Sum(s => s.SACH.GIA),
                            soluong = gr.Sum(b => b.SOLUONG)
                        })
                        .OrderByDescending(r => r.Revenue).Take(5)
                        .Join (
                            context.SACHes,
                            statis => statis.MASACH,
                            sach => sach.MASACH,
                            (statis, sach) => new BookDTO
                            {
                                TenSach = sach.TENSACH,
                                tonggiaban = (decimal)statis.Revenue,
                                soluongban = (int)statis.soluong
                            }
                        ).ToList();

                    return bookStatis;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
