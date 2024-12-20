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
	public class GetMemberMessagesCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetMemberMessagesCall()
		{
			ApiRequest = new GetMemberMessagesRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetMemberMessagesCall(ApiContext ApiContext)
		{
			ApiRequest = new GetMemberMessagesRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves a list of the messages buyers have posted about your
		/// active item listings.
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// The ID of the item the message is about.
		/// 
		/// For ASQ messages, either the ItemID, or a date range
		/// (specified with StartCreationTime and EndCreationTime),
		/// or both must be included. ItemID is otherwise ignored.
		/// </param>
		///
		/// <param name="MailMessageType">
		/// The type of message. Note that <b>GetMemberMessages</b> does not return messages when this field is set to <b>AskSellerQuestion</b>.
		/// </param>
		///
		/// <param name="MessageStatus">
		/// The status of the message.
		/// </param>
		///
		/// <param name="DisplayToPublic">
		/// If included in the request and set to <code>true</code>, only public messages (viewable in the Item listing) are returned. If omitted or set to <code>false</code> in the request, all messages (that match other filters in the request) are returned in the response.
		/// </param>
		///
		/// <param name="StartCreationTime">
		/// Used as beginning of date range filter. If specified, filters the returned messages to only those with a creation date greater than or equal to the specified date and time.
		/// 
		/// For Contact eBay Member (CEM) messages, <b>StartCreationTime</b> and <b>EndCreationTime</b> must be provided.
		/// 
		/// For Ask Seller a Question (ASQ) messages, either the <b>ItemID</b>, or a date range (specified with <b>StartCreationTime</b> and <b>EndCreationTime</b>), or both must be included.
		/// </param>
		///
		/// <param name="EndCreationTime">
		/// Used as end of date range filter. If specified, filters
		/// the returned messages to only those with a creation date
		/// less than or equal to the specified date and time.
		/// 
		/// For Contact eBay Member (CEM) messages, <b>StartCreationTime</b> and <b>EndCreationTime</b>
		/// must be provided.
		/// 
		/// For Ask Seller a Question (ASQ) messages, either the <b>ItemID</b>, or a date range
		/// (specified with <b>StartCreationTime</b> and <b>EndCreationTime</b>),
		/// or both must be included.
		/// </param>
		///
		/// <param name="Pagination">
		/// Standard pagination argument used to reduce response.
		/// </param>
		///
		/// <param name="MemberMessageID">
		/// An ID that uniquely identifies the message for a given user to be retrieved. Used for the <b>AskSellerQuestion</b> notification only.
		/// </param>
		///
		/// <param name="SenderID">
		/// An eBay ID that uniquely identifies a user. For <b>GetMemberMessages</b>, this is the sender of the message. If included in the request, returns only messages from the specified sender.
		/// </param>
		///
		public System.Collections.Generic.List<MemberMessageExchangeType> GetMemberMessages(string ItemID, MessageTypeCodeType MailMessageType, MessageStatusTypeCodeType MessageStatus, bool DisplayToPublic, DateTime StartCreationTime, DateTime EndCreationTime, PaginationType Pagination, string MemberMessageID, string SenderID)
		{
			this.ItemID = ItemID;
			this.MailMessageType = MailMessageType;
			this.MessageStatus = MessageStatus;
			this.DisplayToPublic = DisplayToPublic;
			this.StartCreationTime = StartCreationTime;
			this.EndCreationTime = EndCreationTime;
			this.Pagination = Pagination;
			this.MemberMessageID = MemberMessageID;
			this.SenderID = SenderID;

			Execute();
			return ApiResponse.MemberMessage;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public System.Collections.Generic.List<MemberMessageExchangeType> GetMemberMessages(string ItemID, MessageTypeCodeType MailMessageType, MessageStatusTypeCodeType MessageStatus)
		{
			this.ItemID = ItemID;
			this.MailMessageType = MailMessageType;
			this.MessageStatus = MessageStatus;
			Execute();
			return MemberMessageList;
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public System.Collections.Generic.List<MemberMessageExchangeType> GetMemberMessages(TimeFilter CreateTimeFilter, MessageTypeCodeType MailMessageType, MessageStatusTypeCodeType MessageStatus)
		{
			this.CreateTimeFilter = CreateTimeFilter;
			this.MailMessageType = MailMessageType;
			this.MessageStatus = MessageStatus;
			Execute();
			return MemberMessageList;
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public System.Collections.Generic.List<MemberMessageExchangeType> GetMemberMessages(DateTime TimeFrom, DateTime TimeTo, MessageTypeCodeType MailMessageType, MessageStatusTypeCodeType MessageStatus)
		{
			this.CreateTimeFilter = new TimeFilter(TimeFrom, TimeTo);
			this.MailMessageType = MailMessageType;
			this.MessageStatus = MessageStatus;
			Execute();
			return MemberMessageList;
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
		/// Gets or sets the <see cref="GetMemberMessagesRequestType"/> for this API call.
		/// </summary>
		public GetMemberMessagesRequestType ApiRequest
		{ 
			get { return (GetMemberMessagesRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetMemberMessagesResponseType"/> for this API call.
		/// </summary>
		public GetMemberMessagesResponseType ApiResponse
		{ 
			get { return (GetMemberMessagesResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetMemberMessagesRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMemberMessagesRequestType.MailMessageType"/> of type <see cref="MessageTypeCodeType"/>.
		/// </summary>
		public MessageTypeCodeType MailMessageType
		{ 
			get { return ApiRequest.MailMessageType.Value; }
			set { ApiRequest.MailMessageType = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMemberMessagesRequestType.MessageStatus"/> of type <see cref="MessageStatusTypeCodeType"/>.
		/// </summary>
		public MessageStatusTypeCodeType MessageStatus
		{ 
			get { return ApiRequest.MessageStatus.Value; }
			set { ApiRequest.MessageStatus = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMemberMessagesRequestType.DisplayToPublic"/> of type <see cref="bool"/>.
		/// </summary>
		public bool DisplayToPublic
		{ 
			get { return ApiRequest.DisplayToPublic.Value; }
			set { ApiRequest.DisplayToPublic = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMemberMessagesRequestType.StartCreationTime"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime StartCreationTime
		{ 
			get { return ApiRequest.StartCreationTime.Value; }
			set { ApiRequest.StartCreationTime = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMemberMessagesRequestType.EndCreationTime"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime EndCreationTime
		{ 
			get { return ApiRequest.EndCreationTime.Value; }
			set { ApiRequest.EndCreationTime = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMemberMessagesRequestType.Pagination"/> of type <see cref="PaginationType"/>.
		/// </summary>
		public PaginationType Pagination
		{ 
			get { return ApiRequest.Pagination; }
			set { ApiRequest.Pagination = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMemberMessagesRequestType.MemberMessageID"/> of type <see cref="string"/>.
		/// </summary>
		public string MemberMessageID
		{ 
			get { return ApiRequest.MemberMessageID; }
			set { ApiRequest.MemberMessageID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMemberMessagesRequestType.SenderID"/> of type <see cref="string"/>.
		/// </summary>
		public string SenderID
		{ 
			get { return ApiRequest.SenderID; }
			set { ApiRequest.SenderID = value; }
		}
				/// <summary>
		/// Gets or sets the <see cref="GetMemberMessagesRequestType.StartCreationTime"/> and <see cref="GetMemberMessagesRequestType.EndCreationTime"/> of type <see cref="TimeFilter"/>.
		/// </summary>
		public TimeFilter CreateTimeFilter
		{ 
			get { return new TimeFilter(ApiRequest.StartCreationTime.Value, ApiRequest.EndCreationTime.Value); }
			set 
			{ 
				if (value.TimeFrom > DateTime.MinValue)
					ApiRequest.StartCreationTime = value.TimeFrom;
				if (value.TimeTo > DateTime.MinValue)
					ApiRequest.EndCreationTime = value.TimeTo;
			}
		}

		
 		/// <summary>
		/// Gets the returned <see cref="GetMemberMessagesResponseType.MemberMessage"/> of type <see cref="MemberMessageExchangeTypeCollection"/>.
		/// </summary>
		public System.Collections.Generic.List<MemberMessageExchangeType> MemberMessageList
		{ 
			get { return ApiResponse.MemberMessage; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetMemberMessagesResponseType.PaginationResult"/> of type <see cref="PaginationResultType"/>.
		/// </summary>
		public PaginationResultType PaginationResult
		{ 
			get { return ApiResponse.PaginationResult; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetMemberMessagesResponseType.HasMoreItems"/> of type <see cref="bool"/>.
		/// </summary>
		public bool HasMoreItems
		{ 
			get { return ApiResponse.HasMoreItems.Value; }
		}
		

		#endregion

		
	}
}
