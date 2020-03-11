using System;

namespace Guru.Core.Entities {
    public class Member 
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string WebSite { get; set; }
        public bool IsAdministrator { get; set; }
    }    
}