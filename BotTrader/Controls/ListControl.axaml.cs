using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using BotTrader.ViewModel;

namespace BotTrader;

public partial class ListControl : UserControl
{
    public ListControl()
    {
        InitializeComponent();

        DataContext = new ListControlViewModel();

        listBox.PropertyChanged += ListBox_PropertyChanged;
    }

    private void ListBox_PropertyChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
    {
        listBox.ScrollIntoView(listBox.ItemCount-1);
    }
}