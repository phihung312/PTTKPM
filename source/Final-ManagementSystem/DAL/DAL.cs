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
}
