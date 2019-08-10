using System;
using System.Collections.Generic;
using System.Text;

namespace formcontrol.Models
{

    //Custom Component for Xamarin Entry field. 
    //Shows the following:
    // 1. Title above the entry component
    // 2. The entry component
    // 3. The error message under the component.
    class EntryControl
    {
        public string Name { get; set; }
        public string AutomationId { get; set; }
        public string Type { get; set; }
        public string TitleText { get; set; }
        public string Text { get; set; }
        public string PlaceHolderText { get; set; }
        public string ErrorMessageText { get; set; }
        public string ErrorType { get; set; }
        public bool IsVisible { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Name">Name of entry</param>
        /// <param name="AutomationId">For testing purposes</param>
        /// <param name="Type">Type of entry email or sid etc</param>
        /// <param name="TitleText">Title</param>
        /// <param name="Text">Actual text</param>
        /// <param name="PlaceHolderText">Place holder text</param>
        /// <param name="ErrorMessageText">Error Message text</param>
        /// <param name="ErrorType">Type of Error</param>
        /// <param name="IsVisible">Wheter the field is shown</param>
        public EntryControl(string Name,
            string AutomationId,
            string Type,
            string TitleText,
            string Text,
            string PlaceHolderText,
            string ErrorMessageText,
            string ErrorType,
            bool IsVisible)
        {
            this.Name = Name;
            this.AutomationId = AutomationId;
            this.Type = Type;
            this.TitleText = TitleText;
            this.Text = Text;
            this.PlaceHolderText = PlaceHolderText;
            this.ErrorMessageText = ErrorMessageText;
            this.ErrorType = ErrorType;
            this.IsVisible = IsVisible;
        }
    }
   
}
