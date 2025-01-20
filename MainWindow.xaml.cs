using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Simulator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Player player = null;
        Random random = new Random(); //随机事件
        
        private void Update()   //更新屏幕上的数据
        {
            Days.Text = "Day " + player.Days.ToString();
            Foods.Text = "Foods: " + player.Food.ToString();
        }

        private void InfoUpdate(string s)   //更新文本框的数据
        {
            Info.Text += s;
            Info.ScrollToEnd();
        }

        public MainWindow()
        {
            InitializeComponent();  //窗口初始化

            player = new Player();  //实例化玩家

            Update(); //刷新内容
        }

        private async void NextDay_Click(object sender, RoutedEventArgs e)
        {
            bool type = player.NextDay();   //进入下一天
            if (!type)
            {
                InfoUpdate("\n由于缺乏食物, 你没能看到第二天的太阳...程序10s后关闭");

                //禁用按钮
                NextDay.IsEnabled = false;
                Explore.IsEnabled = false;

                await Task.Delay(10000); //异步关闭窗口
                this.Close();
            }

            Explore.IsEnabled = true;

            Update();
        }

        private void Explore_Click(object sender, RoutedEventArgs e)
        {
            int type = random.Next(1, 100000) % 3; //随机数
            if (type == 0) //没找到
            {
                InfoUpdate("\n你什么也没找到...");
            }
            else if (type == 1) //找到
            {
                int food = random.Next(1, 5); 
                InfoUpdate("\n你找到了" + food + "个食物");
                player.GetFood(food); //同步更改
            }
            else if(type == 2) //战斗
            {
                InfoUpdate("\n进入战斗（未完成）");
            }

            Explore.IsEnabled = false; //一天只能探索一次

            Update();
            return;
        }
    }
}
