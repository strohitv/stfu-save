using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace STFU.Executable.AutoUploader.WPF.Controls
{
    /// <summary>
    /// Interaction logic for FastColoredTextBox.xaml
    /// </summary>
    public partial class FastColoredTextBox : UserControl
    {
        public FastColoredTextBox()
        {
            InitializeComponent();
            Instance.BackColor = Color.White;
            Instance.BookmarkColor = Color.PowderBlue;
            Instance.CaretColor = Color.Black;
            Instance.ChangedLineColor = Color.Transparent;
            Instance.CurrentLineColor = Color.LightGray;
            Instance.DisabledColor = Color.FromArgb(100, 180, 180, 180);
            Instance.FoldingIndicatorColor = Color.Green;
            Instance.Font = new Font("Consolas", 12);
            Instance.ForeColor = Color.Black;
            Instance.IndentBackColor = Color.WhiteSmoke;
            Instance.LineNumberColor = Color.Teal;
            Instance.PaddingBackColor = Color.Transparent;
            Instance.SelectionColor = Color.FromArgb(60, 0, 0, 255);
            Instance.ServiceColors = new ServiceColors()
            {
                CollapseMarkerBackColor = Color.White,
                CollapseMarkerBorderColor = Color.Silver,
                CollapseMarkerForeColor = Color.Silver,
                ExpandMarkerBackColor = Color.White,
                ExpandMarkerBorderColor = Color.Silver,
                ExpandMarkerForeColor = Color.Red
            };
            Instance.ServiceLinesColor = Color.Silver;
            Instance.TextAreaBorderColor = Color.Black;
            Instance.WordWrapIndent = 6;
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(FastColoredTextBox), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, TextPropertyChanged));

        private static void TextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FastColoredTextBox box = d as FastColoredTextBox;
            box.Instance.Text = e.NewValue as string;
        }

        private void Instance_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            FastColoredTextBoxNS.FastColoredTextBox box = sender as FastColoredTextBoxNS.FastColoredTextBox;
            SetCurrentValue(TextProperty, box.Text);
            var x = GetBindingExpression(TextProperty);
            x?.UpdateSource();
        }
    }
}
