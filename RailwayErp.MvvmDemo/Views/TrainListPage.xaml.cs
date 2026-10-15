using System.Diagnostics;
using RailwayErp.MvvmDemo.ViewModels;

namespace RailwayErp.MvvmDemo.Views;

public partial class TrainListPage : ContentPage
{
    private readonly TrainListViewModel _viewModel;

    // ViewModel підставляє DI-контейнер
    public TrainListPage(TrainListViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Debug.WriteLine("[TrainListPage] OnAppearing");
        _viewModel.LoadCommand.Execute(null);
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        Debug.WriteLine("[TrainListPage] OnDisappearing (перехід з екрана)");
    }
}