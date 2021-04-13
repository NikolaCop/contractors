namespace contractors.Models
{
    public class Contractor
    {
        internal int id;
        internal string contractorId;

        public Contractor(string name)
        {
            Name = name;

        }

        public Contractor()
        {

        }

        public string Name { get; set; }
        public int Id { get; private set; }
    }
}