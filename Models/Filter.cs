using System;

namespace Task4RozetkaUA.Models
{
    [Serializable]
    public class Filter
    {
        public string searchProduct { get; set; }
        public string searchFirm { get; set; }
        public string orderSum { get; set; }
    }
}
