using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace POS.Data.Model
{
	[Serializable]
	[DebuggerDisplay("act:{Action}, user:{UserId}")]
	public class RequestAPI
	{
		//	authentification
		//public string User_Card { get; set; }
		/// <summary>
		/// user authentification
		/// </summary>
		public string User_Login { get; set; }
		/// <summary>
		/// user authentification
		/// </summary>
		public string User_Password { get; set; }

		//	actions
		public ActionAPI Action { get; set; }
		/// <summary>
		/// user identification (card or token)
		/// </summary>
		public string UserId { get; set; }
		public Tables Table { get; set; }
		public DataAction DataAction { get; set; }
		/// <summary>
		/// Dictionary<[field], [condition]>
		/// </summary>
		public Dictionary<string, object> WhereEqual { get; set; }

		/// <summary>
		/// addition serialized data
		/// </summary>
		public string Data { get; set; }	
		/// <summary>
		/// addition info
		/// </summary>
		public string Tag { get; set; }

		public override string ToString()
		{
			return $"{base.GetType().Name}, act:{Action}, user:{UserId}";
		}
	}
}
