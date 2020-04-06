namespace OnlineHelpSystem.Models
{
    public class StudentAssignment
    {
        public Student Student { get; set; }
        public Assignment Assignment { get; set; }
        public string StudentAuId { get; set; }
        
        public string AssignmentId { get; set; }

        public string StudentAssignmentId { get; set; }
    }
}
