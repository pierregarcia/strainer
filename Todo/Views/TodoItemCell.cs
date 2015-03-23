using System;
using Xamarin.Forms;

namespace Todo
{
	public class TodoItemCell : ViewCell
	{
		public TodoItemCell ()
		{
			var label = new Label {
				YAlign = TextAlignment.Center,
                TextColor = Color.White
			};
			label.SetBinding (Label.TextProperty, "Name");

            var btnColor = new Button {
                BackgroundColor = Colors.Background,
                BorderRadius = 5,
                WidthRequest = 20,
                HeightRequest = 20,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
			};
            btnColor.SetBinding(StackLayout.BackgroundColorProperty, "BaseAlcoolColor", BindingMode.Default, new HexToColor());
           
           // tick.SetBinding (Image.IsVisibleProperty, "Done");

            var arrow = new Image {
                Source = FileImageSource.FromFile ("right_arrow.png"),
                HorizontalOptions = LayoutOptions.EndAndExpand
            };

			var horizontalLayout = new StackLayout {
				Padding = new Thickness(10, 0, 10, 0),
				Orientation = StackOrientation.Horizontal,
                BackgroundColor = Colors.Background,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = {btnColor, label , arrow}
			};

            var separator = new BoxView {
                BackgroundColor = Colors.Yellow,
                HeightRequest = 1
            };

            var verticalLayout = new StackLayout{
                Spacing = 0,
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = {horizontalLayout, separator}
            };

            View = verticalLayout;

            var deleteAction = new MenuItem { Text = "Delete", IsDestructive = true }; // red background
            deleteAction.SetBinding (MenuItem.CommandParameterProperty, new Binding ("."));
            deleteAction.Clicked += (sender, e) => {
                var mi = ((MenuItem)sender);
                var todoItem = (TodoItem)mi.BindingContext;
                App.Database.DeleteItem(todoItem.ID);
                ((ListView)ParentView).ItemsSource = App.Database.GetItems ();
            };
            ContextActions.Add (deleteAction);
		}
        public class HexToColor : IValueConverter
        {

            #region IValueConverter implementation

            public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                var color = value as string;
                if (color != null)
                {
                    return Color.FromHex(color);
                }
                return Color.FromRgb(34, 49, 62);
            }

            public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException ();
            }

            #endregion
        }

		protected override void OnBindingContextChanged ()
		{
			// Fixme : this is happening because the View.Parent is getting 
			// set after the Cell gets the binding context set on it. Then it is inheriting
			// the parents binding context.
			View.BindingContext = BindingContext;
			base.OnBindingContextChanged ();
		}

       
	}
}

