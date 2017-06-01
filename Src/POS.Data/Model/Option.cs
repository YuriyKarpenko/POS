using System.Runtime.Serialization;

namespace POS.Data.Model
{
	[DataContract(IsReference = true)]
	public partial class Option : BaseModel<string>
	{
		#region Primitive Properties

		[DataMember]
		public string Value
		{
			get { return _Value; }
			set { Set(nameof(Value), value); }
		}
		private string _Value;

		public override bool IsPersisted => !string.IsNullOrEmpty(Id);

		#endregion
	}
}
