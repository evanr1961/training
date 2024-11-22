﻿using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BeeHiveMgmt;


/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    Queen? queen;

    private DispatcherTimer timer = new DispatcherTimer();
    public MainWindow()
    {
        InitializeComponent();


        queen = Resources["queen"] as Queen;
        //statusReport.Text = queen.StatusReport;
        timer.Tick += Timer_Tick;
        timer.Interval = TimeSpan.FromSeconds(1.5);
        timer.Start();

    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        WorkShift_Click(this, new RoutedEventArgs());
    }

    private void WorkShift_Click(object sender, RoutedEventArgs e)
    {
        queen.WorkTheNextShift();

        //statusReport.Text = queen.StatusReport;
    }

    private void AssignJob_Click(object sender, RoutedEventArgs e)
    {
        string jobName = jobSelector.Text;
        queen.AssignBee(jobName);

        //statusReport.Text = queen.StatusReport;
    }
}