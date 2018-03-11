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
using MOMO.Infrastructure.Utilities;
using MOMO.Respository.EFCore.Context;
using MOMO.Respository.EFCore.Generator;
using Remotion.Linq.Parsing.Structure;
using Xunit;

namespace MOMO.Test
{
    public class EFCoreTest
    {
		[Fact]
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
    }

	
}
