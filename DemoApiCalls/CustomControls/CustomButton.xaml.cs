using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DemoApiCalls.CustomControls
{
    /// <summary>
    /// Interaction logic for CustomButton.xaml
    /// </summary>
    public partial class CustomButton : Button
    {
        #region Properties

        public Brush ForegroundOnNotEnabled
        {
            get { return (Brush)GetValue(ForegroundOnNotEnabledProperty); }
            set { SetValue(ForegroundOnNotEnabledProperty, value); }
        }
        public static readonly DependencyProperty ForegroundOnNotEnabledProperty =
            DependencyProperty.Register("ForegroundOnNotEnabled", typeof(Brush), typeof(CustomButton), new PropertyMetadata(Brushes.White));


        public int ImageHeight
        {
            get { return (int)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }
        public static readonly DependencyProperty ImageHeightProperty =
            DependencyProperty.Register("ImageHeight", typeof(int), typeof(CustomButton), new PropertyMetadata(75));


        public string LabelContent
        {
            get { return (string)GetValue(LabelContentProperty); }
            set { SetValue(LabelContentProperty, value); }
        }
        public static readonly DependencyProperty LabelContentProperty =
            DependencyProperty.Register("LabelContent", typeof(string), typeof(CustomButton), new PropertyMetadata(string.Empty));


        public int CornerRadius
        {
            get { return (int)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(int), typeof(CustomButton));


        public Geometry PathDataValue
        {
            get { return (Geometry)GetValue(PathDataValueProperty); }
            set { SetValue(PathDataValueProperty, value); }
        }
        public static readonly DependencyProperty PathDataValueProperty =
            DependencyProperty.Register("PathDataValue", typeof(Geometry), typeof(CustomButton));


        public string SVGImageURL
        {
            get { return (string)GetValue(SVGImageURLProperty); }
            set { SetValue(SVGImageURLProperty, value); }
        }
        public static readonly DependencyProperty SVGImageURLProperty =
            DependencyProperty.Register("SVGImageURL", typeof(string), typeof(CustomButton));


        public string ImageURL
        {
            get { return (string)GetValue(ImageURLProperty); }
            set { SetValue(ImageURLProperty, value); }
        }
        public static readonly DependencyProperty ImageURLProperty =
            DependencyProperty.Register("ImageURL", typeof(string), typeof(CustomButton));


        public Thickness MarginImage
        {
            get { return (Thickness)GetValue(MarginImageProperty); }
            set { SetValue(MarginImageProperty, value); }
        }
        public static readonly DependencyProperty MarginImageProperty =
            DependencyProperty.Register("MarginImage", typeof(Thickness), typeof(CustomButton), new PropertyMetadata(new Thickness(5)));


        public Thickness ImagePadding
        {
            get { return (Thickness)GetValue(ImagePaddingProperty); }
            set { SetValue(ImagePaddingProperty, value); }
        }
        public static readonly DependencyProperty ImagePaddingProperty =
            DependencyProperty.Register("ImagePadding", typeof(Thickness), typeof(CustomButton));


        //public Grid CanvasContent
        //{
        //    get { return (Grid)GetValue(CanvasContentProperty); }
        //    set { SetValue(CanvasContentProperty, value); }
        //}
        //public static readonly DependencyProperty CanvasContentProperty =
        //    DependencyProperty.Register("CanvasContent", typeof(Grid), typeof(CustomButton));

        #endregion
        public CustomButton()
        {
            InitializeComponent();
        }

        private void Button_Loaded(object sender, RoutedEventArgs e)
        {
            //
        }
    }
}
