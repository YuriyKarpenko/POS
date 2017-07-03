	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.ComponentModel.DataAnnotations;
	using System.Linq;
	using System.Reflection;

using IT;

namespace POS.Client.VM
{
	interface ICM_Property
	{
		bool IsEditMode { get; }
	}

	class CM_Property_List : ICM_Property
	{
		public bool IsEditMode { get; set; }
		public IPropertyRecord[] List { get; protected set; }


		public CM_Property_List(IPropertyRecord[] list)
		{
			this.List = list;
		}
	}

	class CM_Property_Value : ICM_Property
	{
		public bool IsEditMode { get; set; }
		public object Value { get; private set; }


		public CM_Property_Value(object value)
		{
			this.Value = value;
			//this.Value_Set(data);
		}


		//protected virtual void Value_Set(TBase value)
		//{
		//	this.Value = value;
		//}
		//protected virtual IEnumerable<IPropertyRecord> GenerateItems(TBase value)
		//{
		//	return GenerateItems<TBase>(value);
		//}
	}
}
