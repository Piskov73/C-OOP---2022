namespace Book.Tests
{
    using System;

    using NUnit.Framework;
    using static System.Net.Mime.MediaTypeNames;

    public class Tests
    {
        private Book book;
        [SetUp]
        public void SetUp() 
        {
            book = new Book("BOOK", "Note");
        }

        [Test] 
        public void Test_Constructor() 
        {
            Assert.NotNull(book);
            Assert.AreEqual("BOOK", book.BookName);
            Assert.AreEqual("Note", book.Author);
        }
        [Test]
        public void Test_FootnoteCount()
        {
            Assert.AreEqual(0,book.FootnoteCount);
            book.AddFootnote(1, "Text");
            Assert.AreEqual(1, book.FootnoteCount);
        }
        [Test]
        public void Test_BookName()
        {
            Assert.AreEqual("BOOK", book.BookName);

            Assert.Throws<ArgumentException>(() => new Book("", "Note"), "Invalid BookName!");
        }
        [Test]
        public void Test_Author()
        {
            Assert.AreEqual("Note", book.Author);

            Assert.Throws<ArgumentException>(() => new Book("BOOK", null), "Invalid Author!");
        }
        [Test]
        public void Test_AddFootnote()
        {
            book.AddFootnote(1, "TestText");
            Assert.AreEqual(1,book.FootnoteCount);

            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(1, "TestText"), "Footnote already exists!");
        }
        [Test]
        public void Test_FindFootnote()
        {
            book.AddFootnote(1, "TestText");

            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(2));
            string expecte= $"Footnote #1: TestText";
            string actual= book.FindFootnote(1);
            Assert.AreEqual(expecte, actual);

        }
        [Test]
        public void Test_AlterFootnote()
        {
            book.AddFootnote(1, "TestText");
            string newText = "2TestText";

            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(2,newText ));

            book.AlterFootnote(1,newText);
            string expecte = $"Footnote #1: {newText}";
            string actual = book.FindFootnote(1);
            Assert.AreEqual(expecte, actual);

        }
    }
}