#region License
/*--------------------------------------------------------------------------------
	Copyright (c) 2009-2012 David Wendland

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
	THE SOFTWARE.
--------------------------------------------------------------------------------*/
#endregion License

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace AutomationElementFinder
{
	/// <summary>
	/// Represents an ItemsControl for easy display controls stacked with an title on the left side 
	/// </summary>
	/// <example>
	/// <code lang="XAML">
	/// <![CDATA[
	/// <UserControl x:Class="DW.WPFToolkit.Demo.TitledItemsControlControl"
	/// 			 xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
	/// 			 xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
	/// 			 xmlns:Toolkit="http://schemas.my-libraries.de/wpf/toolkit">
	/// 	<Grid Margin="10">
	/// 		<Toolkit:TitledItemsControl>
	/// 			<Toolkit:TitledItem Title="Server IP:">
	/// 				<TextBox Text="{Binding ServerIp}" />
	/// 			</Toolkit:TitledItem>
	/// 			<Toolkit:TitledItem Title="User Name:">
	/// 				<TextBox Text="{Binding UserName}" />
	/// 			</Toolkit:TitledItem>
	/// 			<Toolkit:TitledItem Title="Password:">
	/// 				<Toolkit:EnhancedPasswordBox Password="{Binding Password}" />
	/// 			</Toolkit:TitledItem>
	/// 		</Toolkit:TitledItemsControl>
	/// 	</Grid>
	/// </UserControl>]]>
	/// </code>
	/// <code lang="cs">
	/// <![CDATA[
	/// using System;
	/// using System.ComponentModel;
	/// using System.Linq.Expressions;
	/// using System.Windows.Controls;
	/// 
	/// namespace DW.WPFToolkit.Demo
	/// {
	/// 	public partial class TitledItemsControlControl : UserControl, INotifyPropertyChanged
	/// 	{
	/// 		public TitledItemsControlControl()
	/// 		{
	/// 			InitializeComponent();
	/// 			DataContext = this;
	/// 		}
	/// 
	/// 		public string ServerIp
	/// 		{
	/// 			get { return _serverIp; }
	/// 			set
	/// 			{
	/// 				_serverIp = value;
	/// 				NotifyPropertyChanged(() => ServerIp);
	/// 			}
	/// 		}
	/// 		private string _serverIp;
	/// 
	/// 		public string UserName
	/// 		{
	/// 			get { return _userName; }
	/// 			set
	/// 			{
	/// 				_userName = value;
	/// 				NotifyPropertyChanged(() => UserName);
	/// 			}
	/// 		}
	/// 		private string _userName;
	/// 
	/// 		public string Password
	/// 		{
	/// 			get { return _password; }
	/// 			set
	/// 			{
	/// 				_password = value;
	/// 				NotifyPropertyChanged(() => Password);
	/// 			}
	/// 		}
	/// 		private string _password;
	/// 
	/// 		#region NotifyPropertyChanged
	/// 		public event PropertyChangedEventHandler PropertyChanged;
	/// 		void NotifyPropertyChanged<T>(Expression<Func<T>> property)
	/// 		{
	/// 			PropertyChangedEventHandler handler = PropertyChanged;
	/// 			if (handler != null)
	/// 			{
	/// 				var memberExpression = property.Body as MemberExpression;
	/// 				handler(this, new PropertyChangedEventArgs(memberExpression.Member.Name));
	/// 			}
	/// 		}
	/// 		#endregion NotifyPropertyChanged
	/// 	}
	/// }]]>
	/// </code>
	/// </example>
	public class TitledItemsControl : ItemsControl
	{
		static TitledItemsControl()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(TitledItemsControl), new FrameworkPropertyMetadata(typeof(TitledItemsControl)));
		}

		/// <summary>
		/// If items will be generated automatically, it uses a TitledItem as the container
		/// </summary>
		/// <returns>The TitledItem as a container for the item</returns>
		protected override DependencyObject GetContainerForItemOverride()
		{
			return new TitledItem();
		}

		/// <summary>
		/// Checks if the current item is a correct container item
		/// </summary>
		/// <param name="item">The item to check</param>
		/// <returns>True if the given item is a correct container</returns>
		protected override bool IsItemItsOwnContainerOverride(object item)
		{
			return item is TitledItem;
		}

		/// <summary>
		/// Gets or sets the VerticalTitleAlignment of all child TitleItems
		/// </summary>
		/// <value>If not set: VerticalAlignment.Center</value>
		[Category("Common Properties")]
		[Description("Gets or sets the VerticalTitleAlignment of all child TitleItems")]
		[DefaultValue(VerticalAlignment.Center)]
		public VerticalAlignment VerticalTitleAlignments
		{
			get { return (VerticalAlignment)GetValue(VerticalTitleAlignmentsProperty); }
			set { SetValue(VerticalTitleAlignmentsProperty, value); }
		}

		/// <summary>
		/// Identifies the VerticalTitleAlignments dependency property
		/// </summary>
		public static readonly DependencyProperty VerticalTitleAlignmentsProperty =
			DependencyProperty.Register("VerticalTitleAlignments", typeof(VerticalAlignment), typeof(TitledItemsControl), new UIPropertyMetadata(VerticalAlignment.Center));

		/// <summary>
		/// Gets or sets the HorizontalTitleAlignment of all child TitleItems
		/// </summary>
		/// <value>If not set: HorizontalAlignment.Right</value>
		[Category("Common Properties")]
		[Description("Gets or sets the HorizontalTitleAlignment of all child TitleItems")]
		[DefaultValue(HorizontalAlignment.Right)]
		public HorizontalAlignment HorizontalTitleAlignments
		{
			get { return (HorizontalAlignment)GetValue(HorizontalTitleAlignmentsProperty); }
			set { SetValue(HorizontalTitleAlignmentsProperty, value); }
		}

		/// <summary>
		/// Identifies the HorizontalTitleAlignments dependency property
		/// </summary>
		public static readonly DependencyProperty HorizontalTitleAlignmentsProperty =
			DependencyProperty.Register("HorizontalTitleAlignments", typeof(HorizontalAlignment), typeof(TitledItemsControl), new UIPropertyMetadata(HorizontalAlignment.Right));

		/// <summary>
		/// Gets or sets the TitleMargin of all child TitleItems
		/// </summary>
		/// <value>If not set: new Thickness(5, 0, 5, 0)</value>
		[Category("Common Properties")]
		[Description("Gets or sets the TitleMargin of all child TitleItems")]
		public Thickness TitleMargins
		{
			get { return (Thickness)GetValue(TitleMarginsProperty); }
			set { SetValue(TitleMarginsProperty, value); }
		}

		/// <summary>
		/// Initializes a new instance of the TitleMargins class
		/// </summary>
		public static readonly DependencyProperty TitleMarginsProperty =
			DependencyProperty.Register("TitleMargins", typeof(Thickness), typeof(TitledItemsControl), new UIPropertyMetadata(new Thickness(5, 0, 5, 0)));

		/// <summary>
		/// Gets or sets the HorizontalContentAlignment of all child TitleItems
		/// </summary>
		/// <value>If not set: HorizontalAlignment.Stretch</value>
		[Category("Common Properties")]
		[Description("Gets or sets the HorizontalContentAlignment of all child TitleItems")]
		[DefaultValue(HorizontalAlignment.Stretch)]
		public HorizontalAlignment HorizontalContentAlignments
		{
			get { return (HorizontalAlignment)GetValue(HorizontalContentAlignmentsProperty); }
			set { SetValue(HorizontalContentAlignmentsProperty, value); }
		}

		/// <summary>
		/// Identifies the HorizontalContentAlignments dependency property
		/// </summary>
		public static readonly DependencyProperty HorizontalContentAlignmentsProperty =
			DependencyProperty.Register("HorizontalContentAlignments", typeof(HorizontalAlignment), typeof(TitledItemsControl), new UIPropertyMetadata(HorizontalAlignment.Stretch));

		/// <summary>
		/// Gets or sets the VerticalContentAlignment of all child TitleItems
		/// </summary>
		/// <value>If not set: VerticalAlignment.Center</value>
		[Category("Common Properties")]
		[Description("Gets or sets the VerticalContentAlignment of all child TitleItems")]
		[DefaultValue(VerticalAlignment.Center)]
		public VerticalAlignment VerticalContentAlignments
		{
			get { return (VerticalAlignment)GetValue(VerticalContentAlignmentsProperty); }
			set { SetValue(VerticalContentAlignmentsProperty, value); }
		}

		/// <summary>
		/// Identifies the VerticalContentAlignments dependency property
		/// </summary>
		public static readonly DependencyProperty VerticalContentAlignmentsProperty =
			DependencyProperty.Register("VerticalContentAlignments", typeof(VerticalAlignment), typeof(TitledItemsControl), new UIPropertyMetadata(VerticalAlignment.Center));

		/// <summary>
		/// Gets or sets the ContentMargin of all child TitleItems
		/// </summary>
		/// <value>If not set: new Thickness(0, 2, 0, 2)</value>
		[Category("Common Properties")]
		[Description("Gets or sets the ContentMargin of all child TitleItems")]
		public Thickness ContentMargins
		{
			get { return (Thickness)GetValue(ContentMarginsProperty); }
			set { SetValue(ContentMarginsProperty, value); }
		}

		/// <summary>
		/// Identifies the ContentMargins dependency property
		/// </summary>
		public static readonly DependencyProperty ContentMarginsProperty =
			DependencyProperty.Register("ContentMargins", typeof(Thickness), typeof(TitledItemsControl), new UIPropertyMetadata(new Thickness(0, 2, 0, 2)));
	}
}
