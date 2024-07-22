namespace RoadBoM.Web.Models.ViewModels
{
    public class RoadViewModel
    {
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!; 
        public decimal Length { get; set; }

        public decimal Width { get; set; }

        public string Row { get; set; } = null!;

        public int Poles { get; set; } 

        public string Type { get; set; } = null!;

        public int Culvert { get; set; }

        public int Outfall { get; set; }

    }
}
