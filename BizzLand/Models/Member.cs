namespace BizzLand.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public int ProfessionId { get; set; }
        public string InstaUrl { get; set; }
        public string FaceUrl { get; set; }
        public string TwitUrl { get; set; }
        public bool IsDeleted { get; set; }
        
        public Profession? Profession { get; set; }
    }
}
