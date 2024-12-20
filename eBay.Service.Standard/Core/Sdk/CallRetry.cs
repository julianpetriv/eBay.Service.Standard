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
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using eBay.Service.Core.Soap;

#endregion

namespace eBay.Service.Core.Sdk
{

	/// <summary>
	/// When your application accesses the eBay platform using the SDK, errors can occur. For many types of these 
    /// errors, your application should retry the call. For example, for most calls that fail due to HTTP problems, 
    /// such as error 502 bad gateway, error 404, and so forth, you should retry two or three times. Similarly, API call 
    /// failures, notably <see cref="eBay.Service.Call.AddItemCall"/>, can occur even though the request is validly constructed due to server traffic.
    /// 
    /// The SDK provides an easy way to make call retries 
    /// using the <see cref="eBay.Service.Core.Sdk.ApiCall"/> class property named CallRetry. To do this, you instantiate 
    /// an object of the CallRetry class and set the number of retries, the errors for which you want to retry and the 
    /// interval at which you want to retry. You must retry only for errors caused on the eBay server side and not because 
    /// of an error in your application, because retries will not help resolve application errors. You should normally try no more than 2 times. 
    /// You should check the Error result set returned by the API call and set valid input arguments before you retry. 
    /// 
    /// You can retry on any of following errors:
    /// <list type="bullet">
    /// <item>API errors using TriggerErrorCodes</item>
    /// <item>HTTP errors using TriggerHttpStatusCodes</item>
    /// <item>.NET or SDK exception using TriggerExceptions</item>
    /// </list>
    /// For details and a complete code sample, see the knowledgebase article
    /// <see href="http://ebay.custhelp.com/cgi-bin/ebay.cfg/php/enduser/std_adp.php?p_faqid=412">Call Retries.</see>
	/// </summary>
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	public class CallRetry
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public CallRetry() 
		{
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Determines if a retry should be invoked based on an exception that occured.
		/// </summary>
		/// <param name="ex">The <see cref="System.Exception"/> to test for retry.</param>
		/// <returns>Returns <b>true</b> if retry should be invoked, else <b>false</b></returns>
		public bool ShouldRetry(Exception ex)
		{
			return mFilter.Matches(ex);
		}
		#endregion

		#region Properties
		/// <summary>
		/// Time to wait between retries.
		/// </summary>
		public int DelayTime
		{
			get { return mDelayTime; }
			set { mDelayTime = value; }
		}

		/// <summary>
		/// Maximum number of times to retry.
		/// </summary>
		public int MaximumRetries
		{
			get { return mMaximumRetries; }
			set { 
				if (value < 0)
					throw new SdkException("Maximum retries is invalid", new ArgumentException());
				mMaximumRetries = value; }
		}

		/// <summary>
		/// If using the getter, this gets the error codes that will result in a retry. Type <see cref="List<string>"/>.
        /// If using the setter, this specifies the error codes that are to cause a retry.
		/// </summary>
		public List<string> TriggerErrorCodes
		{
			get { return mFilter.TriggerErrorCodes; }
			set { mFilter.TriggerErrorCodes = value ; }
		}

		/// <summary>
		/// If using the getter, this gets the status codes that will result in a retry. Type <see cref="List<string>"/>.
        /// If using the setter, this specifies the status codes that are to cause a retry.
		/// </summary>
		public List<Int32> TriggerHttpStatusCodes
		{
			get { return mFilter.TriggerHttpStatusCodes; }
			set { mFilter.TriggerHttpStatusCodes = value ; }
		}

        /// <summary>
        /// If using the getter, this gets the exceptions that will result in a retry. Type <see cref="List<Type>"/>..
        /// If using the setter, this specifies the exceptions that are to cause a retry.
        /// </summary>
        public List<Type> TriggerExceptions
		{
			get { return mFilter.TriggerExceptions; }
			set { mFilter.TriggerExceptions = value ; }
		}
		#endregion

		#region Private Fields
		private int mDelayTime = 5000;
		private int mMaximumRetries = 0;
		private ExceptionFilter mFilter = new ExceptionFilter();
		#endregion

	}
}
