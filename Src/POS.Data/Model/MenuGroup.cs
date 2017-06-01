//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace POS.Data.Model
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(MenuGroup))]
    [KnownType(typeof(MenuItem))]
    public partial class MenuGroup: INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public System.Guid Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        private System.Guid _id;
    
        [DataMember]
        public Nullable<System.Guid> Parent
        {
            get { return _parent; }
            set
            {
                if (_parent != value)
                {
                    _parent = value;
                    OnPropertyChanged("Parent");
                }
            }
        }
        private Nullable<System.Guid> _parent;
    
        [DataMember]
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private string _name;
    
        [DataMember]
        public int Order
        {
            get { return _order; }
            set
            {
                if (_order != value)
                {
                    _order = value;
                    OnPropertyChanged("Order");
                }
            }
        }
        private int _order;
    
        [DataMember]
        public bool Hidden
        {
            get { return _hidden; }
            set
            {
                if (_hidden != value)
                {
                    _hidden = value;
                    OnPropertyChanged("Hidden");
                }
            }
        }
        private bool _hidden;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public ObservableCollection<MenuGroup> MenuGroup1
        {
            get
            {
                if (_menuGroup1 == null)
                {
                    _menuGroup1 = new ObservableCollection<MenuGroup>();
                }
                return _menuGroup1;
            }
            set
            {
                if (!ReferenceEquals(_menuGroup1, value))
                {
                    _menuGroup1 = value;
                    OnNavigationPropertyChanged("MenuGroup1");
                }
            }
        }
        private ObservableCollection<MenuGroup> _menuGroup1;
    
        [DataMember]
        public MenuGroup MenuGroup2
        {
            get { return _menuGroup2; }
            set
            {
                if (!ReferenceEquals(_menuGroup2, value))
                {
                    _menuGroup2 = value;
                    OnNavigationPropertyChanged("MenuGroup2");
                }
            }
        }
        private MenuGroup _menuGroup2;
    
        [DataMember]
        public ObservableCollection<MenuItem> MenuItems
        {
            get
            {
                if (_menuItems == null)
                {
                    _menuItems = new ObservableCollection<MenuItem>();
                }
                return _menuItems;
            }
            set
            {
                if (!ReferenceEquals(_menuItems, value))
                {
                    _menuItems = value;
                    OnNavigationPropertyChanged("MenuItems");
                }
            }
        }
        private ObservableCollection<MenuItem> _menuItems;

        #endregion
        #region ChangeTracking
    
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged{ add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
    

        #endregion
    }
}
