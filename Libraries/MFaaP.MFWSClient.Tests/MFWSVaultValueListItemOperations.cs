﻿using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;

namespace MFaaP.MFWSClient.Tests
{
	[TestClass]
	public class MFWSVaultValueListItemOperations
	{

		#region GetValueListItems

		/// <summary>
		/// Ensures that a call to <see cref="MFaaP.MFWSClient.MFWSVaultValueListItemOperations.GetValueListItems"/>
		/// requests the correct resource address.
		/// </summary>
		[TestMethod]
		public async Task GetValueListItemsAsync_CorrectResource()
		{
			/* Arrange */

			// The actual requested address.
			var resourceAddress = "";

			// Create our restsharp mock.
			var mock = new Mock<IRestClient>();

			// When the execute method is called, log the resource requested.
			mock
				.Setup(c => c.ExecuteTaskAsync<Results<ValueListItem>>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()))
				.Callback((IRestRequest r, CancellationToken t) => {
					resourceAddress = r.Resource;
				})
				// Return a mock response.
				.Returns(() =>
				{
					// Create the mock response.
					var response = new Mock<IRestResponse<Results<ValueListItem>>>();

					// Setup the return data.
					response.SetupGet(r => r.Data)
						.Returns(new Results<ValueListItem>());

					//Return the mock object.
					return Task.FromResult(response.Object);
				});

			/* Act */

			// Create our MFWSClient.
			var mfwsClient = MFWSClient.GetMFWSClient(mock);

			// Execute.
			await mfwsClient.ValueListItemOperations.GetValueListItemsAsync(1);

			/* Assert */

			// Execute must be called once.
			mock.Verify(c => c.ExecuteTaskAsync<Results<ValueListItem>>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()), Times.Exactly(1));

