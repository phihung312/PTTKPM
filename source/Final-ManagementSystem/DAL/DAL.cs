using Final_ManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_ManagementSystem.DAL
{
    public class SanPham_DAL
    {
        public List<SanPham> LoadAll()
        {
            List<SanPham> sanPhams = new List<SanPham>();
            var db = new QuanLyCuaHangEntities();
            sanPhams = db.SanPhams.ToList();
            return sanPhams;
        }
        public bool AddSanPham(SanPham sanPham)
        {
            try
            {
                var db = new QuanLyCuaHangEntities();
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

            }
            return false;

        }


        public bool EditSanPham(SanPham sanPham)
        {
            try
            {
                var db = new QuanLyCuaHangEntities();

                var sanPham1 = db.SanPhams.Find(sanPham.MaSanPham);
                sanPham1.GiaBan = sanPham.GiaBan;
                sanPham1.GiaGoc = sanPham.GiaGoc;
                sanPham1.HinhAnh = sanPham.HinhAnh;

                sanPham1.MaLoaiSanPham = sanPham.MaLoaiSanPham;
                sanPham1.SoLuongConLai = sanPham.SoLuongConLai;
                sanPham1.TenSanPham = sanPham.TenSanPham;
                sanPham1.isDelete = sanPham.isDelete;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

            }
            return false;

        }
        public bool DeleteSanPham(SanPham sanPham)
        {
            try
            {
                var db = new QuanLyCuaHangEntities();
                db.SanPhams.Remove(sanPham);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

            }
            return false;

        }
        public SanPham FindByID(int i)
        {
            var db = new QuanLyCuaHangEntities();
            var sp= db.SanPhams.Find(i);
            return sp;
        }
    }
    public class LoaiSanPham_DAL
    {
        public List<LoaiSanPham> LoadAll()
        {
            List<LoaiSanPham> LoaiSanPhams = new List<LoaiSanPham>();
            var db = new QuanLyCuaHangEntities();
            LoaiSanPhams = db.LoaiSanPhams.ToList();
            return LoaiSanPhams;
        }
        public bool AddLoaiSanPham(LoaiSanPham loaiSanPham)
        {
            try
            {
                var db = new QuanLyCuaHangEntities();
                db.LoaiSanPhams.Add(loaiSanPham);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

            }
            return false;

        }

       
        public bool DeleteLoaiSanPham(LoaiSanPham loaiSanPham)
        {
            try
            {
                var db = new QuanLyCuaHangEntities();
                db.LoaiSanPhams.Remove(loaiSanPham);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

            }
            return false;

        }
    }

    public class CachThanhToan_DAL
    {
        public List<CachThanhToan> LoadAll()
        {
          
            var db = new QuanLyCuaHangEntities();
            var cachThanhToans = db.CachThanhToans.ToList();
            return cachThanhToans;
        }
 
    }
    public class KhuyenMai_DAL
    {
        public List<KhuyenMai> LoadAll()
        {

            var db = new QuanLyCuaHangEntities();
            var khuyenMais = db.KhuyenMais.ToList();
            return khuyenMais;
        }
        public bool AddKhuyenMai(KhuyenMai khuyenMai)
        {
            try
            {
                var db = new QuanLyCuaHangEntities();
                db.KhuyenMais.Add(khuyenMai);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

            }
            return false;

        }
    }
    public class KhachHang_DAL
    {

        public List<KhachHang> LoadAll()
        {

            var db = new QuanLyCuaHangEntities();
            var khachHangs = db.KhachHangs.ToList();
            return khachHangs;
        }
        public bool AddKhachHang(KhachHang khachHang )
        {
            try
            {
                var db = new QuanLyCuaHangEntities();
                db.KhachHangs.Add(khachHang);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

            }
            return false;

        }
    }
    public class DonHang_DAL
    {

        public List<DonHang> LoadAll()
        {

            var db = new QuanLyCuaHangEntities();
            var donHangs = db.DonHangs.ToList();
            return donHangs;
        }
        public bool AddDonHang(DonHang donHang)
        {
            try
            {
                var db = new QuanLyCuaHangEntities();
                db.DonHangs.Add(donHang);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

            }
            return false;

        }
        public bool EditDonHang(DonHang donHang)
        {
            try
            {
                var db = new QuanLyCuaHangEntities();

                var donHang1 = db.DonHangs.Find(donHang.MaDongHang, donHang.MaSanPham);
              
                donHang1.TinhTrang = donHang.TinhTrang;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

            }
            return false;

        }
        public List<DonHang> FindByID(int i)
        {
            List<DonHang> query;
            using (var db = new QuanLyCuaHangEntities())
            {
                query = db.DonHangs.Where(s => s.MaDongHang == i).ToList();
            }
            return query;
        }
    }
    public class TaiKhoan_DAL
    {

        public List<TaiKhoan> LoadAll()
        {

            var db = new QuanLyCuaHangEntities();
            var TaiKhoan = db.TaiKhoans.ToList();
            return TaiKhoan;
        }
       
    }
}
