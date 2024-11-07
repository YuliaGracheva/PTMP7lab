using System.ComponentModel.DataAnnotations;

namespace lab7PPTPM.Model
{
    public class PositionJob
    {
        [Key]
        public int PositionJobId { get; set; }
        public string PositionName { get; set; }
        public PositionJob(int positionJobId, string positionName)
        {
            PositionJobId = positionJobId;
            PositionName = positionName;
        }
        public PositionJob() { }
    }
}
