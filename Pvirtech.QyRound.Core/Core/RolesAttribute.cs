using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvirtech.QyRound.Core
{

	[AttributeUsage(AttributeTargets.Class|AttributeTargets.Method|AttributeTargets.Property, AllowMultiple = false)]
	public class RolesAttribute : Attribute
	{
		public string[] Roles { get; set; }

		public RolesAttribute(params string[] roles)
		{
			Roles = roles;
		}
	}
}
