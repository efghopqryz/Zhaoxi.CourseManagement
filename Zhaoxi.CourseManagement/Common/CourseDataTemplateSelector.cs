using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Zhaoxi.CourseManagement.Model;

namespace Zhaoxi.CourseManagement.Common
{
    public class CourseDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultTemplate { get; set; }
        public DataTemplate SkeletonTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if ((item as CourseModel).IsShowSkeleton)
            {
                return SkeletonTemplate;
            }
            return DefaultTemplate;
        }
    }
}
