namespace AuthorProblem
{
    [Author("Bond")]
    public class StartUp
    {
        [Author("Bill")]
        public static void Main(string[] args)
        {
            var tracer = new Tracker();
            tracer.PrintMethodsByAuthor();
        }
    }
}
