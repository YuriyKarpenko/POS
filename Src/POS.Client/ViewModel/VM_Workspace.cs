using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace POS.Client.ViewModel
{
	public class VM_Workspace : VM_Base
	{
		public static class Strings
		{
			public const string
				VM_Workspace_IsModifed = "IsModifed",

				VM_Main_Command_Dics = "Справочники",
				VM_Dic_Command_Dic_Division = "Цеха",
				VM_Dic_Command_Dic_UserGroup = "Группы пользователей",
				VM_Dic_Command_Dic_User = "Пользователи";
		}

		RelayCommand _closeCommand = null;
		public ICommand CloseCommand
		{
			get
			{
				if (_closeCommand == null)
					_closeCommand = new RelayCommand(param => this.OnRequestClose());
				return _closeCommand;
			}
		}

		protected VM_Workspace() {}
		//public VM_Workspace(string caption) { this.Caption = caption; }

        #region RequestClose [event]

        public event EventHandler RequestClose;

        void OnRequestClose()
        {
            if (this.RequestClose != null)
                this.RequestClose(this, EventArgs.Empty);
        }

        #endregion // RequestClose [event]

		bool _isModifed = false;
		public virtual bool IsModifed
		{
			get { return _isModifed; }
			set
			{
				if (_isModifed == value) return;
				_isModifed = value;
				this.OnPropertyChanged("IsModifed");
			}
		}
	}
}
