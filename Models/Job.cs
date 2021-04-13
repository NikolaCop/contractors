namespace contractors.Models
{
    public class Job
    {
        internal int id;
        internal string jobId;

        public Job(string title, string description)
        {
            Title = title;
            Description = description;

        }

        public Job()
        {

        }

        public string Title { get; set; }
        public string Description { get; set; }
        public int Id { get; private set; }
    }
}