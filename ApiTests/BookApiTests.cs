using System.Net;

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
        (apiTestBuilder, _) = await apiTestBuilder.GenerateToken();


        apiTestBuilder = apiTestBuilder.AddBearerAuthorization();

        (apiTestBuilder, var getAllBooksResponse) = await apiTestBuilder.GetAllBooks();
        var firstIsbn = getAllBooksResponse.Data.Books.First().Isbn;

        (apiTestBuilder, var addBookResponse) = await apiTestBuilder.AddBookToCollection(firstIsbn);

        Assert.NotNull(addBookResponse.Data);
        Assert.True(addBookResponse.Data.Books.Where(b => b.Isbn == firstIsbn).Any());
    }

    [Fact]
    public async Task VerifyAddBooks_ShouldThrowWhenUserIsNotAuthorized()
    {

        var apiTestBuilder = new ApiTestBuilder();
        apiTestBuilder = await apiTestBuilder.CreateRandomUser();
        (apiTestBuilder, _) = await apiTestBuilder.GenerateToken();

        (apiTestBuilder, var getAllBooksResponse) = await apiTestBuilder.GetAllBooks();
        var firstIsbn = getAllBooksResponse.Data.Books.First().Isbn;

        (apiTestBuilder, var addBookResponse) = await apiTestBuilder.AddBookToCollection(firstIsbn);

        Assert.Equal(HttpStatusCode.Unauthorized, addBookResponse.StatusCode);
        Assert.Contains("User not authorized!", addBookResponse.Content);
    }


    [Fact]
    public async Task VerifyAddBooks_ShouldThrowWhenBookIsbnNotFound()
    {

        var apiTestBuilder = new ApiTestBuilder();
        apiTestBuilder = await apiTestBuilder.CreateRandomUser();
        (apiTestBuilder, _) = await apiTestBuilder.GenerateToken();
        apiTestBuilder = apiTestBuilder.AddBearerAuthorization();


        (apiTestBuilder, var addBookResponse) = await apiTestBuilder.AddBookToCollection(Guid.NewGuid().ToString());

        Assert.Equal(HttpStatusCode.BadRequest, addBookResponse.StatusCode);
        Assert.Contains("ISBN supplied is not available in Books Collection!", addBookResponse.Content);
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
    public async Task VerifyGetBookByIsbn_ShouldThrowWhenIsbnNotFound()
    {
        var apiTestBuilder = new ApiTestBuilder();
        (apiTestBuilder, var getBookResponse) = await apiTestBuilder.GetBookByIsbn(Guid.NewGuid().ToString());

        Assert.Equal(HttpStatusCode.BadRequest, getBookResponse.StatusCode);
        Assert.Contains("ISBN supplied is not available in Books Collection!", getBookResponse.Content);
    }


    [Fact]
    public async Task VerifyDeleteAllBooks_ShouldSucceed()
    {
        var apiTestBuilder = new ApiTestBuilder();
        apiTestBuilder = await apiTestBuilder.CreateRandomUser();
        (apiTestBuilder, _) = await apiTestBuilder.GenerateToken();
        apiTestBuilder = apiTestBuilder.AddBearerAuthorization();

        (apiTestBuilder, var getAllBooksResponse) = await apiTestBuilder.GetAllBooks();
        var firstIsbn = getAllBooksResponse.Data.Books.First().Isbn;

        (apiTestBuilder, var addBookResponse) = await apiTestBuilder.AddBookToCollection(firstIsbn);

        (apiTestBuilder, var deleteBooksResponse) = await apiTestBuilder.DeleteAllBooks();

        Assert.Equal(System.Net.HttpStatusCode.NoContent, deleteBooksResponse.StatusCode);
    }

    [Fact]
    public async Task VerifyDeleteBookByIsbn_ShouldSucceedWhenExistIsbn()
    {
        var apiTestBuilder = new ApiTestBuilder();
        apiTestBuilder = await apiTestBuilder.CreateRandomUser();
        (apiTestBuilder, _) = await apiTestBuilder.GenerateToken();
        apiTestBuilder = apiTestBuilder.AddBearerAuthorization();

        (apiTestBuilder, var getAllBooksResponse) = await apiTestBuilder.GetAllBooks();
        var firstIsbn = getAllBooksResponse.Data.Books.First().Isbn;

        (apiTestBuilder, var addBookResponse) = await apiTestBuilder.AddBookToCollection(firstIsbn);

        (apiTestBuilder, var deleteBookResponse) = await apiTestBuilder.DeleteBook(firstIsbn);

        Assert.Equal(System.Net.HttpStatusCode.NoContent, deleteBookResponse.StatusCode);
    }


    [Fact]
    public async Task VerifyDeleteBookByIsbn_ShouldThrowWhenIsbnNotExist()
    {
        var apiTestBuilder = new ApiTestBuilder();
        apiTestBuilder = await apiTestBuilder.CreateRandomUser();
        (apiTestBuilder, _) = await apiTestBuilder.GenerateToken();
        apiTestBuilder = apiTestBuilder.AddBearerAuthorization();

        (apiTestBuilder, var deleteBookResponse) = await apiTestBuilder.DeleteBook(Guid.NewGuid().ToString());

        Assert.Equal(System.Net.HttpStatusCode.BadRequest, deleteBookResponse.StatusCode);
        Assert.Contains("ISBN supplied is not available in User's Collection!", deleteBookResponse.Content);
    }

    [Fact]
    public async Task VerifyReplaceBook_ShouldUpdateUserBooks()
    {
        var apiTestBuilder = new ApiTestBuilder();
        apiTestBuilder = await apiTestBuilder.CreateRandomUser();
        (apiTestBuilder, _) = await apiTestBuilder.GenerateToken();
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

    [Fact]
    public async Task VerifyReplaceBook_ShouldThrowWhenSourceOrTargetIsbnNotExist()
    {
        var apiTestBuilder = new ApiTestBuilder();
        apiTestBuilder = await apiTestBuilder.CreateRandomUser();
        (apiTestBuilder, _) = await apiTestBuilder.GenerateToken();
        apiTestBuilder = apiTestBuilder.AddBearerAuthorization();

        (apiTestBuilder, var getAllBooksResponse) = await apiTestBuilder.GetAllBooks();

        var firstIsbn = getAllBooksResponse.Data.Books.First().Isbn;
        var lastIsbn = getAllBooksResponse.Data.Books.Last().Isbn;

        (apiTestBuilder, var addBookResponse) = await apiTestBuilder.AddBookToCollection(firstIsbn);

        (apiTestBuilder, var replaceBookResponse) = await apiTestBuilder.ReplaceBook(
            Guid.NewGuid().ToString(),
            lastIsbn
        );

        Assert.Equal(HttpStatusCode.BadRequest, replaceBookResponse.StatusCode);
        Assert.Contains("ISBN supplied is not available in User's Collection!", replaceBookResponse.Content);


        (apiTestBuilder, replaceBookResponse) = await apiTestBuilder.ReplaceBook(
            firstIsbn,
            Guid.NewGuid().ToString()
        );

        Assert.Equal(HttpStatusCode.BadRequest, replaceBookResponse.StatusCode);
        Assert.Contains("ISBN supplied is not available in Books Collection!", replaceBookResponse.Content);

    }
}
