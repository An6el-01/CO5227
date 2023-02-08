using AlfaBookStore.model;

namespace AlfaBookStore.Data

{
    public class DbInitializer
    {
        public static void Initialize(AlfaBookStoreContext context) 
        { 
             if (context.Books.Any()) 
            { 
                return; 
            }
            var books = new Book[]
       {
           new Book{Title="Can't Hurt Me",Author="David Goggins",Price=9.00m},
           new Book{Title="Power",Author="Robert Greene",Price=12.99m},
           new Book{Title="Sapiens",Author="Yuval Noah Harari",Price=12.00m},
           new Book{Title="How To Win Friends & Influence People",Author="Dale Carnegie",Price=10.99m},
           new Book{Title="The Subtle Art Of Not Giving A Fxxx",Author="Mark Manson",Price=15.50m},
           new Book{Title="The 4-Hour Workweek",Author="Timothy Ferriss", Price=10.99m}
       };
            context.Books.AddRange(books);
            context.SaveChanges();

        }


    }
}
