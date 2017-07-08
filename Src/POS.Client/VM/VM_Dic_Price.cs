using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using POS.Client.M;
using POS.Data.Model;

namespace POS.Client.VM
{
	class VM_Dic_Price : VM_Dic_Base<Price>
	{
		private PriceList[] priceLists;
		public PriceList[] PriceLists => priceLists ?? (priceLists = ServiceClient.Instance.Dictionary_Get<PriceList>(Data.Model.Tables.PriceList, null));

		public VM_Dic_Price(VM_Workspace parent):base(parent, "Прайс лист", Tables.Price) { }

		protected override M_ValidationWrapper<Price> GetModelWrapper(Price item)
		{
			var res = base.GetModelWrapper(item);
			res.Value["PriceLists"] = PriceLists;
			return res;
		}

		protected override void ActAdd(object sender, ExecutedRoutedEventArgs e)
		{
			base.ActAdd(sender, e);
		}

		protected override void ActEdit(object sender, ExecutedRoutedEventArgs e)
		{
			base.ActEdit(sender, e);
		}
	}
}
