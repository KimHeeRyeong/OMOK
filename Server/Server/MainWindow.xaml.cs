using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WebSocketSharp;
using WebSocketSharp.Net;
using WebSocketSharp.Server;

namespace Server
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        const int PORT = 15555;
        WebSocketServer socketServer;
        public MainWindow()
        {
            InitializeComponent();
            socketServer = new WebSocketServer(PORT);
            socketServer.AddWebSocketService<Echo>("/Echo");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!socketServer.IsListening)
            {
                socketServer.Start();
                btnStart.Content = "Stop Server";
            }
            else
            {
                socketServer.Stop();
                btnStart.Content = "Start Server";
            }
        }
    }
}
