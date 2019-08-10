using formcontrol.Models;
using formcontrol.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace formcontrol
{
    
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            // Setup the dynamic formfield configuration
            InitializeComponent();
            var monkeyList = new List<string>();
            monkeyList.Add("Intervention 1");
            monkeyList.Add("Intervention 2");
            monkeyList.Add("Intervention 3");

            var EntryList = new List<EntryControl>();
            EntryList.Add(new EntryControl("BranchOffice", "BranchOfficeId", "Picker","BranchOffice", "","BanchOffice","Field is required", "Required",true));
            EntryList.Add(new EntryControl("CumstomsControlArea", "CumstomsControlAreaId","Picker","CumstomsControlArea", "","CumstomsControlArea", "Field is required", "Required",true));
            EntryList.Add(new EntryControl("Location", "LocationId", "Entry","Location", "","Location","Field is required", "Required",true));
            
            foreach(EntryControl item in EntryList)
            {
                if (item.Type=="Entry") {
                    EntryField e = new EntryField();
                    e.ClassId = item.Name;
                    e.AutomationId = item.AutomationId;
                    e.PlaceHolderText = item.PlaceHolderText;
                    e.TitleText = item.TitleText;
                    e.ErrorMessageText = item.ErrorMessageText;
                    e.ErrorType = item.ErrorType;
                    e.WidthRequest = 300;
                    e.IsVisible = item.IsVisible;
                    autoStack.Children.Add(e);
                }
                if (item.Type == "Picker")
                {
                    PickerField e = new PickerField();
                    e.ClassId = item.Name;
                    e.AutomationId = item.AutomationId;                    
                    e.TitleText = item.TitleText;
                    e.ErrorMessageText = item.ErrorMessageText;
                    e.ErrorType = item.ErrorType;
                    e.WidthRequest = 300;
                    e.IsVisible = item.IsVisible;
                    e.ItemsSourceList = monkeyList;
                    autoStack.Children.Add(e);
                }
                if (item.Type == "Label")
                {

                }
            }
        }

        // To validate the grid, flexlayout and the custom field configuration layout

        public void OnButtonClickedValidate(object sender, EventArgs args)
        {
            foreach (View item in ((StackLayout)this.Content).Children)
            {
                if (item.GetType() == typeof(EntryField))
                {
                    EntryField E = (EntryField)item;
                    E.Validate();
                }
            }

            foreach (View item in formGrid.Children)
            {
                if (item.GetType() == typeof(EntryField))
                {
                    EntryField E = (EntryField)item;
                    E.Validate();
                }
                if (item.GetType() == typeof(PickerField))
                {
                    PickerField P = (PickerField)item;
                    P.Validate();
                }
            }

            foreach (View item in formStack.Children)
            {
                if (item.GetType() == typeof(EntryField))
                {
                    EntryField E = (EntryField)item;
                    E.Validate();
                }
                if (item.GetType() == typeof(PickerField))
                {
                    PickerField P = (PickerField)item;
                    P.Validate();
                }
            }
        }
    }
}
