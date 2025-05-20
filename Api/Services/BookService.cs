using BookStoreModel;
using RestSharp;

public class BookService : ApiClient
{
    public BookService(RestClient client)
        : base(client) { }

    public async Task<RestResponse<AllBooksModal>> GetAllBooks()
    {
        return await SendRequest<AllBooksModal>("/BookStore/v1/Books", Method.Get);
    }

    public async Task<RestResponse<AddListOfBookResponseModel>> AddBooks(AddListOfBooks model)
    {
        return await SendRequest<AddListOfBookResponseModel>(
            "/BookStore/v1/Books",
            Method.Post,
            model
        );
    }

    public async Task<RestResponse<BookModal>> GetBookByIsbn(string isbn)
    {
        var resource = $"/BookStore/v1/Book?ISBN={isbn}";
        return await SendRequest<BookModal>(resource, Method.Get);
    }

    public async Task<RestResponse<BooksResult>> DeleteAllBooks(string userId)
    {
        var resource = $"/BookStore/v1/Books?UserId={userId}";
        return await SendRequest<BooksResult>(resource, Method.Delete);
    }

    public async Task<RestResponse<UserBooksResult>> DeleteBook(DeleteBookModel model)
    {
        return await SendRequest<UserBooksResult>("/BookStore/v1/Book", Method.Delete, model);
    }

    public async Task<RestResponse<GetUserResult>> ReplaceBook(string isbn, ReplaceIsbn model)
    {
        var resource = $"/BookStore/v1/Books/{isbn}";
        return await SendRequest<GetUserResult>(resource, Method.Put, model);
    }
}
