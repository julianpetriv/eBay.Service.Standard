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
	public class GetMyMessagesCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetMyMessagesCall()
		{
			ApiRequest = new GetMyMessagesRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetMyMessagesCall(ApiContext ApiContext)
		{
			ApiRequest = new GetMyMessagesRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves information about the messages sent to a given user.
		/// </summary>
		/// 
		/// <param name="AlertIDList">
		/// This container is deprecated.
		/// </param>
		///
		/// <param name="MessageIDList">
		/// This container can be used to retrieve one or more specific messages identified with their unique <b>MessageID</b> values. Up to  10 <b>MessageID</b> values can be specified with one call.
		/// </param>
		///
		/// <param name="FolderID">
		/// A unique identifier for a My Messages folder. If a <b>FolderID</b> value is provided,
		/// only messages from the specified folder are returned in the response.
		/// </param>
		///
		/// <param name="StartTime">
		/// The beginning of the date-range filter.
		/// Filtering takes into account the entire timestamp of when messages were sent.
		/// Messages expire after one year.
		/// </param>
		///
		/// <param name="EndTime">
		/// The end of the date-range filter. See StartTime
		/// (which is the beginning of the date-range filter).
		/// </param>
		///
		/// <param name="ExternalMessageIDList">
		/// This field is currently available on the US site. A container for IDs that
		/// uniquely identify messages for a given user. If provided at the time of message
		/// creation, this ID can be used to retrieve messages and will take precedence
		/// over message ID.
		/// </param>
		///
		/// <param name="Pagination">
		/// Specifies how to create virtual pages in the returned list (such as total
		/// number of entries and total number of pages to return).
		/// Default value for <b>EntriesPerPage</b> with <b>GetMyMessages</b> is 25.
		/// </param>
		///
		/// <param name="IncludeHighPriorityMessageOnly">
		/// If this field is included in the request and set to <code>true</code>, only High Priority messages are returned in the response.
		/// </param>
		///
		public MyMessagesSummaryType GetMyMessages(List<string> AlertIDList, List<string> MessageIDList, long FolderID, DateTime StartTime, DateTime EndTime, List<string> ExternalMessageIDList, PaginationType Pagination, bool IncludeHighPriorityMessageOnly)
		{
			this.MessageIDList = MessageIDList;
			this.FolderID = FolderID;
			this.StartTime = StartTime;
			this.EndTime = EndTime;
			this.ExternalMessageIDList = ExternalMessageIDList;
			this.Pagination = Pagination;
			this.IncludeHighPriorityMessageOnly = IncludeHighPriorityMessageOnly;

			Execute();
			return ApiResponse.Summary;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void GetMyMessages()
		{
			this.Execute();
		}

		/// <summary>
		/// For backward compatibility with old wrappers.
		///Used to retrieve information about the messages and alerts sent
		/// to a given user. Depending on the detail level, this information
		/// can include message and alert counts, resolution and flagged
		/// status, message and/or alert headers, and message and/or alert
		/// body text.
		/// <br /><br />
		/// Note that this call requires a DetailLevel in the
		/// request. Omitting the Detail Level returns an error.
		/// <br /><br />
		/// ItemID is not returned with this call. Use GetMemberMessages instead.
		/// </summary>
		/// 
		/// <param name="AlertIDList">
		/// Contains a list of up to 10 AlertID values.
		/// When AlertID values are used as input, you must
		/// generally specify either AlertID values, or
		/// MessageID values, or both.
		/// </param>
		///
		/// <param name="MessageIDList">
		/// Contains a list of up to 10 MessageID values.
		/// When MessageID values are used as input, you must
		/// generally specify either AlertID values, or
		/// MessageID values, or both.
		/// </param>
		///
		/// <param name="FolderID">
		/// An ID that uniquely identifies the My Messages folder from which to retrieve alerts or messages.
		/// </param>
		///
		public MyMessagesSummaryType GetMyMessages(List<string> AlertIDList, List<string> MessageIDList, long FolderID)
		{
			this.MessageIDList = MessageIDList;
			this.FolderID = FolderID;

			Execute();
			return ApiResponse.Summary;
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
		/// Gets or sets the <see cref="GetMyMessagesRequestType"/> for this API call.
		/// </summary>
		public GetMyMessagesRequestType ApiRequest
		{ 
			get { return (GetMyMessagesRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetMyMessagesResponseType"/> for this API call.
		/// </summary>
		public GetMyMessagesResponseType ApiResponse
		{ 
			get { return (GetMyMessagesResponseType) AbstractResponse; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyMessagesRequestType.MessageIDs"/> of type <see cref="List<string>"/>.
		/// </summary>
		public List<string> MessageIDList
		{ 
			get { return ApiRequest.MessageIDs; }
			set { ApiRequest.MessageIDs =value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyMessagesRequestType.FolderID"/> of type <see cref="long"/>.
		/// </summary>
		public long FolderID
		{ 
			get { return ApiRequest.FolderID.Value; }
			set { ApiRequest.FolderID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyMessagesRequestType.StartTime"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime StartTime
		{ 
			get { return ApiRequest.StartTime.Value; }
			set { ApiRequest.StartTime = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyMessagesRequestType.EndTime"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime EndTime
		{ 
			get { return ApiRequest.EndTime.Value; }
			set { ApiRequest.EndTime = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyMessagesRequestType.ExternalMessageIDs"/> of type <see cref="List<string>"/>.
		/// </summary>
		public List<string> ExternalMessageIDList
		{ 
			get { return ApiRequest.ExternalMessageIDs; }
			set { ApiRequest.ExternalMessageIDs = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyMessagesRequestType.Pagination"/> of type <see cref="PaginationType"/>.
		/// </summary>
		public PaginationType Pagination
		{ 
			get { return ApiRequest.Pagination; }
			set { ApiRequest.Pagination = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyMessagesRequestType.IncludeHighPriorityMessageOnly"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeHighPriorityMessageOnly
		{ 
			get { return ApiRequest.IncludeHighPriorityMessageOnly.Value; }
			set { ApiRequest.IncludeHighPriorityMessageOnly = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetMyMessagesResponseType.Summary"/> of type <see cref="MyMessagesSummaryType"/>.
		/// </summary>
		public MyMessagesSummaryType Summary
		{ 
			get { return ApiResponse.Summary; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetMyMessagesResponseType.Messages"/> of type <see cref="MyMessagesMessageTypeCollection"/>.
		/// </summary>
		public List<MyMessagesMessageType> MessageList
		{ 
			get { return ApiResponse.Messages; }
		}
		

		#endregion

		
	}
}
