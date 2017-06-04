namespace POS.Data.Model
{
	public partial class Option : BaseModel<string>
	{
		public string Value { get; set; }

		//public override bool IsPersisted => !string.IsNullOrEmpty(Id);
	}
}
