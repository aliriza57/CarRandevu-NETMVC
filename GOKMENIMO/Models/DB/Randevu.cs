using System;
using System.Collections.Generic;
#nullable disable
namespace GOKMENIMO.Models.DB
{
    public partial class Randevu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CarType { get; set; }
        public string WorkType { get; set; }
        public string Tell { get; set; }
    }
}
