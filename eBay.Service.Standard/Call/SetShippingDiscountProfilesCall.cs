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
	public class SetShippingDiscountProfilesCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public SetShippingDiscountProfilesCall()
		{
			ApiRequest = new SetShippingDiscountProfilesRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public SetShippingDiscountProfilesCall(ApiContext ApiContext)
		{
			ApiRequest = new SetShippingDiscountProfilesRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// This call enables a seller to create and manage shipping discounts rules. These are the same shipping discount rules that can be created or managed in My eBay Shipping Preferences.
		/// <br/><br/>
		/// The types of shipping discount rules that can be created and managed with this call include flat-rate shipping rules, calculated shipping rules, and promotional shipping rules. This call can also be used by sellers to set whether or not they allow buyers to combine separate line items into one Combined Invoice order, and how many days they allow buyers to perform that action.
		/// <br/><br/>
		/// A seller can only create, update, or delete one discount rule type with each call. The action to take (either <code>Add</code>, <code>Update</code>, or <code>Delete</code>) is set and controlled with the <b>ModifyActionCode</b> field.
		/// </summary>
		/// 
		/// <param name="CurrencyID">
		/// The three-digit code of the currency to be used for shipping discounts and insurance for Combined Invoice orders. A discount profile can only be associated with a listing if the <b>CurrencyID</b> value of the profile matches the <b>Item.Currency</b> value specified in a listing. This field is required if the user is adding or updating one or more shipping discount profiles.
		/// 
		/// 
		/// Note that There is a <b>currencyID</b> attribute on all   <b>SetShippingDiscountProfiles</b> elements involving money. To avoid a call error, be sure to use the same currency type in these attributes as what is set for the <b>CurrencyID</b> field.
		/// </param>
		///
		/// <param name="CombinedDuration">
		/// This field is used to specify the number of days after the purchase of an
		/// item that the buyer or seller can combine multiple and mutual order
		/// line items into one Combined Invoice order. In a Combined Invoice order,
		/// the buyer makes one payment for all order line items, hence only unpaid
		/// order line items can be combined into a Combined Invoice order.
		/// </param>
		///
		/// <param name="ModifyActionCode">
		/// This field is used to set which action is being taken (<code>Add</code>, <code>Update</code>, or <code>Delete</code>) in the call. If you are adding a shipping discount rule, you will have to supply a name for that shipping discount profile. If you want to update or delete a shipping discount profile, you'll have to provide the unique identifier of this rule through the corresponding containers. The unique identifiers of these rules can be retrieved with the <b>GetShippingDiscountRules</b> call, or the seller can view these identifiers in My eBay Shipping Preferences.
		/// </param>
		///
		/// <param name="FlatShippingDiscount">
		/// This container allows you to create, update, or delete a flat-rate shipping discount profile.
		/// </param>
		///
		/// <param name="CalculatedShippingDiscount">
		/// This container allows you to create, update, or delete a calculated shipping discount profile.
		/// </param>
		///
		/// <param name="CalculatedHandlingDiscount">
		/// This container allows you to create, update, or delete a calculated handling discount profile.
		/// </param>
		///
		/// <param name="PromotionalShippingDiscountDetails">
		/// This container allows you to create, update, or delete a promotional shipping discount profile.
		/// </param>
		///
		/// <param name="ShippingInsurance">
		/// This field is no longer applicable as it is not longer possible for a seller to offer a buyer shipping insurance.
		/// </param>
		///
		/// <param name="InternationalShippingInsurance">
		/// This field is no longer applicable as it is not longer possible for a seller to offer a buyer shipping insurance.
		/// </param>
		///
		public void SetShippingDiscountProfiles(CurrencyCodeType CurrencyID, CombinedPaymentPeriodCodeType CombinedDuration, ModifyActionCodeType ModifyActionCode, FlatShippingDiscountType FlatShippingDiscount, CalculatedShippingDiscountType CalculatedShippingDiscount, CalculatedHandlingDiscountType CalculatedHandlingDiscount, PromotionalShippingDiscountDetailsType PromotionalShippingDiscountDetails)
		{
			this.CurrencyID = CurrencyID;
			this.CombinedDuration = CombinedDuration;
			this.ModifyActionCode = ModifyActionCode;
			this.FlatShippingDiscount = FlatShippingDiscount;
			this.CalculatedShippingDiscount = CalculatedShippingDiscount;
			this.CalculatedHandlingDiscount = CalculatedHandlingDiscount;
			this.PromotionalShippingDiscountDetails = PromotionalShippingDiscountDetails;

			Execute();
			
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
		/// Gets or sets the <see cref="SetShippingDiscountProfilesRequestType"/> for this API call.
		/// </summary>
		public SetShippingDiscountProfilesRequestType ApiRequest
		{ 
			get { return (SetShippingDiscountProfilesRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="SetShippingDiscountProfilesResponseType"/> for this API call.
		/// </summary>
		public SetShippingDiscountProfilesResponseType ApiResponse
		{ 
			get { return (SetShippingDiscountProfilesResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="SetShippingDiscountProfilesRequestType.CurrencyID"/> of type <see cref="CurrencyCodeType"/>.
		/// </summary>
		public CurrencyCodeType CurrencyID
		{ 
			get { return ApiRequest.CurrencyID.Value; }
			set { ApiRequest.CurrencyID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetShippingDiscountProfilesRequestType.CombinedDuration"/> of type <see cref="CombinedPaymentPeriodCodeType"/>.
		/// </summary>
		public CombinedPaymentPeriodCodeType CombinedDuration
		{ 
			get { return ApiRequest.CombinedDuration.Value; }
			set { ApiRequest.CombinedDuration = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetShippingDiscountProfilesRequestType.ModifyActionCode"/> of type <see cref="ModifyActionCodeType"/>.
		/// </summary>
		public ModifyActionCodeType ModifyActionCode
		{ 
			get { return ApiRequest.ModifyActionCode.Value; }
			set { ApiRequest.ModifyActionCode = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetShippingDiscountProfilesRequestType.FlatShippingDiscount"/> of type <see cref="FlatShippingDiscountType"/>.
		/// </summary>
		public FlatShippingDiscountType FlatShippingDiscount
		{ 
			get { return ApiRequest.FlatShippingDiscount; }
			set { ApiRequest.FlatShippingDiscount = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetShippingDiscountProfilesRequestType.CalculatedShippingDiscount"/> of type <see cref="CalculatedShippingDiscountType"/>.
		/// </summary>
		public CalculatedShippingDiscountType CalculatedShippingDiscount
		{ 
			get { return ApiRequest.CalculatedShippingDiscount; }
			set { ApiRequest.CalculatedShippingDiscount = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetShippingDiscountProfilesRequestType.CalculatedHandlingDiscount"/> of type <see cref="CalculatedHandlingDiscountType"/>.
		/// </summary>
		public CalculatedHandlingDiscountType CalculatedHandlingDiscount
		{ 
			get { return ApiRequest.CalculatedHandlingDiscount; }
			set { ApiRequest.CalculatedHandlingDiscount = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetShippingDiscountProfilesRequestType.PromotionalShippingDiscountDetails"/> of type <see cref="PromotionalShippingDiscountDetailsType"/>.
		/// </summary>
		public PromotionalShippingDiscountDetailsType PromotionalShippingDiscountDetails
		{ 
			get { return ApiRequest.PromotionalShippingDiscountDetails; }
			set { ApiRequest.PromotionalShippingDiscountDetails = value; }
		}

		#endregion

		
	}
}
