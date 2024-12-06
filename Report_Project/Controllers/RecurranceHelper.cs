namespace Report_Project.Controllers
{
    public static class RecurrenceHelper
    {
        public static IEnumerable<DateTime> GetRecurrenceDates(
            DateTime startDate,
            string recurrenceType,
            DateTime? endDate = null)
        {
            var dates = new List<DateTime>();
            var currentDate = startDate;

            while (!endDate.HasValue || currentDate <= endDate.Value)
            {
                dates.Add(currentDate);

                currentDate = recurrenceType switch
                {
                    "Daily" => currentDate.AddDays(1),
                    "Weekly" => currentDate.AddDays(7),
                    "Monthly" => currentDate.AddMonths(1),
                    "Yearly" => currentDate.AddYears(1),
                    _ => throw new ArgumentException("Invalid recurrence type"),
                };
            }

            return dates;
        }
    }

}
