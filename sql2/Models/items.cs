﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sql2.Models
{
	public class items
	{
		[Key]
		public int id { get; set; }
		[Required]
		public String name { get; set; }
		[Required]
		[DisplayName("The Price")]
		[Range(10.0,1000.0,ErrorMessage ="Valeu for {0}Must Be Between {1} - {2}")]
		public decimal price { get; set; }
		[Required]
		[DisplayName("Category")]
		[ForeignKey("Category")]
		public int categoryid {get; set; }
		public Category? Category { get; set; }
		public items()
		{
		}
	}
}

