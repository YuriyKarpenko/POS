using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace POS.Data.Model
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(MenuItem))]
    [KnownType(typeof(PriceList))]
    public partial class Price: INotifyPropertyChanged
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
        public System.Guid PriceListId
        {
            get { return _priceListId; }
            set
            {
                if (_priceListId != value)
                {
                    _priceListId = value;
                    OnPropertyChanged("PriceListId");
                }
            }
        }
        private System.Guid _priceListId;
    
        [DataMember]
        public System.Guid MenuItemId
        {
            get { return _menuItemId; }
            set
            {
                if (_menuItemId != value)
                {
                    _menuItemId = value;
                    OnPropertyChanged("MenuItemId");
                }
            }
        }
        private System.Guid _menuItemId;
    
        [DataMember]
        public decimal Price1
        {
            get { return _price1; }
            set
            {
                if (_price1 != value)
                {
                    _price1 = value;
                    OnPropertyChanged("Price1");
                }
            }
        }
        private decimal _price1;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public MenuItem MenuItem
        {
            get { return _menuItem; }
            set
            {
                if (!ReferenceEquals(_menuItem, value))
                {
                    _menuItem = value;
                    OnNavigationPropertyChanged("MenuItem");
                }
            }
        }
        private MenuItem _menuItem;
    
        [DataMember]
        public PriceList PriceList
        {
            get { return _priceList; }
            set
            {
                if (!ReferenceEquals(_priceList, value))
                {
                    _priceList = value;
                    OnNavigationPropertyChanged("PriceList");
                }
            }
        }
        private PriceList _priceList;

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
