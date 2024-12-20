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
	public class VerifyRelistItemCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public VerifyRelistItemCall()
		{
			ApiRequest = new VerifyRelistItemRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public VerifyRelistItemCall(ApiContext ApiContext)
		{
			ApiRequest = new VerifyRelistItemRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Enable the seller to verify that the data they plan to pass into a <b>RelistItem</b> call will produce the results that you are expecting, including a successful call with no errors.
		/// </summary>
		/// 
		/// <param name="Item">
		/// The <b>Item</b> container is used to configure the item that will be relisted. If the seller plans to relist the item with no changes, the only field under the <b>Item</b> container that is required is the <b>ItemID</b> field. In the <b>ItemID</b> field, the seller specifies the item that will be relisted. If the seller wishes to change anything else for the listing, the seller should include this field in the call request and give it a new value.
		/// <br/><br/>
		/// If the seller wants to delete one or more optional settings in the listing, the seller should use the <b>DeletedField</b> tag.
		/// </param>
		///
		/// <param name="DeletedFieldList">
		/// Specifies the name of the field to delete from a listing. See the eBay Features Guide for rules on deleting values when relisting items. Also see the relevant field descriptions to determine when to use <b>DeletedField</b> (and potential consequences).
		/// The request can contain zero, one, or many instances of <b>DeletedField</b> (one for each field to be deleted).
		/// 
		/// Case-sensitivity must be taken into account when using a <b>DeletedField</b> tag to delete a field. The value passed into a <b>DeletedField</b> tag must either match the case of the schema element names in the full field path (Item.PictureDetails.GalleryURL), or the initial letter of each schema element name in the full field path must be  lowercase (item.pictureDetails.galleryURL).
		/// Do not change the case of letters in the middle of a field name.
		/// For example, item.picturedetails.galleryUrl is not allowed.
		/// To delete a listing enhancement like 'BoldTitle', specify the value you are deleting;
		/// for example, Item.ListingEnhancement[BoldTitle].
		/// </param>
		///
		public string VerifyRelistItem(ItemType Item, List<string> DeletedFieldList)
		{
			this.Item = Item;
			this.DeletedFieldList = DeletedFieldList;

			Execute();
			return ApiResponse.ItemID;
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
		/// Gets or sets the <see cref="VerifyRelistItemRequestType"/> for this API call.
		/// </summary>
		public VerifyRelistItemRequestType ApiRequest
		{ 
			get { return (VerifyRelistItemRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="VerifyRelistItemResponseType"/> for this API call.
		/// </summary>
		public VerifyRelistItemResponseType ApiResponse
		{ 
			get { return (VerifyRelistItemResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="VerifyRelistItemRequestType.Item"/> of type <see cref="ItemType"/>.
		/// </summary>
		public ItemType Item
		{ 
			get { return ApiRequest.Item; }
			set { ApiRequest.Item = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="VerifyRelistItemRequestType.DeletedField"/> of type <see cref="List<string>"/>.
		/// </summary>
		public List<string> DeletedFieldList
		{ 
			get { return ApiRequest.DeletedField; }
			set { ApiRequest.DeletedField = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="VerifyRelistItemResponseType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiResponse.ItemID; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="VerifyRelistItemResponseType.Fees"/> of type <see cref="FeeTypeCollection"/>.
		/// </summary>
		public List<FeeType> FeeList
		{ 
			get { return ApiResponse.Fees; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="VerifyRelistItemResponseType.StartTime"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime StartTime
		{ 
			get { return ApiResponse.StartTime.Value; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="VerifyRelistItemResponseType.EndTime"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime EndTime
		{ 
			get { return ApiResponse.EndTime.Value; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="VerifyRelistItemResponseType.DiscountReason"/> of type <see cref="DiscountReasonCodeTypeCollection"/>.
		/// </summary>
		public List<DiscountReasonCodeType> DiscountReasonList
		{ 
			get { return ApiResponse.DiscountReason; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="VerifyRelistItemResponseType.ProductSuggestions"/> of type <see cref="ProductSuggestionsType"/>.
		/// </summary>
		public ProductSuggestionsType ProductSuggestions
		{ 
			get { return ApiResponse.ProductSuggestions; }
		}
		

		#endregion

		
	}
}
