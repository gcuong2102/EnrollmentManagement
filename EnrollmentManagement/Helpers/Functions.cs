namespace EnrollmentManagement.Functions
{
    public static class Functions
    {
        public static string CreateKey(string Char)
        {
            var now = DateTime.Now;
            var result = Char+"_"+now.Year.ToString()+now.Month.ToString()+now.Day.ToString()+now.Hour.ToString()+now.Minute.ToString()+now.Second.ToString()+now.Millisecond.ToString();
            return result;
        }
    }
}
