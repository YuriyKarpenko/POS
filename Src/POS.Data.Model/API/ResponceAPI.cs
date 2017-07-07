using System;
using System.Diagnostics;

namespace POS.Data.Model
{
	[Serializable]
	[DebuggerDisplay("{Result}, q:{ResultQuantity}, d:'{Data?.Substring(10)}...', e:'{Error}'")]
	public class ResponceAPI
	{
		public ResultAPI Result { get; set; }		//	result of operation
		//public Exception Error { get; set; }		//	при передаче этого поля с сервиса, клиент вызывает свой Exception
		public string Error { get; set; }			//	текст ошибки
		public string Description { get; set; }		//	reserved

		public int ResultQuantity { get; set; }		//	count of returned items for select query
		public string Data { get; set; }			//	serialized data

		public override string ToString()
		{
			return $"{base.GetType().Name} : {Result}, q:{ResultQuantity}, d:'{Data?.Substring(10)}', e:'{Error}'";
		}
	}
}
