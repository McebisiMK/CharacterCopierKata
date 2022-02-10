[![.NET](https://github.com/McebisiMK/CharacterCopierKata/actions/workflows/dotnet.yml/badge.svg)](https://github.com/McebisiMK/CharacterCopierKata/actions/workflows/dotnet.yml)

# CharacterCopierKata

Write a character **copier class** that reads characters from a **source** and copies them to a
**destination**. It must copy and write one character at a time.

To do this create a [Copier class](https://github.com/McebisiMK/CharacterCopierKata/blob/main/CharacterCopierKata.Services/Implementation/Copier.cs) that takes in a [ISource](https://github.com/McebisiMK/CharacterCopierKata/blob/main/CharacterCopierKata.Services/Interfaces/ISource.cs) and [IDestination](https://github.com/McebisiMK/CharacterCopierKata/blob/main/CharacterCopierKata.Services/Interfaces/IDestination.cs). [ISource](https://github.com/McebisiMK/CharacterCopierKata/blob/main/CharacterCopierKata.Services/Interfaces/ISource.cs) has one method
**char ReadChar()** and [IDestination](https://github.com/McebisiMK/CharacterCopierKata/blob/main/CharacterCopierKata.Services/Interfaces/IDestination.cs) has one method **void WriteChar(char c)**. The [Copier class](https://github.com/McebisiMK/CharacterCopierKata/blob/main/CharacterCopierKata.Services/Implementation/Copier.cs) has one
method **void Copy()** that when called reads from the [ISource](https://github.com/McebisiMK/CharacterCopierKata/blob/main/CharacterCopierKata.Services/Interfaces/ISource.cs) one character at a time and write to
[IDestination](https://github.com/McebisiMK/CharacterCopierKata/blob/main/CharacterCopierKata.Services/Interfaces/IDestination.cs) as seen in Figure 1 below.

The copying and writing is done character at a time until a **newline (‘\n’)** is encountered. Then the
processing stops without writing the newline. Only the [Copier class](https://github.com/McebisiMK/CharacterCopierKata/blob/main/CharacterCopierKata.Services/Implementation/Copier.cs) may exist as a concrete.

## Tech Used:

- [.NET 6](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-6)
- [NUnit](https://nunit.org/)
- [NSubstitute](https://nsubstitute.github.io/help/getting-started/)
