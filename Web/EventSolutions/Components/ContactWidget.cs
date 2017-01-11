using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace EventSolutions.Components
{
    public class ContactWidget : ViewComponent
    {
        public ContactWidget()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           
            return View();
        }
    }
}
