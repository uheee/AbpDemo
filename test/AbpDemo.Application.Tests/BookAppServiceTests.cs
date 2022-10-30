using System;
using System.Linq;
using System.Threading.Tasks;
using AbpDemo.Books;
using Shouldly;
using Volo.Abp.Validation;
using Xunit;

namespace AbpDemo;

public sealed class BookAppServiceTests : AbpDemoApplicationTestBase
{
    private readonly IBookAppService _bookAppService;

    public BookAppServiceTests()
    {
        _bookAppService = GetRequiredService<IBookAppService>();
    }

    [Fact]
    public async Task Should_Get_List_Of_Books()
    {
        #region Act

        var result = await _bookAppService.GetListAsync(new());

        #endregion

        #region Assert

        result.TotalCount.ShouldBeGreaterThan(0);
        result.Items.ShouldContain(book => book.Name == "1984");

        #endregion
    }

    [Fact]
    public async Task Should_Create_A_Valid_Book()
    {
        #region Act

        var result = await _bookAppService.CreateAsync(new()
        {
            Name = "New test book 42",
            Price = 10,
            PublishDate = DateTime.Now,
            Type = BookType.ScienceFiction
        });

        #endregion

        #region Assert

        //Assert
        result.Id.ShouldNotBe(Guid.Empty);
        result.Name.ShouldBe("New test book 42");

        #endregion
    }
    
    [Fact]
    public async Task Should_Not_Create_A_Book_Without_Name()
    {
        var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
        {
            await _bookAppService.CreateAsync(
                new CreateUpdateBookDto
                {
                    Name = "",
                    Price = 10,
                    PublishDate = DateTime.Now,
                    Type = BookType.ScienceFiction
                }
            );
        });

        exception.ValidationErrors
            .ShouldContain(err => err.MemberNames.Any(mem => mem == "Name"));
    }
}