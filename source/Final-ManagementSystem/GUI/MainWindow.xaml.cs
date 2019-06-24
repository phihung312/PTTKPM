
using Fluent;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnList_Click(object sender, RoutedEventArgs e)
        {
            var screens = new ObservableCollection<TabItem>()
            {
                new TabItem() {
                    Content = new Frame() {
                        Content = new BanHang()
                    },
                },
                 new TabItem() {
                    Content = new Frame() {
                        Content = new DanhSachSanPham()
                    },
                },
                 new TabItem() {
                    Content = new Frame() {
                        Content = new QuanLyDonHang()
                    },
                }
             };
            tabs.ItemsSource = screens;
            tabs.SelectedIndex = 1;
        }

        private void RibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var screens = new ObservableCollection<TabItem>()
            {
                new TabItem() {
                    Content = new Frame() {
                        Content = new BanHang()
                    },
                },
                 new TabItem() {
                    Content = new Frame() {
                        Content = new DanhSachSanPham()
                    },
                }
             };
            tabs.ItemsSource = screens;
            tabs.SelectedIndex = 0;
          
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ThemSanPham themSanPham = new ThemSanPham();
            themSanPham.ShowDialog();
            tabs.SelectedIndex = 1;
            btnList_Click(null,null);

        }

        private void Cart_Button_Click(object sender, RoutedEventArgs e)
        {
            var screens = new ObservableCollection<TabItem>()
            {
                new TabItem() {
                    Content = new Frame() {
                        Content = new GioHang()
                    },
                },
            };
            tabs.ItemsSource = screens;
            tabs.SelectedIndex = 0;
            btnList1.Visibility = Visibility;
            Cart_Button.Visibility = Visibility.Hidden;
        }

        private void btnList1_Click(object sender, RoutedEventArgs e)
        {
            var screens = new ObservableCollection<TabItem>()
            {
                new TabItem() {
                    Content = new Frame() {
                        Content = new BanHang()
                    },
                },
            };
            tabs.ItemsSource = screens;
            tabs.SelectedIndex = 0;
          
            Cart_Button.Visibility = Visibility;
        }

        private void ThongKeTheoSanPham_Click(object sender, RoutedEventArgs e)
        {
            var screens = new ObservableCollection<TabItem>()
            {
                new TabItem() {
                    Content = new Frame() {
                        Content = new QuanLyDonHang()
                    },
                },
            };
            tabs.ItemsSource = screens;
            tabs.SelectedIndex = 2;
        }

       

        private void btnThemMaKMB_Click(object sender, RoutedEventArgs e)
        {

            ThemKhuyenMai themKhuyenMai = new ThemKhuyenMai();
            themKhuyenMai.ShowDialog();
            tabs.SelectedIndex = 1;
            btnList_Click(null, null);
        }
    }
}
