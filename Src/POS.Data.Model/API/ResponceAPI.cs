using System;
using System.Diagnostics;

namespace POS.Data.Model
{
	[Serializable]
	[DebuggerDisplay("{Result}, q:{ResultQuantity}, d:'{Data?.Substring(10)}...', e:'{Error.Message}'")]
	public class ResponceAPI
	{
		public ResultAPI Result { get; set; }
		public Exception Error { get; set; }
		public string Description { get; set; }

		public int ResultQuantity { get; set; }
		public string Data { get; set; }        //	addition serialized data

		public override string ToString()
		{
			return $"{base.GetType().Name} : {Result}, q:{ResultQuantity}, d:'{Data?.Substring(10)}', e:'{Error.Message}'";
		}
	}
}
