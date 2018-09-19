using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tagayasu7AspNetCoreApp1.Pages
{
    public class EventListModel : PageModel
    {
        public List<Event.EventItem> EventList;
        
        public void OnGet()
        {
            EventList = Event.GetEvents("タガヤス");

        }
    }
}