using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using MOMO.Domain;
using MOMO.Domain.Enum;
using MOMO.Infrastructure.Utilities;
using MOMO.Respository.EFCore.Context;
using MOMO.Respository.EFCore.Generator;
using Remotion.Linq.Parsing.Structure;
using Xunit;

namespace MOMO.Test
{
    public class EFCoreTest
    {
	    void Test1()
	    {
			MoMoDbMsSqlContext db = new MoMoDbMsSqlContext(new DbContextOptions<MoMoDbMsSqlContext>());
		    var qure = from user in db.Set<User>() select user ;

		    var SqlServerQuery = db.Set<User>().Select(x => x.Password== "123sdf")
			   .Take(4);

			Console.WriteLine("SQL Server Generated:");
		    Console.WriteLine(SqlServerQuery.ToSql());
		    Console.WriteLine("Unevaluated:");
		    Console.WriteLine(string.Join(
			    Environment.NewLine,
			    SqlServerQuery
				    .ToUnevaluated()));
		    Console.WriteLine();


			var sdfsd = qure.ToSql();
			var sdf =  db.Set<User>().Select(s=>s.Password== "123sdf").ToSql();
			Console.WriteLine(sdf);

			// db.SaveChanges();
		}



        [Fact]
        void Test2()
        {
            MoMoDbMsSqlContext db = new MoMoDbMsSqlContext(new DbContextOptions<MoMoDbMsSqlContext>());
            User user = new User();
            user.Account = "asdf";
            user.Password = "123";
            user.Name = "Gzy";
            user.Status = 1;
            user.Type = 2;
            user.Sex = Sex.男;
            user.BizCode = "001";

            db.Set<User>().Add(user);
            db.SaveChanges();


            // db.SaveChanges();
        }
    }

	
}
