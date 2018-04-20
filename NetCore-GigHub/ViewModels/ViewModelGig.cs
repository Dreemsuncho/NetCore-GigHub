using System;
using System.ComponentModel.DataAnnotations;

namespace NetCore_GigHub.ViewModels
{
    public class ViewModelGig
    {
        [Required]
        [StringLength(40)]
        public string Venue { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Date)]
        public DateTime Time { get; set; }

        [Required]
        public byte Genre { get; set; }

        public DateTime GetDateTime()
        {
            return new DateTime(
                Date.Year, 
                Date.Month, 
                Date.Day, 
                Time.Hour, 
                Time.Minute, 
                Time.Second);
        }
    }
}
