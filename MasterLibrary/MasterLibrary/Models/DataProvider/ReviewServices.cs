using MasterLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterLibrary.Models.DataProvider
{
    public class ReviewServices
    {
        private static ReviewServices _ins;
        public static ReviewServices Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new ReviewServices();
                }
                return _ins;
            }
            private set => _ins = value;
        }

        public async Task<bool> FindCusReview(int _makh, int _masach)
        {
            try
            {
                using (var context = new MasterlibraryEntities())
                {
                    if (_masach != null)
                    {
                        var currentReview = context.REVIEWs.FirstOrDefault(s => s.MAKH == _makh && s.MASACH == _masach);
                        if (currentReview != null)
                        {
                            return true;
                        }
                    }
                    
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<(bool, string)> AddReview(int _makh, int _bookId, string _reviewText, double _ratingStar)
        {
            try
            {
                using (var context = new MasterlibraryEntities())
                {
                    var currentBook = context.REVIEWs.FirstOrDefault(s => s.MASACH == _bookId && s.MAKH == _makh);
                    if (currentBook != null)
                    {
                        currentBook.NHANXET = _reviewText;
                    }
                    else
                    {
                        REVIEW newReview = new REVIEW()
                        {
                            MAKH = _makh,
                            MASACH = _bookId,
                            NHANXET = _reviewText,
                            RATINGSTAR = _ratingStar
                        };

                        context.REVIEWs.Add(newReview);
                    }

                    context.SaveChanges();

                    return (true, "Thêm nhận xét thành công!");
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                return (false, "Không thể kết nối được với cơ sở dữ liệu.");
            }
            catch (Exception)
            {
                return (false, "Gặp lỗi trong việc thêm nhận xét.");
            }
        }

        public async Task<List<ReviewDTO>> GetAllReview(int _masach)
        {
            try
            {
                using (var context = new MasterlibraryEntities())
                {
                    var allReviewList = (from rv in context.REVIEWs
                                         where rv.SACH.MASACH == _masach
                                         select new ReviewDTO
                                         {
                                             MAKH = (int)rv.MAKH,
                                             TenKH = rv.KHACHHANG.TENKH,
                                             NHANXET = rv.NHANXET,
                                             ratingStar = (double)rv.RATINGSTAR,
                                         }).ToListAsync();

                    return await allReviewList;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
