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
    /// Interaction logic for ThemSanPham.xaml
    /// </summary>
    public partial class ThemSanPham : Window
    {
        public ThemSanPham()
        {
            InitializeComponent();
        }

        string strfileName;
        List<LoaiSanPham> dsLoaiSp = new List<LoaiSanPham>();
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
                Soluong_Textbox.Text = "";
            }
        }
        private void Luu_Button_Click(object sender, RoutedEventArgs e)
        {
            var sanPham = new SanPham();
            var DsSp = new List<SanPham>();
            var loaiSp = new LoaiSanPham();
            SanPham_Bus sanPham_Bus = new SanPham_Bus();
       
            DsSp = sanPham_Bus.LoadAll();
            
            try
            {
              
                sanPham.TenSanPham = TenSP_Textbox.Text;
                sanPham.GiaGoc = int.Parse(GiaGoc_Textbox.Text);
                sanPham.GiaBan = int.Parse(GiaBan_TextBox.Text);
                if (LoaiSP_ComboBox.SelectedIndex < dsLoaiSp.Count())
                {
                    sanPham.MaLoaiSanPham = dsLoaiSp[LoaiSP_ComboBox.SelectedIndex].MaLoaiSanPham;
                }
                else
                {
                    loaiSp.TenLoaiSanPham = LoaiSP_Textbox.Text;
                    LoaiSanPham_Bus loaiSanPham_Bus = new LoaiSanPham_Bus();
                   
                    loaiSanPham_Bus.AddLoaiSanPham(loaiSp);
                  
                    sanPham.MaLoaiSanPham = loaiSp.MaLoaiSanPham;
                }
                
                sanPham.HinhAnh = strfileName;
                sanPham.isDelete = 0;
       
                sanPham.SoLuongConLai = int.Parse(Soluong_Textbox.Text);
                if (sanPham_Bus.AddSanPham(sanPham))
                {
                    MessageBox.Show("Thêm thành công");
                    Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lol");
            }
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
            if (Soluong_Textbox.Text == "")
            {
                Soluong_Textbox.Text = "1";
            }
            else
            {
                Soluong_Textbox.Text = (Int32.Parse(Soluong_Textbox.Text) + 1).ToString();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
            LoaiSanPham_Bus loaiSanPham_Bus = new LoaiSanPham_Bus();
            dsLoaiSp = loaiSanPham_Bus.LoadAll();

            List<string> ten = new List<string>();
            for (int i = 0; i < dsLoaiSp.Count(); i++)
            {
                ten.Add(dsLoaiSp[i].TenLoaiSanPham);
            }
            ten.Add("Khác");
            LoaiSP_ComboBox.ItemsSource = ten;

        }

        private void LoaiSP_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LoaiSP_ComboBox.SelectedIndex == dsLoaiSp.Count())
            {
                LoaiSP_Textbox.Visibility = Visibility;
            }
        }
    }
}
