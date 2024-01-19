using System;
using System.ComponentModel.DataAnnotations;

namespace sql2.Models
{
	public class items
	{
		[Key]
		public int id { get; set; }
		[Required]
		public String name { get; set; }
		[Required]
		public decimal price { get; set; }

		public items()
		{
		}
	}
}

