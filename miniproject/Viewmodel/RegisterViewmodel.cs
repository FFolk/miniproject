using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using miniproject.Model;

namespace miniproject.Viewmodel;

[QueryProperty("Email", "email")]

public partial class RegisterViewmodel : ObservableObject
{
    public string Email { get; set; } = "";
    [ObservableProperty]
    ObservableCollection<Students> student = new ObservableCollection<Students>();
    [ObservableProperty]
    ObservableCollection<Courses> course = new ObservableCollection<Courses>();

    public RegisterViewmodel()
    {
        LoadDataAsync();
    }
    async Task LoadDataAsync()
    {
        using var c_stream = await FileSystem.OpenAppPackageFileAsync("courses.json");

        using var c_reader = new StreamReader(c_stream);

        var c_contents = await c_reader.ReadToEndAsync();

        List<Courses> courseList = Courses.FromJson(c_contents);


        Course = new ObservableCollection<Courses>(courseList);
    }

    [RelayCommand]
    public async Task Register(String Sid)
    {

    }
}
