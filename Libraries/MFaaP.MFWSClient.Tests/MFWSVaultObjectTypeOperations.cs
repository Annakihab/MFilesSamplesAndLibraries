﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;

namespace MFaaP.MFWSClient.Tests
{
	[TestClass]
	public class MFWSVaultObjectTypeOperations
	{

		#region Object type alias to ID resolution

		/// <summary>
		/// Ensures that a call to <see cref="MFaaP.MFWSClient.MFWSVaultObjectTypeOperations.GetObjectTypeIDByAliasAsync"/>
		/// requests the correct resource address with the correct method.
		/// </summary>
		[TestMethod]
		public async Task GetObjectTypeIDByAliasAsync()
		{
			// Create our test runner.
			var runner = new RestApiTestRunner<Dictionary<string, int>>(Method.POST, "/REST/structure/objecttypes/itemidbyalias.aspx");

			// Set up the expected body.
			var body = new JsonArray { "hello world" };
			runner.SetExpectedRequestBody(body);

			// Execute.
			await runner.MFWSClient.ObjectTypeOperations.GetObjectTypeIDByAliasAsync("hello world");

			// Verify.
			runner.Verify();
		}

		/// <summary>
		/// Ensures that a call to <see cref="MFaaP.MFWSClient.MFWSVaultObjectTypeOperations.GetObjectTypeIDsByAliasesAsync"/>
		/// requests the correct resource address with the correct method.
		/// </summary>
		[TestMethod]
		public async Task GetObjectTypeIDsByAliasesAsync()
		{
			// Create our test runner.
			var runner = new RestApiTestRunner<Dictionary<string, int>>(Method.POST, "/REST/structure/objecttypes/itemidbyalias.aspx");

			// Set up the expected body.
			var body = new JsonArray { "hello", "world", "third option" };
			runner.SetExpectedRequestBody(body);

			// Execute.
			await runner.MFWSClient.ObjectTypeOperations.GetObjectTypeIDsByAliasesAsync(aliases: new string[] { "hello", "world", "third option" });

			// Verify.
			runner.Verify();
		}

		/// <summary>
		/// Ensures that a call to <see cref="MFaaP.MFWSClient.MFWSVaultObjectTypeOperations.GetObjectTypeIDsByAliases"/>
		/// requests the correct resource address with the correct method.
		/// </summary>
		[TestMethod]
		public void GetObjectTypeIDsByAliases()
		{
			// Create our test runner.
			var runner = new RestApiTestRunner<Dictionary<string, int>>(Method.POST, "/REST/structure/objecttypes/itemidbyalias.aspx");

			// Set up the expected body.
			var body = new JsonArray { "hello", "world", "third option" };
			runner.SetExpectedRequestBody(body);

			// Execute.
			runner.MFWSClient.ObjectTypeOperations.GetObjectTypeIDsByAliases(aliases: new string[] { "hello", "world", "third option" });

			// Verify.
			runner.Verify();
		}

		/// <summary>
		/// Ensures that a call to <see cref="MFaaP.MFWSClient.MFWSVaultObjectTypeOperations.GetObjectTypeIDByAlias"/>
		/// requests the correct resource address with the correct method.
		/// </summary>
		[TestMethod]
		public void GetObjectTypeIDByAlias()
		{
			// Create our test runner.
			var runner = new RestApiTestRunner<Dictionary<string, int>>(Method.POST, "/REST/structure/objecttypes/itemidbyalias.aspx");

			// Set up the expected body.
			var body = new JsonArray { "hello world" };
			runner.SetExpectedRequestBody(body);

			// Execute.
			runner.MFWSClient.ObjectTypeOperations.GetObjectTypeIDByAlias("hello world");

			// Verify.
			runner.Verify();
		}

		#endregion

		#region GetObjectTypes

		/// <summary>
		/// Ensures that a call to <see cref="MFaaP.MFWSClient.MFWSVaultObjectTypeOperations.GetObjectTypes"/>
		/// requests the correct resource address.
		/// </summary>
		[TestMethod]
		public async Task GetObjectTypesAsync_CorrectResource()
		{
			/* Arrange */

			// The actual requested address.
			var resourceAddress = "";

			// Create our restsharp mock.
			var mock = new Mock<IRestClient>();

			// When the execute method is called, log the resource requested.
			mock
				.Setup(c => c.ExecuteTaskAsync<List<ObjType>>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()))
				.Callback((IRestRequest r, CancellationToken t) => {
					resourceAddress = r.Resource;
				})
				// Return a mock response.
				.Returns(() =>
				{
					// Create the mock response.
					var response = new Mock<IRestResponse<List<ObjType>>>();

					// Setup the return data.
					response.SetupGet(r => r.Data)
						.Returns(new List<ObjType>());

					//Return the mock object.
					return Task.FromResult(response.Object);
				});

			/* Act */

			// Create our MFWSClient.
			var mfwsClient = MFWSClient.GetMFWSClient(mock);

