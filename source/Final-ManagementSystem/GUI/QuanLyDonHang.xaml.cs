using Final_ManagementSystem.BUS;
using Final_ManagementSystem.DTO;
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
    /// Interaction logic for QuanLyDonHang.xaml
    /// </summary>
    public partial class QuanLyDonHang : UserControl
    {
        public QuanLyDonHang()
        {
            InitializeComponent();
        }
       
        public class Data
        {
            public int MaDonHang { get; set; }
            public string TenKhachHang { get; set; }
            public int Gia { get; set; }
            public string TinhTrang { get; set; }
            public string ThoiGian { get; set; }
        }

        private void DonHang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        List<DonHang> donhang = new List<DonHang>();
        private void DonHang_Loaded(object sender, RoutedEventArgs e)
        {
            var datas = new List<Data>();
            var data = new Data();
            DonHang_Bus dongHang_Bus = new DonHang_Bus();
            donhang = dongHang_Bus.LoadAll();

            data.MaDonHang = donhang[0].MaDongHang;
            data.TenKhachHang = donhang[0].KhachHang.TenKhachHang;
            data.Gia += donhang[0].Gia;
            data.TinhTrang = donhang[0].TinhTrang1.TenTinhTrang;
            data.ThoiGian = donhang[0].ThoiGian.ToString();
            datas.Add(data);
            for (int i = 0; i < donhang.Count() - 1; i++)
            {
                if (donhang[i].isDelete == 0)
                {
                    if (donhang[i].MaDongHang == donhang[i + 1].MaDongHang)
                    {
                        datas[i].MaDonHang = donhang[i].MaDongHang;
                        datas[i].TenKhachHang = donhang[i].KhachHang.TenKhachHang;
                        datas[i].Gia += donhang[i + 1].Gia;
                        datas[i].TinhTrang = donhang[i].TinhTrang1.TenTinhTrang;
                        donhang.RemoveAt(i);
                        i--;

                    }
                    else
                    {
                        var dt = new Data();
                        datas.Add(dt);
                        datas[i + 1].MaDonHang = donhang[i + 1].MaDongHang;
                        datas[i + 1].TenKhachHang = donhang[i + 1].KhachHang.TenKhachHang;
                        datas[i + 1].Gia += donhang[i + 1].Gia;
                        datas[i + 1].TinhTrang = donhang[i + 1].TinhTrang1.TenTinhTrang;
                        datas[i + 1].ThoiGian= donhang[i + 1].ThoiGian.ToString();
                    }
                }
            }
            DonHangDataGrid.ItemsSource = datas;
        }

        private void Xoa_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Bạn chắc chắn muốn hủy đơn hàng này?", "Thông báo", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {


                DonHang_Bus donHang_Bus = new DonHang_Bus();


                var donHang = donHang_Bus.FindByID(donhang[DonHangDataGrid.SelectedIndex].MaDongHang);
                
                for (int i=0; i< donHang.Count(); i++)
                {
                    donHang[i].TinhTrang = 3;
                    DonHang_Bus bus = new DonHang_Bus();
                    bus.EditDonHang(donHang[i]);
                }
                DonHang_Loaded(null, null);

            }
        }
    }
}
