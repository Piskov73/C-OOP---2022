namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System.Text;

    public class Tests
    {
        private TextBook textBook;
        private UniversityLibrary university;
        [SetUp]
        public void Setup()
        {
            this.textBook = new TextBook("ti", "au", "cat");
            this .university=new UniversityLibrary();
        }
      

        [Test]
        public void Test_TextBook()
        {
            string title = "Title";
            string author = "Author";
            string category = "Category";

            this.textBook=new TextBook(title, author, category);

            Assert.NotNull(textBook);

            Assert.AreEqual(title, textBook.Title);
            Assert.AreEqual(author, textBook.Author);
            Assert.AreEqual(category, textBook.Category);
            Assert.AreEqual(0, textBook.InventoryNumber);
            Assert.Null(textBook.Holder);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Book: {title} - {0}");
            sb.AppendLine($"Category: {category}");
            sb.AppendLine($"Author: {author}");

            string expecte=sb.ToString().TrimEnd();
            string actual = textBook.ToString();

            Assert.AreEqual(expecte, actual);
        }

        [Test]
        public void Test_ConstruktorUniversityLibrary()
        {
             university = new UniversityLibrary();

            Assert.NotNull(university);
            Assert.AreEqual(0,university.Catalogue.Count);
        }

        [Test]
        public void Test_AddTextBookToLibrary()
        {
            string title = "Title";
            string author = "Author";
            string category = "Category";

            this.textBook = new TextBook(title, author, category);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Book: {title} - {1}");
            sb.AppendLine($"Category: {category}");
            sb.AppendLine($"Author: {author}");


            university = new UniversityLibrary();

            string expecte = sb.ToString().TrimEnd();
            string actual = university.AddTextBookToLibrary(textBook);

            Assert.AreEqual(expecte, actual);   
            Assert.AreEqual(1,university.Catalogue.Count);  
        }

        [Test]
        public void Test_LoanTextBook()
        {
            string title = "Title";
            string author = "Author";
            string category = "Category";

            this.textBook = new TextBook(title, author, category);
            university = new UniversityLibrary();

            university.AddTextBookToLibrary(textBook);

            string studentName = "Vanko";
            int bixNumber = 1;

            string expecte= $"{title} loaned to {studentName}.";
            string actual=university.LoanTextBook(bixNumber, studentName);
            Assert.AreEqual(expecte, actual);

            expecte = $"{studentName} still hasn't returned {title}!";
            actual = university.LoanTextBook(bixNumber, studentName);
            Assert.AreEqual(expecte, actual);

        }
        [Test]
        public void Test_ReturnTextBook()
        {
            string title = "Title";
            string author = "Author";
            string category = "Category";

            this.textBook = new TextBook(title, author, category);
            university = new UniversityLibrary();

            university.AddTextBookToLibrary(textBook);

            string studentName = "Vanko";
            int bixNumber = 1;

            university.LoanTextBook(bixNumber, studentName);

            string expecte= $"{title} is returned to the library.";
            string actual = university.ReturnTextBook(bixNumber);
            Assert.AreEqual(expecte, actual);
            Assert.AreEqual(string.Empty,textBook.Holder);

        }


    }
}