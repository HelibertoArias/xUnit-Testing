using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould
    {
        [Fact]
        public void BeInexperienceWhenNew()
        {
            var sut = new PlayerCharacter();

            Assert.True(sut.IsNoob);
        }

        [Fact]
        public void CalculateFullName()
        {
            var sut = new PlayerCharacter()
            {
                FirstName = "Sarah",
                LastName = "Smith"
            };

            Assert.Equal("Sarah Smith", sut.FullName);
        }

        [Fact]
        public void HaveFullNameEndingWithLastName()
        {
            var sut = new PlayerCharacter() { LastName = "Smith" };

            Assert.EndsWith("Smith", sut.FullName);
        }

        [Fact]
        public void CalculateFullName_IgnoreCaseAssertExample()
        {
            var sut = new PlayerCharacter() { FirstName = "SARAH", LastName = "SMITH" };

            Assert.Equal("Sarah Smith", sut.FullName, ignoreCase: true);
        }

        [Fact]
        public void CalculateFullNameWithTitleCase()
        {
            var sut = new PlayerCharacter() { FirstName = "Sarah", LastName = "Smith" };
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]", sut.FullName);
        }

        [Fact]
        public void StartWithDefaultHealth()
        {
            var sut = new PlayerCharacter();
            Assert.Equal(100, sut.Health);
        }

        [Fact]
        public void StartWithDefaultHealth_NotEqualExample()
        {
            var sut = new PlayerCharacter();
            Assert.NotEqual(0, sut.Health);
        }

        [Fact]
        public void IncreaseHealthAfterSleeping()
        {
            var sut = new PlayerCharacter();
            sut.Sleep();

            Assert.True(sut.Health >= 101 && sut.Health <= 200);
        }

        class Property { public string Name { get; set; } public string Value { get; set; }}
        [Fact]
        public void DummyTesting()
        {
            var list = new List<Property>
            {
                new Property{ Name = "mainColor", Value="Red"},
                new Property{ Name = "buttonsColor", Value="Blue"}
            };


             list.Find(p => p.Name.Equals("mainColor")).Value ="red";
            

            Assert.True(true);
            //Assert.(list.Find(p=>p.Name.Equals("mainColor")
            //                     ).Value.Equals("yellow"));

        }

        [Fact]
        public void RaiseSleptEvent()
        {
            var sut = new PlayerCharacter();
            Assert.Raises<EventArgs>(
                handler => sut.PlayerSlept += handler,
                handler => sut.PlayerSlept -= handler,
                () => sut.Sleep()
                );
        }

        [Fact]
        public void RaisePropertyChangedEvent()
        {
            var sut = new PlayerCharacter();
            Assert.PropertyChanged(sut, 
                                    "Health", 
                                    () => sut.TakeDamage(10));
        }
    }
}
