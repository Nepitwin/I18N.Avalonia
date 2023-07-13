using Avalonia;
using Avalonia.Controls;

namespace I18N.Prism.Example.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }
}
