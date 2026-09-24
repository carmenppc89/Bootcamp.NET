using ASP.NET_MVC_Login.Models;
using ASP.NET_MVC_Login.Tools;

namespace ASP.NET_MVC_Login.DAL
{
    public class DALUsuario
    {
        private UserContext _userContext;

        public DALUsuario()
        {
            _userContext = new UserContext();
        }

        //public List<Usuario> GetAll()
        //{
        //    using (_userContext = new UserContext())
        //    {
        //        IQueryable<Usuario> usuarios = from Usuario in _userContext.Usuarios
        //                                       select Usuario;
        //        return usuarios.ToList();
        //    }
        //}

        public Usuario GetUsuarioByLogin(string userName, string userPwd)
        {
            using (_userContext = new UserContext())
            {
                Usuario? userLoged = (from Usuario in _userContext.Usuarios
                                      where Usuario.UserName == userName
                                      select Usuario).FirstOrDefault();

                if (userLoged != null)
                {
                    if (PasswordHelper.VerifyPasswordHash(userPwd,
                        userLoged.PwdHash, userLoged.PwdSalt))
                        return userLoged;
                }

                return null;

            }
        }

        public void CreateUsuario(Usuario userSigned, string pwd)
        {
            PasswordHelper.CreatePasswordHash(pwd, out byte[] pwdHash, out byte[] pwdSalt);

            using (_userContext = new UserContext())
            {
                Usuario newUser = new Usuario();

                newUser.UserName = userSigned.UserName;
                newUser.PwdHash = pwdHash;
                newUser.PwdSalt = pwdSalt;

                _userContext.Usuarios.Add(newUser);
                _userContext.SaveChanges();
            }
        }

    }
}
