using System;
using System.Collections.Generic;

namespace Navigation_View
{
	public class AccountCore
	{
		public static IDictionary<string, string> Dictionary(string FName, string Email, string Password)
		{
			IDictionary<string, string> d = new Dictionary<string, string> ();
			d.Add ("FName", FName);
			d.Add ("Password", Password);
			d.Add ("Email", Email);
			return d;
		}
	}
}

