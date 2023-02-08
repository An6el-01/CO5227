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
           new Book{title="Can't Hurt Me",author="David Goggins",price=9.00m},
           new Book{title="Power",author="Robert Greene",price=12.99m},
           new Book{title="Sapiens",author="Yuval Noah Harari",price=12.00m},
           new Book{title="How To Win Friends & Influence People",author="Dale Carnegie",price=10.99m},
           new Book{title="The Subtle Art Of Not Giving A Fxxx",author="Mark Manson",price=15.50m},
           new Book{title="The 4-Hour Workweek",author="Timothy Ferriss", price=10.99m}
       };
            context.Books.AddRange(books);
            context.SaveChanges();

        }


    }
}
