using NUnit.Framework;

/*
 * Your task is to write a function that takes two arguments, a string and an integer width.
The function returns the string, 
but with line breaks inserted at just the right places 
to make sure that no line is longer than the column number. 
You try to break lines at word boundaries.
Like a word processor, break the line by replacing the last space in a line with a newline.

                |-----------------------------------------------------------------------------------------|
                |                           Tests:                                                        |
                |-----------------------------------------------------------------------------------------|
                |("test", 7) -> "test"                                                                    |
                |("hello world", 7) -> "hello--world"                                                     |
                |("a lot of words for a single line", 10) -> "a lot of--words for--a single--line"        |
                |("this is a test", 4) -> "this--is a--test"                                              |
                |("a longword", 6) -> "a long--word"                                                      |
                |("areallylongword", 6) -> "areall--ylongw--ord"                                          |
                |-----------------------------------------------------------------------------------------|

 */
namespace Katas
{
    [TestFixture]
    public class WordWrapTest
    {
        [TestCase("1234567890", 10, "1234567890")]
        [TestCase("hello world", 7, "hello\nworld")]
        [TestCase("hello there dude", 10, "hello\nthere dude")]
        [TestCase("a lot of words for a single line", 10, "a lot of\nwords for\na single\nline")]
        [TestCase("a longword", 6, "a long\nword")]
        [TestCase("areallylongword", 6, "areall\nylongw\nord")]
        [TestCase("areallylongword followed by short word", 6, "areall\nylongw\nord fo\nllowed\nby\nshort\nword")]
        public void test_wordwrap(string input_string, int width, string expected)
        {
            // a simple example to start you off       
            Assert.AreEqual(expected, word_wrap(input_string, width));
        }


        private string word_wrap(string input_string, int width)
        {
            if (input_string.Length <= width)
                return input_string;

            string line = "";
            string output = "";

            string[] words = input_string.Split(' ');

            for (int index = 0; index < words.Length; index++)
            {
                string word = words[index];
                line = AddWordToLine(line, word);

                if (line.Length >= width)
                {
                    if(isLastWord(index, words) && line.Length == width)
                    {
                        output += line;
                    }
                    else
                    {
                        if (is_a_really_long_word(width, word))
                        {

                            int wordLengthExceedingWidthBy = word.Length - width;
                            while (wordLengthExceedingWidthBy > 0)
                            {
                                string remainingPartOfWord = line.Substring(width, line.Length - width);
                                line = line.Substring(0, width); //Wrap current line
                                line += "\n";
                                output += line;
                                line = remainingPartOfWord; //remaining part to next line
                                wordLengthExceedingWidthBy = line.Length - width;
                            }
                        }
                        else
                        {
                            line = remove_last_word_from_line(line, word);
                            line += "\n";
                            output += line;
                            line = word;
                        }
                        
                        if (isLastWord(index, words))
                        {
                            output += line;
                        }
                    }
                }
            }

            return output;

        }

        private static bool is_a_really_long_word(int width, string word)
        {
            return word.Length > width;
        }

        private static bool isLastWord(int index, string[] words)
        {
            return (index == words.Length-1);
        }

        private string AddWordToLine(string line, string word)
        {
            if (line == "")
                line = word;
            else
                line += " " + word;

            return line;
        }


        private string remove_last_word_from_line(string line, string last_word)
        {
            if (line.Contains(" "))
                line = line.Substring(0, line.Length - last_word.Length - 1);
            else
                line = line.Substring(0, line.Length - last_word.Length);

            return line;
        }
    }
}
