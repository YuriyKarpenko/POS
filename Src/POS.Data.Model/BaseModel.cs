using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace POS.Data.Model
{
	[Serializable]
	public abstract partial class BaseModel<TKey>
	{
		[Key]
		[Display(Order = 1), Editable(false)]
		public TKey Id { get; set; }
		//public abstract bool IsPersisted { get; }
	}

#if USE_GUID
	public interface IBaseModel
	{
		Guid Id { get; }
		//bool IsPersisted { get; }
	}
	public abstract class BaseModel : BaseModel<Guid>
	{
		//public override bool IsPersisted => Id != default(Guid);
	}
#else
	public interface IBaseModel
	{
		int Id { get; }
		//bool IsPersisted { get; }
	}
	[Serializable]
	public abstract class BaseModel : BaseModel<int>
	{
		//public override bool IsPersisted => Id != default(int);
	}
#endif

	public interface IPersistedModel : IBaseModel
	{
		DateTime DateCreated { get; set; }
		DateTime DateLastModified { get; set; }
	}
	[Serializable]
	public abstract class PersistedModel : BaseModel, IPersistedModel
	{
		[Required(AllowEmptyStrings = false, ErrorMessage = "Поле обязательно")]
		[Display(Name = "Дата создания", Order = 4), Editable(false)]
		public DateTime DateCreated { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Поле обязательно")]
		[Display(Name = "Дата изменения", Order = 6), Editable(false)]
		public DateTime DateLastModified { get; set; }

		public PersistedModel()
		{
			//	because error at json serialization
			DateCreated = DateTime.Now;
			DateLastModified = DateTime.Now;
		}
	}

	[Serializable]
	public abstract class DictionaryModel : PersistedModel
	{
		[Required(AllowEmptyStrings = false, ErrorMessage = "Поле обязательно")]
		[Display(Name = "Название", Order = 8)]
		public string Name { get; set; }

		[Display(Name = "Скрыть", Order = 2)]
		public bool Hidden { get; set; }
	}

	[Serializable]
	public abstract class PersistedUserModel : PersistedModel
	{
		[Browsable(false)]
#if USE_GUID
		public Guid CreatedByUserId { get; set; }
#else
		public int CreatedByUserId { get; set; }
#endif

		[Browsable(false)]
		public User CreatedByUser { get; set; }
	}

	[Serializable]
	public abstract class PersistedUser2Model : PersistedUserModel
	{
		[Browsable(false)]
#if USE_GUID
			public Guid? ModifiedByUserId { get; set; }
#else
		public int? ModifiedByUserId { get; set; }
#endif

		[Browsable(false)]
		public User ModifiedByUser { get; set; }
	}

	public class PersonInfo
	{
		[Required(AllowEmptyStrings = false, ErrorMessage = "Поле обязательно")]
		[Display(Name = "Карта", Order = 11), Editable(true)]
		public string Card { get; set; }

		[Display(Name = "Фамилия", Order = 12), Editable(true)]
		public string LastName { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Поле обязательно")]
		[Display(Name = "Имя", Order = 13), Editable(true)]
		public string FirstName { get; set; }

		[Display(Name = "Отчество", Order = 14), Editable(true)]
		public string MiddleName { get; set; }

		[Display(Name = "ФИО", Order = 15), Editable(false)]
		public string Name => $"{FirstName} {MiddleName} {LastName}";

		[Display(Name = "Пол (м)", Order = 16), Editable(true)]
		public bool SexMale { get; set; }

		[Display(Name = "Дата рождения", Order = 17), Editable(true)]
		public DateTime? BirthDay { get; set; }

		[Display(Name = "Возраст", Order = 18), Editable(false)]
		public int Age => DateTime.Today.Year - BirthDay?.Year ?? 1900;

		[Display(Name = "Телефон", Order = 19), Editable(false)]
		public string Phone { get; set; }

	}

	//	[ComplexType]
	//	public class UserInfo
	//	{
	//#if USE_GUID
	//		public Guid CreatedByUserId { get; set; }
	//#else
	//		public int UserId { get; set; }
	//#endif

	//		public User User { get; set; }
	//	}
}
