using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

using IT;
using POS.Data.Model;

namespace POS.Client
{
	class ServiceClient : ILog
	{
		private static readonly ServiceClient _Instance = new ServiceClient();
		public static ServiceClient Instance => _Instance;


		private Service.Service1 svc = new Service.Service1Client();

		public User CurrentUser { get; set; }

		public ResponceAPI Execute(RequestAPI request)
		{
			//this.Debug("()");
			try
			{
				//	TODO:	must include user info
				var res = svc.UseAPI(request);
				return res;
			}
			catch (Exception ex)
			{
				this.Error(ex, "()");
				return new ResponceAPI() { Error = ex, Result = ResultAPI.ErrorService };
			}
		}

		public string Dictionary_Get(Tables tab, Dictionary<string, object> where)
		{
			try
			{
				var arg = new RequestAPI()
				{
					Action = ActionAPI.Dictionary_Get,
					Table = tab,
					Where = where
				};

				var res = Execute(arg);
				if (res.Result == ResultAPI.Ok)
				{
					return res.Data;
				}
				else
				{

				}
			}
			catch (Exception ex)
			{
				this.Error(ex, "()");
				throw;
			}

			return null;
		}

		public int Dictionary_Set(Tables tab, DataAction act, object item)
		{
			try
			{
				if (item != null)
				{
					var arg = new RequestAPI()
					{
						Action = ActionAPI.Dictionary_Set,
						DataAction = act,
						Table = tab,
						Data = JsonConvert.SerializeObject(item)
					};

					var res = Execute(arg);
					if (res.Result == ResultAPI.Ok)
					{
						return res.ResultQuantity;
					}
					else
					{

					}
				}
			}
			catch (Exception ex)
			{
				this.Error(ex, $"({tab}, {act}, {item})");
				throw;
			}

			return 0;
		}
	}
}
