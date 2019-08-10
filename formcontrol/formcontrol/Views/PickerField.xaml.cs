using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace formcontrol.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickerField : ContentView
    {

        public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(
                                                         propertyName: "TitleText",
                                                         returnType: typeof(string),
                                                         declaringType: typeof(PickerField),
                                                         defaultValue: "",
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: TitleTextPropertyChanged);

        public string TitleText
        {
            get { return base.GetValue(TitleTextProperty).ToString(); }
            set { base.SetValue(TitleTextProperty, value); }
        }

        private static void TitleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (PickerField)bindable;
            control.title.Text = newValue.ToString();
        }

        public static readonly BindableProperty PlaceHolderTextProperty = BindableProperty.Create(
                                                         propertyName: "PlaceHolderText",
                                                         returnType: typeof(string),
                                                         declaringType: typeof(PickerField),
                                                         defaultValue: "",
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: PlaceHolderTextPropertyChanged);

        public string PlaceHolderText
        {
            get { return base.GetValue(PlaceHolderTextProperty).ToString(); }
            set { base.SetValue(PlaceHolderTextProperty, value); }
        }

        private static void PlaceHolderTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (PickerField)bindable;

        }

        public static readonly BindableProperty ErrorMessageTextProperty = BindableProperty.Create(
                                                         propertyName: "ErrorMessageText",
                                                         returnType: typeof(string),
                                                         declaringType: typeof(PickerField),
                                                         defaultValue: "",
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: ErrorMessageTextPropertyChanged);

        public string ErrorMessageText
        {
            get { return base.GetValue(ErrorMessageTextProperty).ToString(); }
            set { base.SetValue(ErrorMessageTextProperty, value); }
        }

        private static void ErrorMessageTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (PickerField)bindable;
            control.errorMessageLabel.Text = newValue.ToString();
        }

        public static readonly BindableProperty ErrorTypeProperty = BindableProperty.Create(
                                                         propertyName: "ErrorType",
                                                         returnType: typeof(string),
                                                         declaringType: typeof(PickerField),
                                                         defaultValue: "",
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: ErrorTypePropertyChanged);

        public string ErrorType
        {
            get { return base.GetValue(ErrorTypeProperty).ToString(); }
            set { base.SetValue(ErrorTypeProperty, value); }
        }

        private static void ErrorTypePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (PickerField)bindable;
        }

        public static readonly BindableProperty DisplayErrorProperty = BindableProperty.Create(
                                                         propertyName: "DisplayError",
                                                         returnType: typeof(bool),
                                                         declaringType: typeof(PickerField),
                                                         defaultValue: false,
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: DisplayErrorPropertyChanged);

        public bool DisplayError
        {
            get { return (bool)base.GetValue(DisplayErrorProperty); }
            set => base.SetValue(DisplayErrorProperty, value);
        }

        private static void DisplayErrorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (PickerField)bindable;
            control.DisplayError = (bool)newValue;
            control.errorMessageLabel.IsVisible = control.DisplayError;
        }

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
                                                         propertyName: "DisplayError",
                                                         returnType: typeof(List<String>),
                                                         declaringType: typeof(PickerField),
                                                         defaultValue: new List<String>{"Tempvalue"},
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: ItemsSourcePropertyChanged);

        public List<String> ItemsSourceList
        {
            get { return (List<String>)base.GetValue(ItemsSourceProperty); }
            set => base.SetValue(ItemsSourceProperty, value);
        }

        private static void ItemsSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (PickerField)bindable;
            //control?.picker.ItemsSource = (List<String>) newValue;
        }

        private void picker_TextChanged(object sender, TextChangedEventArgs e)
        {
            Validate();
        }

        public void Validate()
        {
            if (ErrorType == "Required")
            {
                ErrorMessageText = "The Field is required";
                if (picker.SelectedItem == null)
                {
                    DisplayError = true;
                }
                else
                {
                    DisplayError = false;
                }
                return;
            }           
        }

        private void picker_OnFocusChanged(object sender, FocusEventArgs focusChangedEventArgs)
        {
            Validate();
        }

        public PickerField()
        {
            var tempList = new List<string>();
            tempList.Add("Intervention 1");
            tempList.Add("Intervention 2");
            tempList.Add("Intervention 3");

            InitializeComponent();
            DisplayError = false;
            errorMessageLabel.IsVisible = DisplayError;            
            picker.Focused += picker_OnFocusChanged;
            picker.Unfocused += picker_OnFocusChanged;

            ItemsSourceList = tempList;
            picker.ItemsSource = new List<String>();
            picker.ItemsSource = tempList;
        }
    }
}