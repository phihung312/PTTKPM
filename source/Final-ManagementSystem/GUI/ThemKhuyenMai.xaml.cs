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
using System.Windows.Shapes;

namespace Final_ManagementSystem
{
    /// <summary>
    /// Interaction logic for ThemKhuyenMai.xaml
    /// </summary>
    public partial class ThemKhuyenMai : Window
    {
        public ThemKhuyenMai()
        {
            InitializeComponent();
        }

        private void ThemKM_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var db = new QuanLyCuaHangEntities();
                KhuyenMai_Bus khuyenMai_Bus = new KhuyenMai_Bus();
                KhuyenMai km = new KhuyenMai();
                km.MaKhuyenMai = MaKM_TextBox.Text;
                km.TenKhuyenMai = TenKM_TextBox.Text;
                km.MucKhuyenMai = int.Parse(MucKM_TextBox.Text);
                khuyenMai_Bus.AddKhuyenMai(km);
                db.SaveChanges();
                MessageBox.Show("Thêm mã khuyến mãi thành công!");
                MaKM_TextBox.Text = "";
                TenKM_TextBox.Text = "";
                MucKM_TextBox.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm không thành công vui lòng kiểm tra lại");
            }
            DanhSachKMDataGrid_Loaded(null, null);
        }

        private void DanhSachKMDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            KhuyenMai_Bus khuyenMaiBus = new KhuyenMai_Bus();
            DanhSachKMDataGrid.ItemsSource = khuyenMaiBus.LoadAll();
        }
    }
}
