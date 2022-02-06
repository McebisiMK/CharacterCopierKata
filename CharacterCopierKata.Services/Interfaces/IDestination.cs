namespace CharacterCopierKata.Services.Interfaces
{
    public interface IDestination
    {
        void WriteChar(char character);
        void WriteChars(char[] characters);
    }
}
