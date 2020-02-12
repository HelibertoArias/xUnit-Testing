using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould : IDisposable
    {
        private readonly PlayerCharacter _sut;
        private readonly ITestOutputHelper _output;


        public PlayerCharacterShould(ITestOutputHelper output)
        {
            _output = output;
            _sut = new PlayerCharacter();
            _output.WriteLine("Creating a new Player Character");
        }

        public void Dispose()
        {
            _output.WriteLine("Disponsing a new Player Character");
        }

        [Fact]
        public void BeInexperienceWhenNew()
        {
            Assert.True(_sut.IsNoob);
        }

        [Fact]
        public void CalculateFullName()
        {
            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";
            Assert.Equal("Sarah Smith", _sut.FullName);
        }

        [Fact]
        public void HaveFullNameEndingWithLastName()
        {
            _sut.LastName = "Smith" ;
            Assert.EndsWith("Smith", _sut.FullName);
        }

        [Fact]
        public void CalculateFullName_IgnoreCaseAssertExample()
        {
            _sut.FirstName = "SARAH";
            _sut.LastName = "SMITH";
            Assert.Equal("Sarah Smith", _sut.FullName, ignoreCase: true);
        }

        [Fact]
        public void CalculateFullNameWithTitleCase()
        {
            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith" ;
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]", _sut.FullName);
        }

        [Fact]
        public void StartWithDefaultHealth()
        {
            Assert.Equal(100, _sut.Health);
        }

        [Fact]
        public void StartWithDefaultHealth_NotEqualExample()
        {
            Assert.NotEqual(0, _sut.Health);
        }

        [Fact]
        public void IncreaseHealthAfterSleeping()
        {
            _sut.Sleep();

            Assert.True(_sut.Health >= 101 && _sut.Health <= 200);
        }

        class Property { public string Name { get; set; } public string Value { get; set; } }
        [Fact]
        public void DummyTesting()
        {
            var list = new List<Property>
            {
                new Property{ Name = "mainColor", Value="Red"},
                new Property{ Name = "buttonsColor", Value="Blue"}
            };


            list.Find(p => p.Name.Equals("mainColor")).Value = "red";


            Assert.True(true);
            //Assert.(list.Find(p=>p.Name.Equals("mainColor")
            //                     ).Value.Equals("yellow"));

        }

        [Fact]
        public void RaiseSleptEvent()
        {
            Assert.Raises<EventArgs>(
                handler => _sut.PlayerSlept += handler,
                handler => _sut.PlayerSlept -= handler,
                () => _sut.Sleep());
        }

        [Fact]
        public void RaisePropertyChangedEvent()
        {
            Assert.PropertyChanged(_sut,
                                    "Health",
                                    () => _sut.TakeDamage(10));
        }

      
    }
}
