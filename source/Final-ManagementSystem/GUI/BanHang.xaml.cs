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
    /// Interaction logic for BanHang.xaml
    /// </summary>
    public partial class BanHang : Page
    {
        public BanHang()
        {
            InitializeComponent();
        }
        public static List<SanPham> dsSpMua { get; set; }
        
        List<LoaiSanPham> dsLoaiSp = new List<LoaiSanPham>();
        List<SanPham> dsSP = new List<SanPham>();
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SanPham_Bus sanPham_Bus = new SanPham_Bus();
            dsSP = sanPham_Bus.LoadAll();

            SanPhamListView.ItemsSource = dsSP;
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
                SanPhamListView.ItemsSource = dsSpTk;
            }
            else
            {
                SanPhamListView.ItemsSource = dsSP;
            }

        }


        private void Gia_ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var ds = new List<string> { "---", "<1tr", "1tr -> 3tr", " >3tr" };
            Gia_ComboBox.ItemsSource = ds;
        }


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
                Page_Loaded(null, null);
            }
            SanPhamListView.ItemsSource = dsSP;
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
                SanPhamListView.ItemsSource = dsSpTk;
            }
            else
            {
                SanPhamListView.ItemsSource = dsSP;
            }
        }

        private void Plus_Button_Click(object sender, RoutedEventArgs e)
        {
            if (dsSpMua== null)
            {
                dsSpMua = new List<SanPham>();
            }
            if (SanPhamListView.SelectedIndex != -1)
            {
                SanPham sp = (SanPham)SanPhamListView.SelectedItems[0];
                if (dsSpMua.Contains(sp) == false)
                {
                    dsSpMua.Add(sp);
                }
                
            }
            
        }
        
        private void SanPhamListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }

}