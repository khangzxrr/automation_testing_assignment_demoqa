using AccountModel;
using BookStoreModel;

[Trait("Category", "API")]
[Trait("API", "Book")]
public class BookStoreApiTests : IAsyncLifetime
{
    private readonly AccountService accountService = new();
    private readonly BookService bookService = new();

    private RegisterModel registerModel = RegisterModel.Generate();

    private string userId;

    public async Task InitializeAsync()
    {
        var registedUser = await accountService.CreateUser(registerModel);

        userId = registedUser.Data.UserId;

        bookService.AddBasicHeader(registerModel.UserName, registerModel.Password);
    }

    [Fact]
    public async Task VerifyGetAllBooks_ShouldReturnListOfBooks()
    {
        var response = await bookService.GetAllBooks();

        Assert.True(response.IsSuccessful);
        Assert.NotNull(response.Data);
        Assert.NotEmpty(response.Data.Books);
    }

    [Fact]
    public async Task VerifyAddBooks_ShouldReturnCollectionOfIsbns()
    {
        await bookService.DeleteAllBooks(userId);

        var addBooks = new AddListOfBooks
        {
            UserId = userId,
            CollectionOfIsbns = new List<CollectionOfIsbn>
            {
                new CollectionOfIsbn { Isbn = "9781449331818" },
            },
        };

        var response = await bookService.AddBooks(addBooks);

        Assert.NotNull(response.Data);
        Assert.True(response.Data.Books.Where(b => b.Isbn == "9781449331818").Any());
    }

    [Fact]
    public async Task VerifyGetBookByIsbn_ShouldReturnBookDetail()
    {
        var response = await bookService.GetBookByIsbn("9781449331818");

        Assert.True(response.IsSuccessful);
        Assert.Equal("9781449331818", response.Data?.Isbn);
    }

    [Fact]
    public async Task VerifyDeleteAllBooks_ShouldSucceed()
    {
        var response = await bookService.DeleteAllBooks(userId);

        Assert.True(response.IsSuccessful);
    }

    [Fact]
    public async Task VerifyDeleteBookByIsbn_ShouldSucceed()
    {
        var addBooks = new AddListOfBooks
        {
            UserId = userId,
            CollectionOfIsbns = new List<CollectionOfIsbn>
            {
                new CollectionOfIsbn { Isbn = "9781449331818" },
            },
        };

        await bookService.AddBooks(addBooks);

        var deleteRequest = new StringObject { Isbn = "9781449331818", UserId = userId };

        var response = await bookService.DeleteBook(deleteRequest);

        Assert.True(response.IsSuccessful);
    }

    [Fact]
    public async Task VerifyReplaceBook_ShouldUpdateUserBooks()
    {
        var addBooks = new AddListOfBooks
        {
            UserId = userId,
            CollectionOfIsbns = new List<CollectionOfIsbn>
            {
                new CollectionOfIsbn { Isbn = "9781449331818" },
            },
        };

        await bookService.AddBooks(addBooks);

        var response = await bookService.ReplaceBook(
            "9781449331818",
            new ReplaceIsbn { UserId = userId, Isbn = "9781449365035" }
        );

        Assert.True(response.IsSuccessful);
    }

    public async Task DisposeAsync()
    {
        await accountService.DeleteUser(userId);
    }
}
