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
	public class ReviseItemCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public ReviseItemCall()
		{
			ApiRequest = new ReviseItemRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public ReviseItemCall(ApiContext ApiContext)
		{
			ApiRequest = new ReviseItemRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Enables a seller to revise a listing on a specified eBay site. To revise an active listing, the seller specifies the <b>ItemID</b> value for the listing. The seller makes one or multiple changes to the listing through the <b>Item</b> container, and the seller can also use one or more <b>DeletedField</b> tags to remove an optional field/setting from the listing.
		/// 
		/// 
		/// After a multiple-quantity, fixed-price listing has one or more sales, or less than 12 hours remain before the listing is scheduled to end, you can not edit the values in the Listing Title, Primary Category, Secondary Category, Listing Duration, and Listing Type fields for that listing. The same applies to an auction listing that has at least one bid.
		/// 
		/// 
		/// To revise a multiple-variation, fixed-price listing, the <b>ReviseFixedPriceItem</b> call should be used instead, as the <b>ReviseItem</b> call does not support variation-level edits.
		/// </summary>
		/// 
		/// <param name="Item">
		/// The <b>Item</b> container is used to make changes to the active listing. The seller must pass in the <b>ItemID</b> value for the listing that is being revised. For anything else that the seller wishes to change, such as quantity or price, the seller should include this field in the call request and give it a new value.
		/// <br/><br/>
		/// If the seller wants to delete one or more optional settings in the listing, the seller should use the <b>DeletedField</b> tag.
		/// </param>
		///
		/// <param name="DeletedFieldList">
		/// Specifies the name of a field to delete from a listing. The request can
		/// contain zero, one, or many instances of <b>DeletedField</b> (one for each field
		/// to be deleted). See the relevant field descriptions to determine when to
		/// use <b>DeletedField</b> (and potential consequences).
		/// 
		/// You cannot delete required fields from a listing.
		/// 
		/// Some fields are optional when you first list an item (e.g.,
		/// <b>SecondaryCategory</b>), but once they are set they cannot be deleted when you
		/// revise an item. Some optional fields cannot be deleted if the item has
		/// bids and/or ends within 12 hours. Some optional fields cannot be deleted
		/// if other fields depend on them.
		/// 
		/// Use values that match the case of the
		/// schema element names (<b>Item.PictureDetails.GalleryURL</b>) or make the initial
		/// letter of each field name lowercase (<b>item.pictureDetails.galleryURL</b>).
		/// However, do not change the case of letters in the middle of a field name.
		/// For example, <b>item.picturedetails.galleryUrl</b> is not allowed.
		/// 
		/// To delete a listing enhancement like <b>BoldTitle</b>, specify the value you are
		/// deleting in square brackets ("[ ]"); for example,
		/// <b>Item.ListingEnhancement[BoldTitle]</b>.
		/// </param>
		///
		/// <param name="VerifyOnly">
		/// When the <b>VerifyOnly</b> is included and set as <code>true</code>, the active listing is not actually revised, but the same response is returned and the seller gets to see the expected fees based on the changes made, and can also view any listing recommendations if the <b>Item.IncludeRecommedations</b> boolean field is included and set to <code>true</code>.
		/// </param>
		///
		public DateTime ReviseItem(ItemType Item, List<string> DeletedFieldList, bool VerifyOnly)
		{
			this.Item = Item;
			this.DeletedFieldList = DeletedFieldList;
			this.VerifyOnly = VerifyOnly;

			Execute();
			return ApiResponse.StartTime.Value;
		}

		/// <summary>
		/// 
		/// </summary>
		public override void Execute()
		{
			if (ApiContext.EPSServerUrl != null && PictureFileList != null && PictureFileList.Count > 0)
			{
				eBayPictureService eps = new eBayPictureService(this.ApiContext);
				if (Item.PictureDetails == null)
				{
					Item.PictureDetails = new PictureDetailsType();
				} 

				try
				{
					Item.PictureDetails.PictureURL = new List<string>();
					Item.PictureDetails.PictureURL.AddRange(eps.UpLoadPictureFiles(PictureFileList.ToArray()));
				} 
				catch (Exception ex)
				{
					LogMessage(ex.Message, MessageType.Exception, MessageSeverity.Error);
					throw new SdkException(ex.Message, ex);
				}
			}				
			base.Execute();

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
		/// Gets or sets the <see cref="ReviseItemRequestType"/> for this API call.
		/// </summary>
		public ReviseItemRequestType ApiRequest
		{ 
			get { return (ReviseItemRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="ReviseItemResponseType"/> for this API call.
		/// </summary>
		public ReviseItemResponseType ApiResponse
		{ 
			get { return (ReviseItemResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseItemRequestType.Item"/> of type <see cref="ItemType"/>.
		/// </summary>
		public ItemType Item
		{ 
			get { return ApiRequest.Item; }
			set { ApiRequest.Item = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseItemRequestType.DeletedField"/> of type <see cref="List<string>"/>.
		/// </summary>
		public List<string> DeletedFieldList
		{ 
			get { return ApiRequest.DeletedField; }
			set { ApiRequest.DeletedField = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseItemRequestType.VerifyOnly"/> of type <see cref="bool"/>.
		/// </summary>
		public bool VerifyOnly
		{ 
			get { return ApiRequest.VerifyOnly.Value; }
			set { ApiRequest.VerifyOnly = value; }
		}
		/// <summary>
		///
		/// </summary>
										public List<string> PictureFileList
		{ 
			get { return mPictureFileList; }
			set { mPictureFileList = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="ReviseItemResponseType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiResponse.ItemID; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="ReviseItemResponseType.StartTime"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime StartTime
		{ 
			get { return ApiResponse.StartTime.Value; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="ReviseItemResponseType.EndTime"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime EndTime
		{ 
			get { return ApiResponse.EndTime.Value; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="ReviseItemResponseType.Fees"/> of type <see cref="List<FeeType>"/>.
		/// </summary>
		public List<FeeType> FeeList
		{ 
			get { return ApiResponse.Fees; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="ReviseItemResponseType.CategoryID"/> of type <see cref="string"/>.
		/// </summary>
		public string CategoryID
		{ 
			get { return ApiResponse.CategoryID; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="ReviseItemResponseType.Category2ID"/> of type <see cref="string"/>.
		/// </summary>
		public string Category2ID
		{ 
			get { return ApiResponse.Category2ID; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="ReviseItemResponseType.VerifyOnly"/> of type <see cref="bool"/>.
		/// </summary>
		public bool VerifyOnlyReturn
		{ 
			get { return ApiResponse.VerifyOnly.Value; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="ReviseItemResponseType.DiscountReason"/> of type <see cref="List<DiscountReasonCodeType?>"/>.
		/// </summary>
		public List<DiscountReasonCodeType> DiscountReasonList
		{ 
			get { return ApiResponse.DiscountReason; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="ReviseItemResponseType.ProductSuggestions"/> of type <see cref="ProductSuggestionsType"/>.
		/// </summary>
		public ProductSuggestionsType ProductSuggestions
		{ 
			get { return ApiResponse.ProductSuggestions; }
		}
		

		#endregion

		#region Private Fields
		private List<string> mPictureFileList = new List<string>();
		#endregion
		
	}
}
