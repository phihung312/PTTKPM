using Final_ManagementSystem.DTO;
using Final_ManagementSystem.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Final_ManagementSystem
{
    /// <summary>
    /// Interaction logic for GioHang.xaml
    /// </summary>
    public partial class GioHang : Page
    {
        public GioHang()
        {
            InitializeComponent();
            
        }
       
        public class Data
        {
            public int maSP { get; set; }
            public string TenSP { get; set; }
            public int SoLuong { get; set; }
            public int GiaBan { get; set; }
        }
        List<Data> datas = new List<Data>();
        int tongTien=0;
        List<SanPham> sanPhams = new List<SanPham>();
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            sanPhams = BanHang.dsSpMua;
            if (sanPhams != null)
            {
                for (int i = 0; i < sanPhams.Count(); i++)
                {
                    Data data = new Data();
                    data.maSP = sanPhams[i].MaSanPham;
                    data.TenSP = sanPhams[i].TenSanPham;
                    data.SoLuong = 1;
                    data.GiaBan = sanPhams[i].GiaBan * data.SoLuong;
                    datas.Add(data);
                    tongTien += datas[i].GiaBan;
                }
            }
            TongTien_TextBlock.Text = tongTien.ToString() + "VND";
        }

        private void DanhSachSPDataGrid_Loaded(object sender, RoutedEventArgs e)
        {

            DanhSachSPDataGrid.ItemsSource = null;

            DanhSachSPDataGrid.ItemsSource = datas;
           

        }



      
        private void CachThanhToan_ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var ctt = new CachThanhToan_Bus();
            var ctts = ctt.LoadAll();
            
            CachThanhToan_ComboBox.ItemsSource = ctts;
        }

        private void MaKM_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            KhuyenMai_Bus khuyenMai_Bus = new KhuyenMai_Bus();
            var KMs = khuyenMai_Bus.LoadAll();
            if (KMs != null)
            {
                for (int i = 0; i < KMs.Count(); i++)
                {
                    if (MaKM_TextBox.Text == KMs[i].MaKhuyenMai)
                    {
                        tongTien -= tongTien * KMs[i].MucKhuyenMai/100;
                        TongTien_TextBlock.Text = tongTien.ToString() + " VND";
                        MaKM_TextBox.Text = KMs[i].MaKhuyenMai;
                    }
                }
            }
        }
        List<KhachHang> DsKH = new List<KhachHang>();
        List<DonHang> DsDH = new List<DonHang>();
        private void ThanhToan_Button_Click(object sender, RoutedEventArgs e)
        {
            var KH = new KhachHang();
            int kiemTra = 1;
            int km = 100;
            var DH = new DonHang();
            var db = new QuanLyCuaHangEntities();
            DsKH = db.KhachHangs.ToList();
            DsDH = db.DonHangs.ToList();
                        //try
            //{
                if (CachThanhToan_ComboBox.SelectedIndex == 1 && (DC_TextBox.Text == "" || SDT_TextBox.Text == ""))
                {
                    MessageBox.Show("Bạn phải nhập số điện thoại và địa chỉ để chuyển hàng");
                    kiemTra = 0;
                }
                else
                {
                  
                   
                    KH.TenKhachHang = TenKH_TextBox.Text;
                    KH.SoDienThoai = SDT_TextBox.Text;
                    KH.DiaChi = DC_TextBox.Text;
                    //KH.isDelete = false;

                    var db1 = new QuanLyCuaHangEntities();
                    db1.KhachHangs.Add(KH);

                    db1.SaveChanges();
                   

              
                 
                  
                    if (MaKM_TextBox.Text != "")
                    {

                        var db4 = new QuanLyCuaHangEntities();
                        var KMs = db4.KhuyenMais.ToList();
                        if (KMs != null)
                        {
                            for (int i = 0; i < KMs.Count(); i++)
                            {
                                if (MaKM_TextBox.Text == KMs[i].MaKhuyenMai)
                                {
                                    //km = KMs[i].MucKM;
                                    
                                }
                            }
                        }
                        DH.MaKhuyenMai = MaKM_TextBox.Text;
                        
                    }

                    //DH.TrangThai = dsTT[TrangThai_ComboBox.SelectedIndex].TrangThai1;

                    DH.ThoiGian = DateTime.Now;
                    for (int i = 0; i < datas.Count(); i++)
                    {
                       
                        DH.MaSanPham = datas[i].maSP;
                        DH.Gia = datas[i].GiaBan*km/100;
                        DH.SoLuong = datas[i].SoLuong;
                        var db3 = new QuanLyCuaHangEntities();
                        var sanpham = db3.SanPhams.Find(DH.MaSanPham);
                        if (sanpham.SoLuongConLai >= DH.SoLuong)
                        {
                            sanpham.SoLuongConLai -= DH.SoLuong;
                           
                            db3.SaveChanges();
                            var db2 = new QuanLyCuaHangEntities();
                            db2.DonHangs.Add(DH);
                            db2.SaveChanges();
                            kiemTra = 1;
                        }
                        else
                        {
                            MessageBox.Show("Sản phẩm " + datas[i].TenSP + " không đủ vui lòng xem lại");
                            kiemTra = 0;
                            break;
                           
                        }
                       
                    }
                    if (kiemTra == 1)
                    {
                        MessageBox.Show("Giao dịch thành công!");
                        datas.Clear();
                        sanPhams.Clear();
                        Page_Loaded(null, null);
                        DanhSachSPDataGrid_Loaded(null, null);
                        CachThanhToan_ComboBox.SelectedIndex = -1;
                        TenKH_TextBox.Text = "";
                        DC_TextBox.Text = "";
                        SDT_TextBox.Text = "";
                        TongTien_TextBlock.Text = "";
                    }
                }
            
            //catch (Exception)
            //{
            //    MessageBox.Show("Giao dịch k thành công!");
            //}
        }

      

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            datas[DanhSachSPDataGrid.SelectedIndex].SoLuong += 1;
            datas[DanhSachSPDataGrid.SelectedIndex].GiaBan +=sanPhams[DanhSachSPDataGrid.SelectedIndex].GiaBan;
            tongTien += sanPhams[DanhSachSPDataGrid.SelectedIndex].GiaBan;
            TongTien_TextBlock.Text = tongTien.ToString();
            DanhSachSPDataGrid_Loaded(null, null);
        }

        private void SubtractButton_Click(object sender, RoutedEventArgs e)
        {
            if (datas[DanhSachSPDataGrid.SelectedIndex].SoLuong > 1)
            {
                datas[DanhSachSPDataGrid.SelectedIndex].SoLuong -= 1;
                datas[DanhSachSPDataGrid.SelectedIndex].GiaBan -= sanPhams[DanhSachSPDataGrid.SelectedIndex].GiaBan;
                tongTien -= sanPhams[DanhSachSPDataGrid.SelectedIndex].GiaBan;
                TongTien_TextBlock.Text = tongTien.ToString();
                DanhSachSPDataGrid_Loaded(null, null);
            }
            else
            {
                tongTien -= sanPhams[DanhSachSPDataGrid.SelectedIndex].GiaBan;
                TongTien_TextBlock.Text = tongTien.ToString();
                datas.RemoveAt(DanhSachSPDataGrid.SelectedIndex);
                sanPhams.RemoveAt(DanhSachSPDataGrid.SelectedIndex);
                
                DanhSachSPDataGrid_Loaded(null, null);
            }
        }

       
    }
}
