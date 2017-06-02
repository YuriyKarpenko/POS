using System;
using System.Data.Entity.Validation;
using System.Text;

namespace POS.Data.Repositories
{
	public static class EntityFrameworkExceptionHelper
	{
		public static TRes CatchValidationErrors<TRes>(Func<TRes> action)
		{
			try
			{
				return action();
			}
			catch (DbEntityValidationException e)
			{
				throw new Exception(GetValidationMessages(e), e);
			}
		}

		private static string GetValidationMessages(DbEntityValidationException e)
		{
			var newMessage = new StringBuilder();
			newMessage.AppendLine(e.Message);

			foreach (var entityValidationError in e.EntityValidationErrors)
			{
				if (newMessage.Length > 0)
					newMessage.AppendLine();

				var entityType = entityValidationError.Entry.Entity.GetType();
				var entityTypeName = entityType.Name;
				if (entityTypeName.Contains("_") && entityType.BaseType != null)
					entityTypeName = entityType.BaseType.Name;

				newMessage.AppendFormat("Entity of type '{0}' in state '{1}' has the following validation errors:",
					entityTypeName, entityValidationError.Entry.State);

				foreach (var validationError in entityValidationError.ValidationErrors)
				{
					newMessage.AppendLine();
					if (!string.IsNullOrWhiteSpace(validationError.PropertyName))
						newMessage.AppendFormat("{0}: {1}", validationError.PropertyName, validationError.ErrorMessage);
					else
						newMessage.AppendFormat("{0}", validationError.ErrorMessage);
				}
			}
			return newMessage.ToString();
		}
	}
}