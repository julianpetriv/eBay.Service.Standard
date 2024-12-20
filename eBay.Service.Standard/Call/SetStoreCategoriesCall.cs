#region Copyright
//	Copyright (c) 2013 eBay, Inc.
//	
//	This program is licensed under the terms of the eBay Common Development and
//	Distribution License (CDDL) Version 1.0 (the "License") and any subsequent  
//	version thereof released by eBay.  The then-current version of the License can be 
//	found at http://www.opensource.org/licenses/cddl1.php and in the eBaySDKLicense 
//	file that is under the eBay SDK ../docs directory
#endregion

#region Namespaces
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using eBay.Service.EPS;
using eBay.Service.Util;

#endregion

namespace eBay.Service.Call
{

	/// <summary>
	/// 
	/// </summary>
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	public class SetStoreCategoriesCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public SetStoreCategoriesCall()
		{
			ApiRequest = new SetStoreCategoriesRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public SetStoreCategoriesCall(ApiContext ApiContext)
		{
			ApiRequest = new SetStoreCategoriesRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// This call allows you to set or modify the category structure of an eBay Store. Sellers must have an eBay Store subscription in order to use this call.
		/// </summary>
		/// 
		/// <param name="Action">
		/// Specifies the type of action (Add, Move, Delete, or Rename) to carry out
		/// for the specified eBay Store categories.
		/// </param>
		///
		/// <param name="ItemDestinationCategoryID">
		/// Items can only be contained within child categories. A parent category
		/// cannot contain items. If adding, moving, or deleting categories displaces
		/// items, you must specify a destination child category under which the
		/// displaced items will be moved. The destination category must have no
		/// child categories.
		/// </param>
		///
		/// <param name="DestinationParentCategoryID">
		/// When adding or moving store categories, specifies the category under
		/// which the listed categories will be located. To add or move categories to
		/// the top level, set the value to -999.
		/// </param>
		///
		/// <param name="StoreCategoryList">
		/// Specifies the store categories on which to act.
		/// </param>
		///
		public long SetStoreCategories(StoreCategoryUpdateActionCodeType Action, long ItemDestinationCategoryID, long DestinationParentCategoryID, List<StoreCustomCategoryType> StoreCategoryList)
		{
			this.Action = Action;
			this.ItemDestinationCategoryID = ItemDestinationCategoryID;
			this.DestinationParentCategoryID = DestinationParentCategoryID;
			this.StoreCategoryList = StoreCategoryList;

			Execute();
			return ApiResponse.TaskID.Value;
		}


		public long SetStoreCategories(StoreCategoryUpdateActionCodeType Action, List<StoreCustomCategoryType> StoreCategoryList)
		{
			this.Action = Action;
			this.StoreCategoryList = StoreCategoryList;

			Execute();
			return ApiResponse.TaskID.Value;
		}
		#endregion




		#region Properties
		/// <summary>
		/// The base interface object.
		/// </summary>
		/// <remarks>This property is reserved for users who have difficulty querying multiple interfaces.</remarks>
		public ApiCall ApiCallBase
		{
			get { return this; }
		}

		/// <summary>
		/// Gets or sets the <see cref="SetStoreCategoriesRequestType"/> for this API call.
		/// </summary>
		public SetStoreCategoriesRequestType ApiRequest
		{ 
			get { return (SetStoreCategoriesRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="SetStoreCategoriesResponseType"/> for this API call.
		/// </summary>
		public SetStoreCategoriesResponseType ApiResponse
		{ 
			get { return (SetStoreCategoriesResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="SetStoreCategoriesRequestType.Action"/> of type <see cref="StoreCategoryUpdateActionCodeType"/>.
		/// </summary>
		public StoreCategoryUpdateActionCodeType Action
		{ 
			get { return ApiRequest.Action.Value; }
			set { ApiRequest.Action = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetStoreCategoriesRequestType.ItemDestinationCategoryID"/> of type <see cref="long"/>.
		/// </summary>
		public long ItemDestinationCategoryID
		{ 
			get { return ApiRequest.ItemDestinationCategoryID.Value; }
			set { ApiRequest.ItemDestinationCategoryID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetStoreCategoriesRequestType.DestinationParentCategoryID"/> of type <see cref="long"/>.
		/// </summary>
		public long DestinationParentCategoryID
		{ 
			get { return ApiRequest.DestinationParentCategoryID.Value; }
			set { ApiRequest.DestinationParentCategoryID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetStoreCategoriesRequestType.StoreCategories"/> of type <see cref="StoreCustomCategoryTypeCollection"/>.
		/// </summary>
		public List<StoreCustomCategoryType> StoreCategoryList
		{ 
			get { return ApiRequest.StoreCategories; }
			set { ApiRequest.StoreCategories = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="SetStoreCategoriesResponseType.TaskID"/> of type <see cref="long"/>.
		/// </summary>
		public long TaskID
		{ 
			get { return ApiResponse.TaskID.Value; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="SetStoreCategoriesResponseType.Status"/> of type <see cref="TaskStatusCodeType"/>.
		/// </summary>
		public TaskStatusCodeType Status
		{ 
			get { return ApiResponse.Status.Value; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="SetStoreCategoriesResponseType.CustomCategory"/> of type <see cref="StoreCustomCategoryTypeCollection"/>.
		/// </summary>
		public List<StoreCustomCategoryType> CustomCategoryList
		{ 
			get { return ApiResponse.CustomCategory; }
		}
		

		#endregion

		
	}
}
