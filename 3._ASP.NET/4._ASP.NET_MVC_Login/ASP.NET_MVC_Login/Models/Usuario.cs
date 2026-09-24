namespace ASP.NET_MVC_Login.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string UserName { get; set; }
        public byte[] PwdHash { get; set; }
        public byte[] PwdSalt { get; set; }
        public DateTime FechaRegistro { get; set; }

    }

}
