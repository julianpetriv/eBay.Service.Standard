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
	public class AddFixedPriceItemCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public AddFixedPriceItemCall()
		{
			ApiRequest = new AddFixedPriceItemRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public AddFixedPriceItemCall(ApiContext ApiContext)
		{
			ApiRequest = new AddFixedPriceItemRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Defines and lists a new fixed-price listing.
		/// The main difference between <b>AddFixedPriceItem</b> and <b>AddItem</b> is that
		/// <b>AddFixedPriceItem</b> supports the creation of fixed-price listings only,
		/// whereas <b>AddItem</b> supports all listing formats.
		/// 
		/// 
		/// Also, only <b>AddFixedPriceItem</b> supports multi-variation listings
		/// and tracking inventory by SKU. <b>AddItem</b> does not support
		/// Variations or the <b>InventoryTrackingMethod</b> field.
		/// </summary>
		/// 
		/// <param name="Item">
		/// This container is used to specify all of the values and settings that define a new fixed-price listing.
		/// </param>
		///
		public List<FeeType> AddFixedPriceItem(ItemType Item)
		{
			this.Item = Item;

			Execute();
			return ApiResponse.Fees;
		}

		/// <summary>
		/// 
		/// </summary>
		public override void Execute()
		{
			if (Item != null)
			{

				if ((Item.UUID == null || Item.UUID.Length == 0) && AutoSetItemUUID)
				{
					Item.UUID = NewUUID();
				}

				if (ApiContext.EPSServerUrl != null && PictureFileList != null && PictureFileList.Count > 0)
				{
					eBayPictureService eps = new eBayPictureService(ApiContext);

					if (Item.PictureDetails == null)
					{
						Item.PictureDetails = new PictureDetailsType();
					}
					try
					{
						Item.PictureDetails.PictureURL = new List<String>();
						Item.PictureDetails.PictureURL.AddRange(eps.UpLoadPictureFiles(PictureFileList.ToArray()));
					} 
					catch (Exception ex)
					{
						LogMessage(ex.Message, MessageType.Exception, MessageSeverity.Error);
						throw new SdkException(ex.Message, ex);
					}
					
				}
			}

			base.Execute();

			Item.ItemID = ApiResponse.ItemID;

			if (Item.ListingDetails == null)
				Item.ListingDetails = new ListingDetailsType();
			Item.ListingDetails.StartTime = ApiResponse.StartTime;
			Item.ListingDetails.EndTime = ApiResponse.EndTime;

			if (ApiResponse.CategoryID != null && ApiResponse.CategoryID.Length > 0)
			{
				if (Item.PrimaryCategory == null)
					Item.PrimaryCategory = new CategoryType();

				Item.PrimaryCategory.CategoryID = ApiResponse.CategoryID;
			}
			if (ApiResponse.Category2ID != null && ApiResponse.Category2ID.Length > 0)
			{
				if (Item.SecondaryCategory == null)
					Item.SecondaryCategory = new CategoryType();

				Item.SecondaryCategory.CategoryID = ApiResponse.Category2ID;
			}
		}


		#endregion



		#region Static Methods
		/// <summary>
		/// Generates a universal unique identifier.
		/// </summary>
		/// <returns>A universal unique identifier of type <see cref="string"/></returns>
		public static string NewUUID()
		{
			return System.Guid.NewGuid().ToString().Replace("-", "").ToString();
		}

		/// <summary>
		/// Sets or overwrites the <see cref="ItemType.UUID"/>.
		/// </summary>
		/// <param name="Item">The item to assign a universal unique identifier to.</param>
		public static void ResetItemUUID(ItemType Item)
		{
			Item.UUID = NewUUID();
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
		/// Gets or sets the <see cref="AddFixedPriceItemRequestType"/> for this API call.
		/// </summary>
		public AddFixedPriceItemRequestType ApiRequest
		{ 
			get { return (AddFixedPriceItemRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="AddFixedPriceItemResponseType"/> for this API call.
		/// </summary>
		public AddFixedPriceItemResponseType ApiResponse
		{ 
			get { return (AddFixedPriceItemResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="AddFixedPriceItemRequestType.Item"/> of type <see cref="ItemType"/>.
		/// </summary>
		public ItemType Item
		{ 
			get { return ApiRequest.Item; }
			set { ApiRequest.Item = value; }
		}
		/// <summary>
		///
		/// </summary>
										public bool AutoSetItemUUID
		{ 
			get { return mAutoSetItemUUID; }
			set { mAutoSetItemUUID = value; }
		}
        /// <summary>
        ///
        /// </summary>
        public List<String> PictureFileList
		{ 
			get { return mPictureFileList; }
			set { mPictureFileList = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="AddFixedPriceItemResponseType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiResponse.ItemID; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="AddFixedPriceItemResponseType.SKU"/> of type <see cref="string"/>.
		/// </summary>
		public string SKU
		{ 
			get { return ApiResponse.SKU; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="AddFixedPriceItemResponseType.StartTime"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime StartTime
		{ 
			get { return ApiResponse.StartTime.Value; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="AddFixedPriceItemResponseType.EndTime"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime EndTime
		{ 
			get { return ApiResponse.EndTime.Value; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="AddFixedPriceItemResponseType.Fees"/> of type <see cref="List<FeeType>"/>.
		/// </summary>
		public List<FeeType> FeeList
		{ 
			get { return ApiResponse.Fees; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="AddFixedPriceItemResponseType.CategoryID"/> of type <see cref="string"/>.
		/// </summary>
		public string CategoryID
		{ 
			get { return ApiResponse.CategoryID; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="AddFixedPriceItemResponseType.Category2ID"/> of type <see cref="string"/>.
		/// </summary>
		public string Category2ID
		{ 
			get { return ApiResponse.Category2ID; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="AddFixedPriceItemResponseType.DiscountReason"/> of type <see cref="List<DiscountReasonCodeType?>"/>.
		/// </summary>
		public List<DiscountReasonCodeType> DiscountReasonList
		{ 
			get { return ApiResponse.DiscountReason; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="AddFixedPriceItemResponseType.ProductSuggestions"/> of type <see cref="ProductSuggestionsType"/>.
		/// </summary>
		public ProductSuggestionsType ProductSuggestions
		{ 
			get { return ApiResponse.ProductSuggestions; }
		}
		
		#endregion

		#region Private Fields
		private bool mAutoSetItemUUID = false;
		private List< String> mPictureFileList = new List<String>();
		#endregion
		
	}
}
