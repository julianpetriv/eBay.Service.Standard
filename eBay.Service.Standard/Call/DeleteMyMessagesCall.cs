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
    public class DeleteMyMessagesCall : ApiCall
    {

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public DeleteMyMessagesCall()
        {
            ApiRequest = new DeleteMyMessagesRequestType();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
        public DeleteMyMessagesCall(ApiContext ApiContext)
        {
            ApiRequest = new DeleteMyMessagesRequestType();
            this.ApiContext = ApiContext;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Removes selected messages for a given user.
        /// </summary>
        /// 
        /// <param name="AlertIDList">
        /// This field is deprecated.
        /// </param>
        ///
        /// <param name="MessageIDList">
        /// Contains a list of up to 10 <b>MessageID</b> values.
        /// </param>
        ///
        public void DeleteMyMessages(List<string> AlertIDList, List<string> MessageIDList)
        {
            this.MessageIDList = MessageIDList;

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
        /// Gets or sets the <see cref="DeleteMyMessagesRequestType"/> for this API call.
        /// </summary>
        public DeleteMyMessagesRequestType ApiRequest
        {
            get { return (DeleteMyMessagesRequestType)AbstractRequest; }
            set { AbstractRequest = value; }
        }

        /// <summary>
        /// Gets the <see cref="DeleteMyMessagesResponseType"/> for this API call.
        /// </summary>
        public DeleteMyMessagesResponseType ApiResponse
        {
            get { return (DeleteMyMessagesResponseType)AbstractResponse; }
        }

        /// <summary>
        /// Gets or sets the <see cref="DeleteMyMessagesRequestType.MessageIDs"/> of type <see cref="List<string>"/>.
        /// </summary>
        public List<string> MessageIDList
        {
            get { return ApiRequest.MessageIDs; }
            set { ApiRequest.MessageIDs = value; }
        }



        #endregion


    }
}
