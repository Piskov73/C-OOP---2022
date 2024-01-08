namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System.Text;

    public class Tests
    {
        private TextBook book;
        private UniversityLibrary libarty;
        [SetUp]
        public void Setup()
        {
            book = new TextBook("t", "a", "c");
            libarty = new UniversityLibrary();
        }
        [Test]
        public void Test_TextBookConstructor()
        {
            string title = "Title";
            string author = "Author";
            string category = "Category";

            book = new TextBook(title, author, category);

            Assert.NotNull(book);

            Assert.That(book.Title, Is.EqualTo(title));
            Assert.That(book.Author, Is.EqualTo(author));
            Assert.That(book.Category, Is.EqualTo(category));
            Assert.That(book.Category, Is.EqualTo(category));
            Assert.That(book.InventoryNumber, Is.EqualTo(0));
            Assert.That(book.Holder, Is.EqualTo(default));

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Book: {title} - {0}");
            sb.AppendLine($"Category: {category}");
            sb.AppendLine($"Author: {author}");

            string expected = sb.ToString().TrimEnd();
            string actual = book.ToString();

        }

        [Test]
        public void Test_UniversityLibraryConstructor()
        {
            libarty = new UniversityLibrary();
            Assert.NotNull(libarty);

            Assert.That(libarty.Catalogue.Count, Is.EqualTo(0));
        }
        [Test]
        public void Test_UniversityLibraryAddTextBookToLibrary()
        {
            libarty = new UniversityLibrary(); string title = "Title";
            string author = "Author";
            string category = "Category";

            book = new TextBook(title, author, category);
            var book2 = new TextBook("Dune", "Frank Harbart", "Fantastika");

            string actual = libarty.AddTextBookToLibrary(book);
            string expekted = book.ToString();


            Assert.That(actual, Is.EqualTo(expekted));

            actual = libarty.AddTextBookToLibrary(book2);
            expekted = book2.ToString();


            Assert.That(actual, Is.EqualTo(expekted));

            Assert.That(libarty.Catalogue.Count, Is.EqualTo(2));
        }
        [Test]
        public void Test_UniversityLibraryLoanTextBook()
        {
            libarty = new UniversityLibrary(); string title = "Title";
            string author = "Author";
            string category = "Category";
            string studentName = "Pen-Cho";

            book = new TextBook(title, author, category);
            var book2 = new TextBook("Dune", "Frank Harbart", "Fantastika");

            libarty.AddTextBookToLibrary(book);

            libarty.AddTextBookToLibrary(book2);

            string actual = libarty.LoanTextBook(2, studentName);

            string expekted = $"{book2.Title} loaned to {studentName}.";

            Assert.That(actual, Is.EqualTo(expekted));

            Assert.That(book2.Holder, Is.EqualTo(studentName));

            libarty.LoanTextBook(1, studentName);

            Assert.That(book.Holder, Is.EqualTo(studentName));

            actual = libarty.LoanTextBook(2, studentName);

            expekted = $"{studentName} still hasn't returned {book2.Title}!";

            Assert.That(actual, Is.EqualTo(expekted));


        }
        [Test]
        public void Test_UniversityLibrary()
        {
            libarty = new UniversityLibrary(); string title = "Title";
            string author = "Author";
            string category = "Category";
            string studentName = "Pen-Cho";

            book = new TextBook(title, author, category);
            var book2 = new TextBook("Dune", "Frank Harbart", "Fantastika");

            libarty.AddTextBookToLibrary(book);

            libarty.AddTextBookToLibrary(book2);

            libarty.LoanTextBook(2, studentName);

            string actual = libarty.ReturnTextBook(2);
            string  expected= $"{book2.Title} is returned to the library.";

            Assert.That(actual,Is.EqualTo(expected));

            Assert.That(book2.Holder, Is.EqualTo(string.Empty));

            Assert.That(libarty.Catalogue.Count, Is.EqualTo(2));
        }

    }
}