using Microsoft.AspNetCore.Identity;

namespace Trining_RESTApi.Data.Models
{
    public class User: IdentityUser
    {
        public virtual ICollection<Borrow> Borrows { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
