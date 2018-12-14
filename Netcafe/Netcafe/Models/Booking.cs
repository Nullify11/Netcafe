using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Netcafe.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public decimal TotalPrice { get; set; }

        public string UserId { get; set; }

        public int ComputerId { get; set; }

    }

    public class CreateBookingViewModel
    {
        [Required]
        [Display(Name = "Start time")]
        public DateTime StartTime { get; set; }

        [Required]
        [Display(Name = "End  time")]
        public DateTime EndTime { get; set; }

        [Required]
        [Display(Name = "Total price")]
        public decimal TotalPrice { get; set; }


        [Required]
        public string UserId { get; set; }

        public IEnumerable<SelectListItem> Users { get; set; }

        [Required]
        public int ComputerId { get; set; }

        public IEnumerable<SelectListItem> Computers { get; set; }

        public CreateBookingViewModel()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Users = new SelectList(db.Users.ToList(), "Id", "UserName");
                Computers = new SelectList(db.Computers.ToList(), "Id", "Id");
            }
        }

    }

}