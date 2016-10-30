using System;
using System.Collections.ObjectModel;
using System.Drawing;
using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using MvxTicTacToe.Core.Models;
using MvxTicTacToe.Core.ViewModels;
using UIKit;

namespace MvxTicTacToe.iOS
{
	public class MainView : MvxTableViewController
	{
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			Title = "Tic Tac Toe";

			var flowLayout = new UICollectionViewFlowLayout
			{
				SectionInset = new UIEdgeInsets
				{
					Top = 0,
					Left = 15,
					Right = 15,
					Bottom = 0
				}
			};

			var collectionView = new UICollectionView(View.Frame, flowLayout)
			{
				BackgroundColor = UIColor.White,
				LayoutMargins = new UIEdgeInsets(0, 15, 0, 15)
			};

			View.Add(collectionView);

			var source = new GridViewSource(collectionView);
			collectionView.Source = source;
			collectionView.Delegate = new GridDelegateFlowLayout(source);

			var bindingSet = this.CreateBindingSet<MainView, MainViewModel>();

			bindingSet.Bind(source).To(vm => vm.Marks);
			bindingSet.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.MarkGridCommand);
			bindingSet.Apply();

			collectionView.ReloadData();
		}

		public class GridViewSource : MvxCollectionViewSource
		{
			public GridViewSource(UICollectionView collectionView)
				: base(collectionView, new NSString("GridViewCell"))
			{
				CollectionView.RegisterClassForCell(typeof(GridViewCell), DefaultCellIdentifier);
				ReloadOnAllItemsSourceSets = true;
			}

			public ObservableCollection<Item> Categorias => ItemsSource as ObservableCollection<Item>;

			protected override UICollectionViewCell GetOrCreateCellFor(UICollectionView collectionView, NSIndexPath indexPath, object item)
				=> collectionView.DequeueReusableCell(DefaultCellIdentifier, indexPath) as UICollectionViewCell;

			public sealed class GridViewCell : MvxCollectionViewCell
			{
				private readonly UILabel _label;

				[Export("initWithFrame:")]
				public GridViewCell(RectangleF frame)
					: base(frame)
				{
					this.CreateBindingContext("Text Mark; TextColor MarkColor(Mark)");

					_label = new UILabel 
					{
						Frame = new CGRect(0, 0, 100, 100),
						TextAlignment = UITextAlignment.Center,
						Font = UIFont.SystemFontOfSize(56),
						Lines = 1,
						LineBreakMode = UILineBreakMode.WordWrap
					};

					ContentView.BackgroundColor = UIColor.FromRGB(245, 245, 245);
					ContentView.AddSubview(_label);
				}

				public string Text
				{
					get
					{
						return _label.Text;
					}
					set
					{
						_label.Text = value;
					}
				}

				public UIColor TextColor
				{
					get
					{
						return _label.TextColor;
					}
					set
					{
						_label.TextColor = value;
					}
				}
			}
		}

		public class GridDelegateFlowLayout : UICollectionViewDelegateFlowLayout
		{

			private readonly GridViewSource _gridViewSource;

			public GridDelegateFlowLayout(GridViewSource gridViewSource)
			{
				_gridViewSource = gridViewSource;
			}

			#region Public Methods and Operators

			public override nfloat GetMinimumInteritemSpacingForSection(UICollectionView collectionView, UICollectionViewLayout layout, nint section)
				=> 15;

			public override nfloat GetMinimumLineSpacingForSection(UICollectionView collectionView, UICollectionViewLayout layout, nint section)
				=> 15;
		
			public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
				=> _gridViewSource.ItemSelected(collectionView, indexPath);

			public override CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
			{
				var size = (collectionView.Bounds.Size.Width - (60)) / 3;

				return new CGSize(size, size);
			}
			#endregion
		}
	}
}

