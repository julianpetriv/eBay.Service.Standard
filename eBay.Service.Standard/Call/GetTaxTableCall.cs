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
	public class GetTaxTableCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetTaxTableCall()
		{
			ApiRequest = new GetTaxTableRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetTaxTableCall(ApiContext ApiContext)
		{
			ApiRequest = new GetTaxTableRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// The base request type of the <b>GetTaxTable</b> call, which retrieves information on the seller's Sales Tax Table. This information includes all of the site's tax jurisdictions, a boolean field to indicate if sales tax is applied to shipping and handling charges, and the sales tax rate for each jurisdiction (if a sales tax rate is set for that jurisdiction).
		/// <br/><br/>
		/// Sales tax tables are only supported on the eBay US, Candada, and India sites.
		/// </summary>
		/// 
		public List<TaxJurisdictionType> GetTaxTable()
		{

			Execute();
			return ApiResponse.TaxTable;
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
		/// Gets or sets the <see cref="GetTaxTableRequestType"/> for this API call.
		/// </summary>
		public GetTaxTableRequestType ApiRequest
		{ 
			get { return (GetTaxTableRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetTaxTableResponseType"/> for this API call.
		/// </summary>
		public GetTaxTableResponseType ApiResponse
		{ 
			get { return (GetTaxTableResponseType) AbstractResponse; }
		}

		
		
 		/// <summary>
		/// Gets the returned <see cref="GetTaxTableResponseType.LastUpdateTime"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime LastUpdateTime
		{ 
			get { return ApiResponse.LastUpdateTime.Value; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetTaxTableResponseType.TaxTable"/> of type <see cref="TaxJurisdictionTypeCollection"/>.
		/// </summary>
		public List<TaxJurisdictionType> TaxTableList
		{ 
			get { return ApiResponse.TaxTable; }
		}
		

		#endregion

		
	}
}
