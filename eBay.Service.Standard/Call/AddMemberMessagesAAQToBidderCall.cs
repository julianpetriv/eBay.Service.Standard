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
	public class AddMemberMessagesAAQToBidderCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public AddMemberMessagesAAQToBidderCall()
		{
			ApiRequest = new AddMemberMessagesAAQToBidderRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public AddMemberMessagesAAQToBidderCall(ApiContext ApiContext)
		{
			ApiRequest = new AddMemberMessagesAAQToBidderRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// The base request of the <b>AddMemberMessagesAAQToBidder</b> call, which allows a seller to send up to 10 messages to bidders/potential buyers regarding an active listing. These potential buyers may include those who have made a Best Offer on a listing.
		/// </summary>
		/// 
		/// <param name="AddMemberMessagesAAQToBidderRequestContainerList">
		/// An <b>AddMemberMessagesAAQToBidderRequestContainer</b> container is required for each message being sent to unique bidders/potential buyers.  A seller can send up to 10 messages to unique bidders/potential buyers in one <b>AddMemberMessagesAAQToBidder</b> call.
		/// </param>
		///
		public List<AddMemberMessagesAAQToBidderResponseContainerType> AddMemberMessagesAAQToBidder(List<AddMemberMessagesAAQToBidderRequestContainerType> AddMemberMessagesAAQToBidderRequestContainerList)
		{
			this.AddMemberMessagesAAQToBidderRequestContainerList = AddMemberMessagesAAQToBidderRequestContainerList;

			Execute();
			return ApiResponse.AddMemberMessagesAAQToBidderResponseContainer;
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
		/// Gets or sets the <see cref="AddMemberMessagesAAQToBidderRequestType"/> for this API call.
		/// </summary>
		public AddMemberMessagesAAQToBidderRequestType ApiRequest
		{ 
			get { return (AddMemberMessagesAAQToBidderRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="AddMemberMessagesAAQToBidderResponseType"/> for this API call.
		/// </summary>
		public AddMemberMessagesAAQToBidderResponseType ApiResponse
		{ 
			get { return (AddMemberMessagesAAQToBidderResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="AddMemberMessagesAAQToBidderRequestType.AddMemberMessagesAAQToBidderRequestContainer"/> of type <see cref="AddMemberMessagesAAQToBidderRequestContainerTypeCollection"/>.
		/// </summary>
		public List<AddMemberMessagesAAQToBidderRequestContainerType> AddMemberMessagesAAQToBidderRequestContainerList
		{ 
			get { return ApiRequest.AddMemberMessagesAAQToBidderRequestContainer; }
			set { ApiRequest.AddMemberMessagesAAQToBidderRequestContainer = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="AddMemberMessagesAAQToBidderResponseType.AddMemberMessagesAAQToBidderResponseContainer"/> of type <see cref="AddMemberMessagesAAQToBidderResponseContainerTypeCollection"/>.
		/// </summary>
		public List<AddMemberMessagesAAQToBidderResponseContainerType> AddMemberMessagesAAQToBidderResponseContainerList
		{ 
			get { return ApiResponse.AddMemberMessagesAAQToBidderResponseContainer; }
		}
		

		#endregion

		
	}
}
