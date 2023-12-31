﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InventoryManagement
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Database_Inventory")]
	public partial class DbzDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertTable_Product(Table_Product instance);
    partial void UpdateTable_Product(Table_Product instance);
    partial void DeleteTable_Product(Table_Product instance);
    partial void InsertTable_User(Table_User instance);
    partial void UpdateTable_User(Table_User instance);
    partial void DeleteTable_User(Table_User instance);
    partial void InsertTable_Transactions(Table_Transactions instance);
    partial void UpdateTable_Transactions(Table_Transactions instance);
    partial void DeleteTable_Transactions(Table_Transactions instance);
    #endregion
		
		public DbzDataContext() : 
				base(global::InventoryManagement.Properties.Settings.Default.Database_InventoryConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DbzDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DbzDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DbzDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DbzDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Table_Product> Table_Products
		{
			get
			{
				return this.GetTable<Table_Product>();
			}
		}
		
		public System.Data.Linq.Table<Table_User> Table_Users
		{
			get
			{
				return this.GetTable<Table_User>();
			}
		}
		
		public System.Data.Linq.Table<Table_Transactions> Table_Transactions
		{
			get
			{
				return this.GetTable<Table_Transactions>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Table_Product")]
	public partial class Table_Product : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Product_ID;
		
		private string _Product_Name;
		
		private string _Product_Details;
		
		private int _Product_Cost;
		
		private int _Product_SellingPrice;
		
		private EntitySet<Table_Transactions> _Table_Transactions;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnProduct_IDChanging(int value);
    partial void OnProduct_IDChanged();
    partial void OnProduct_NameChanging(string value);
    partial void OnProduct_NameChanged();
    partial void OnProduct_DetailsChanging(string value);
    partial void OnProduct_DetailsChanged();
    partial void OnProduct_CostChanging(int value);
    partial void OnProduct_CostChanged();
    partial void OnProduct_SellingPriceChanging(int value);
    partial void OnProduct_SellingPriceChanged();
    #endregion
		
		public Table_Product()
		{
			this._Table_Transactions = new EntitySet<Table_Transactions>(new Action<Table_Transactions>(this.attach_Table_Transactions), new Action<Table_Transactions>(this.detach_Table_Transactions));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Product_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Product_ID
		{
			get
			{
				return this._Product_ID;
			}
			set
			{
				if ((this._Product_ID != value))
				{
					this.OnProduct_IDChanging(value);
					this.SendPropertyChanging();
					this._Product_ID = value;
					this.SendPropertyChanged("Product_ID");
					this.OnProduct_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Product_Name", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string Product_Name
		{
			get
			{
				return this._Product_Name;
			}
			set
			{
				if ((this._Product_Name != value))
				{
					this.OnProduct_NameChanging(value);
					this.SendPropertyChanging();
					this._Product_Name = value;
					this.SendPropertyChanged("Product_Name");
					this.OnProduct_NameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Product_Details", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Product_Details
		{
			get
			{
				return this._Product_Details;
			}
			set
			{
				if ((this._Product_Details != value))
				{
					this.OnProduct_DetailsChanging(value);
					this.SendPropertyChanging();
					this._Product_Details = value;
					this.SendPropertyChanged("Product_Details");
					this.OnProduct_DetailsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Product_Cost", DbType="Int NOT NULL")]
		public int Product_Cost
		{
			get
			{
				return this._Product_Cost;
			}
			set
			{
				if ((this._Product_Cost != value))
				{
					this.OnProduct_CostChanging(value);
					this.SendPropertyChanging();
					this._Product_Cost = value;
					this.SendPropertyChanged("Product_Cost");
					this.OnProduct_CostChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Product_SellingPrice", DbType="Int NOT NULL")]
		public int Product_SellingPrice
		{
			get
			{
				return this._Product_SellingPrice;
			}
			set
			{
				if ((this._Product_SellingPrice != value))
				{
					this.OnProduct_SellingPriceChanging(value);
					this.SendPropertyChanging();
					this._Product_SellingPrice = value;
					this.SendPropertyChanged("Product_SellingPrice");
					this.OnProduct_SellingPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Table_Product_Table_Transaction", Storage="_Table_Transactions", ThisKey="Product_ID", OtherKey="Product_ID")]
		public EntitySet<Table_Transactions> Table_Transactions
		{
			get
			{
				return this._Table_Transactions;
			}
			set
			{
				this._Table_Transactions.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Table_Transactions(Table_Transactions entity)
		{
			this.SendPropertyChanging();
			entity.Table_Product = this;
		}
		
		private void detach_Table_Transactions(Table_Transactions entity)
		{
			this.SendPropertyChanging();
			entity.Table_Product = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Table_User")]
	public partial class Table_User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _User_ID;
		
		private string _Password;
		
		private string _Role;
		
		private EntitySet<Table_Transactions> _Table_Transactions;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUser_IDChanging(string value);
    partial void OnUser_IDChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnRoleChanging(string value);
    partial void OnRoleChanged();
    #endregion
		
		public Table_User()
		{
			this._Table_Transactions = new EntitySet<Table_Transactions>(new Action<Table_Transactions>(this.attach_Table_Transactions), new Action<Table_Transactions>(this.detach_Table_Transactions));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_User_ID", DbType="NVarChar(20) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string User_ID
		{
			get
			{
				return this._User_ID;
			}
			set
			{
				if ((this._User_ID != value))
				{
					this.OnUser_IDChanging(value);
					this.SendPropertyChanging();
					this._User_ID = value;
					this.SendPropertyChanged("User_ID");
					this.OnUser_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Role", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string Role
		{
			get
			{
				return this._Role;
			}
			set
			{
				if ((this._Role != value))
				{
					this.OnRoleChanging(value);
					this.SendPropertyChanging();
					this._Role = value;
					this.SendPropertyChanged("Role");
					this.OnRoleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Table_User_Table_Transaction", Storage="_Table_Transactions", ThisKey="User_ID", OtherKey="User_ID")]
		public EntitySet<Table_Transactions> Table_Transactions
		{
			get
			{
				return this._Table_Transactions;
			}
			set
			{
				this._Table_Transactions.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Table_Transactions(Table_Transactions entity)
		{
			this.SendPropertyChanging();
			entity.Table_User = this;
		}
		
		private void detach_Table_Transactions(Table_Transactions entity)
		{
			this.SendPropertyChanging();
			entity.Table_User = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Table_Transactions")]
	public partial class Table_Transactions : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Transaction_ID;
		
		private int _Product_ID;
		
		private int _Product_Quantity;
		
		private string _User_ID;
		
		private int _Product_SellingPrice;
		
		private System.Nullable<System.DateTime> _DateTime;
		
		private EntityRef<Table_Product> _Table_Product;
		
		private EntityRef<Table_User> _Table_User;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnTransaction_IDChanging(int value);
    partial void OnTransaction_IDChanged();
    partial void OnProduct_IDChanging(int value);
    partial void OnProduct_IDChanged();
    partial void OnProduct_QuantityChanging(int value);
    partial void OnProduct_QuantityChanged();
    partial void OnUser_IDChanging(string value);
    partial void OnUser_IDChanged();
    partial void OnProduct_SellingPriceChanging(int value);
    partial void OnProduct_SellingPriceChanged();
    partial void OnDateTimeChanging(System.Nullable<System.DateTime> value);
    partial void OnDateTimeChanged();
    #endregion
		
		public Table_Transactions()
		{
			this._Table_Product = default(EntityRef<Table_Product>);
			this._Table_User = default(EntityRef<Table_User>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Transaction_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Transaction_ID
		{
			get
			{
				return this._Transaction_ID;
			}
			set
			{
				if ((this._Transaction_ID != value))
				{
					this.OnTransaction_IDChanging(value);
					this.SendPropertyChanging();
					this._Transaction_ID = value;
					this.SendPropertyChanged("Transaction_ID");
					this.OnTransaction_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Product_ID", DbType="Int NOT NULL")]
		public int Product_ID
		{
			get
			{
				return this._Product_ID;
			}
			set
			{
				if ((this._Product_ID != value))
				{
					if (this._Table_Product.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnProduct_IDChanging(value);
					this.SendPropertyChanging();
					this._Product_ID = value;
					this.SendPropertyChanged("Product_ID");
					this.OnProduct_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Product_Quantity", DbType="Int NOT NULL")]
		public int Product_Quantity
		{
			get
			{
				return this._Product_Quantity;
			}
			set
			{
				if ((this._Product_Quantity != value))
				{
					this.OnProduct_QuantityChanging(value);
					this.SendPropertyChanging();
					this._Product_Quantity = value;
					this.SendPropertyChanged("Product_Quantity");
					this.OnProduct_QuantityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_User_ID", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string User_ID
		{
			get
			{
				return this._User_ID;
			}
			set
			{
				if ((this._User_ID != value))
				{
					if (this._Table_User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUser_IDChanging(value);
					this.SendPropertyChanging();
					this._User_ID = value;
					this.SendPropertyChanged("User_ID");
					this.OnUser_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Product_SellingPrice", DbType="Int NOT NULL")]
		public int Product_SellingPrice
		{
			get
			{
				return this._Product_SellingPrice;
			}
			set
			{
				if ((this._Product_SellingPrice != value))
				{
					this.OnProduct_SellingPriceChanging(value);
					this.SendPropertyChanging();
					this._Product_SellingPrice = value;
					this.SendPropertyChanged("Product_SellingPrice");
					this.OnProduct_SellingPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateTime", DbType="DateTime")]
		public System.Nullable<System.DateTime> DateTime
		{
			get
			{
				return this._DateTime;
			}
			set
			{
				if ((this._DateTime != value))
				{
					this.OnDateTimeChanging(value);
					this.SendPropertyChanging();
					this._DateTime = value;
					this.SendPropertyChanged("DateTime");
					this.OnDateTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Table_Product_Table_Transaction", Storage="_Table_Product", ThisKey="Product_ID", OtherKey="Product_ID", IsForeignKey=true)]
		public Table_Product Table_Product
		{
			get
			{
				return this._Table_Product.Entity;
			}
			set
			{
				Table_Product previousValue = this._Table_Product.Entity;
				if (((previousValue != value) 
							|| (this._Table_Product.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Table_Product.Entity = null;
						previousValue.Table_Transactions.Remove(this);
					}
					this._Table_Product.Entity = value;
					if ((value != null))
					{
						value.Table_Transactions.Add(this);
						this._Product_ID = value.Product_ID;
					}
					else
					{
						this._Product_ID = default(int);
					}
					this.SendPropertyChanged("Table_Product");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Table_User_Table_Transaction", Storage="_Table_User", ThisKey="User_ID", OtherKey="User_ID", IsForeignKey=true)]
		public Table_User Table_User
		{
			get
			{
				return this._Table_User.Entity;
			}
			set
			{
				Table_User previousValue = this._Table_User.Entity;
				if (((previousValue != value) 
							|| (this._Table_User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Table_User.Entity = null;
						previousValue.Table_Transactions.Remove(this);
					}
					this._Table_User.Entity = value;
					if ((value != null))
					{
						value.Table_Transactions.Add(this);
						this._User_ID = value.User_ID;
					}
					else
					{
						this._User_ID = default(string);
					}
					this.SendPropertyChanged("Table_User");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
