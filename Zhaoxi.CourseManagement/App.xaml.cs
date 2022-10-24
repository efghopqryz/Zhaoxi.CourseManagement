using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Zhaoxi.CourseManagement.View;

namespace Zhaoxi.CourseManagement
{
    /// <summary>
    /// App.xaml 的互動邏輯
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //1.登入窗口關閉之後
            if (new LoginView().ShowDialog() == true)
            {
                //2.然後打開一個主窗口，竊用ShowDialog()的方式，把線程卡在這地方，當主窗口關閉之後
                new MainView().ShowDialog();
            }
            //3.然後就會馬上調用這句Application.Current.Shutdown()，整個應用就退出了。
            //在App.xaml中這句語法ShutdownMode="OnExplicitShutdown，表示所有窗體關閉也不會退出，只有調用Application.Current.Shutdown()才會退出。"
            Application.Current.Shutdown();
        }
    }
}