			// Execute.
			await mfwsClient.ObjectTypeOperations.GetObjectTypesAsync();

			/* Assert */

			// Execute must be called once.
			mock.Verify(c => c.ExecuteTaskAsync<List<ObjType>>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()), Times.Exactly(1));

			// Resource must be correct.
			Assert.AreEqual("/REST/structure/objecttypes", resourceAddress);
		}

		/// <summary>
		/// Ensures that a call to <see cref="MFaaP.MFWSClient.MFWSVaultObjectTypeOperations.GetObjectTypes"/>
		/// requests the correct resource address.
		/// </summary>
		[TestMethod]
		public void GetObjectTypes_CorrectResource()
		{
			/* Arrange */

			// The actual requested address.
			var resourceAddress = "";

			// Create our restsharp mock.
			var mock = new Mock<IRestClient>();

			// When the execute method is called, log the resource requested.
			mock
				.Setup(c => c.ExecuteTaskAsync<List<ObjType>>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()))
				.Callback((IRestRequest r, CancellationToken t) => {
					resourceAddress = r.Resource;
				})
				// Return a mock response.
				.Returns(() =>
				{
					// Create the mock response.
					var response = new Mock<IRestResponse<List<ObjType>>>();

					// Setup the return data.
					response.SetupGet(r => r.Data)
						.Returns(new List<ObjType>());

					//Return the mock object.
					return Task.FromResult(response.Object);
				});

			/* Act */

			// Create our MFWSClient.
			var mfwsClient = MFWSClient.GetMFWSClient(mock);

			// Execute.
			mfwsClient.ObjectTypeOperations.GetObjectTypes();

			/* Assert */

			// Execute must be called once.
			mock.Verify(c => c.ExecuteTaskAsync<List<ObjType>>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()), Times.Exactly(1));

			// Resource must be correct.
			Assert.AreEqual("/REST/structure/objecttypes", resourceAddress);
		}

		/// <summary>
		/// Ensures that a call to <see cref="MFaaP.MFWSClient.MFWSVaultObjectTypeOperations.GetObjectTypes"/>
		/// uses the correct Http method.
		/// </summary>
		[TestMethod]
		public async Task GetObjectTypesAsync_CorrectMethod()
		{
			/* Arrange */

			// The method.
			Method? methodUsed = null;

			// Create our restsharp mock.
			var mock = new Mock<IRestClient>();

			// When the execute method is called, log the resource requested.
			mock
				.Setup(c => c.ExecuteTaskAsync<List<ObjType>>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()))
				.Callback((IRestRequest r, CancellationToken t) => {
					methodUsed = r.Method;
				})
				// Return a mock response.
				.Returns(() =>
				{
					// Create the mock response.
					var response = new Mock<IRestResponse<List<ObjType>>>();

					// Setup the return data.
					response.SetupGet(r => r.Data)
						.Returns(new List<ObjType>());

					//Return the mock object.
					return Task.FromResult(response.Object);
				});

			/* Act */

			// Create our MFWSClient.
			var mfwsClient = MFWSClient.GetMFWSClient(mock);

			// Execute.
			await mfwsClient.ObjectTypeOperations.GetObjectTypesAsync();

			/* Assert */

			// Execute must be called once.
			mock.Verify(c => c.ExecuteTaskAsync<List<ObjType>>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()), Times.Exactly(1));

			// Method must be correct.
			Assert.AreEqual(Method.GET, methodUsed);
		}

		/// <summary>
		/// Ensures that a call to <see cref="MFaaP.MFWSClient.MFWSVaultObjectTypeOperations.GetObjectTypes"/>
		/// uses the correct Http method.
		/// </summary>
		[TestMethod]
		public void GetObjectTypes_CorrectMethod()
		{
			/* Arrange */

			// The method.
			Method? methodUsed = null;

			// Create our restsharp mock.
			var mock = new Mock<IRestClient>();

			// When the execute method is called, log the resource requested.
			mock
				.Setup(c => c.ExecuteTaskAsync<List<ObjType>>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()))
				.Callback((IRestRequest r, CancellationToken t) => {
					methodUsed = r.Method;
				})
				// Return a mock response.
				.Returns(() =>
				{
					// Create the mock response.
					var response = new Mock<IRestResponse<List<ObjType>>>();

					// Setup the return data.
					response.SetupGet(r => r.Data)
						.Returns(new List<ObjType>());

					//Return the mock object.
					return Task.FromResult(response.Object);
				});

			/* Act */

			// Create our MFWSClient.
			var mfwsClient = MFWSClient.GetMFWSClient(mock);

			// Execute.
			mfwsClient.ObjectTypeOperations.GetObjectTypes();

			/* Assert */

			// Execute must be called once.
			mock.Verify(c => c.ExecuteTaskAsync<List<ObjType>>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()), Times.Exactly(1));

			// Method must be correct.
			Assert.AreEqual(Method.GET, methodUsed);
		}

		#endregion

	}
}
