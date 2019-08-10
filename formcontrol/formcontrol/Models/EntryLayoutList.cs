using System;
using System.Collections.Generic;
using System.Text;

namespace formcontrol.Models
{
    /// <summary>
    /// Main Form control list that displays the field configuration setup in the view
    /// </summary>
    class EntryLayoutList
    {
        public string EntryListTitle { get; set; }
        public List<EntryControl> Entries { get; set; }
        public string Layout { get; set; }
        public string BackgroundColor { get; set; }
        public string AutomationId { get; set; }        

    }
}
