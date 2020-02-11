using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MF.Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;

namespace MF.Entity.Context
{
    public static class DbContextExtension
    {

        public static bool AllMigrationsApplied(this DbContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
            //return false;
        }

        public static void EnsureSeeded(this MFContext context)
        {

            if (!context.Accounts.Any())
            {
                var accounts = JsonConvert.DeserializeObject<List<Account>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "accounts.json"));
                context.AddRange(accounts);
                context.SaveChanges();
            }

            //Ensure we have some status
            if (!context.Users.Any())
            {
                var users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(@"seed" + Path.DirectorySeparatorChar + "users.json"));
                context.AddRange(users);
                context.SaveChanges();
            }
            if (!context.Contact.Any())
            {
                var contacts = JsonConvert.DeserializeObject<List<Contact>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "contact.json"));
                context.AddRange(contacts);
                context.SaveChanges();
            }
        }

    }
}
