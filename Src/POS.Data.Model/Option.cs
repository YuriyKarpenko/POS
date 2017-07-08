using System;

namespace POS.Data.Model
{
	/// <summary>
	/// Параметры системы
	/// </summary>
	[Serializable]
	public partial class Option : BaseModel<string>
	{
		public const string Key_ = "";

		public string Value { get; set; }

		//public override bool IsPersisted => !string.IsNullOrEmpty(Id);
	}
}
