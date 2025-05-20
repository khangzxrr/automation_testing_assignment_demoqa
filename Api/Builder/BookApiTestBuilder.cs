using BookStoreModel;
using RestSharp;

public static class BookApiTestBuilder
{
    public static async Task<(
        ApiTestBuilder builder,
        RestResponse<AllBooksModal> allBooksResponse
    )> GetAllBooks(this ApiTestBuilder apiTestBuilder)
    {
        var response = await apiTestBuilder.bookService.GetAllBooks();

        return (apiTestBuilder, response);
    }

    public static async Task<(
        ApiTestBuilder builder,
        RestResponse<AddListOfBookResponseModel> addListBooksResponse
    )> AddBookToCollection(this ApiTestBuilder apiTestBuilder, string isbn)
    {
        apiTestBuilder.EnsureAuthorization();

        var addListBooks = new AddListOfBooks
        {
            UserId = apiTestBuilder.UserModel.UserId,
            CollectionOfIsbns = new List<CollectionOfIsbn> { new CollectionOfIsbn { Isbn = isbn } },
        };

        var response = await apiTestBuilder.bookService.AddBooks(addListBooks);

        return (apiTestBuilder, response);
    }

    public static async Task<(
        ApiTestBuilder builder,
        RestResponse<BookModal> getBookResponse
    )> GetBookByIsbn(this ApiTestBuilder apiTestBuilder, string isbn)
    {
        var response = await apiTestBuilder.bookService.GetBookByIsbn(isbn);

        return (apiTestBuilder, response);
    }

    public static async Task<(
        ApiTestBuilder builder,
        RestResponse<BooksResult> deleteAllBooksResponse
    )> DeleteAllBooks(this ApiTestBuilder apiTestBuilder, string? userId = null)
    {
        apiTestBuilder.EnsureAuthorization();

        var response = await apiTestBuilder.bookService.DeleteAllBooks(
            userId ?? apiTestBuilder.UserModel.UserId
        );

        return (apiTestBuilder, response);
    }

    public static async Task<(
        ApiTestBuilder builder,
        RestResponse<UserBooksResult> deleteBookResponse
    )> DeleteBook(this ApiTestBuilder apiTestBuilder, string isbn)
    {
        apiTestBuilder.EnsureAuthorization();

        var deleteBookModel = new DeleteBookModel
        {
            UserId = apiTestBuilder.UserModel.UserId,
            Isbn = isbn,
        };

        var response = await apiTestBuilder.bookService.DeleteBook(deleteBookModel);

        return (apiTestBuilder, response);
    }

    public static async Task<(
        ApiTestBuilder builder,
        RestResponse<GetUserResult> replaceBookResponse
    )> ReplaceBook(this ApiTestBuilder apiTestBuilder, string sourceIsbn, string replaceIsbn)
    {
        apiTestBuilder.EnsureAuthorization();

        var replaceIsbnModel = new ReplaceIsbn
        {
            Isbn = replaceIsbn,
            UserId = apiTestBuilder.UserModel.UserId,
        };

        var response = await apiTestBuilder.bookService.ReplaceBook(sourceIsbn, replaceIsbnModel);

        return (apiTestBuilder, response);
    }
}
