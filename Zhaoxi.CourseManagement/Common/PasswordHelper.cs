using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Zhaoxi.CourseManagement.Common
{
    public class PasswordHelper
    {
        //PropertyMetaData參數：屬性改變時要觸發的
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordHelper), new FrameworkPropertyMetadata("", new PropertyChangedCallback(OnPropertyChanged)));

        //GetPassword()與SetPassword()是封裝PasswordProperty屬性的方法，可以對PasswordProperty屬性取值和設定
        /// <summary>
        /// 返回依賴屬性的值
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string GetPassword(DependencyObject d)
        {
            return d.GetValue(PasswordProperty).ToString();
        }

        public static void SetPassword(DependencyObject d, string value)
        {
            d.SetValue(PasswordProperty, value);
        }

        public static readonly DependencyProperty AttachProperty = DependencyProperty.RegisterAttached("Attach", typeof(bool), typeof(PasswordHelper), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(OnAttached)));

        public static bool GetAttach(DependencyObject d)
        {
            return (bool)d.GetValue(AttachProperty);
        }

        public static void SetAttach(DependencyObject d, bool value)
        {
            d.SetValue(AttachProperty, value);
        }

        static bool _isUpdating = false;

        /// <summary>
        /// 會通知UI的密碼框進行實際的更改
        /// </summary>
        /// <param name="d">是附加到UI密碼框上面的，所以d就可以取到PasswordBox的值</param>
        /// <param name="e"></param>
        private static void OnPropertyChanged(DependencyObject d,DependencyPropertyChangedEventArgs e)
        {
            PasswordBox password = d as PasswordBox;
            password.PasswordChanged -= Password_PasswordChanged;
            if(!_isUpdating)//如果沒有進行更新的時候
                password.Password = e.NewValue?.ToString();
            password.PasswordChanged += Password_PasswordChanged;
        }

        private static void OnAttached(DependencyObject d,DependencyPropertyChangedEventArgs e)
        {
            PasswordBox password = d as PasswordBox;
            //PasswordChanged是事件
            password.PasswordChanged += Password_PasswordChanged;
        }

        private static void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox password = sender as PasswordBox;
            _isUpdating = true;//更新之前，表示不再更新
            //通過SetPassword()設置到PasswordProperty依賴屬性上面，當PasswordProperty屬性變化時，又會設置到SetAttach()中，然後再設置到OnPropertyChanged()會把NewValue新值設置到PasswordBox控件去
            SetPassword(password, password.Password);
            _isUpdating = false;//更新之後告訴她更新完了
        }
    }
}
