namespace ELN.Elasticsearch.API.Indexes
{
    public class PeopleIndex : BaseIndex
    {
        public bool IsActive { get; set; }
        public string Balance { get; set; }
        public string Picture { get; set; }
        public int Age { get; set; }
        public string EyeColor { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Registered { get; set; }
    }
}
