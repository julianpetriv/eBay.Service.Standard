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
	public class GetCategoryMappingsCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetCategoryMappingsCall()
		{
			ApiRequest = new GetCategoryMappingsRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetCategoryMappingsCall(ApiContext ApiContext)
		{
			ApiRequest = new GetCategoryMappingsRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves a map of old category IDs and corresponding active
		/// category IDs defined for the site to which the request is sent.
		/// </summary>
		/// 
		/// <param name="CategoryVersion">
		/// A version of the category mapping for the site. Filters
		/// out data from the call to return only the category
		/// mappings for which the data has changed since the
		/// specified version. If not specified, all category
		/// mappings are returned. Typically, an application passes
		/// the version value of the last set of category mappings
		/// that the application stored locally. The latest version
		/// value is not necessarily greater than the previous value
		/// that was returned. Therefore, when comparing versions,
		/// only compare whether the value has changed.
		/// </param>
		///
		public List<CategoryMappingType> GetCategoryMappings(string CategoryVersion)
		{
			this.CategoryVersion = CategoryVersion;

			Execute();
			return ApiResponse.CategoryMapping;
		}


 		/// <summary>
 		/// Call GetCategoryMappingsVersion to retrieve the Category Mapping version for a site.
 		/// </summary>
 		/// <returns>The <see cref="GetCategoryMappingsResponseType.CategoryVersion"/>.</returns>
 		public string GetCategoryMappingsVersion()
 		{
 			this.DetailLevelOverride = true;
 			Execute();
 			this.DetailLevelOverride = false;
 			return CategoryVersionResponse;
 		}	

		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public List<CategoryMappingType> GetCategoryMappings()
		{
			Execute();
			return CategoryMappingList;
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
		/// Gets or sets the <see cref="GetCategoryMappingsRequestType"/> for this API call.
		/// </summary>
		public GetCategoryMappingsRequestType ApiRequest
		{ 
			get { return (GetCategoryMappingsRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetCategoryMappingsResponseType"/> for this API call.
		/// </summary>
		public GetCategoryMappingsResponseType ApiResponse
		{ 
			get { return (GetCategoryMappingsResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetCategoryMappingsRequestType.CategoryVersion"/> of type <see cref="string"/>.
		/// </summary>
		public string CategoryVersion
		{ 
			get { return ApiRequest.CategoryVersion; }
			set { ApiRequest.CategoryVersion = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetCategoryMappingsResponseType.CategoryMapping"/> of type <see cref="CategoryMappingTypeCollection"/>.
		/// </summary>
		public List<CategoryMappingType> CategoryMappingList
		{ 
			get { return ApiResponse.CategoryMapping; }
		}
		
		/// <summary>
		/// 
		/// </summary>

		public string CategoryVersionResponse
		{ 
			get { return ApiResponse.CategoryVersion; }
		}

		#endregion

		
	}
}
