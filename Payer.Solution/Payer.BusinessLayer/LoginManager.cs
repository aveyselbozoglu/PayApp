using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Payer.DataAccessLayer.EntityFramework;
using Payer.Entities;

namespace Payer.BusinessLayer
{
    public class LoginManager
    {
        public BusinessLayerResult<Login> Login(Login loginModel)
        {
            BusinessLayerResult<Login> blResultLogin = new BusinessLayerResult<Login>();
            Repository<Login> repositoryLogin = new Repository<Login>();

            blResultLogin.BlResult =repositoryLogin.Find(x => x.Username == loginModel.Username && x.Password == loginModel.Password);

            return blResultLogin;

        }
    }
}
