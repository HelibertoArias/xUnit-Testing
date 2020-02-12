using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameEngine.Tests
{
    [Trait("Category", "Enemy")]

    public class EnemyFactoryShould
    {
        [Fact(Skip ="Don't neet to run this")]
        public void CreateNormalEnemyByDefaul()
        {
            var sut = new EnemyFactory();
            var enemy = sut.Create("Zombie");

            Assert.IsType<NormalEnemy>(enemy);
        }

        [Fact]
        public void CreateNormalEnemyByDefault_NotTypeExample()
        {
            var sut = new EnemyFactory();
            var enemy = sut.Create("Zombie");
            Assert.IsNotType<DateTime>(enemy);
        }

        [Fact]
        public void CreateBossEnemy_AssertAssignableType()
        {
            var sut = new EnemyFactory();
            var enemy = sut.Create("Zombie King", true);
            Assert.IsAssignableFrom<Enemy>(enemy);
        }

        [Fact]
        public void CreateSeparatedInstances()
        {
            var sut = new EnemyFactory();
            Enemy enemy1 = sut.Create("Zombie");
            Enemy enemy2 = sut.Create("Zombie");
            Assert.NotSame(enemy1, enemy2);
        }

        [Fact]
        public void NotAllowNullName()
        {
            var sut = new EnemyFactory();

           // Assert.Throws<ArgumentNullException>(() => { sut.Create(null); });
            Assert.Throws<ArgumentNullException>("name",
                                                    () =>  sut.Create(null));
        }

        [Fact]
        public void OnlyAllowKingOrQueenBossEnemies()
        {
            var sut = new EnemyFactory();
            EnemyCreationException ex = Assert.Throws<EnemyCreationException>(() => sut.Create("Zombie", true));
            Assert.Equal("Zombie", ex.RequestedEnemyName);
        }
    } 
}
