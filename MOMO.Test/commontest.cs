using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MOMO.Infrastructure.Utilities;
using Xunit;

namespace MOMO.Test
{
	public class Commontest
    {
	    [Fact]
		public void test1()
	    {

			List<Student> ssdf= new List<Student>();
		    ssdf.Add(new Student(){Id = 1,ParentId = 0,Name = "1"});
		    ssdf.Add(new Student() { Id = 2, ParentId = 1, Name = "21" });
		    ssdf.Add(new Student() { Id = 3, ParentId = 1, Name = "22" });
		    ssdf.Add(new Student() { Id = 4, ParentId = 2, Name = "31" });

		   var sdf=  ssdf.GenerateTree(s => s.Id, p => p.ParentId);
	    }
	}

	public class Student
	{
		public int Id { get; set; }
		public int ParentId { get; set; }
		public string Name { get; set; }	
	}
}
