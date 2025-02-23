namespace DevPulse.Extensions
{
    public static class DateTimeExtensions
    {
        public static int CalculateJobAge(this DateOnly startdate)
        {
            //Calculating JobAge in Days    
            var ageInDays = (DateOnly.FromDateTime(DateTime.Now).DayNumber - startdate.DayNumber);
            return (int)ageInDays;

            //Calculating Age in Years
            // var today = DateOnly.FromDateTime(DateTime.Now);
            // var age = today.Year - startdate.Year;
            // if (startdate > today.AddYears(-age)) age--;
            // return age;

        }
        
    }
}