using BCrypt.Net;
using Login.Data;
using Login.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Login.Repositoryes
{
    public class LoginRepo : ILoginRepo
    {
        private readonly appdbcontext _context;
        public LoginRepo(appdbcontext context)
        {
            _context = context;
        }

        public bool Add(Logindto logindto)
        {
            Models.Login add = new  Models.Login();
           var exit = _context.logins.FirstOrDefault(u => u.email ==  logindto.email);
            if(exit != null)
            {
                return false;
            }
            else
            {
                add.email = logindto.email;
            }
            if(logindto.role == "Admin" || logindto.role == "User")
            {
                add.role = logindto.role;
            }
            else
            {
                return false;
            }
            if(logindto.password == logindto.confirmpassword)
            {
                add.password = BCrypt.Net.BCrypt.HashPassword(logindto.password );
                add.confirmpassword = logindto.confirmpassword;
            }
            else
            {
                return false;
            }
            _context.logins.Add(add);
            _context.SaveChanges();
            return true;
        }

        public List<getallusersoradmins> GetALL(string role)
        {
            
            if(role == "Admin" || role == "User")
            {
                var res = _context.logins.FirstOrDefault(x => x.role == role);
                if (res != null)
                {
                    var v = _context.logins.Where(x => x.role == role).Select(x => new getallusersoradmins
                    {
                        email = x.email,
                        password = x.confirmpassword
                    }).ToList();
                    return v;
                }
            }
           
            return null;
        }

        public bool SearchOfuser(Logindto0 logindto)
        {
            var search = _context.logins.FirstOrDefault(x => x.email ==  logindto.email);
            if(search != null && BCrypt.Net.BCrypt.Verify(logindto.password , search.password))
            {
                
                return true;
            }
            
            return false;
        }
        
    }
}
