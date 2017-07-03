namespace POS.Client.VM
{
	public class VM_Workspace : VM_Base
	{
		protected readonly VM_Workspace VM_Parent;

		public virtual string Caption { get; private set; }
		protected void SetCaption(string caption)
		{
			Caption = caption;
			OnPropertyChanged(nameof(Caption));
		}

		private bool _isModifed = false;
		public virtual bool IsModifed
		{
			get { return _isModifed; }
			set
			{
				if (_isModifed == value) return;
				_isModifed = value;
				this.OnPropertyChanged(nameof(IsModifed));
			}
		}


		public VM_Workspace(VM_Workspace vmParent, string caption)
		{
			VM_Parent = vmParent;
			Caption = caption;
		}

	}
}
