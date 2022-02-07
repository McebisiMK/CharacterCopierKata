using CharacterCopierKata.Services.Implementation;
using CharacterCopierKata.Services.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System;

namespace CharacterCopierKata.Tests.UnitTests
{
    [TestFixture]
    public class CopierServiceTests
    {
        [Test]
        public void Copy_Given_Source_Returned_Empty_Character_Should_Not_Copy_To_Destination()
        {
            //-------------------------------Arrange---------------------------------------
            var source = Substitute.For<ISource>();
            var destination = Substitute.For<IDestination>();
            var copier = CreateCopier(source, destination);
            char characterToCopy = '\0';

            source.ReadChar().Returns(characterToCopy);

            //-------------------------------Act-------------------------------------------
            copier.Copy();

            //-------------------------------Assert----------------------------------------
            source.Received(1).ReadChar();
            destination.Received(0).WriteChar(Arg.Any<char>());
        }

        [Test]
        public void Copy_Given_Source_Returned_New_Line_Should_Not_Copy_To_Destination()
        {
            //-------------------------------Arrange---------------------------------------
            var source = Substitute.For<ISource>();
            var destination = Substitute.For<IDestination>();
            var copier = CreateCopier(source, destination);
            char characterToCopy = '\n';

            source.ReadChar().Returns(characterToCopy);

            //-------------------------------Act-------------------------------------------
            copier.Copy();

            //-------------------------------Assert----------------------------------------
            source.Received(1).ReadChar();
            destination.Received(0).WriteChar(Arg.Any<char>());
        }

        [Test]
        public void Copy_Given_Source_Returned_A_Character_Should_Copy_Destination_Until_New_Line_Is_Returned()
        {
            //-------------------------------Arrange---------------------------------------
            var source = Substitute.For<ISource>();
            var destination = Substitute.For<IDestination>();
            var copier = CreateCopier(source, destination);

            source.ReadChar().Returns('a', 'b', 'c', '\n');

            //-------------------------------Act-------------------------------------------
            copier.Copy();

            //-------------------------------Assert----------------------------------------
            source.Received(4).ReadChar();
            destination.Received(3).WriteChar(Arg.Any<char>());
        }

        [Test]
        public void CopyRange_Given_Source_Returned_An_Empty_Array_Should_Not_Call_Destination()
        {
            //-------------------------------Arrange---------------------------------------
            var source = Substitute.For<ISource>();
            var destination = Substitute.For<IDestination>();
            var copier = CreateCopier(source, destination);

            source.ReadChars(2).Returns(Array.Empty<char>());

            //-------------------------------Act-------------------------------------------
            copier.CopyRange(2);

            //-------------------------------Assert----------------------------------------
            source.Received(1).ReadChars(2);
            destination.Received(0).WriteChars(Arg.Any<char[]>());
        }

        [TestCase(new char[] { '\n' })]
        [TestCase(new char[] { '\n', 'd' })]
        [TestCase(new char[] { '\n', 'f', 's', 'e', 'r' })]
        public void CopyRange_Given_Source_Returned_Results_Starting_With_A_New_Line_Should_Not_Call_Destination(char[] sourceResults)
        {
            //-------------------------------Arrange---------------------------------------
            var source = Substitute.For<ISource>();
            var destination = Substitute.For<IDestination>();
            var copier = CreateCopier(source, destination);

            source.ReadChars(2).Returns(sourceResults);

            //-------------------------------Act-------------------------------------------
            copier.CopyRange(2);

            //-------------------------------Assert----------------------------------------
            source.Received(1).ReadChars(2);
            destination.Received(0).WriteChars(Arg.Any<char[]>());
        }

        [TestCase(new char[] { 'r', 'd', '\n', 'e' }, 4, new char[] { 'r', 'd' })]
        [TestCase(new char[] { 'l', 'o', 'y', '\n', 'f', 's', 'e' }, 7, new char[] { 'l', 'o', 'y' })]
        [TestCase(new char[] { 'r', 'd', 'n', 'x', 'a', '\n', 'd', 'm', 'z' }, 9, new char[] { 'r', 'd', 'n', 'x', 'a' })]
        public void CopyRange_Given_Source_Returned_Results_Containing_New_Line_Should_Write_Characters_Before_New_Line_To_Destination(char[] sourceResults, int count, char[] CharactersToCopy)
        {
            //-------------------------------Arrange---------------------------------------
            var source = Substitute.For<ISource>();
            var destination = Substitute.For<IDestination>();
            var copier = CreateCopier(source, destination);

            source.ReadChars(count).Returns(sourceResults);

            //-------------------------------Act-------------------------------------------
            copier.CopyRange(count);

            //-------------------------------Assert----------------------------------------
            source.Received(1).ReadChars(count);
            destination.Received(1).WriteChars(Arg.Do<char[]>(receivedCharacters => CharactersToCopy = receivedCharacters));
        }

        [Test]
        public void CopyRange_Given_Source_Returned_Characters_Should_Copy_To_Destination_Until_New_LineLine_Is_Returned()
        {
            //-------------------------------Arrange---------------------------------------
            var source = Substitute.For<ISource>();
            var destination = Substitute.For<IDestination>();
            var copier = CreateCopier(source, destination);

            source.ReadChars(2).Returns(new char[] {'s','f'}, new char[] { 'r', 'y' }, new char[] { 'h', 'n' }, new char[] { '\n', 'f' });

            //-------------------------------Act-------------------------------------------
            copier.CopyRange(2);

            //-------------------------------Assert----------------------------------------
            source.Received(4).ReadChars(2);
            destination.Received(3).WriteChars(Arg.Any<char[]>());
        }

        private static Copier CreateCopier(ISource source, IDestination destination)
        {
            return new Copier(source, destination);
        }
    }
}
