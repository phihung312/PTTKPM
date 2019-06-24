using Final_ManagementSystem.DAL;
using Final_ManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_ManagementSystem.BUS
{
    public class SanPham_Bus
    {
        SanPham_DAL sanPham_Dal = new SanPham_DAL();
        public List<SanPham> LoadAll()
        {
            var list = sanPham_Dal.LoadAll();
            for (int i=0; i < list.Count(); i++)
            {
                if (list[i].isDelete == 1)
                {
                    list.Remove(list[i]);
                    i--;
                }
            }
            return list;
        }
        public bool AddSanPham(SanPham sanPham)
        {
            return sanPham_Dal.AddSanPham(sanPham);

        }


        public bool EditSanPham(SanPham sanPham)
        {
            return sanPham_Dal.EditSanPham(sanPham);
        }
        public bool DeleteSanPham(SanPham sanPham)
        {
            return sanPham_Dal.DeleteSanPham(sanPham);

        }
        public SanPham FindByID(int i)
        {
            return sanPham_Dal.FindByID( i);
        }
    }
    public class LoaiSanPham_Bus
    {
        LoaiSanPham_DAL loaiSanPham_Dal = new LoaiSanPham_DAL();
        public List<LoaiSanPham> LoadAll()
        {
            return loaiSanPham_Dal.LoadAll();
        }
        public bool AddLoaiSanPham(LoaiSanPham loaiSanPham)
        {
            return loaiSanPham_Dal.AddLoaiSanPham(loaiSanPham);

        }


        public bool DeleteLoaiSanPham(LoaiSanPham loaiSanPham)
        {
            return loaiSanPham_Dal.DeleteLoaiSanPham(loaiSanPham);

        }
    }

    public class CachThanhToan_Bus
    {
        CachThanhToan_DAL CachThanhToan_DAL = new CachThanhToan_DAL();
        public List<CachThanhToan> LoadAll()
        {

            return CachThanhToan_DAL.LoadAll();
        }

    }
    public class KhuyenMai_Bus
    {
        KhuyenMai_DAL khuyenMai_DAL = new KhuyenMai_DAL();
        public List<KhuyenMai> LoadAll()
        {
            return khuyenMai_DAL.LoadAll();
          
        }
        public bool AddKhuyenMai(KhuyenMai khuyenMai)
        {
            return khuyenMai_DAL.AddKhuyenMai(khuyenMai);
        }
    }
    public class KhachHang_Bus
    {
        KhachHang_DAL KhachHang_DAL = new KhachHang_DAL();

        public List<KhachHang> LoadAll()
        {
            return KhachHang_DAL.LoadAll();
        }
        public bool AddKhachHang(KhachHang khachHang)
        {
            return KhachHang_DAL.AddKhachHang(khachHang);
        }
    }
    public class DonHang_Bus
    {
        DonHang_DAL DonHang_DAL = new DonHang_DAL();

        public List<DonHang> LoadAll()
        {
            return DonHang_DAL.LoadAll();
           
        }
        public bool AddDonHang(DonHang donHang)
        {
            return DonHang_DAL.AddDonHang(donHang);
        }
        public bool EditDonHang(DonHang donHang)
        {
            return DonHang_DAL.EditDonHang(donHang);

        }
        public List<DonHang> FindByID(int i)
        {
            return DonHang_DAL.FindByID(i);
        }
    }
    public class TaiKhoan_Bus
    {
        
        public List<TaiKhoan> LoadAll()
        {
            TaiKhoan_DAL taiKhoan_Dal = new TaiKhoan_DAL();
            return taiKhoan_Dal.LoadAll();
        }

    }
}

