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
	public class GetTokenStatusCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetTokenStatusCall()
		{
			ApiRequest = new GetTokenStatusRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetTokenStatusCall(ApiContext ApiContext)
		{
			ApiRequest = new GetTokenStatusRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// This call is used to get the current status of a user token. There are no call-specific fields in the request payload.
		/// </summary>
		/// 
		public TokenStatusType GetTokenStatus()
		{

			Execute();
			return ApiResponse.TokenStatus;
		}



		#endregion

		#region Private Methods
		/// <summary>
		/// Constructs a security header from values in <see cref="ApiCall.ApiContext"/>.
		/// </summary>
		/// <returns>Security information of type <see cref="CustomSecurityHeaderType"/>.</returns>
		protected override CustomSecurityHeaderType GetSecurityHeader()
		{
			CustomSecurityHeaderType sechdr = new CustomSecurityHeaderType();
			if (ApiContext.ApiCredential.eBayToken != null && ApiContext.ApiCredential.eBayToken.Length > 0)
			{
				sechdr.eBayAuthToken = ApiContext.ApiCredential.eBayToken;
			}
			else
			{
			        throw new SdkException("GetTokenStatus needs a valid, active auth token to be called!");
			}

			if (ApiContext.ApiCredential.ApiAccount != null)
			{
				sechdr.Credentials = new UserIdPasswordType();
				sechdr.Credentials.AppId = ApiContext.ApiCredential.ApiAccount.Application;
				sechdr.Credentials.DevId = ApiContext.ApiCredential.ApiAccount.Developer;
				sechdr.Credentials.AuthCert = ApiContext.ApiCredential.ApiAccount.Certificate;
			}
			else
			{
			        throw new SdkException("GetTokenStatus needs the full set of developer credentials to be called!");			
			}
			
			return (sechdr);
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
		/// Gets or sets the <see cref="GetTokenStatusRequestType"/> for this API call.
		/// </summary>
		public GetTokenStatusRequestType ApiRequest
		{ 
			get { return (GetTokenStatusRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetTokenStatusResponseType"/> for this API call.
		/// </summary>
		public GetTokenStatusResponseType ApiResponse
		{ 
			get { return (GetTokenStatusResponseType) AbstractResponse; }
		}

		
		
 		/// <summary>
		/// Gets the returned <see cref="GetTokenStatusResponseType.TokenStatus"/> of type <see cref="TokenStatusType"/>.
		/// </summary>
		public TokenStatusType TokenStatus
		{ 
			get { return ApiResponse.TokenStatus; }
		}
		

		#endregion

		
	}
}
