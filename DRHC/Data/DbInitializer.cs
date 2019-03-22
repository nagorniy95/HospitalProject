using DRHC.Models;
using System;
using System.Linq;

namespace DRHC.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DrhcCMSContext context)
        {
            //We can "seed" some data in here when the DB is created
            //Q:How can we do that?
            //A:https://github.com/aspnet/Docs/blob/master/aspnetcore/data/ef-mvc/intro/samples/cu-final/Data/DbInitializer.cs
            context.Database.EnsureCreated();

            return;
        }
    }
}