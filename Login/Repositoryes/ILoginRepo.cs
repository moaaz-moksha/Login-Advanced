using Login.Dtos;

namespace Login.Repositoryes
{
    public interface ILoginRepo
    {
        public bool Add(Logindto logindto);
        public bool SearchOfuser(Logindto0 logindto0);
        public List<getallusersoradmins> GetALL(string role);
    }

}
