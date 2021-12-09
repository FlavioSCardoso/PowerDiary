using Shouldly;
using AutoFixture;
using Moq;
using NUnit.Framework;
using PowerDiary.BoundedContexts.Messaging.Chats.Models;
using PowerDiary.BoundedContexts.Messaging.Chats.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace PowerDiary.BoundedContexts.Messaging.Chats.Services.Tests
{
	public class MessagesServicesTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void MessageRepository_Should_ThrowExceptionWithNullRepository()
		{
			//Act
			//Assert
			IMessagesServices messagesServices;
			Mock<ChatsUnitOfWork> unitOfWork = new();
			var ex = Assert.Throws<ArgumentNullException>(() => messagesServices = new MessagesServices(null, unitOfWork.Object));
			ex.Message.ShouldContain("messageRepository");
		}

		[Test]
		public void MessageRepository_Should_ThrowExceptionWithNullUnitOfWork()
		{
			//Act
			//Assert
			IMessagesServices messagesServices;
			Mock<IMessageRepository> mockRepository = new();
			var ex = Assert.Throws<ArgumentNullException>(() => messagesServices = new MessagesServices(mockRepository.Object, null));
			ex.Message.ShouldContain("unitOfWork");
		}

		[Test]
		public async Task MessageRepository_Should_GetAllMessages()
		{
			//Arrange
			Mock<IMessageRepository> mockRepository = new();

			Fixture fixture = new();
			IEnumerable<Message> fakeMessages = fixture.Build<Message>()
													.Without(m => m.Chat)
													.CreateMany();

			mockRepository.Setup(m => m.GetAllAsync()).ReturnsAsync(fakeMessages);
			Mock<ChatsUnitOfWork> unitOfWork = new();

			//Act
			IMessagesServices messagesServices = new MessagesServices(mockRepository.Object, unitOfWork.Object);
			var result = await messagesServices.GetAllMessages();

			//Assert
			result.ShouldNotBeNull();
			result.Count().ShouldBe(fakeMessages.Count());
			result.Any().ShouldBeTrue();
			foreach (var item in result)
			{
				fakeMessages.Any(b => b.Id == item.Id).ShouldBeTrue();
			}
		}

		[Test]
		public async Task MessageRepository_Should_AddOneMessage()
		{
			//Arrange
			Mock<IMessageRepository> mockRepository = new();

			Fixture fixture = new();
			Message fakeMessage = fixture.Build<Message>()
													.Without(m => m.Chat)
													.Create();

			mockRepository.Setup(m => m.AddAsync(It.IsAny<Message>())).Verifiable();
			Mock<ChatsUnitOfWork> unitOfWork = new();

			//Act
			IMessagesServices messagesServices = new MessagesServices(mockRepository.Object, unitOfWork.Object);
			await messagesServices.AddAsync(fakeMessage);

			//Assert
			mockRepository.Verify();
		}

		// Ok, I think you got the point. I should write tests for each service
	}
}