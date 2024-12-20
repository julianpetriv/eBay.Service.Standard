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
	public class ReviseMyMessagesCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public ReviseMyMessagesCall()
		{
			ApiRequest = new ReviseMyMessagesRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public ReviseMyMessagesCall(ApiContext ApiContext)
		{
			ApiRequest = new ReviseMyMessagesRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// This call can be used to mark one or more messages as 'Read', to flag one or more messages, and/or to move one or more messages to another My Messages folder. Any of these actions can be applied on up to 10 messages with one call.
		/// </summary>
		/// 
		/// <param name="MessageIDList">
		/// This container is used to specify up to 10 messages (specified with their  <b>MessageID</b> values) on which to perform on or more actions. At least one <b>MessageID</b> value must be included in the request. <b>MessageID</b> values can be retrieved with the <b>GetMyMessages</b> call with the <b>DetailLevel</b> value set to <code>ReturnHeaders</code>.
		/// 
		/// 
		/// <span class="tablenote"><b>Note:</b> Messages in the Sent folder of My Messages cannot be moved, marked as read, or flagged. </span>
		/// </param>
		///
		/// <param name="AlertIDList">
		/// This field is deprecated.
		/// </param>
		///
		/// <param name="Read">
		/// This boolean field is used to change the 'Read' status of the message(s) in the <b>MessageIDs</b> container. Including this field and setting its value to <code>true</code> will mark all messages in the <b>MessageIDs</b> container as 'Read'. Conversely, including this field and setting its value to <code>false</code> will mark all messages in the <b>MessageIDs</b> container as 'Unread'. The 'Read' status of a message can be retrieved by looking at the <b>Message.Read</b> boolean field of the <b>GetMyMessages</b> call response.
		/// 
		/// 
		/// In each <b>ReviseMyMessages</b> call, at least one of the following fields must be specified in the request: <b>Read</b>, <b>Flagged</b>, and <b>FolderID</b>.
		/// 
		/// 
		/// <span class="tablenote"><b>Note:</b> Messages in the Sent folder of My Messages cannot be moved, marked as read, or flagged. </span>
		/// </param>
		///
		/// <param name="Flagged">
		/// This boolean field is used to change the 'Flagged' status of the message(s) in the <b>MessageIDs</b> container. Including this field and setting its value to <code>true</code> will flag all messages in the <b>MessageIDs</b> container. Conversely, including this field and setting its value to <code>false</code> will unflag all messages in the <b>MessageIDs</b> container. The 'Flagged' status of a message can be retrieved by looking at the <b>Message.Flagged</b> boolean field of the <b>GetMyMessages</b> call response.
		/// 
		/// 
		/// In each <b>ReviseMyMessages</b> call, at least one of the following fields must be specified in the request: <b>Read</b>, <b>Flagged</b>, and <b>FolderID</b>.
		/// 
		/// 
		/// <span class="tablenote"><b>Note:</b> Messages in the Sent folder of My Messages cannot be moved, marked as read, or flagged. </span>
		/// </param>
		///
		/// <param name="FolderID">
		/// A unique identifier of My Messages folder. A <b>FolderID</b> value is supplied if the user want to move the message(s) in the <b>MessageIDs</b> container to a different folder. <b>FolderID</b> values can be retrieved with the <b>GetMyMessages</b> call with the <b>DetailLevel</b> value set to <code>ReturnSummary</code>. 
		/// 
		/// In each <b>ReviseMyMessages</b> call, at least one of the following fields must be specified in the request: <b>Read</b>, <b>Flagged</b>, and <b>FolderID</b>.
		/// 
		/// 
		/// <span class="tablenote"><b>Note:</b> Messages in the Sent folder of My Messages cannot be moved, marked as read, or flagged. </span>
		/// </param>
		///
		public void ReviseMyMessages(List<string> MessageIDList, List<string> AlertIDList, bool Read, bool Flagged, long FolderID)
		{
			this.MessageIDList = MessageIDList;
			this.Read = Read;
			this.Flagged = Flagged;
			this.FolderID = FolderID;

			Execute();
			
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void ReviseMyMessages(bool Read, bool Flagged, List<string> MessageIDList)
		{
			this.Read = Read;
			this.Flagged = Flagged;
			this.MessageIDList = MessageIDList;
			this.Execute();
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
		/// Gets or sets the <see cref="ReviseMyMessagesRequestType"/> for this API call.
		/// </summary>
		public ReviseMyMessagesRequestType ApiRequest
		{ 
			get { return (ReviseMyMessagesRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="ReviseMyMessagesResponseType"/> for this API call.
		/// </summary>
		public ReviseMyMessagesResponseType ApiResponse
		{ 
			get { return (ReviseMyMessagesResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseMyMessagesRequestType.MessageIDs"/> of type <see cref="List<string>"/>.
		/// </summary>
		public List<string> MessageIDList
		{ 
			get { return ApiRequest.MessageIDs; }
			set { ApiRequest.MessageIDs = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseMyMessagesRequestType.Read"/> of type <see cref="bool"/>.
		/// </summary>
		public bool Read
		{ 
			get { return ApiRequest.Read.Value; }
			set { ApiRequest.Read = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseMyMessagesRequestType.Flagged"/> of type <see cref="bool"/>.
		/// </summary>
		public bool Flagged
		{ 
			get { return ApiRequest.Flagged.Value; }
			set { ApiRequest.Flagged = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseMyMessagesRequestType.FolderID"/> of type <see cref="long"/>.
		/// </summary>
		public long FolderID
		{ 
			get { return ApiRequest.FolderID.Value; }
			set { ApiRequest.FolderID = value; }
		}
		
		

		#endregion

		
	}
}
