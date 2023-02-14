namespace Budgethold.Modules.Users.Core.DTO
{
    using System;
    using System.Collections.Generic;

    public class AccountDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public Dictionary<string, IEnumerable<string>> Claims { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}