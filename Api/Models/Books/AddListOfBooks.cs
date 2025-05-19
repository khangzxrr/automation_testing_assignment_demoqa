
using System.Collections.Generic;

namespace BookStoreModel
{
    public class AddListOfBooks
    {
        public string UserId { get; set; }
        public List<CollectionOfIsbn> CollectionOfIsbns { get; set; }
    }
}
