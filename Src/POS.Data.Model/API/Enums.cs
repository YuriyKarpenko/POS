using System.ComponentModel;

namespace POS.Data.Model
{
	public enum Tables
	{
		Bill,
		BillItem,
		//Check,
		Division,
		MenuGroup,
		MenuItem,
		Option,
		Price,
		PriceList,
		User,
		UserGroup,
	}

	public enum IdColumn
	{
		BillId,
		BillItemId,
		DivisionId,
		Id,
		MenuGroupId,
		MenuItemId,
		UserId,
		UserCreatedId,
		UserModifiedId,
	}

	public enum DataAction
	{
		Delete,
		Insert,
		Update
	}

	public enum ActionAPI {
		[Description("")]
		Login,
		[Description("Получение справочников")]
		Dictionary_Get,
		[Description("Изменение справочников")]
		Dictionary_Set,

	}

	public enum ResultAPI
	{
		Ok,
		Permission,
		ErrorDB,
		ErrorService,
		ErrorOther
	}
}