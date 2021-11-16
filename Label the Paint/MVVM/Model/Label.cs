using Label_the_Paint.Core;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;


namespace Label_the_Paint.MVVM.Model
{
    public class Label : ObservableObject
    {

        public Label()
        {
            
        }

        private string _name = "";
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _number = "";
        public string Number
        {
            get
            {
                return _number;
            }

            set
            {
                _number = value;
                OnPropertyChanged();
            }
        }

        private string _catalog = "";
        public string Catalog
        {
            get
            {
                return _catalog;
            }

            set
            {
                _catalog = value;
                OnPropertyChanged();
            }
        }

        private string _date = null;
        public string Date
        {
            get
            {
                return _date;
            }

            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        private string _code = "";
        public string Code
        {
            get
            {
                return _code;
            }

            set
            {
                _code = value;
                OnPropertyChanged();
            }
        }

        #region CREATE A LABEL PAGE
        public FixedPage CreateOneFixedPage(Label label)
        {
            FixedPage fixedPage = PageLayout();

            fixedPage.Children.Add((UIElement)NameLine(label));
            fixedPage.Children.Add((UIElement)QuantityLine());
            fixedPage.Children.Add((UIElement)OrderLine());
            fixedPage.Children.Add((UIElement)NumberLine());
            fixedPage.Children.Add((UIElement)BarcodeLine(label));
            fixedPage.Children.Add((UIElement)TextLine("KATALOG", 1.25, 1));
            fixedPage.Children.Add((UIElement)CatalogLine(label));
            fixedPage.Children.Add((UIElement)TextLine("DATA PRZYDATNOŚCI", 1.25, 1.3));
            fixedPage.Children.Add((UIElement)DateLine(label));
            fixedPage.Children.Add((UIElement)TextLine("KOD FARBY", 1.25, 1.6));
            fixedPage.Children.Add((UIElement)CodeLine(label));

            fixedPage.UpdateLayout();
            return fixedPage;
        }

        private FixedPage PageLayout()
        {
            FixedPage page = new FixedPage
            {
                Background = Brushes.White,
                Width = 96 * 3,
                Height = 96 * 2
            };

            Size sz = new Size(96 * 3.0, 96 * 2.0);
            page.Measure(sz);
            page.Arrange(new Rect(new Point(), sz));

            return page;
        }

        private TextBlock NameLine(Label label)
        {
            TextBlock tb = new TextBlock();
            tb.Inlines.Add(new Run(label.Name) { FontWeight = FontWeights.Bold });
            tb.FontSize = 20;
            tb.FontFamily = new FontFamily("Calibri");
            tb.LayoutTransform = new RotateTransform(-90);

            FixedPage.SetLeft(tb, 96 * 0.10);
            FixedPage.SetTop(tb, 96 * 0.3);


            return tb;
        }

        private TextBlock QuantityLine()
        {
            TextBlock tb = new TextBlock();
            tb.Inlines.Add(new Run("Ilość ................................."));
            tb.FontSize = 14;
            tb.FontFamily = new FontFamily("Calibri");
            tb.LayoutTransform = new RotateTransform(-90);

            FixedPage.SetLeft(tb, 96 * 0.45);
            FixedPage.SetTop(tb, 96 * 0.2);

            return tb;
        }

        private TextBlock OrderLine()
        {
            TextBlock tb = new TextBlock();
            tb.Inlines.Add(new Run("Zamówienie ..........................."));
            tb.FontSize = 14;
            tb.FontFamily = new FontFamily("Calibri");
            tb.LayoutTransform = new RotateTransform(-90);

            FixedPage.SetLeft(tb, 96 * 0.7);
            FixedPage.SetTop(tb, 96 * 0.15);

            return tb;
        }

        private TextBlock NumberLine()
        {
            TextBlock tb = new TextBlock();
            tb.Inlines.Add(new Run("NUMER INWENTARZOWY"));
            tb.FontSize = 10;
            tb.FontFamily = new FontFamily("Calibri");

            FixedPage.SetLeft(tb, 96 * 1.5);
            FixedPage.SetTop(tb, 96 * 0.1);

            return tb;
        }

        private TextBlock BarcodeLine(Label label)
        {
            TextBlock tb = new TextBlock();
            tb.Inlines.Add(new Run(label.Number));
            tb.FontSize = 65;
            tb.FontWeight = FontWeights.Medium;
            tb.FontFamily = new FontFamily(AppDomain.CurrentDomain.BaseDirectory + @"\Font\#Libre Barcode 128 Text");

            FixedPage.SetLeft(tb, 96 * 1.25);
            FixedPage.SetTop(tb, 96 * 0.25);

            return tb;
        }

        private TextBlock TextLine(string text, double lenght, double height)
        {
            TextBlock tb = new TextBlock();
            tb.Inlines.Add(new Run(text));
            tb.FontSize = 10;
            tb.FontWeight = FontWeights.Medium;
            tb.FontFamily = new FontFamily("Calibri");

            FixedPage.SetLeft(tb, 96 * lenght);
            FixedPage.SetTop(tb, 96 * height);

            return tb;
        }

        private TextBlock CatalogLine(Label label)
        {
            TextBlock tb = new TextBlock();
            tb.Inlines.Add(new Run(label.Catalog) { FontWeight = FontWeights.Bold });
            tb.FontSize = 14;
            tb.TextAlignment = TextAlignment.Right;
            tb.FontFamily = new FontFamily("Calibri");

            FixedPage.SetLeft(tb, 96 * 1.25);
            FixedPage.SetTop(tb, 96 * 1.1);

            return tb;
        }

        private TextBlock DateLine(Label label)
        {
            TextBlock tb = new TextBlock();
            tb.Inlines.Add(new Run(label.Date) { FontWeight = FontWeights.Bold });
            tb.FontSize = 14;
            tb.TextAlignment = TextAlignment.Left;
            tb.FontFamily = new FontFamily("Calibri");

            FixedPage.SetLeft(tb, 96* 1.25);
            FixedPage.SetTop(tb, 96 * 1.4);

            return tb;
        }

        private TextBlock CodeLine(Label label)
        {
            TextBlock tb = new TextBlock();
            tb.Inlines.Add(new Run(label.Code) { FontWeight = FontWeights.Bold });
            tb.FontSize = 14;
            tb.TextAlignment = TextAlignment.Center;
            tb.FontFamily = new FontFamily("Calibri");

            FixedPage.SetLeft(tb, 96 * 1.25);
            FixedPage.SetTop(tb, 96 * 1.7);
            

            return tb;
        }
        #endregion
    }
}
