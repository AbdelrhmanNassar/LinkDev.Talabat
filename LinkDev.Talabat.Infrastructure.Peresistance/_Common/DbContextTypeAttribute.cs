using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastructure.Peresistance._Common
{
    //[AttributeUsage(AttributeTargets.Class)] //We will traget only classes because for sure configurations will be classes 
    //public class DbContextTypeAttribute: Attribute
    //{
    //    public Type DbContextType { get; set; }
    //    public DbContextTypeAttribute(Type type)
    //    {
    //        DbContextType = type;
    //    }
    //}


    //[AttributeUsage(AttributeTargets.Class)]
    //public  class DbContextTypeAttribute : Attribute
    //{
    //    public Type DbContextType { get; set; }
    //    public DbContextTypeAttribute(Type type)
    //    {
    //        this.DbContextType = type;
    //    }
    //}




    public class DbContextTypeAttribute : Attribute
    {

        public Type DbContextType { get; set; }

        public DbContextTypeAttribute(Type type)
        {
            DbContextType = type;
        }

    }














}
