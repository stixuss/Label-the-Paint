using Label_the_Paint.Core;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Xps.Packaging;
using System.Windows.Xps;
using Label = Label_the_Paint.MVVM.Model.Label;

namespace Label_the_Paint.MVVM.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        public Label Label { get; set; }
        public ICommand GenerateLabel { get; set; }
        

        public MainWindowViewModel()
        {
            PaintLabel = null;
            Label = new Label();

            GenerateLabel = new RelayCommand(ExecuteGenerateLabel, CanExecuteGenerateLabel);
        }


        private bool CanExecuteGenerateLabel(object parameter)
        {
            bool condition = Label.Name != "" && 
                             Label.Number != "" && 
                             Label.Date != null && 
                             Label.Date != "";

            if (condition)
                return true;

            return false;
        }


        private void ExecuteGenerateLabel(object parameter)
        {
            FixedDocument doc = CreateFixedDocument();
            string filePath = "Etykiety\\" + Label.Number + "_" + Label.Date + ".xps";

            if (File.Exists(filePath) == true)
            {
                MessageBoxResult mbr = MessageBox.Show("Taki etykieta już istnieje. Czy chcesz zobaczyć podgląd?", "Błąd", MessageBoxButton.YesNo, MessageBoxImage.Error);

                if (mbr == MessageBoxResult.Yes)
                {
                    ShowLabel(filePath);
                }
                else
                {
                    MessageBoxResult mbr2 = MessageBox.Show("Czy chcesz zamienić etykietę farby?", "Ostrzeżenie", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (mbr2 == MessageBoxResult.Yes)
                    {
                        File.Delete(filePath);

                        CreateLabel(filePath, doc);
                        ShowLabel(filePath);
                    }
                }
            }
            else
            {
                CreateLabel(filePath, doc);
                ShowLabel(filePath);
            }

            PaintLabel = _paintLabel;
        }


        private IDocumentPaginatorSource _paintLabel;
        public IDocumentPaginatorSource PaintLabel
        {
            get { return _paintLabel; }
            set { _paintLabel = value; OnPropertyChanged(); }
        }

        public void CreateLabel(string filePath, FixedDocument doc)
        {
            XpsDocument xpsd = new XpsDocument(filePath, FileAccess.ReadWrite);
            XpsDocumentWriter xw = XpsDocument.CreateXpsDocumentWriter(xpsd);
            xw.Write(doc);
            xpsd.Close();
        }

        public void ShowLabel(string filePath)
        {
            XpsDocument xpsDocument = new XpsDocument(filePath, FileAccess.Read);
            _paintLabel = xpsDocument.GetFixedDocumentSequence();

            xpsDocument.Close();
        }

        public FixedDocument CreateFixedDocument()
        {
            FixedDocument doc = new FixedDocument();
            doc.DocumentPaginator.PageSize = new Size(96 * 3, 96 * 2);

            PageContent page = new PageContent();
            FixedPage fixedPage = Label.CreateOneFixedPage(Label);

            ((System.Windows.Markup.IAddChild)page).AddChild(fixedPage);

            doc.Pages.Add(page);
            return doc;
        }
    }
}
