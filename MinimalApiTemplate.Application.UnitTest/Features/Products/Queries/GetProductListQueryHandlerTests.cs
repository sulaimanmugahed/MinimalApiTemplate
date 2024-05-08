using FluentAssertions;
using MinimalApiTemplate.Application.Contracts.Persistence;
using MinimalApiTemplate.Application.Features.Products.Queries.GetProductList;
using MinimalApiTemplate.Application.UnitTest.Mocks;
using Moq;


namespace MinimalApiTemplate.Application.UnitTest.Features.Products.Queries;
public class GetProductListQueryHandlerTests
{

	private readonly Mock<IProductRepository> _mockProductRepo;
	public GetProductListQueryHandlerTests()
	{
		_mockProductRepo = MockProductRepository.GetProductRepository();
	}


	[Fact]
	public async Task Handel_Should_ReturnTrueBaseResultWithProductDtoList_When_GetProductListQueryRequested()
	{
		// Arrange
		var handler = new GetProductListQueryHandler(_mockProductRepo.Object);

		// Act
		var result = await handler.Handle(new GetProductListQuery(), CancellationToken.None);

		// Assert
		result.Data.Count.Should().Be(5);
		result.Success.Should().BeTrue();
	}

}
