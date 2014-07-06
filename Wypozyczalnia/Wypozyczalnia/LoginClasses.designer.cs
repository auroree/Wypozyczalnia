﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Wypozyczalnia
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
    using System.Security.Cryptography;
    using System.Text;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Wypozyczalnia")]
	public partial class LoginClassesDataContext : System.Data.Linq.DataContext
	{

        public string HashMD5(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
                // To force the hex string to lower-case letters instead of
                // upper-case, use he following line instead:
                // sb.Append(hashBytes[i].ToString("x2")); 
            }
            return sb.ToString();
        }
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertUżytkownik(Użytkownik instance);
    partial void UpdateUżytkownik(Użytkownik instance);
    partial void DeleteUżytkownik(Użytkownik instance);
    #endregion
		
		public LoginClassesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LoginClassesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LoginClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LoginClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Użytkownik> Użytkowniks
		{
			get
			{
				return this.GetTable<Użytkownik>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.LoginAs", IsComposable=true)]
		public IQueryable<LoginAsResult> LoginAs([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(64)")] string nazwa, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(64)")] string haslo)
		{
			return this.CreateMethodCallQuery<LoginAsResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), nazwa, haslo);
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Użytkownik")]
	public partial class Użytkownik : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private decimal _Użytkownik_ID;
		
		private string _Nazwa;
		
		private string _Hasło;
		
		private decimal _Uprawnienia_Uprawnienia_ID;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUżytkownik_IDChanging(decimal value);
    partial void OnUżytkownik_IDChanged();
    partial void OnNazwaChanging(string value);
    partial void OnNazwaChanged();
    partial void OnHasłoChanging(string value);
    partial void OnHasłoChanged();
    partial void OnUprawnienia_Uprawnienia_IDChanging(decimal value);
    partial void OnUprawnienia_Uprawnienia_IDChanged();
    #endregion
		
		public Użytkownik()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Użytkownik_ID", AutoSync=AutoSync.OnInsert, DbType="Decimal(28,0) NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public decimal Użytkownik_ID
		{
			get
			{
				return this._Użytkownik_ID;
			}
			set
			{
				if ((this._Użytkownik_ID != value))
				{
					this.OnUżytkownik_IDChanging(value);
					this.SendPropertyChanging();
					this._Użytkownik_ID = value;
					this.SendPropertyChanged("Użytkownik_ID");
					this.OnUżytkownik_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nazwa", DbType="VarChar(64) NOT NULL", CanBeNull=false)]
		public string Nazwa
		{
			get
			{
				return this._Nazwa;
			}
			set
			{
				if ((this._Nazwa != value))
				{
					this.OnNazwaChanging(value);
					this.SendPropertyChanging();
					this._Nazwa = value;
					this.SendPropertyChanged("Nazwa");
					this.OnNazwaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Hasło", DbType="VarChar(64) NOT NULL", CanBeNull=false)]
		public string Hasło
		{
			get
			{
				return this._Hasło;
			}
			set
			{
				if ((this._Hasło != value))
				{
					this.OnHasłoChanging(value);
					this.SendPropertyChanging();
					this._Hasło = value;
					this.SendPropertyChanged("Hasło");
					this.OnHasłoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Uprawnienia_Uprawnienia_ID", DbType="Decimal(28,0) NOT NULL")]
		public decimal Uprawnienia_Uprawnienia_ID
		{
			get
			{
				return this._Uprawnienia_Uprawnienia_ID;
			}
			set
			{
				if ((this._Uprawnienia_Uprawnienia_ID != value))
				{
					this.OnUprawnienia_Uprawnienia_IDChanging(value);
					this.SendPropertyChanging();
					this._Uprawnienia_Uprawnienia_ID = value;
					this.SendPropertyChanged("Uprawnienia_Uprawnienia_ID");
					this.OnUprawnienia_Uprawnienia_IDChanged();
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
	
	public partial class LoginAsResult
	{
		
		private string _Funkcja;
		
		private string _Hasło;
		
		public LoginAsResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Funkcja", DbType="VarChar(64) NOT NULL", CanBeNull=false)]
		public string Funkcja
		{
			get
			{
				return this._Funkcja;
			}
			set
			{
				if ((this._Funkcja != value))
				{
					this._Funkcja = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Hasło", DbType="VarChar(64) NOT NULL", CanBeNull=false)]
		public string Hasło
		{
			get
			{
				return this._Hasło;
			}
			set
			{
				if ((this._Hasło != value))
				{
					this._Hasło = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
