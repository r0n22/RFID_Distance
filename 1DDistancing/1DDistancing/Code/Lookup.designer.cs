﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _1DDistancing.Code
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
	
	
	public partial class LookupTable : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertDistance_Measurements(Distance_Measurements instance);
    partial void UpdateDistance_Measurements(Distance_Measurements instance);
    partial void DeleteDistance_Measurements(Distance_Measurements instance);
    partial void InsertLookupData(LookupData instance);
    partial void UpdateLookupData(LookupData instance);
    partial void DeleteLookupData(LookupData instance);
    #endregion
		
		public LookupTable(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LookupTable(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LookupTable(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LookupTable(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Distance_Measurements> Distance_Measurements
		{
			get
			{
				return this.GetTable<Distance_Measurements>();
			}
		}
		
		public System.Data.Linq.Table<LookupData> LookupData
		{
			get
			{
				return this.GetTable<LookupData>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute()]
	public partial class Distance_Measurements : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Exact_Measurements;
		
		private int _Avg_Measurement;
		
		private int _DFT_Measurement;
		
		private int _Id;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnExact_MeasurementsChanging(int value);
    partial void OnExact_MeasurementsChanged();
    partial void OnAvg_MeasurementChanging(int value);
    partial void OnAvg_MeasurementChanged();
    partial void OnDFT_MeasurementChanging(int value);
    partial void OnDFT_MeasurementChanged();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    #endregion
		
		public Distance_Measurements()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Exact_Measurements", DbType="Int NOT NULL")]
		public int Exact_Measurements
		{
			get
			{
				return this._Exact_Measurements;
			}
			set
			{
				if ((this._Exact_Measurements != value))
				{
					this.OnExact_MeasurementsChanging(value);
					this.SendPropertyChanging();
					this._Exact_Measurements = value;
					this.SendPropertyChanged("Exact_Measurements");
					this.OnExact_MeasurementsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Avg_Measurement", DbType="Int NOT NULL")]
		public int Avg_Measurement
		{
			get
			{
				return this._Avg_Measurement;
			}
			set
			{
				if ((this._Avg_Measurement != value))
				{
					this.OnAvg_MeasurementChanging(value);
					this.SendPropertyChanging();
					this._Avg_Measurement = value;
					this.SendPropertyChanged("Avg_Measurement");
					this.OnAvg_MeasurementChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DFT_Measurement", DbType="Int NOT NULL")]
		public int DFT_Measurement
		{
			get
			{
				return this._DFT_Measurement;
			}
			set
			{
				if ((this._DFT_Measurement != value))
				{
					this.OnDFT_MeasurementChanging(value);
					this.SendPropertyChanging();
					this._DFT_Measurement = value;
					this.SendPropertyChanged("DFT_Measurement");
					this.OnDFT_MeasurementChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="id", Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute()]
	public partial class LookupData : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _Distance;
		
		private int _Q;
		
		private int _I;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnDistanceChanging(int value);
    partial void OnDistanceChanged();
    partial void OnQChanging(int value);
    partial void OnQChanged();
    partial void OnIChanging(int value);
    partial void OnIChanged();
    #endregion
		
		public LookupData()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="id", Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="distance", Storage="_Distance", DbType="Int NOT NULL")]
		public int Distance
		{
			get
			{
				return this._Distance;
			}
			set
			{
				if ((this._Distance != value))
				{
					this.OnDistanceChanging(value);
					this.SendPropertyChanging();
					this._Distance = value;
					this.SendPropertyChanged("Distance");
					this.OnDistanceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Q", DbType="Int NOT NULL")]
		public int Q
		{
			get
			{
				return this._Q;
			}
			set
			{
				if ((this._Q != value))
				{
					this.OnQChanging(value);
					this.SendPropertyChanging();
					this._Q = value;
					this.SendPropertyChanged("Q");
					this.OnQChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_I", DbType="Int NOT NULL")]
		public int I
		{
			get
			{
				return this._I;
			}
			set
			{
				if ((this._I != value))
				{
					this.OnIChanging(value);
					this.SendPropertyChanging();
					this._I = value;
					this.SendPropertyChanged("I");
					this.OnIChanged();
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
