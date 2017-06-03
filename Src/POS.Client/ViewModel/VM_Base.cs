using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using IT;
using IT.WPF;

namespace POS.Client.ViewModel
{
	public abstract class VM_Base : NotifyPropertyChangedBase, ILog
	{
		
		public virtual string Caption {get; protected set;}


	}
}
