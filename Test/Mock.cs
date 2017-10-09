using System;
using Moq;
using MyMoqApp;
using Xunit;

namespace Test
{
    public class Mock
    {
        public DataWorker DataWorker { get; set; }

        public Mock()
        {
            DataWorker = new DataWorker(null);
        }

        public Mock<IDatabase> SetUpBeforeTest()
        {
            // re-mock the database for each test 
            var dbMock = MockIDatabase();
            DataWorker.Database = dbMock.Object;
            return dbMock;
        }

        [Fact]
        public void TestStringReversing()
        {
            var dbMock = SetUpBeforeTest();

            // first call
            var reversedValues = DataWorker.ReverseValues();
            Assert.NotEmpty(reversedValues);
            var expected = new[] { "olleH", "dlroW" };
            Assert.Equal(expected, reversedValues);
            Assert.Throws<MockException>(() => dbMock.Verify(database => database.GetValues(), Times.Never));

            // wil throw error and fail the test
            dbMock.Verify(database => database.GetValues(), Times.Once);

            // second call
            reversedValues = DataWorker.ReverseValues();
            Assert.NotEmpty(reversedValues);
            expected = new[] { "puddahW", "god" };
            Assert.Equal(expected, reversedValues);
            Assert.Throws<MockException>(() => dbMock.Verify(database => database.GetValues(), Times.Once));
            dbMock.Verify(database => database.GetValues(), Times.Exactly(2));
        }

        [Fact]
        public void TestCountFormatting()
        {
            SetUpBeforeTest();

            var formatted = DataWorker.FormatCount();
            Assert.Equal("1.00", formatted);
        }

        private static Mock<IDatabase> MockIDatabase()
        {
            var mock = new Mock<IDatabase>();

            mock.Setup(d => d.GetCountOfVAlues()).Returns(1);
            mock.SetupSequence(database => database.GetValues())
                .Returns(new[] { "Hello", "World" }) // first call
                .Returns(new[] { "Whaddup", "dog" }); // second call
            return mock;
        }
    }
}
