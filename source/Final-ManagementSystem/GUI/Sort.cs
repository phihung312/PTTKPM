using Final_ManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_ManagementSystem
{


    public class SpGiaComparer : IComparer<SanPham> 
    {
        public int Compare(SanPham x, SanPham y)
        {
            return x.GiaBan.CompareTo(y.GiaBan);
        }
    }
    //public class SpBanChayComparer : IComparer<SanPham>
    //{
    //    //public int Compare(SanPham x, SanPham y)
    //    //{
            
    //    //    //return x.SoLuongDaBan.CompareTo(y.SoLuongDaBan);
    //    //}
    //}

}
