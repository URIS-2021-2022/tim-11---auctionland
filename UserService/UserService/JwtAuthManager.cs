using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserService.Database;

namespace UserService
{
    public class JwtAuthManager : IJwtAuthManager
    {
        private readonly string key;
        public JwtAuthManager(string key)
        {
            this.key = key;
        }
        public string Authenticate(string username, string password)
        {
            UserDbContext db = new UserDbContext();
            List<User> users = new List<User>();
            users = db.Users.ToList();
            var temp = new User();
            if(!users.Any(u => u.UserName == username && u.Password == password))
            {
                return null;
            }
            foreach(var user in users)
            {
                if(user.UserName == username)
                {
                    temp=user;
                }
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim("useracctype",temp.Type)
                    
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
