#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2015 David Wendland

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE
*/
#endregion License

using System.Windows;
using System.Windows.Controls;

namespace ElementFinder.Controls
{
    public class TitledItemsControl : ItemsControl
    {
        static TitledItemsControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TitledItemsControl), new FrameworkPropertyMetadata(typeof(TitledItemsControl)));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new TitledItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is TitledItem;
        }

        public VerticalAlignment VerticalTitleAlignments
        {
            get { return (VerticalAlignment)GetValue(VerticalTitleAlignmentsProperty); }
            set { SetValue(VerticalTitleAlignmentsProperty, value); }
        }

        public static readonly DependencyProperty VerticalTitleAlignmentsProperty =
            DependencyProperty.Register("VerticalTitleAlignments", typeof(VerticalAlignment), typeof(TitledItemsControl), new UIPropertyMetadata(VerticalAlignment.Center));

        public HorizontalAlignment HorizontalTitleAlignments
        {
            get { return (HorizontalAlignment)GetValue(HorizontalTitleAlignmentsProperty); }
            set { SetValue(HorizontalTitleAlignmentsProperty, value); }
        }

        public static readonly DependencyProperty HorizontalTitleAlignmentsProperty =
            DependencyProperty.Register("HorizontalTitleAlignments", typeof(HorizontalAlignment), typeof(TitledItemsControl), new UIPropertyMetadata(HorizontalAlignment.Left));

        public Thickness TitleMargins
        {
            get { return (Thickness)GetValue(TitleMarginsProperty); }
            set { SetValue(TitleMarginsProperty, value); }
        }

        public static readonly DependencyProperty TitleMarginsProperty =
            DependencyProperty.Register("TitleMargins", typeof(Thickness), typeof(TitledItemsControl), new UIPropertyMetadata(new Thickness(5, 0, 5, 0)));

        public HorizontalAlignment HorizontalContentAlignments
        {
            get { return (HorizontalAlignment)GetValue(HorizontalContentAlignmentsProperty); }
            set { SetValue(HorizontalContentAlignmentsProperty, value); }
        }

        public static readonly DependencyProperty HorizontalContentAlignmentsProperty =
            DependencyProperty.Register("HorizontalContentAlignments", typeof(HorizontalAlignment), typeof(TitledItemsControl), new UIPropertyMetadata(HorizontalAlignment.Stretch));

        public VerticalAlignment VerticalContentAlignments
        {
            get { return (VerticalAlignment)GetValue(VerticalContentAlignmentsProperty); }
            set { SetValue(VerticalContentAlignmentsProperty, value); }
        }

        public static readonly DependencyProperty VerticalContentAlignmentsProperty =
            DependencyProperty.Register("VerticalContentAlignments", typeof(VerticalAlignment), typeof(TitledItemsControl), new UIPropertyMetadata(VerticalAlignment.Center));

        public Thickness ContentMargins
        {
            get { return (Thickness)GetValue(ContentMarginsProperty); }
            set { SetValue(ContentMarginsProperty, value); }
        }

        public static readonly DependencyProperty ContentMarginsProperty =
            DependencyProperty.Register("ContentMargins", typeof(Thickness), typeof(TitledItemsControl), new UIPropertyMetadata(new Thickness(0, 2, 0, 2)));
    }
}
