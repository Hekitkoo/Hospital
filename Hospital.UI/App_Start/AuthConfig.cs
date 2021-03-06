﻿using System;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace Hospital.UI
{
    public class AuthConfig
    {
        public static void ConfigureAuth(IAppBuilder app)
        {
            var loginPath = "/Home/Login";

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                ExpireTimeSpan = TimeSpan.FromMinutes(30),
                LoginPath = new PathString(loginPath),
                CookieName = $"SomeCustomNameForAuthCookie",
                CookieSecure = CookieSecureOption.SameAsRequest,
                CookieHttpOnly = false
            });
        }
    }
}