using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrohisUploadLib.Accounts
{
	internal class Authentification
	{
		internal string AccessToken { get; set; }
		internal string RefreshToken { get; set; }
		internal string Type { get; set; }
		internal DateTime ExpireDate { get; set; }
	}
}
