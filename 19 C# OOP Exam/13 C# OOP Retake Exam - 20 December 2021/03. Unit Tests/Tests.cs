namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        private Book book;
        [SetUp]
        public void SetUp()
        {
            this.book = new Book("BookName", "AuthorName");
        }
        [Test]
        public void Test_BookConstructor()
        {
            Assert.NotNull(book);
            Assert.AreEqual(0, book.FootnoteCount);
        }
        [Test]
        public void Test_BookBookName()
        {
            string bookName = "BookName";
            string author = "Author";

            book = new Book(bookName, author);

            Assert.AreEqual(bookName, book.BookName);

            bookName = null;

            Assert.Throws<ArgumentException>(()=>new Book(bookName, author), $"Invalid {bookName}!");
        }
        [Test]
        public void Test_BookAuthor()
        {
            string bookName = "BookName";
            string author = "Author";

            book = new Book(bookName, author);

            Assert.AreEqual(author, book.Author);

            author = null;

            Assert.Throws<ArgumentException>(() => new Book(bookName, author), $"Invalid {author}!");
        }
        [Test]
        public void Test_BookAddFootnote()
        {
            string bookName = "BookName";
            string author = "Author";

            book = new Book(bookName, author);

            int footNoteNumber = 1;
            string text = "Text";

            book.AddFootnote(footNoteNumber, text);

            Assert.AreEqual(1,book.FootnoteCount);

            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(footNoteNumber, text), "Footnote already exists!");
        }
        [Test]
        public void Test_BookFindFootnote()
        {
            string bookName = "BookName";
            string author = "Author";

            book = new Book(bookName, author);

            int footNoteNumber = 1;
            string text = "Text";

            book.AddFootnote(footNoteNumber, text);

            string expected = $"Footnote #{footNoteNumber}: {text}";
            string actual = book.FindFootnote(footNoteNumber);

            Assert.AreEqual(expected, actual);

            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(5), "Footnote does not exists!");
        }
        [Test]
        public void Test_BookAlterFootnote()
        {
            string bookName = "BookName";
            string author = "Author";

            book = new Book(bookName, author);

            int footNoteNumber = 1;
            string text = "Text";

            book.AddFootnote(footNoteNumber, text);
            string expected = $"Footnote #{footNoteNumber}: {text}";
            string actual = book.FindFootnote(footNoteNumber);

            Assert.AreEqual(expected, actual);

            string newText = "NewText";

            book.AlterFootnote(footNoteNumber,newText);

             expected = $"Footnote #{footNoteNumber}: {newText}";
             actual = book.FindFootnote(footNoteNumber);

            Assert.AreEqual(expected, actual);

            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(2, newText), "Footnote does not exists!");

        }
    }
}