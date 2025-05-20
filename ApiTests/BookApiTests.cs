[Trait("Category", "API")]
[Trait("API", "Book")]
public class BookStoreApiTests
{
    [Fact]
    public async Task VerifyGetAllBooks_ShouldReturnListOfBooks()
    {
        var apiTestBuilder = new ApiTestBuilder();
        (apiTestBuilder, var bookResponse) = await apiTestBuilder.GetAllBooks();

        Assert.NotNull(bookResponse.Data);
        Assert.NotEmpty(bookResponse.Data.Books);
    }

    [Fact]
    public async Task VerifyAddBooks_ShouldReturnCollectionOfIsbns()
    {
        var apiTestBuilder = new ApiTestBuilder();
        apiTestBuilder = await apiTestBuilder.CreateRandomUser();
        apiTestBuilder = await apiTestBuilder.GenerateToken();
        apiTestBuilder = apiTestBuilder.AddBearerAuthorization();

        (apiTestBuilder, var getAllBooksResponse) = await apiTestBuilder.GetAllBooks();
        var firstIsbn = getAllBooksResponse.Data.Books.First().Isbn;

        (apiTestBuilder, var addBookResponse) = await apiTestBuilder.AddBookToCollection(firstIsbn);

        Assert.NotNull(addBookResponse.Data);
        Assert.True(addBookResponse.Data.Books.Where(b => b.Isbn == firstIsbn).Any());
    }

    [Fact]
    public async Task VerifyGetBookByIsbn_ShouldReturnBookDetail()
    {
        var apiTestBuilder = new ApiTestBuilder();

        (apiTestBuilder, var getAllBooksResponse) = await apiTestBuilder.GetAllBooks();
        var firstIsbn = getAllBooksResponse.Data.Books.First().Isbn;

        (apiTestBuilder, var getBookResponse) = await apiTestBuilder.GetBookByIsbn(firstIsbn);

        Assert.NotNull(getBookResponse.Data);
        Assert.Equal(firstIsbn, getBookResponse.Data.Isbn);
    }

    [Fact]
    public async Task VerifyDeleteAllBooks_ShouldSucceed()
    {
        var apiTestBuilder = new ApiTestBuilder();
        apiTestBuilder = await apiTestBuilder.CreateRandomUser();
        apiTestBuilder = await apiTestBuilder.GenerateToken();
        apiTestBuilder = apiTestBuilder.AddBearerAuthorization();

        (apiTestBuilder, var getAllBooksResponse) = await apiTestBuilder.GetAllBooks();
        var firstIsbn = getAllBooksResponse.Data.Books.First().Isbn;

        (apiTestBuilder, var addBookResponse) = await apiTestBuilder.AddBookToCollection(firstIsbn);

        (apiTestBuilder, var deleteBooksResponse) = await apiTestBuilder.DeleteAllBooks();

        Assert.Equal(System.Net.HttpStatusCode.NoContent, deleteBooksResponse.StatusCode);
    }

    [Fact]
    public async Task VerifyDeleteBookByIsbn_ShouldSucceed()
    {
        var apiTestBuilder = new ApiTestBuilder();
        apiTestBuilder = await apiTestBuilder.CreateRandomUser();
        apiTestBuilder = await apiTestBuilder.GenerateToken();
        apiTestBuilder = apiTestBuilder.AddBearerAuthorization();

        (apiTestBuilder, var getAllBooksResponse) = await apiTestBuilder.GetAllBooks();
        var firstIsbn = getAllBooksResponse.Data.Books.First().Isbn;

        (apiTestBuilder, var addBookResponse) = await apiTestBuilder.AddBookToCollection(firstIsbn);

        (apiTestBuilder, var deleteBookResponse) = await apiTestBuilder.DeleteBook(firstIsbn);

        Assert.Equal(System.Net.HttpStatusCode.NoContent, deleteBookResponse.StatusCode);
    }

    [Fact]
    public async Task VerifyReplaceBook_ShouldUpdateUserBooks()
    {
        var apiTestBuilder = new ApiTestBuilder();
        apiTestBuilder = await apiTestBuilder.CreateRandomUser();
        apiTestBuilder = await apiTestBuilder.GenerateToken();
        apiTestBuilder = apiTestBuilder.AddBearerAuthorization();

        (apiTestBuilder, var getAllBooksResponse) = await apiTestBuilder.GetAllBooks();

        var firstIsbn = getAllBooksResponse.Data.Books.First().Isbn;
        var lastIsbn = getAllBooksResponse.Data.Books.Last().Isbn;

        (apiTestBuilder, var addBookResponse) = await apiTestBuilder.AddBookToCollection(firstIsbn);

        (apiTestBuilder, var replaceBookResponse) = await apiTestBuilder.ReplaceBook(
            firstIsbn,
            lastIsbn
        );

        Assert.True(replaceBookResponse.IsSuccessful);
    }
}
