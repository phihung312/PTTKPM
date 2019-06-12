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
            //try
            //{
            //    var db = new QuanLyCuaHangEntities();
            //    KhuyenMai km = new KhuyenMai();
            //    km.MaKM = MaKM_TextBox.Text;
            //    km.TenKM = TenKM_TextBox.Text;
            //    km.MucKM =int.Parse( MucKM_TextBox.Text);
            //    db.KhuyenMais.Add(km);
            //    db.SaveChanges();
            //    MessageBox.Show("Thêm mã khuyến mãi thành công!");
            //    MaKM_TextBox.Text = "";
            //    TenKM_TextBox.Text = "";
            //    MucKM_TextBox.Text = "";
            //}
            //catch(Exception)
            //{
            //    MessageBox.Show("Thêm không thành công vui lòng kiểm tra lại");
            //}
            //DanhSachKMDataGrid_Loaded(null, null);
        }

        private void DanhSachKMDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            //var db = new QuanLyCuaHangEntities();
            //DanhSachKMDataGrid.ItemsSource = db.KhuyenMais.ToList();
        }
    }
}
