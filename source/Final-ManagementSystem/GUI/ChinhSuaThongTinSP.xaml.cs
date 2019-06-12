using Final_ManagementSystem.DTO;
using Final_ManagementSystem.BUS;
using Microsoft.Win32;
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
    /// Interaction logic for ChinhSuaThongTinSP.xaml
    /// </summary>
    public partial class ChinhSuaThongTinSP : Window
    {
        public ChinhSuaThongTinSP()
        {
            InitializeComponent();
        }
        List<LoaiSanPham> dsLoaiSp = new List<LoaiSanPham>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var db = new QuanLyCuaHangEntities();
            LoaiSanPham_Bus loaiSanPham_Bus = new LoaiSanPham_Bus();
            dsLoaiSp = loaiSanPham_Bus.LoadAll();

            List<string> ten = new List<string>();
            for (int i = 0; i < dsLoaiSp.Count(); i++)
            {
                ten.Add(dsLoaiSp[i].TenLoaiSanPham);
            }
            ten.Add("Khác");
            LoaiSP_ComboBox.ItemsSource = ten;
            LoaiSP_ComboBox.SelectedItem = "Chọn loại sản phẩm";
        }

        private void Soluong_Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (Soluong_Textbox.Text != "")
                {
                    int.Parse(Soluong_Textbox.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Kiểu dữ liệu bạn nhập phải là số tự nhiên!");

            }
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            TenSP_Textbox.IsEnabled = true;
            GiaBan_TextBox.IsEnabled = true;
            GiaGoc_Textbox.IsEnabled = true;
            Soluong_Textbox.IsEnabled = true;
            Plus_Button.Visibility = Visibility;
            Subtract_Button.Visibility = Visibility;
            Luu_Button.Visibility = Visibility;
            CapNhatHinhAnh_Button.Visibility = Visibility;
            SuaHinhAnh_Button.Visibility = Visibility;
            LoaiSP_ComboBox.Visibility = Visibility;
        }

        private void Subtract_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.Parse(Soluong_Textbox.Text) > 0 && Soluong_Textbox.IsEnabled == true)
            {
                Soluong_Textbox.Text = (Int32.Parse(Soluong_Textbox.Text) - 1).ToString();
            }
        }

        private void Plus_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Soluong_Textbox.IsEnabled == true)
            {
                Soluong_Textbox.Text = (Int32.Parse(Soluong_Textbox.Text) + 1).ToString();
            }
        }
        string strfileName;
        private void SuaHinhAnh_Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Image files (.png;.jpg)|*.png;*.jpg|All files (.)|*.*";//Chọn những file có định dạng png,jpg ban đầu

            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                strfileName = openFileDialog.FileName;
                BitmapImage bm = new BitmapImage();
                bm.BeginInit();
                bm.UriSource = new Uri(strfileName, UriKind.RelativeOrAbsolute);
                bm.EndInit();

                HinhAnh_Image.Source = bm;
            }
        }

        private void Luu_Button_Click(object sender, RoutedEventArgs e)
        {
            var sanPham = new SanPham();
            var loaiSp = new LoaiSanPham();
            SanPham_Bus sanPham_Bus = new SanPham_Bus();
            LoaiSanPham_Bus loaiSanPham_Bus = new LoaiSanPham_Bus();
            sanPham.MaSanPham = int.Parse(MaSP_textbox.Text);
            var sp = sanPham_Bus.FindByID(sanPham.MaSanPham);
            try
            {
                sanPham.TenSanPham = TenSP_Textbox.Text;
                sanPham.GiaGoc = int.Parse(GiaGoc_Textbox.Text);
                sanPham.GiaBan = int.Parse(GiaBan_TextBox.Text);
                if (sp.HinhAnh != null)
                {
                    sanPham.HinhAnh = sp.HinhAnh;
                }
                if (LoaiSP_ComboBox.SelectedIndex == -1)
                {
                    sanPham.MaLoaiSanPham = sp.MaLoaiSanPham;
                }
                else
               if (LoaiSP_ComboBox.SelectedIndex < dsLoaiSp.Count())
                {
                    var lsp = loaiSanPham_Bus.LoadAll();
                    sanPham.MaLoaiSanPham = lsp[LoaiSP_ComboBox.SelectedIndex].MaLoaiSanPham;
                }
                else

                {
                    loaiSp.TenLoaiSanPham = LoaiSP_Textbox.Text;




                    loaiSanPham_Bus.AddLoaiSanPham(loaiSp);

                    sanPham.MaLoaiSanPham = loaiSp.MaLoaiSanPham;

                }
                sanPham.SoLuongConLai = int.Parse(Soluong_Textbox.Text);

                if (sanPham_Bus.EditSanPham(sanPham))
                    MessageBox.Show("Lưu thành công");

            }
            catch (Exception)
            {
                MessageBox.Show("Lưu k thành công");
            }
        }

        private void LoaiSP_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LoaiSP_ComboBox.SelectedIndex == dsLoaiSp.Count())
            {
                LoaiSP_Textbox.IsEnabled = true;
                LoaiSP_Textbox.Text = "";
            }
            else
            {
                LoaiSP_Textbox.Text = LoaiSP_ComboBox.SelectedItem.ToString();
            }
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Bạn chắc chắn muốn xóa sản phẩm này?", "Thông báo", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {


                SanPham_Bus sanPham_Bus1 = new SanPham_Bus();


                var sanPham = sanPham_Bus1.FindByID(int.Parse(MaSP_textbox.Text));
                sanPham.isDelete = 1;
                if (sanPham_Bus1.EditSanPham(sanPham))
                {
                    MessageBox.Show("Xóa thành công!");
                    Close();
                }

                
            }
        }
    }
}
