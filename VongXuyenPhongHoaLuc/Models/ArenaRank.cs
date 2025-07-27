namespace VongXuyenPhongHoaLuc.Models
{
    public class ArenaRank
    {
        public int Id { get; set; }
        public string Name { get; set; } // e.g. "Silver", "Gold", "Challenger"
        public string Description { get; set; }
        public int MinPoints { get; set; }
        public int MaxPoints { get; set; }
        public string IconUrl { get; set; }
    }
}
