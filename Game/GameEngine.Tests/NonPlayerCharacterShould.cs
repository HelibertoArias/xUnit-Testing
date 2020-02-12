using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameEngine.Tests
{
    public class NonPlayerCharacterShould
    {
        [Theory]
        [MemberData(nameof(InternalHealthDamageTestData.TestData), 
            MemberType =typeof(InternalHealthDamageTestData))]
        public void TakeDamage(int damage, int expectedHealth)
        {
            var _sut = new NonPlayerCharacter();
            _sut.TakeDamage(damage);
            Assert.Equal(expectedHealth, _sut.Health);
        }


        [Theory]
        [MemberData(nameof(ExternallHealthDamageTestData.TestData),
          MemberType = typeof(ExternallHealthDamageTestData))]
        public void TakeDamageExternal(int damage, int expectedHealth)
        {
            var _sut = new NonPlayerCharacter();
            _sut.TakeDamage(damage);
            Assert.Equal(expectedHealth, _sut.Health);
        }

        [Theory]
        [HealthDamageData]
        public void TakeDamageCustomAttribute(int damage, int expectedHealth)
        {
            var _sut = new NonPlayerCharacter();
            _sut.TakeDamage(damage);
            Assert.Equal(expectedHealth, _sut.Health);
        }

    }
}
