namespace ASP.NETCoreApplication.Controllers
{
    public static class MyExtentionClass
    {
        public static int WordCount( this string str)
        {
            return str.Split(' ').Length;

        }

    }
}
