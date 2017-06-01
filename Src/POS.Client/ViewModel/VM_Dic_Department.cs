using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.Client.ViewModel
{
	public class VM_Dic_Division : VM_Dic_Base<POS.Data.Model.Division>
	{
		public VM_Dic_Division(VM_Workspace parent) : base(parent, "Цех") { }

		public override void Load()
		{
			itemsClear();
			foreach (var x in this.svc.DivisionsGet(null))
			{
				_items.Add(x);
			}
		}

		public override void Delete(POS.Data.Model.Division item) { this.svc.DivisionDel(item); }

		public override void Add(POS.Data.Model.Division item) { this.svc.DivisionIns(item); }

		public override void Edit(POS.Data.Model.Division item) { this.svc.DivisionUpd(item); }

	}
}
