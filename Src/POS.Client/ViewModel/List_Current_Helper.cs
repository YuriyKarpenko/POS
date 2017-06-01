using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace POS.Client.ViewModel
{
	public class List_Current_Helper<T> 
		where T:class//, CoderOD.DB35.Common.IDbEntityG, new()
	{
		public ObservableCollection<T> Items { get; set; }
		//private T _item;
		public T Item { get; set; }

		public List_Current_Helper(ObservableCollection<T> items, T current)
		{
			this.Items = new ObservableCollection<T>(items);
			foreach(T i in items)
				if (i == current)
				{
					this.Item = i;
					break;
				}
		}
	}
}
