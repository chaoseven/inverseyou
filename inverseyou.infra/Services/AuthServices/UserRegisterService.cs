using inverseyou.ddd.Events;
using inverseyou.infra.Services.EncryptionServices;
using MediatR;
using System;

namespace inverseyou.infra.Services.AuthServices
{
    public class UserRegisterService
    {
        private readonly EncryptionManage _encryptionManage;
        private readonly IMediator _mediatR;

        public UserRegisterService(EncryptionManage encryptionManage,IMediator mediator)
        {
            _encryptionManage = encryptionManage;
            _mediatR = mediator;
        }

        public void SendValidationEmail(string name, string token)
        {
            _mediatR.Publish(new MailRequest { Subject = "please confirm your email address", Body = $"please click the address below to confirm your email address</br><a href='http://localhost:27637/auth/emailcomfirm/?name={name}&token={token}'>http://localhost:27637/auth/emailcomfirm/?name={name}&token={token}</a></br>inverseyou.com", IsHTMLFormat = true });
        }

        public bool ValidationUserEmail(string name, string token,out Exception ex)
        {
            var payload = _encryptionManage.Decrypt(token);
            ex = null;
            var payloadName = payload["Name"].ToString();
            var payloadExpTime = DateTime.Parse(payload["ExpTime"].ToString());

            if(payloadExpTime!=null)
            {
                if (payloadExpTime < DateTime.Now)
                {
                    ex = new Exception("token expired");
                    return false;
                }
                else
                {
                    return name == payloadName ? true : false;
                }
            }
            else
            {
                ex = new Exception("no valid expire mark");
                return false;
            }
        }

        public void ActiveUserAccount(int id)
        {

        }
    }
}
