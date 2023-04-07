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

namespace DemoApiCalls.CustomControls
{
    /// <summary>
    /// Interaction logic for IButton.xaml
    /// </summary>
    public partial class IButton : UserControl
    {
        public int ImageHeight
        {
            get { return (int)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }
        public static readonly DependencyProperty ImageHeightProperty =
            DependencyProperty.Register("ImageHeight", typeof(int), typeof(IButton), new PropertyMetadata(75));

        public string LabelContent
        {
            get { return (string)GetValue(LabelContentProperty); }
            set { SetValue(LabelContentProperty, value); }
        }
        public static readonly DependencyProperty LabelContentProperty =
            DependencyProperty.Register("LabelContent", typeof(string), typeof(IButton), new PropertyMetadata(string.Empty));

        public Geometry PathDataValue
        {
            get { return (Geometry)GetValue(PathDataValueProperty); }
            set { SetValue(PathDataValueProperty, value); }
        }

        public static readonly DependencyProperty PathDataValueProperty =
            DependencyProperty.Register("PathDataValue", typeof(Geometry), typeof(IButton));


        public string SVGImageURL
        {
            get { return (string)GetValue(SVGImageURLProperty); }
            set { SetValue(SVGImageURLProperty, value); }
        }
        public static readonly DependencyProperty SVGImageURLProperty =
            DependencyProperty.Register("SVGImageURL", typeof(string), typeof(IButton));


        public string ImageURL
        {
            get { return (string)GetValue(ImageURLProperty); }
            set { SetValue(ImageURLProperty, value); }
        }
        public static readonly DependencyProperty ImageURLProperty =
            DependencyProperty.Register("ImageURL", typeof(string), typeof(IButton));

        public Thickness MarginImage
        {
            get { return (Thickness)GetValue(MarginImageProperty); }
            set { SetValue(MarginImageProperty, value); }
        }
        public static readonly DependencyProperty MarginImageProperty =
            DependencyProperty.Register("MarginImage", typeof(Thickness), typeof(IButton));

        public IButton()
        {
            InitializeComponent();
        }
    }
}
