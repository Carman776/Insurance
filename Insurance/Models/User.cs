using MongoDB.Bson;

namespace Insurance.Models
{
    public class User
    {
        public ObjectId Id { get; set; }
        public String? Name { get; set; }
        public String? Email { get; set; }
        public String? UserName { get; set; }
        public String? Password { get; set; }

    }
}
