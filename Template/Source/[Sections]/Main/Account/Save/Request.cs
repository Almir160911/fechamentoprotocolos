﻿using Data;
using MongoWebApiStarter;
using ServiceStack;

namespace Main.Account.Save
{
    [Route("/account")]
    public class Request : Model, IRequest<Response>
    {
        public bool EmailBelongsToSomeOneElse()
        {
            if (EmailAddress == null) return true;

            var idForEmail = RepoAccount.GetID(EmailAddress.LowerCase());
            return idForEmail != ID;
        }
    }
}