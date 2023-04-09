using Ecommerce.Website.Database.Models;
using Ecommerce.Website.Database.Models.Authetication;
using Ecommerce.Website.Database.Models.Authetication.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Contacts
{
    public interface IUserRepository : IBaseRepository<User>
    {
        TokenModel Validate(Login model);
        TokenModel RenewToken(TokenModel model);
    }
}
