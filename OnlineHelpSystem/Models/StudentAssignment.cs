namespace OnlineHelpSystem.Models
{
    public class StudentAssignment
    {
        public Student Student { get; set; }
        public Assignment Assignment { get; set; }
        public string AssignmentName { get; set; }
        public string StudentAuId { get; set; }
        public int AssignmentNumber { get; set; }

        public int AssignmentId { get; set; }
    }
}
