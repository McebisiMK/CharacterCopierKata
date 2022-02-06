namespace CharacterCopierKata.Services.Interfaces
{
    public interface ISource
    {
        char ReadChar();
        char[] ReadChars(int count);
    }
}
