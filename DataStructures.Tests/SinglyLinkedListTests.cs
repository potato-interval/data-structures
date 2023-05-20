using System.Text;

namespace DataStructures.Tests
{
    public class SinglyLinkedListTests
    {
        [Fact]
        public void PeekFirst_ShouldReturnExceptionIfLLIsEmpty()
        {
            SinglyLinkedList<object> list = new();

            Action act = () => list.PeekFirst();

            Assert.Throws<InvalidOperationException>(act);
        }

        [Fact]
        public void PeekLast_ShouldReturnExceptionIfLLIsEmpty()
        {
            SinglyLinkedList<object> list = new();

            Action act = () => list.PeekLast();

            Assert.Throws<InvalidOperationException>(act);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(-1, 2)]
        public void IndexOf_ShouldReturnExpectedValue(
            int expected, int value)
        {
            SinglyLinkedList<int> ints = new() { 1 };

            Assert.Equal(expected, ints.IndexOf(value));
        }

        [Theory]
        [InlineData(true, 1)]
        [InlineData(false, 0)]
        public void Contains_ShouldReturnExpectedValue(
            bool expected, int actual)
        {
            SinglyLinkedList<int> ints = new() { 1 };

            Assert.Equal(expected, ints.Contains(actual));
        }

        [Fact]
        public void Foreach_ShouldWorkAsExpected()
        {
            SinglyLinkedList<string> list = new() { "one", "two", "three" };
            string expected = "one two three ";

            StringBuilder sb = new();
            foreach (var item in list)
            {
                sb.Append(item).Append(' ');
            }

            Assert.Equal(expected, sb.ToString());
        }
    }
}