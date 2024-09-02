using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tibia.Ciclopedia.Application.BaseOutput
{
	public class Output<T>
	{
		public bool IsValid { get; set; }
		public List<string> Errors { get; set; }
		public T Result { get; set; }

		public Output()
		{
			Errors = new List<string>();
		}

		public static Output<T> Success(T result)
		{
			return new Output<T> { IsValid = true, Result = result };
		}

		public static Output<T> Failure(List<string> errors)
		{
			return new Output<T> { IsValid = false, Errors = errors };
		}
	}
}
