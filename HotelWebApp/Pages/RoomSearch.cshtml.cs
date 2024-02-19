using HotelAppLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace HotelWebApp.Pages
{
    public class RoomSearchModel : PageModel
    {
       
        [BindProperty] 
        public DateTime StartDate { get; set; } = DateTime.Now;
        [BindProperty]
        public DateTime EndDate { get; set; }= DateTime.Now.AddDays(1); 

        public void OnGet()
        {
            RoomModel room = new RoomModel();

        }
        public IActionResult OnPost()
        {
            return Page();
            

        }
    }
}
