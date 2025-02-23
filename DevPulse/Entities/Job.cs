using System.ComponentModel.DataAnnotations.Schema;
using DevPulse.Extensions;

namespace DevPulse.Entities
{
    //Use annotations to specify the table name. Inf this case we will name the Jobs not Job
    [Table("Jobs")]
    public class Job
    {
        public int Id { get; set; }

        public required string Type { get; set; }//Ex. LOPA, ALC, LXService, etc.
        public required string AssignedBy { get; set; }//Select UserName from Table SS, Parmi, Francis, etc.
        public required string Description { get; set; }//Bug Fix, New Feature, Release Notes, etc.
        public required string Details { get; set; }//Details of the job
        public required string Status { get; set; }//completed, in progress, etc.
        public required string Priority { get; set; }//high, medium, low
        public DateOnly StartDate { get; set; }
        public DateOnly EndtDate { get; set; }
        public string? PublicId { get; set; }//Storing image in cloudinary


        //Navigation Property for required one to many relationship between user and job
        public int AppUserId { get; set; }  
        public AppUser AppUser { get; set; } = null!;



        //Calculating JobAge in Days
        // public int GetJobAge()
        // {
        //     return StartDate.CalculateJobAge();
        // }


    }
}