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
using Final_ManagementSystem.DTO;
using Final_ManagementSystem.BUS;
using Fluent;
namespace Final_ManagementSystem
{
    /// <summary>
    /// Interaction logic for DanhSachSanPham.xaml
    /// </summary>
    public partial class DanhSachSanPham : UserControl
    {
        public DanhSachSanPham()
        {
            InitializeComponent();
        }
        List<LoaiSanPham> dsLoaiSp = new List<LoaiSanPham>();
        private void LoaiSP_ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            
            LoaiSanPham_Bus loaiSanPham_Bus = new LoaiSanPham_Bus();
            dsLoaiSp = loaiSanPham_Bus.LoadAll();

            List<string> ten = new List<string> { "Tất cả" };
            for (int i = 0; i < dsLoaiSp.Count(); i++)
            {
                ten.Add(dsLoaiSp[i].TenLoaiSanPham);
            }
            LoaiSP_ComboBox.ItemsSource = ten;
            LoaiSP_ComboBox.SelectedIndex = 0;
        }
        public List<SanPham> dsSP { get; set; }
        private void DanhSachSPDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            SanPham_Bus sanPham_Bus = new SanPham_Bus();
            dsSP = sanPham_Bus.LoadAll();
            
            DanhSachSPDataGrid.ItemsSource = dsSP;

        }

        private void Gia_ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var ds = new List<string> { "---", "<1tr", "1tr -> 3tr", " >3tr" };
            Gia_ComboBox.ItemsSource = ds;
            Gia_ComboBox.SelectedIndex = 0;
        }



        private void TimKiem_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var dsSpTk = new List<SanPham>();
            if (TimKiem_TextBox.Text != "")
            {

                for (int i = 0; i < dsSP.Count(); i++)
                {
                    if (dsSP[i].TenSanPham.ToLower().Contains(TimKiem_TextBox.Text.ToLower()) == true)
                    {
                        dsSpTk.Add(dsSP[i]);
                    }
                }
                DanhSachSPDataGrid.ItemsSource = dsSpTk;
            }
            else { DanhSachSPDataGrid.ItemsSource = dsSP; }

        }

        private void TimKiem_Button_Click(object sender, RoutedEventArgs e)
        {
            var db = new QuanLyCuaHangEntities();
            var dsSpTk = new List<SanPham>();

            if (LoaiSP_ComboBox.SelectedIndex != 0)
            {
                db.LoaiSanPhams.ToList();

                dsSP = db.SanPhams.Where(s => s.LoaiSanPham.TenLoaiSanPham.Contains(LoaiSP_ComboBox.SelectedItem.ToString())).ToList();

            }
            if (Gia_ComboBox.SelectedIndex != 0)
            {

                dsSP.Sort(new SpGiaComparer());
                if (Gia_ComboBox.SelectedIndex == 1)
                {
                    for (int i = 0; i < dsSP.Count(); i++)
                    {
                        if (dsSP[i].GiaBan > 1000000)
                        {
                            dsSP.Remove(dsSP[i]);
                            i--;
                        }
                    }
                }
                if (Gia_ComboBox.SelectedIndex == 2)
                {
                    for (int i = 0; i < dsSP.Count(); i++)
                    {
                        if (dsSP[i].GiaBan < 1000000 && dsSP[i].GiaBan > 3000000)
                        {
                            dsSP.Remove(dsSP[i]);
                            i--;
                        }
                    }
                }
                if (Gia_ComboBox.SelectedIndex == 3)
                {
                    for (int i = 0; i < dsSP.Count(); i++)
                    {
                        if (dsSP[i].GiaBan < 3000000)
                        {
                            dsSP.Remove(dsSP[i]);
                            i--;
                        }
                    }
                }
            }

            DanhSachSPDataGrid.ItemsSource = dsSP;
        }

        private void DanhSachSPDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DanhSachSPDataGrid.SelectedIndex != -1)
            {
                ChinhSuaThongTinSP chinhSuaThongTinSP = new ChinhSuaThongTinSP();
                chinhSuaThongTinSP.MaSP_textbox.Text = dsSP[DanhSachSPDataGrid.SelectedIndex].MaSanPham.ToString();
                chinhSuaThongTinSP.TenSP_Textbox.Text = dsSP[DanhSachSPDataGrid.SelectedIndex].TenSanPham;
                chinhSuaThongTinSP.LoaiSP_Textbox.Text = dsSP[DanhSachSPDataGrid.SelectedIndex].LoaiSanPham.TenLoaiSanPham;
                chinhSuaThongTinSP.GiaGoc_Textbox.Text = dsSP[DanhSachSPDataGrid.SelectedIndex].GiaGoc.ToString();
                chinhSuaThongTinSP.GiaBan_TextBox.Text = dsSP[DanhSachSPDataGrid.SelectedIndex].GiaBan.ToString();
                chinhSuaThongTinSP.Soluong_Textbox.Text = dsSP[DanhSachSPDataGrid.SelectedIndex].SoLuongConLai.ToString();
                if (dsSP[DanhSachSPDataGrid.SelectedIndex].HinhAnh != null)
                {
                    chinhSuaThongTinSP.HinhAnh_Image.Source = new BitmapImage(new Uri(dsSP[DanhSachSPDataGrid.SelectedIndex].HinhAnh, UriKind.Relative));
                }
                chinhSuaThongTinSP.ShowDialog();
                DanhSachSPDataGrid_Loaded(null, null);
                LoaiSP_ComboBox_Loaded(null, null);
                Gia_ComboBox_Loaded(null, null);
            }
        }

        private void LoaiSP_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var db = new QuanLyCuaHangEntities();
            if (LoaiSP_ComboBox.SelectedIndex != 0)
            {
                db.LoaiSanPhams.ToList();

                dsSP = db.SanPhams.Where(s => s.LoaiSanPham.TenLoaiSanPham.Contains(LoaiSP_ComboBox.SelectedItem.ToString())).ToList();

            }
            else
            {
                DanhSachSPDataGrid_Loaded(null, null);
            }
            DanhSachSPDataGrid.ItemsSource = dsSP;
        }

        private void Gia_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dsSpTk = new List<SanPham>();
            if (Gia_ComboBox.SelectedIndex != 0)
            {

                dsSP.Sort(new SpGiaComparer());
                if (Gia_ComboBox.SelectedIndex == 1)
                {
                    for (int i = 0; i < dsSP.Count(); i++)
                    {
                        if (dsSP[i].GiaBan <= 1000000)
                        {
                            dsSpTk.Add(dsSP[i]);

                        }
                    }
                }
                if (Gia_ComboBox.SelectedIndex == 2)
                {
                    for (int i = 0; i < dsSP.Count(); i++)
                    {
                        if (dsSP[i].GiaBan >= 1000000 && dsSP[i].GiaBan <= 3000000)
                        {
                            dsSpTk.Add(dsSP[i]);

                        }
                    }
                }
                if (Gia_ComboBox.SelectedIndex == 3)
                {
                    for (int i = 0; i < dsSP.Count(); i++)
                    {
                        if (dsSP[i].GiaBan >= 3000000)
                        {
                            dsSpTk.Add(dsSP[i]);

                        }
                    }
                }

            }

            if (dsSpTk.Count() > 0)
            {
                DanhSachSPDataGrid.ItemsSource = dsSpTk;
            }
            else
            {
                DanhSachSPDataGrid.ItemsSource = dsSP;
            }
        }


        }
}
