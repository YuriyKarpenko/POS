﻿using System;

namespace POS.Data.Model
{
	[Serializable]
	public abstract class BaseModel<TKey>
	{
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
		public DateTime DateCreated { get; set; }
		public DateTime DateLastModified { get; set; }

		public PersistedModel()
		{
			//	because error at json serialization
			DateCreated = DateTime.Today;
			DateLastModified = DateTime.Today;
		}
	}

	[Serializable]
	public abstract class DictionaryModel : PersistedModel
	{
		public string Name { get; set; }
		public bool Hidden { get; set; }
	}

	[Serializable]
	public abstract class PersistedUserModel : PersistedModel
	{
#if USE_GUID
		public Guid CreatedByUserId { get; set; }
#else
		public int CreatedByUserId { get; set; }
#endif

		public User CreatedByUser { get; set; }
	}

	[Serializable]
	public abstract class PersistedUser2Model : PersistedUserModel
	{
#if USE_GUID
			public Guid? ModifiedByUserId { get; set; }
#else
		public int? ModifiedByUserId { get; set; }
#endif

		public User ModifiedByUser { get; set; }
	}

	public class PersonInfo
	{
		public string Card { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public string Name => $"{FirstName} {MiddleName} {LastName}";

		public bool SexMale { get; set; }

		public DateTime? BirthDay { get; set; }
		public string Phone { get; set; }
		public int Age => DateTime.Today.Year - BirthDay?.Year ?? 1900;

		public bool Hidden { get; set; }

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