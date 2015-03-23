using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;
using Todo;

namespace Todo
{
	public class TodoItemPage : ContentPage
	{
		public TodoItemPage ()
		{
            NavigationPage.SetHasNavigationBar (this, true);
            this.SetBinding (ContentPage.TitleProperty, "Name");
           
			var nameLabel = new Label { Text = "Name" };
			var nameEntry = new Entry ();
            nameEntry.SetBinding (Entry.TextProperty, "Name");

            var labelAlcool = new Label { Text = "Base Alcool" };

            var pickerAlcool = new Picker
                {
                    Title = "Select",
                    VerticalOptions = LayoutOptions.CenterAndExpand
                };
            pickerAlcool.SetBinding (Picker.SelectedIndexProperty, "BaseAlcoolIndex");

            foreach (string alcool in Constants.AlcoolColors.Keys)
            {
                pickerAlcool.Items.Add(alcool);
            }

            pickerAlcool.SelectedIndexChanged += (sender, args) =>
                {
                    if (pickerAlcool.SelectedIndex != -1)
                    {
                        var todoItem = (TodoItem)BindingContext;
                        todoItem.BaseAlcoolIndex = pickerAlcool.SelectedIndex;
                        todoItem.BaseAlcool = pickerAlcool.Items[todoItem.BaseAlcoolIndex ];
                        todoItem.BaseAlcoolColor = Constants.AlcoolColors[todoItem.BaseAlcool];
                    }
                };

            var labelGlass = new Label { Text = "GlassWare" };

            var pickerGlass = new Picker
                {
                    Title = "Select",
                    VerticalOptions = LayoutOptions.CenterAndExpand
                };
            pickerGlass.SetBinding (Picker.SelectedIndexProperty, "GlasswareIndex");

            foreach (string glass in Constants.GlassWare.Keys)
            {
                pickerGlass.Items.Add(glass);
            }

            pickerGlass.SelectedIndexChanged += (sender, args) =>
                {
                    if (pickerAlcool.SelectedIndex != -1)
                    {
                        var todoItem = (TodoItem)BindingContext;
                        todoItem.GlasswareIndex = pickerGlass.SelectedIndex;
                        todoItem.Glassware = pickerGlass.Items[todoItem.BaseAlcoolIndex ];
                    }
                };
            
			var saveButton = new Button { Text = "Save" };
			saveButton.Clicked += (sender, e) => {
				var todoItem = (TodoItem)BindingContext;
				App.Database.SaveItem(todoItem);
				this.Navigation.PopAsync();
			};

			var deleteButton = new Button { Text = "Delete" };
			deleteButton.Clicked += (sender, e) => {
				var todoItem = (TodoItem)BindingContext;
				App.Database.DeleteItem(todoItem.ID);
                this.Navigation.PopAsync();
			};

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.StartAndExpand,
				Padding = new Thickness(20),
				Children = {
					nameLabel, nameEntry, 
                    labelAlcool, pickerAlcool,
                    labelGlass, pickerGlass,
					saveButton, deleteButton,
				}
			};
		}
	}
}