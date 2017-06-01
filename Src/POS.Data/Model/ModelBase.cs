using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;

namespace POS.Data.Model
{
	public abstract class BaseModel<TKey> : INotifyPropertyChanged
	{
		private event PropertyChangedEventHandler _propertyChanged;
		event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged { add { _propertyChanged += value; } remove { _propertyChanged -= value; } }

		//private IT.MemCache<string, PropertyInfo> _cache = new IT.MemCache<string, PropertyInfo>();

		[DataMember]
		public TKey Id { get; set; }

		public abstract bool IsPersisted { get; }


		protected virtual void OnPropertyChanged(String propertyName)
		{
			if (_propertyChanged != null)
			{
				_propertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		protected T Get<T>(string name)
		{
			var p = pi(name);
			return (T)p.GetValue(this);
		}

		protected void Set(string name, object value)
		{
			var p = pi(name);
			var v = p.GetValue(this);
			if (!value.Equals(v))
			{
				p.SetValue(this, v);
				OnPropertyChanged(name);
			}
		}
		protected void SetNav(string name, object value)
		{
			var p = pi(name);
			var v = p.GetValue(this);
			if (!ReferenceEquals(value, v))
			{
				p.SetValue(this, v);
				OnPropertyChanged(name);
			}
		}


		private FieldInfo pi(string name)
		{
			//return _cache[name, () => this.GetType().GetProperty(name)];
			return this.GetType().GetField("_"+name);
		}
	}

	public abstract class BaseModel : BaseModel<Guid>
	{
		public override bool IsPersisted => Id != default(Guid);
	}

	public abstract class PersistedModel : BaseModel
	{
		[DataMember]
		public DateTime DateCreated
		{
			get { return _DateCreated; }
			set { Set(nameof(DateCreated), value); }
		}
		private DateTime _DateCreated;

		[DataMember]
		public DateTime DateLastModified
		{
			get { return _DateLastModified; }
			set { Set(nameof(DateLastModified), value); }
		}
		private DateTime _DateLastModified;
	}

	public abstract class DictionaryModel : PersistedModel
	{
		[DataMember]
		public string Name
		{
			get { return _Name; }
			set { Set(nameof(Name), value); }
		}
		private string _Name;

		[DataMember]
		public bool Hidden
		{
			get { return _Hidden; }
			set { Set(nameof(Hidden), value); }
		}
		private bool _Hidden;

	}

	[KnownType(typeof(User))]
	public abstract class PersistedUserModel : PersistedModel
	{
		[DataMember]
		public Guid CreatedByUserId
		{
			get { return _CreatedByUserId; }
			set { Set(nameof(CreatedByUserId), value); }
		}
		private Guid _CreatedByUserId;


		[DataMember]
		public User CreatedByUser
		{
			get { return _CreatedByUser; }
			set { SetNav(nameof(CreatedByUser), value); }
		}
		private User _CreatedByUser;
	}

	[KnownType(typeof(User))]
	public abstract class PersistedUser2Model : PersistedUserModel
	{
		[DataMember]
		public Guid? ModifiedByUserId
		{
			get { return _ModifiedByUserId; }
			set { Set(nameof(ModifiedByUserId), value); }
		}
		private Guid? _ModifiedByUserId;


		[DataMember]
		public User ModifiedByUser
		{
			get { return _ModifiedByUser; }
			set { SetNav(nameof(ModifiedByUser), value); }
		}
		private User _ModifiedByUser;
	}

}
