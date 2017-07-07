using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using IT;

namespace POS.Client.VM
{
	public interface IValidateMember
	{
		string BindingFormatString { get; }
		IEnumerable<string> Names { get; }
		Func<string, string> GetCaption { get; }
		Func<string, PropertyInfo> GetProperty { get; }
	}

	class M_Property<T> : IT.MemCache<string, object>
	{
		public static readonly PropertyInfo[] Properties = typeof(T)
			//.GetTypeInfo().DeclaredProperties
			.GetProperties();

		public T Value { get; private set; }

		public M_Property(T value)
		{
			Value = value;
			this.AddRange(Properties.Select(i => new KeyValuePair<string, object>(i.Name, i.GetValue(value))));
		}

		public PropertyInfo GetProperty(string name)
		{
			return Properties.FirstOrDefault(i => i.Name == name);
		}

		protected override object GetValue(string key, Func<object> getValue)
		{
			getValue = getValue ?? (() => GetProperty(key)?.GetValue(Value));
			return base.GetValue(key, getValue);
		}
		protected override void SetValue(string key, object value)
		{
			GetProperty(key)?.SetValue(Value, value);
			base.SetValue(key, value);
		}
	}

	class M_ValidationBase<T> : DynamicObject, IDataErrorInfo
	{
		protected static readonly PropertyInfo[] validateProperties = M_Property<T>.Properties
			.Where(p => p.GetCustomAttributes<ValidationAttribute>(true).Any())
			.ToArray();

		protected readonly Dictionary<string, ValidationAttribute[]> validators;


		public M_Property<T> Value { get; private set; }


		public string this[string columnName]
		{
			get
			{
				var res = string.Empty;

				if (validators.ContainsKey(columnName))
				{
					var val = Value[columnName];
					var errs = validators[columnName]
						.Where(i => !i.IsValid(val))
						.Select(i => i.ErrorMessage);
					res = string.Join(Environment.NewLine, errs);
				}

				return res;
			}
		}

		public string Error
		{
			get
			{
				var errors1 = validators
					.Join(Value, i => i.Key, i => i.Key, (v, pg) => v.Value.Where(a => !a.IsValid(pg.Value)))
					.SelectMany(i => i.Select(a => a.ErrorMessage))
					.ToArray();
				var errors = (from validator in this.validators
							  from attribute in validator.Value
							  where !attribute.IsValid(Value[validator.Key])
							  select attribute.ErrorMessage)
							 .ToArray();

				return string.Join(Environment.NewLine, errors);
			}
		}

		public M_ValidationBase(T value)
		{
			this.Value = new M_Property<T>(value);
			validators = validateProperties.ToDictionary(p => p.Name, p => p.GetCustomAttributes<ValidationAttribute>().ToArray());
		}
	}

	class M_ValidationWrapper<T> : M_ValidationBase<T>, IValidateMember
	{
		private static IEnumerable<string> NAMES = M_Property<T>.Properties
			.OrderBy(i => i.GetCustomAttribute<DisplayAttribute>()?.GetOrder() ?? 10)
			.Select(i => i.Name);

		#region IValidateMember

		public string BindingFormatString => "{0}";
		public IEnumerable<string> Names => NAMES;
		public Func<string, PropertyInfo> GetProperty => Value.GetProperty;
		public Func<string, string> GetCaption => name => GetProperty(name).GetNameFromAttributes(name);

		#endregion

		public M_ValidationWrapper(T value) : base(value) { }


		public override IEnumerable<string> GetDynamicMemberNames()
		{
			return base.GetDynamicMemberNames();
		}

		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
			//var res = base.TryGetMember(binder, out result);
			result = Value[binder.Name];
			return result != null;
		}

		public override bool TrySetMember(SetMemberBinder binder, object value)
		{
			//var res = base.TrySetMember(binder, value);
			Value[binder.Name] = value;
			return true;
		}
	}
}