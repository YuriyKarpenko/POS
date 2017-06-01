using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace POS.Client.ViewModel
{
	public abstract class VM_Base : INotifyPropertyChanged, IDisposable
	{
		#region Fields
		
		public event PropertyChangedEventHandler PropertyChanged;
		public bool ThrowOnInvalidPropertyName {get; protected set;}
		public virtual string Caption {get; protected set;}

		#endregion

		#region Constructor

		protected VM_Base() { this.ThrowOnInvalidPropertyName = true; }

		#endregion

		#region Debugging And NotifyPropertyChanged

		[Conditional("DEBUG")]
		[DebuggerStepThrough]
		public void VerifyPropertyName(string propertyName)
		{
			// Verify that the property name matches a real,  
			// public, instance property on this object.
			if (TypeDescriptor.GetProperties(this)[propertyName] == null)
			{
				string msg = "Invalid property name: " + propertyName;

				if (this.ThrowOnInvalidPropertyName) throw new Exception(msg);
				else
					Debug.Fail(msg);
			}
		}

		protected virtual void OnPropertyChanged(string propertyName)
		{
			this.VerifyPropertyName(propertyName);

			if (this.PropertyChanged != null)
			{
				var e = new PropertyChangedEventArgs(propertyName);
				this.PropertyChanged(this, e);
			}
		}

		#endregion

		#region Disposing

		protected virtual void OnDispose() { }

		public void Dispose() { OnDispose(); }

#if DEBUG
		~VM_Base()
		{
			string msg = string.Format("{0} ({1}) ({2}) Finalized", this.GetType().Name, this.Caption, this.GetHashCode());
			System.Diagnostics.Debug.WriteLine(msg);
		}
#endif
		#endregion
	}
}
