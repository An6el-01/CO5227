using AlfaBookStore.model;

namespace AlfaBookStore.Data

{
    /* I used this database initializer in order to see if I connected the database properly and if so, see the items listed below displayed in the library page*/
    public class DbInitializer
    {
        public static void Initialize(AlfaBookStoreContext context) 
        { 
             if (context.Books.Any()) 
            { 
                return; 
            }
            var books = new Books[]
       {
           new Books{Title="Can't Hurt Me",Author="David Goggins",Price=9.00m},
           new Books{Title="Power",Author="Robert Greene",Price=12.99m},
           new Books{Title="Sapiens",Author="Yuval Noah Harari",Price=12.00m},
           new Books{Title="How To Win Friends & Influence People",Author="Dale Carnegie",Price=10.99m},
           new Books{Title="The Subtle Art Of Not Giving A Fxxx",Author="Mark Manson",Price=15.50m},
           new Books{Title="The 4-Hour Workweek",Author="Timothy Ferriss", Price=10.99m}
       };
            context.Books.AddRange(books);
            context.SaveChanges();

        }


    }
}
