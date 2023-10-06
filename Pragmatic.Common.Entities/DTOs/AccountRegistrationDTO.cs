using Pragmatic.Common.Entities.Entities;

namespace Pragmatic.Common.Entities.DTOs
{
    public class AccountRegistrationDTO
    {
        public AccountRegistrationDTO()
        {
                Variables = new Variables();
        }

        public int AccountNumber { get; set; }
        public string AccountName { get; set; }
        public virtual Variables Variables { get; set; }
    }
}
