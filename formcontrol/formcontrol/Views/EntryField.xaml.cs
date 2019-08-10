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
    // Entry Control field 
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryField : ContentView
    {

        public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(
                                                         propertyName: "TitleText",
                                                         returnType: typeof(string),
                                                         declaringType: typeof(EntryField),
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
            var control = (EntryField)bindable;
            control.EntryTitle.Text = newValue.ToString();
        }

        public static readonly BindableProperty PlaceHolderTextProperty = BindableProperty.Create(
                                                         propertyName: "PlaceHolderText",
                                                         returnType: typeof(string),
                                                         declaringType: typeof(EntryField),
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
            var control = (EntryField)bindable;
            control.entry.Placeholder = newValue.ToString();
        }

        public static readonly BindableProperty ErrorMessageTextProperty = BindableProperty.Create(
                                                         propertyName: "ErrorMessageText",
                                                         returnType: typeof(string),
                                                         declaringType: typeof(EntryField),
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
            var control = (EntryField)bindable;
            control.errorMessageLabel.Text = newValue.ToString();
        }

        public static readonly BindableProperty ErrorTypeProperty = BindableProperty.Create(
                                                         propertyName: "ErrorType",
                                                         returnType: typeof(string),
                                                         declaringType: typeof(EntryField),
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
            var control = (EntryField)bindable;            
        }

        public static readonly BindableProperty DisplayErrorProperty = BindableProperty.Create(
                                                         propertyName: "DisplayError",
                                                         returnType: typeof(bool),
                                                         declaringType: typeof(EntryField),
                                                         defaultValue: false,
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: DisplayErrorPropertyChanged);

        public bool DisplayError
        {
            get { return (bool) base.GetValue(DisplayErrorProperty); }
            set => base.SetValue(DisplayErrorProperty, value); 
        }

        private static void DisplayErrorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (EntryField)bindable;
            control.DisplayError = (bool) newValue;
            control.errorMessageLabel.IsVisible = control.DisplayError;
        }

        private void entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Validate();            
        }

        public void Validate()
        {
            if (ErrorType == "Required")
            {
                ErrorMessageText = "The Field is required";
                if (string.IsNullOrEmpty(entry.Text))
                {
                    DisplayError = true;
                }
                else
                {
                    DisplayError = false;
                }
                return;
            }

            if (ErrorType == "Email")
            {
                ErrorMessageText = "Invalid Email";
                Regex format = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                RegexOptions.CultureInvariant | RegexOptions.Singleline);

                if (string.IsNullOrEmpty(entry.Text))
                {
                    DisplayError = true;
                    return;
                }

                if (!format.IsMatch(entry.Text))
                {
                    DisplayError = true;
                }
                else
                {
                    DisplayError = false;
                }
                return;
            }

            if (ErrorType == "Sid")
            {
                ErrorMessageText = "Invalid Sid";
                Regex format = new Regex(@"^([sS])\d{7}$",
                RegexOptions.CultureInvariant | RegexOptions.Singleline);

                if (string.IsNullOrEmpty(entry.Text))
                {
                    DisplayError = true;
                    return;
                }

                if (!format.IsMatch(entry.Text))
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

        private void entry_OnFocusChanged(object sender, FocusEventArgs focusChangedEventArgs)
        {
            Validate();
        }

        public EntryField()
        {
            InitializeComponent();
            DisplayError = false;
            errorMessageLabel.IsVisible = DisplayError;
            entry.TextChanged += entry_TextChanged;
            entry.Focused += entry_OnFocusChanged;
            entry.Unfocused += entry_OnFocusChanged;

        }
    }
}