			// Resource must be correct.
			Assert.AreEqual("/REST/valuelists/1/items", resourceAddress);
		}

		/// <summary>
		/// Ensures that a call to <see cref="MFaaP.MFWSClient.MFWSVaultValueListItemOperations.GetValueListItems"/>
		/// requests the correct resource address.
		/// </summary>
		[TestMethod]
		public void GetValueListItems_CorrectResource()
		{
			/* Arrange */

			// The actual requested address.
			var resourceAddress = "";

			// Create our restsharp mock.
			var mock = new Mock<IRestClient>();

			// When the execute method is called, log the resource requested.
			mock
				.Setup(c => c.ExecuteTaskAsync<Results<ValueListItem>>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()))
				.Callback((IRestRequest r, CancellationToken t) => {
					resourceAddress = r.Resource;
				})
				// Return a mock response.
				.Returns(() =>
				{
					// Create the mock response.
					var response = new Mock<IRestResponse<Results<ValueListItem>>>();

					// Setup the return data.
					response.SetupGet(r => r.Data)
						.Returns(new Results<ValueListItem>());

					//Return the mock object.
					return Task.FromResult(response.Object);
				});

			/* Act */

			// Create our MFWSClient.
			var mfwsClient = MFWSClient.GetMFWSClient(mock);

			// Execute.
			mfwsClient.ValueListItemOperations.GetValueListItems(1);

			/* Assert */

			// Execute must be called once.
			mock.Verify(c => c.ExecuteTaskAsync<Results<ValueListItem>>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()), Times.Exactly(1));

			// Resource must be correct.
			Assert.AreEqual("/REST/valuelists/1/items", resourceAddress);
		}

		/// <summary>
		/// Ensures that a call to <see cref="MFaaP.MFWSClient.MFWSVaultValueListItemOperations.GetValueListItems"/>
		/// requests the correct resource address.
		/// </summary>
		[TestMethod]
		public async Task GetValueListItemsAsync_CorrectResource_WithNameFilter()
		{
			/* Arrange */

			// The actual requested address.
			var resourceAddress = "";

			// Create our restsharp mock.
			var mock = new Mock<IRestClient>();

			// When the execute method is called, log the resource requested.
			mock
				.Setup(c => c.ExecuteTaskAsync<Results<ValueListItem>>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()))
				.Callback((IRestRequest r, CancellationToken t) => {
					resourceAddress = r.Resource;
				})
				// Return a mock response.
				.Returns(() =>
				{
					// Create the mock response.
					var response = new Mock<IRestResponse<Results<ValueListItem>>>();

					// Setup the return data.
					response.SetupGet(r => r.Data)
						.Returns(new Results<ValueListItem>());

					//Return the mock object.
					return Task.FromResult(response.Object);
				});

			/* Act */

			// Create our MFWSClient.
			var mfwsClient = MFWSClient.GetMFWSClient(mock);

			// Execute.
			await mfwsClient.ValueListItemOperations.GetValueListItemsAsync(1, "hello");

			/* Assert */

			// Execute must be called once.
			mock.Verify(c => c.ExecuteTaskAsync<Results<ValueListItem>>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()), Times.Exactly(1));

			// Resource must be correct.
			Assert.AreEqual("/REST/valuelists/1/items?filter=hello", resourceAddress);
		}

		/// <summary>
		/// Ensures that a call to <see cref="MFaaP.MFWSClient.MFWSVaultValueListItemOperations.GetValueListItems"/>
		/// requests the correct resource address.
		/// </summary>
		[TestMethod]
		public void GetValueListItems_CorrectResource_WithNameFilter()
		{
			/* Arrange */

			// The actual requested address.
			var resourceAddress = "";

			// Create our restsharp mock.
			var mock = new Mock<IRestClient>();

			// When the execute method is called, log the resource requested.
			mock
				.Setup(c => c.ExecuteTaskAsync<Results<ValueListItem>>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()))
				.Callback((IRestRequest r, CancellationToken t) => {
					resourceAddress = r.Resource;
				})
				// Return a mock response.
				.Returns(() =>
				{
					// Create the mock response.
					var response = new Mock<IRestResponse<Results<ValueListItem>>>();

					// Setup the return data.
					response.SetupGet(r => r.Data)
						.Returns(new Results<ValueListItem>());

					//Return the mock object.
					return Task.FromResult(response.Object);
				});

			/* Act */

			// Create our MFWSClient.
			var mfwsClient = MFWSClient.GetMFWSClient(mock);

			// Execute.
			mfwsClient.ValueListItemOperations.GetValueListItems(1, "hello");

			/* Assert */

			// Execute must be called once.
			mock.Verify(c => c.ExecuteTaskAsync<Results<ValueListItem>>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()), Times.Exactly(1));

			// Resource must be correct.
			Assert.AreEqual("/REST/valuelists/1/items?filter=hello", resourceAddress);
		}

		/// <summary>
		/// Ensures that a call to <see cref="MFaaP.MFWSClient.MFWSVaultValueListItemOperations.GetValueListItems"/>
		/// requests the correct resource address.
		/// </summary>
		[TestMethod]
		public async Task GetValueListItemsAsync_CorrectResource_WithLimit()
		{
			/* Arrange */

			// The actual requested address.
			var resourceAddress = "";

			// Create our restsharp mock.
			var mock = new Mock<IRestClient>();

			// When the execute method is called, log the resource requested.
			mock
				.Setup(c => c.ExecuteTaskAsync<Results<ValueListItem>>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()))
				.Callback((IRestRequest r, CancellationToken t) => {
					resourceAddress = r.Resource;
				})
				// Return a mock response.
				.Returns(() =>
				{
					// Create the mock response.
					var response = new Mock<IRestResponse<Results<ValueListItem>>>();

					// Setup the return data.
					response.SetupGet(r => r.Data)
						.Returns(new Results<ValueListItem>());

					//Return the mock object.
					return Task.FromResult(response.Object);
				});

			/* Act */

			// Create our MFWSClient.
			var mfwsClient = MFWSClient.GetMFWSClient(mock);

			// Execute.
			await mfwsClient.ValueListItemOperations.GetValueListItemsAsync(1, null, default(CancellationToken), 501);

			/* Assert */

			// Execute must be called once.
			mock.Verify(c => c.ExecuteTaskAsync<Results<ValueListItem>>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()), Times.Exactly(1));

			// Resource must be correct.
			Assert.AreEqual("/REST/valuelists/1/items?limit=501", resourceAddress);
		}

		/// <summary>
		/// Ensures that a call to <see cref="MFaaP.MFWSClient.MFWSVaultValueListItemOperations.GetValueListItems"/>
		/// requests the correct resource address.
		/// </summary>
		[TestMethod]
		public void GetValueListItems_CorrectResource_WithLimit()
		{
			/* Arrange */

			// The actual requested address.
			var resourceAddress = "";

			// Create our restsharp mock.
			var mock = new Mock<IRestClient>();

			// When the execute method is called, log the resource requested.
			mock
				.Setup(c => c.ExecuteTaskAsync<Results<ValueListItem>>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()))
				.Callback((IRestRequest r, CancellationToken t) => {
					resourceAddress = r.Resource;
				})
				// Return a mock response.
				.Returns(() =>
				{
					// Create the mock response.
					var response = new Mock<IRestResponse<Results<ValueListItem>>>();

					// Setup the return data.
					response.SetupGet(r => r.Data)
						.Returns(new Results<ValueListItem>());

					//Return the mock object.
					return Task.FromResult(response.Object);
				});

			/* Act */

			// Create our MFWSClient.
			var mfwsClient = MFWSClient.GetMFWSClient(mock);

			// Execute.
			mfwsClient.ValueListItemOperations.GetValueListItems(1, null, default(CancellationToken), 501);

			/* Assert */

			// Execute must be called once.
			mock.Verify(c => c.ExecuteTaskAsync<Results<ValueListItem>>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()), Times.Exactly(1));

			// Resource must be correct.
			Assert.AreEqual("/REST/valuelists/1/items?limit=501", resourceAddress);
		}
		
		/// <summary>
		/// Ensures that a call to <see cref="MFaaP.MFWSClient.MFWSVaultValueListItemOperations.GetValueListItems"/>
		/// requests the correct resource address.
		/// </summary>
		[TestMethod]
		public async Task GetValueListItemsAsync_CorrectResource_WithLimitAndNameFilter()
		{
			/* Arrange */

			// The actual requested address.
			var resourceAddress = "";

			// Create our restsharp mock.
			var mock = new Mock<IRestClient>();

			// When the execute method is called, log the resource requested.
			mock
				.Setup(c => c.ExecuteTaskAsync<Results<ValueListItem>>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()))
				.Callback((IRestRequest r, CancellationToken t) => {
					resourceAddress = r.Resource;
				})
				// Return a mock response.
				.Returns(() =>
				{
					// Create the mock response.
					var response = new Mock<IRestResponse<Results<ValueListItem>>>();

					// Setup the return data.
					response.SetupGet(r => r.Data)
						.Returns(new Results<ValueListItem>());

					//Return the mock object.
					return Task.FromResult(response.Object);
				});

			/* Act */

			// Create our MFWSClient.
			var mfwsClient = MFWSClient.GetMFWSClient(mock);

			// Execute.
			await mfwsClient.ValueListItemOperations.GetValueListItemsAsync(1, "hello", default(CancellationToken), 501);

			/* Assert */

			// Execute must be called once.
			mock.Verify(c => c.ExecuteTaskAsync<Results<ValueListItem>>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()), Times.Exactly(1));

			// Resource must be correct.
			Assert.AreEqual("/REST/valuelists/1/items?filter=hello&limit=501", resourceAddress);
		}

		/// <summary>
		/// Ensures that a call to <see cref="MFaaP.MFWSClient.MFWSVaultValueListItemOperations.GetValueListItems"/>
		/// requests the correct resource address.
		/// </summary>
		[TestMethod]
		public void GetValueListItems_CorrectResource_WithLimitAndNameFilter()
		{
			/* Arrange */

			// The actual requested address.
			var resourceAddress = "";

			// Create our restsharp mock.
			var mock = new Mock<IRestClient>();

			// When the execute method is called, log the resource requested.
			mock
				.Setup(c => c.ExecuteTaskAsync<Results<ValueListItem>>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()))
				.Callback((IRestRequest r, CancellationToken t) => {
					resourceAddress = r.Resource;
				})
				// Return a mock response.
				.Returns(() =>
				{
					// Create the mock response.
					var response = new Mock<IRestResponse<Results<ValueListItem>>>();

					// Setup the return data.
					response.SetupGet(r => r.Data)
						.Returns(new Results<ValueListItem>());

					//Return the mock object.
					return Task.FromResult(response.Object);
				});

			/* Act */

			// Create our MFWSClient.
			var mfwsClient = MFWSClient.GetMFWSClient(mock);

			// Execute.
			mfwsClient.ValueListItemOperations.GetValueListItems(1, "hello", default(CancellationToken), 501);

            /* Assert */

            // Execute must be called once.
            mock.Verify(c => c.ExecuteTaskAsync<Results<ValueListItem>>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()), Times.Exactly(1));

			// Resource must be correct.
			Assert.AreEqual("/REST/valuelists/1/items?filter=hello&limit=501", resourceAddress);
		}
		
		/// <summary>
		/// Ensures that a call to <see cref="MFaaP.MFWSClient.MFWSVaultValueListItemOperations.GetValueListItems"/>
		/// uses the correct Http method.
		/// </summary>
		[TestMethod]
		public async Task GetValueListItemsAsync_CorrectMethod()
		{
			/* Arrange */

			// The method.
			Method? methodUsed = null;

			// Create our restsharp mock.
			var mock = new Mock<IRestClient>();

			// When the execute method is called, log the resource requested.
			mock
				.Setup(c => c.ExecuteTaskAsync<Results<ValueListItem>>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()))
				.Callback((IRestRequest r, CancellationToken t) => {
					methodUsed = r.Method;
				})
				// Return a mock response.
				.Returns(() =>
				{
					// Create the mock response.
					var response = new Mock<IRestResponse<Results<ValueListItem>>>();

					// Setup the return data.
					response.SetupGet(r => r.Data)
						.Returns(new Results<ValueListItem>());

					//Return the mock object.
					return Task.FromResult(response.Object);
				});

			/* Act */

			// Create our MFWSClient.
			var mfwsClient = MFWSClient.GetMFWSClient(mock);

			// Execute.
			await mfwsClient.ValueListItemOperations.GetValueListItemsAsync(1);

			/* Assert */

			// Execute must be called once.
			mock.Verify(c => c.ExecuteTaskAsync<Results<ValueListItem>>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()), Times.Exactly(1));

			// Method must be correct.
			Assert.AreEqual(Method.GET, methodUsed);
		}

		/// <summary>
		/// Ensures that a call to <see cref="MFaaP.MFWSClient.MFWSVaultValueListItemOperations.GetValueListItems"/>
		/// uses the correct Http method.
		/// </summary>
		[TestMethod]
		public void GetValueListItems_CorrectMethod()
		{
			/* Arrange */

			// The method.
			Method? methodUsed = null;

			// Create our restsharp mock.
			var mock = new Mock<IRestClient>();

			// When the execute method is called, log the resource requested.
			mock
				.Setup(c => c.ExecuteTaskAsync<Results<ValueListItem>>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()))
				.Callback((IRestRequest r, CancellationToken t) => {
					methodUsed = r.Method;
				})
				// Return a mock response.
				.Returns(() =>
				{
					// Create the mock response.
					var response = new Mock<IRestResponse<Results<ValueListItem>>>();

					// Setup the return data.
					response.SetupGet(r => r.Data)
						.Returns(new Results<ValueListItem>());

					//Return the mock object.
					return Task.FromResult(response.Object);
				});

			/* Act */

			// Create our MFWSClient.
			var mfwsClient = MFWSClient.GetMFWSClient(mock);

			// Execute.
			mfwsClient.ValueListItemOperations.GetValueListItems(1);

			/* Assert */

			// Execute must be called once.
			mock.Verify(c => c.ExecuteTaskAsync<Results<ValueListItem>>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()), Times.Exactly(1));

			// Method must be correct.
			Assert.AreEqual(Method.GET, methodUsed);
		}

		#endregion

	}
}
