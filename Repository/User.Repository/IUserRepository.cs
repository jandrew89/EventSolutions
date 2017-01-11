using User.Repository.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace User.Repository
{
    public interface IUserRepository
    {
        void AddUser(User.Repository.Entities.User user);
        void AddUserClaim(UserClaim userClaim);
        void AddUserClaim(string subject, string claimType, string claimValue);
        void AddUserLogin(string subject, string loginProvider, string providerKey);
        void Dispose();
        User.Repository.Entities.User GetUser(string subject);
        User.Repository.Entities.User GetUser(string userName, string password);
        IList<UserClaim> GetUserClaims(string subject);
        User.Repository.Entities.User GetUserForExternalProvider(string loginProvider, string providerKey);
        User.Repository.Entities.User GetUserByEmail(string email);
        IList<UserLogin> GetUserLogins(string subject);

    }
}