namespace OnlineHelpSystem.Models
{
    public class StudentAssignment
    {
        public Student Student { get; set; }
        public Assignment Assignment { get; set; }
        public string StudentFKAuId { get; set; }
        
        public int AssignmentFKId { get; set; }

        public int StudentAssignmentId { get; set; }
    }
}
