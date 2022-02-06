using CharacterCopierKata.Services.Interfaces;

namespace CharacterCopierKata.Services.Implementation
{
    public class Copier : ICopier
    {
        private readonly ISource _source;
        private readonly IDestination _destination;

        public Copier(ISource source, IDestination destination)
        {
            _destination = destination;
            _source = source;
        }

        public void Copy()
        {
            var character = _source.ReadChar();

            if (IsCopyable(character))
            {
                _destination.WriteChar(character);
                Copy();
            }
        }

        public void CopyRange(int count)
        {
            var characters = _source.ReadChars(count);

            if (Contains(characters))
            {
                var charactersToCopy = characters.TakeWhile(character => character != '\n').ToArray();
                _destination.WriteChars(charactersToCopy);

                if (characters.Contains('\n'))
                    return;

                CopyRange(count);
            }
        }

        private static bool Contains(char[] characters)
        {
            return characters.Length != 0 && !(StartsWithNewLine(characters));
        }

        private static bool StartsWithNewLine(char[] characters)
        {
            return IsNewLine(characters.First());
        }

        private static bool IsCopyable(char character)
        {
            return !(IsEmpty(character)) && !(IsNewLine(character));
        }

        private static bool IsNewLine(char character)
        {
            return (character == '\n');
        }

        private static bool IsEmpty(char character)
        {
            return ((int)character == 0);
        }
    }
}
