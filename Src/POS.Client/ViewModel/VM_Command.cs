using System;
using System.Collections.Generic;
using System.Windows.Input;

using IT;

namespace POS.Client.ViewModel
{
	public class VM_Command 
	{
		public string Caption { get; }
		public ICommand Command { get; private set; }

		//protected VM_Command() { }
		public VM_Command(string caption) { Caption = caption; }
		public VM_Command(string caption, ICommand command):this(caption)
		{
			if (command == null) throw new ArgumentNullException("command");
			this.Command = command;
		}
	}
}
