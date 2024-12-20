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
	public class PlaceOfferCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public PlaceOfferCall()
		{
			ApiRequest = new PlaceOfferRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public PlaceOfferCall(ApiContext ApiContext)
		{
			ApiRequest = new PlaceOfferRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Enables the authenticated user to to make a bid on an auction item, propose a Best Offer, or purchase a fixed-price/Buy It Now item. Note that this call cannot be used to purchase items that require immediate payment.
		/// </summary>
		/// 
		/// <param name="Offer">
		/// This container is used to specifies the type of offer being made for the listing specified in the <b>ItemID</b> field. The <b>Offer.Action</b> is used to set the action that is being taken on the listing.
		/// </param>
		///
		/// <param name="ItemID">
		/// Unique identifier that identifies the listing for which the action is being submitted.
		/// 
		/// For a multiple-variation listing, you must also identify the specific variation within that listing using the <b>VariationSpecifics</b> container.
		/// </param>
		///
		/// <param name="BlockOnWarning">
		/// If a warning message is generated when the call is made, this <b>BlockOnWarning</b> will block the bid/buy action if set to <code>true</code>. If <b>BlockOnWarning</b>
		/// is <code>false</code> or omitted, the bid/buy action is allowed, regardless of whether or not a warning message occurs.
		/// 
		/// </param>
		///
		/// <param name="AffiliateTrackingDetails">
		/// Container for affiliate-related tags, which enable the tracking of user
		/// activity. If you include the <b>AffiliateTrackingDetails</b> container in your <b>PlaceOffer</b> call, then
		/// it is possible to receive affiliate commissions based on calls made by your
		/// application. (See the <a href=
		/// "http://www.ebaypartnernetwork.com/" target="_blank">eBay Partner Network</a>
		/// for information about commissions.) Please note that affiliate tracking is not
		/// available in the Sandbox environment, and that affiliate tracking is not
		/// available when you make a Best Offer.
		/// </param>
		///
		/// <param name="VariationSpecificList">
		/// This container is used to identify a specific variation within a multiple-variation listing identified by the <b>ItemID</b> value. This container is required when attempting to perform an action on a multiple-variation listing.
		/// </param>
		///
		public SellingStatusType PlaceOffer(OfferType Offer, string ItemID, bool BlockOnWarning, AffiliateTrackingDetailsType AffiliateTrackingDetails, List<NameValueListType> VariationSpecificList)
		{
			this.Offer = Offer;
			this.ItemID = ItemID;
			this.BlockOnWarning = BlockOnWarning;
			this.AffiliateTrackingDetails = AffiliateTrackingDetails;
			this.VariationSpecificList = VariationSpecificList;

			Execute();
			return ApiResponse.SellingStatus;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public SellingStatusType PlaceOffer(OfferType Offer, string ItemID)
		{
			this.Offer = Offer;
			this.ItemID = ItemID;

			Execute();
			return ApiResponse.SellingStatus;
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
		/// Gets or sets the <see cref="PlaceOfferRequestType"/> for this API call.
		/// </summary>
		public PlaceOfferRequestType ApiRequest
		{ 
			get { return (PlaceOfferRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="PlaceOfferResponseType"/> for this API call.
		/// </summary>
		public PlaceOfferResponseType ApiResponse
		{ 
			get { return (PlaceOfferResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="PlaceOfferRequestType.Offer"/> of type <see cref="OfferType"/>.
		/// </summary>
		public OfferType Offer
		{ 
			get { return ApiRequest.Offer; }
			set { ApiRequest.Offer = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="PlaceOfferRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="PlaceOfferRequestType.BlockOnWarning"/> of type <see cref="bool"/>.
		/// </summary>
		public bool BlockOnWarning
		{ 
			get { return ApiRequest.BlockOnWarning.Value; }
			set { ApiRequest.BlockOnWarning = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="PlaceOfferRequestType.AffiliateTrackingDetails"/> of type <see cref="AffiliateTrackingDetailsType"/>.
		/// </summary>
		public AffiliateTrackingDetailsType AffiliateTrackingDetails
		{ 
			get { return ApiRequest.AffiliateTrackingDetails; }
			set { ApiRequest.AffiliateTrackingDetails = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="PlaceOfferRequestType.VariationSpecifics"/> of type <see cref="NameValueListTypeCollection"/>.
		/// </summary>
		public List<NameValueListType> VariationSpecificList
		{ 
			get { return ApiRequest.VariationSpecifics; }
			set { ApiRequest.VariationSpecifics = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="PlaceOfferResponseType.SellingStatus"/> of type <see cref="SellingStatusType"/>.
		/// </summary>
		public SellingStatusType SellingStatus
		{ 
			get { return ApiResponse.SellingStatus; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="PlaceOfferResponseType.TransactionID"/> of type <see cref="string"/>.
		/// </summary>
		public string TransactionID
		{ 
			get { return ApiResponse.TransactionID; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="PlaceOfferResponseType.BestOffer"/> of type <see cref="BestOfferType"/>.
		/// </summary>
		public BestOfferType BestOffer
		{ 
			get { return ApiResponse.BestOffer; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="PlaceOfferResponseType.OrderLineItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string OrderLineItemID
		{ 
			get { return ApiResponse.OrderLineItemID; }
		}
		

		#endregion

		
	}
}
