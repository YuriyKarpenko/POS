using System.ComponentModel;

namespace POS.Data.Model
{
	public enum Tables
	{
		/// <summary>
		/// счет
		/// </summary>
		Bill,	

		/// <summary>
		/// детали счета
		/// </summary>
		BillItem,

		//Check,

		/// <summary>
		/// Подразделение кухни
		/// </summary>
		Division,	

		/// <summary>
		/// Дерево групп меню
		/// </summary>
		MenuGroup,

		/// <summary>
		/// Меню в группе
		/// </summary>
		MenuItem,

		/// <summary>
		/// Параметры системы
		/// </summary>
		Option,

		/// <summary>
		/// Названия прайс-листов
		/// </summary>
		PriceList,

		/// <summary>
		/// Прайс-листы
		/// </summary>
		Price,

		/// <summary>
		/// Группы пользователей
		/// </summary>
		UserGroup,

		/// <summary>
		/// Пользователи
		/// </summary>
		User,
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