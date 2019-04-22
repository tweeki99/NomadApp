using NomadAppWf.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomadAppWf
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            context.Users.Add(new User
            {
                Name = "Данил",
                Login = "Danil",
                Password = "3ae7f053e7e4c560ba548ddd928a09b0"
            });
            
            base.Seed(context);
        }
    }
}
