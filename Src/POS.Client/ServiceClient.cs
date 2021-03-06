﻿using System;
using System.Collections.Generic;

using IT;
using Newtonsoft.Json;
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
				return new ResponceAPI() { Error = ex.Message, Result = ResultAPI.ErrorService };
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
					WhereEqual = where
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
		public T[] Dictionary_Get<T>(Tables tab, Dictionary<string, object> where)
		{
			var json = Dictionary_Get(tab, where);
			if (!string.IsNullOrEmpty(json))
				return JsonConvert.DeserializeObject<T[]>(json);
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
						//this.Error(null, $"({tab}, {act}, {item}) {res.Error}");
						throw new Exception(res.Error);
					}
				}
			}
			catch (Exception ex)
			{
				this.Warn(ex, $"({tab}, {act}, {item})");
				throw;
			}

			return 0;
		}
	}
}
