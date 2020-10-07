﻿using AGAT.LocoDispatcher.AuthData.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.AuthData.Managers
{
    public class AppUserManager : UserManager<User>
    {
        public AppUserManager(IUserStore<User> store)
           : base(store)
        {
        }
        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options,
                                                IOwinContext context)
        {
            AuthContext db = context.Get<AuthContext>();
            AppUserManager manager = new AppUserManager(new UserStore<User>(db));
            return manager;
        }
    }
}
