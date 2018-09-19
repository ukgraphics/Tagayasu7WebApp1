using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tagayasu7AspNetCoreApp1.Pages
{
    public class EventDetailModel : PageModel
    {
        public List<Event.EventItem> EventItem;

        public ActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EventItem = Event.GetEvents(id);

            if (EventItem == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}