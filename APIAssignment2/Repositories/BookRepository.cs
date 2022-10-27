using APIAssignment2.Entities;

namespace APIAssignment2.Repositories
{
    public class BookRepository
    {
        private readonly AssignmentDBContext db;
        public BookRepository()
        {
            this.db = new AssignmentDBContext();
        }
        public List<Book> GetBooks()
        {
            try
            {
                return db.Books.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Book> GetBooksByAuthor(string author)
        {
            try
            {
                return db.Books.Where(i => i.Author == author).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Book> GetBooksByPublisher(string publisher)
        {
            try
            {
                return db.Books.Where(i => i.Publisher == publisher).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Book GetBookById(int eid)
        {
            try
            {
                return db.Books.Find(eid);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Book GetBookByName(string name)
        {
            try
            {
                return db.Books.SingleOrDefault(i => i.BookName == name);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void AddBook(Book book)
        {
            try
            {
                db.Books.Add(book);
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteBook(int id)
        {
            Book book = db.Books.SingleOrDefault(i => i.BookId == id);
            db.Books.Remove(book);
            db.SaveChanges();
        }

        public void EditBook(Book book)
        {
            db.Books.Update(book);
            db.SaveChanges();
        }
    }
}