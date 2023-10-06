namespace PruebaIngresoBibliotecario.Business.Utils
{
    public static class LaboralDaysCounter
    {
        internal static List<DayOfWeek> exceptedDays = new List<DayOfWeek> { DayOfWeek.Saturday, DayOfWeek.Sunday };
        public static int CountLaboralDays(DateTime initialDate, DateTime finalDate)
        {
            var totalDays = 0;
            DateTime currentDate = initialDate;

            while (currentDate <= finalDate)
            {
                if (!exceptedDays.Contains(currentDate.DayOfWeek))
                {
                    totalDays++;
                }
                currentDate = currentDate.AddDays(1);
            }

            return totalDays;
        }

        public static DateTime CalculateDevolutionDate(DateTime initialDate, int addDays)
        {
            var currentDate = initialDate;
            var daysAdded = 0;

            while (daysAdded < addDays)
            {
                currentDate = currentDate.AddDays(1);
                if (!exceptedDays.Contains(currentDate.DayOfWeek))
                {
                    daysAdded++;
                }
            }

            return currentDate;
        }
    }
}
