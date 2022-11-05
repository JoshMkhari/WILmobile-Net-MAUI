namespace PointOfSale.Pages.Handheld;

[INotifyPropertyChanged]
public partial class OrdersViewModel
{
    [ObservableProperty]
    private ObservableCollection<Order> _orders;

    public OrdersViewModel()
    {
        _orders = new ObservableCollection<Order>(AppData.Orders);
    }
    
    [RelayCommand]
    async Task Pay()
    {
        try
        {
            await Shell.Current.GoToAsync($"{nameof(ScanPage)}");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}