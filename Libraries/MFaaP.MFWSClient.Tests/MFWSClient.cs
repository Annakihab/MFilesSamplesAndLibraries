﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace MFaaP.MFWSClient.Tests
{
	[TestClass]
	public partial class MFWSClient
	{
		/// <summary>
		/// Creates a MFWSClient using the supplied mock request client.
		/// </summary>
		/// <param name="restClientMoq">The mocked rest client.</param>
		/// <returns></returns>
		public static MFaaP.MFWSClient.MFWSClient GetMFWSClient(Moq.Mock<IRestClient> restClientMoq)
		{
			// Sanity.
			if(null == restClientMoq)
				throw new ArgumentNullException(nameof(restClientMoq));

			// Ensure that we have a default parameter collection, if it's not been mocked already.
			if (null == restClientMoq.Object.DefaultParameters)
			{
				var defaultParameters = new List<Parameter>();
				restClientMoq
					.SetupGet(p => p.DefaultParameters)
					.Returns(defaultParameters);
			}

			// Return our proxy.
			return new MFWSClientProxy(restClientMoq.Object);
		}

		/// <summary>
		/// A proxy around <see cref="MFaaP.MFWSClient.MFWSClient"/>
		/// to allow provision of a mocked <see cref="IRestClient"/>.
		/// </summary>
		private class MFWSClientProxy
			: MFaaP.MFWSClient.MFWSClient
		{
			/// <inheritdoc />
			public MFWSClientProxy(IRestClient restClient) 
				: base(restClient)
			{
			}
			protected override void OnAfterExecuteRequest(IRestResponse e)
			{
				// If the response is null it's because we were testing for the wrong endpoint details.
				if (null == e)
				{
					Assert.Fail("Incorrect HTTP request (either method, endpoint address, or return type was invalid).");
					return;
				}

				// Base implementation.
				base.OnAfterExecuteRequest(e);
			}
		}
	}
}
