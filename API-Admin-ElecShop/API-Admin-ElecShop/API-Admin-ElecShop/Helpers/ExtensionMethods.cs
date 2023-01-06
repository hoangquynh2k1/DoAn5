﻿using API_Admin_ElecShop.Entities;
using System.Collections.Generic;
using System.Linq;

namespace API_Admin_ElecShop.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<User> WithoutPasswords(this IEnumerable<User> users)
        {
            if (users == null) return null;

            return users.Select(x => x.WithoutPassword());
        }

        public static User WithoutPassword(this User user)
        {
            if (user == null) return null;

            user.MatKhau = null;
            return user;
        }
    }
}
