using Microsoft.AspNetCore.Identity;

namespace LibraryManagementSystemAPI.Domain.Entities
{
    public class User: IdentityUser
    {
        public virtual ICollection<Borrow> Borrows { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
