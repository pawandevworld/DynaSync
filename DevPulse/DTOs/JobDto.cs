namespace DevPulse.DTOs;

public class JobDto
{

    public int Id { get; set; }

     public string? Type { get; set; }//Ex. LOPA, ALC, LXService, etc.
    public string? AssignedBy { get; set; }//Select UserName from Table SS, Parmi, Francis, etc.
    public string? Description { get; set; }//Bug Fix, New Feature, Release Notes, etc.
    public string? Details { get; set; }//Details of the job
    public string? Status { get; set; }//completed, in progress, etc.
    public string? Priority { get; set; }//high, medium, low
    public int JobAge { get; set; }

}