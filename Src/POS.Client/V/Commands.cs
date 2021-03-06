﻿using System.Windows.Input;

namespace POS.Client.V
{
	public static class Commands
	{
		public static readonly RoutedUICommand Main_Options = new RoutedUICommand("Настройки", "Main_Options", typeof(Commands));
		public static readonly RoutedUICommand Main_Manager = new RoutedUICommand("Менеджер", "Main_Manager", typeof(Commands));

		public static readonly RoutedUICommand CloseItem = new RoutedUICommand("Закрыть", "CloseItem", typeof(Commands));

		public static readonly RoutedUICommand Nav_Ok = new RoutedUICommand("Ok", "Nav_Ok", typeof(Commands));
		public static readonly RoutedUICommand Nav_Cancel = new RoutedUICommand("Отмена", "Nav_Cancel", typeof(Commands));

		public static readonly RoutedUICommand Nav_Refresh = new RoutedUICommand("Обновить", "Nav_Refresh", typeof(Commands));
		public static readonly RoutedUICommand Nav_Delete = new RoutedUICommand("Удалить", "Nav_Delete", typeof(Commands));
		public static readonly RoutedUICommand Nav_Insert = new RoutedUICommand("Добавить", "Nav_Insert", typeof(Commands));
		public static readonly RoutedUICommand Nav_Edit = new RoutedUICommand("Изменить", "Nav_Edit", typeof(Commands));
		public static readonly RoutedUICommand Nav_Save = new RoutedUICommand("Сохранить", "Nav_Save", typeof(Commands));

		//	справочники
		public static readonly RoutedUICommand Dic = new RoutedUICommand("Справочники", "Dic", typeof(Commands));

		public static readonly RoutedUICommand Dic_Division = new RoutedUICommand("Цеха", "Dic_Division", typeof(Commands));

		public static readonly RoutedUICommand Dic_MenuGroup = new RoutedUICommand("Группы меню", "Dic_MenuGroup", typeof(Commands));
		public static readonly RoutedUICommand Dic_MenuItem = new RoutedUICommand("Меню", "Dic_MenuItem", typeof(Commands));

		public static readonly RoutedUICommand Dic_PriceList = new RoutedUICommand("Прайс листы", "Dic_PriceList", typeof(Commands));
		public static readonly RoutedUICommand Dic_Price = new RoutedUICommand("Прайс лист", "Dic_Price", typeof(Commands));

		public static readonly RoutedUICommand Dic_UserGroup = new RoutedUICommand("Группы пльзовтелей", "Dic_UserGroup", typeof(Commands));
		public static readonly RoutedUICommand Dic_User = new RoutedUICommand("Пользователи", "Dic_User", typeof(Commands));


		static Commands()
		{
		}
	}
}
