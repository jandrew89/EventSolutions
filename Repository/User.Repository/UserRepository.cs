using User.Repository.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace User.Repository
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private UserContext _context;

        public UserRepository(UserContext context)
        {
            this._context = context;
        }

        public UserRepository()
        {
            this._context = new UserContext();
        }

        public void AddUser(User.Repository.Entities.User user)
        {
            _context.Users.Add(user);

            Save();
        }

        public void AddUserClaim(UserClaim userClaim)
        {
            _context.UserClaims.Add(userClaim);

            Save();
        }

        public void AddUserClaim(string subject, string claimType, string claimValue)
        {
            var user = GetUser(subject);
            if (user == null)
            {
                throw new ArgumentException("User with given subject not found.", subject.ToString());
            }

            user.UserClaims.Add(new UserClaim()
            {
                Id = Guid.NewGuid().ToString(),
                Subject = subject,
                ClaimType = claimType,
                ClaimValue = claimValue
            });

            Save();
        }

        public void AddUserLogin(string subject, string loginProvider, string providerKey)
        {
            var user = GetUser(subject);
            if (user == null)
            {
                throw new ArgumentException("User with given subject not found.", subject);
            }

            user.UserLogins.Add(new UserLogin()
            {
                Subject = subject,
                LoginProvider = loginProvider,
                ProviderKey = providerKey
            });

            Save();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                   
                }

            }
        }

        private void Save()
        {
            _context.SaveChanges();
        }

        public User.Repository.Entities.User GetUser(string subject)
        {
            return _context.Users.First(u => u.Subject == subject);
        }

        public User.Repository.Entities.User GetUser(string userName, string password)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == userName && u.Password == password);
        }

        public IList<UserClaim> GetUserClaims(string subject)
        {
            var userClaims = _context.UserClaims.Where(uc => uc.Subject == subject);
            if (userClaims == null)
            {
                return new List<UserClaim>();
            }

            return userClaims.ToList();
        }

        public User.Repository.Entities.User GetUserForExternalProvider(string loginProvider, string providerKey)
        {
            foreach (var user in _context.Users)
            {
                if (user.UserLogins.Any(l => l.LoginProvider.ToLowerInvariant() == loginProvider.ToLowerInvariant()
                    && l.ProviderKey.ToLowerInvariant() == providerKey.ToLowerInvariant()))
                {
                    return user;
                }
            }

            return null;
        }

        public User.Repository.Entities.User GetUserByEmail(string email)
        {
            foreach (var user in _context.Users)
            {
                if (user.UserClaims.Any(c => c.ClaimType == "email"
                    && c.ClaimValue.ToLowerInvariant() == email.ToLowerInvariant()))
                {
                    return user;
                }
            }

            return null;
        }

        public IList<UserLogin> GetUserLogins(string subject)
        {
            var user = GetUser(subject);
            if (user == null)
            {
                return new List<UserLogin>();
            }

            return user.UserLogins;
        }
    }
}