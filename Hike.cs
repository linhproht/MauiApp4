using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.ComponentModel.DataAnnotations;

namespace MauiApp4
{
    public class Hike
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public bool ParkingAvailable { get; set; }

        [Required]
        public string Length { get; set; }

        [Required]
        public string DifficultyLevel { get; set; }

        public string Description { get; set; }
    }
}
