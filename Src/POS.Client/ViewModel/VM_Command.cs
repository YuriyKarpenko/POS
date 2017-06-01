using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace POS.Client.ViewModel
{
	public class VM_Command : VM_Base
	{
		public ICommand Command { get; private set; }

		//protected VM_Command() { }
		public VM_Command(string caption) { base.Caption = caption; }
		public VM_Command(string caption, ICommand command):this(caption)
		{
			if (command == null) throw new ArgumentNullException("command");
			this.Command = command;
		}
	}
}
