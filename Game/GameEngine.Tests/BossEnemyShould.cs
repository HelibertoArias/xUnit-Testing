using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameEngine.Tests
{
    public class BossEnemyShould
    {
        [Fact]
        public void HaveCorretPower()
        {
            BossEnemy sut = new BossEnemy();
            Assert.Equal(166.667, sut.TotalSpecialAttackPower, 3);
        }

        [Fact]
        public void NotHAveNickNameByDefault()
        {
            var sut = new PlayerCharacter();
            Assert.Null(sut.Nickname);
        }

        [Fact]
        public void HaveALongBow()
        {
            var sut = new PlayerCharacter();
            Assert.Contains("Long Bow", sut.Weapons);
        }

        [Fact]
        public void HaveAtLeastOneKindOfSWord()
        {
            var sut = new PlayerCharacter();
            Assert.Contains(sut.Weapons,
                               w => w.Contains("Sword"));
        }

        [Fact]
        public void HaveAllExpectedWeapons()
        {
            var sut = new PlayerCharacter();

            var expectedWeapons = new[] { "Long Bow", "Short Bow", "Short Sword" };

            Assert.Equal(expectedWeapons, sut.Weapons);
        }

        [Fact]
        public void HaveNoEmptyDefaultWeapons()
        {
            var sut = new PlayerCharacter();

            Assert.All(sut.Weapons, 
                       w => Assert.False(string.IsNullOrWhiteSpace(w)));
        }
    }
}
