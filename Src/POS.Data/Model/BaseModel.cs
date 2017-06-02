﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Data.Model
{
	public abstract class BaseModel<TKey> 
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public TKey Id { get; set; }

		public abstract bool IsPersisted { get; }
	}

#if USE_GUID
	public abstract class BaseModel : BaseModel<Guid>
	{
		public override bool IsPersisted => Id != default(Guid);
	}
#else
	public abstract class BaseModel : BaseModel<int>
	{
		public override bool IsPersisted => Id != default(int);
	}
#endif

	public abstract class PersistedModel : BaseModel
	{
		[Required]
		public DateTime DateCreated { get; set; }
		[Required]
		public DateTime DateLastModified { get; set; }
	}

	public abstract class DictionaryModel : PersistedModel
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public bool Hidden { get; set; }
	}

	public abstract class PersistedUserModel : PersistedModel
	{
		[Required]
#if USE_GUID
		public Guid CreatedByUserId { get; set; }
#else
		public int CreatedByUserId { get; set; }
#endif

		public User CreatedByUser { get; set; }
	}

	public abstract class PersistedUser2Model : PersistedUserModel
	{
#if USE_GUID
		public Guid? ModifiedByUserId { get; set; }
#else
		public int? ModifiedByUserId { get; set; }
#endif

		public User ModifiedByUser { get; set; }
	}

	[ComplexType]
	public class PersonInfo
	{
		[Required]
		public string Card { get; set; }
		[Required]
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		[Required]
		public bool SexMale { get; set; }

		public DateTime? BirthDay { get; set; }
		public string Phone { get; set; }
		public int Age => DateTime.Today.Year - BirthDay?.Year ?? 1900;

		[Required]
		public bool Hidden { get; set; }

	}
}