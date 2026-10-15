namespace RailwayErp.MvvmDemo.Models
{
    // Model: звичайний клас даних, без залежностей від UI
    public class Train
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public string Route { get; set; } = string.Empty;
    }
}