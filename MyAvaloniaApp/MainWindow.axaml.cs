using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using AvaloniaApp;

namespace MyAvaloniaApp;

public partial class MainWindow : Window
{
    private void Button1_OnClick(object? sender, RoutedEventArgs e)
    {
        string val1 = TextBox1.Text ?? "";
        string val2 = TextBox2.Text ?? "";
        
        int base1 = int.Parse((ComboBase1.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "10");
        int base2 = int.Parse((ComboBase2.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "10");
        int outBase = int.Parse((ComboBaseOut.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "10");
        
        string operation = (ComboOp.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "+";

        ResultLabel.Text = Logic.Calculate(val1, base1, val2, base2, operation, outBase);
    }
}
