namespace EX.Core.Domain
{
    public class Activite
    {
        public int activiteId { get; set; }
        // public string vile { get; set;}
        // public string pays { get; set;}
        public Zone zone { get; set; }
        public string prix { get; set;}
        public string typeService { get; set;}

    }
}
