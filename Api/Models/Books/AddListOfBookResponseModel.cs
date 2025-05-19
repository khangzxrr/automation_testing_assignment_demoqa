using BookStoreModel;

public class AddListOfBookResponseModel
{
    public string UserId { get; set; }
    public List<BookModal> Books { get; set; }
}
