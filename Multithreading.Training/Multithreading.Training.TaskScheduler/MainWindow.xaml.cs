
namespace Multithreading.Training.TaskScheduler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly System.Threading.Tasks.TaskScheduler taskScheduler;
        CancellationTokenSource cts;

        public MainWindow()
        {
            InitializeComponent();
            this.taskScheduler = System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (this.cts != null)
            {
                this.cts.Cancel();
                this.cts = null;
            }
            else
            {
                Log.Content = "OPERATION IS RUNNING" + Environment.NewLine;
                this.cts = new CancellationTokenSource();

                var task = Task<string>.Run(() => RunTask(cts.Token) ,this.cts.Token);

                task.ContinueWith(_ => Log.Content += _.Result, CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, this.taskScheduler);
            }
        }

        string RunTask(CancellationToken token)
        {
            var resultBuilder = new StringBuilder();

            while (true)
            {
                resultBuilder.AppendFormat("data: {0}" + Environment.NewLine, Guid.NewGuid());
                Thread.Sleep(200);

                if(token.IsCancellationRequested) break;
            }

            return resultBuilder.ToString();
        }
    }
}
