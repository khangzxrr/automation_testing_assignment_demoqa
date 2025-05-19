
using System.Collections.Generic;

namespace BookStoreModel
{
    public class GetUserResult
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public List<BookModal> Books { get; set; }
    }
}
