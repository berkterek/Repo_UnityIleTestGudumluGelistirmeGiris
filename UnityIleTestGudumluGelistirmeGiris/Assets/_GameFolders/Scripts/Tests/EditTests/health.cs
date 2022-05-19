using NSubstitute;
using NUnit.Framework;
using UnityTddBeginner.Abstracts.Combats;
using UnityTddBeginner.Abstracts.ScriptableObjects;
using UnityTddBeginner.Combats;

namespace Combats
{
    public class health
    {
        IAttacker _attacker;
        
        [SetUp]
        public void Setup()
        {
            _attacker = Substitute.For<IAttacker>();
        }
        
        private IHealth GetHealth(int maxHealth)
        {
            IStats stats = Substitute.For<IStats>();
            stats.MaxHealth.Returns(maxHealth);
            IHealth health = new Health(stats);
            return health;
        }
        
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(10)]
        public void take_damage_not_equal_max_health(int damageValue)
        {
            //Arrange
            int maxHealth = 1;
            var health = GetHealth(maxHealth);

            //Act
            _attacker.Damage.Returns(damageValue);
            health.TakeDamage(_attacker);

            //Assert
            Assert.AreNotEqual(maxHealth, health.CurrentHealth);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(10)]
        public void take_damage_current_health_not_less_then_zero(int damageValue)
        {
            //Arrange
            int maxHealth = 1;
            var health = GetHealth(maxHealth);

            //Act
            _attacker.Damage.Returns(damageValue);
            health.TakeDamage(_attacker);

            //Assert
            Assert.GreaterOrEqual(health.CurrentHealth, 0);
        }

        [Test]
        public void take_damage_one_on_took_damage_event_triggered_one_time()
        {
            var health = GetHealth(5);

            _attacker.Damage.Returns(1);

            string message = string.Empty;
            health.OnTookDamage += () => message = "On Took Damage Event Triggered";
            health.TakeDamage(_attacker);
            
            Assert.AreNotEqual(string.Empty, message);
        }
        
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(10)]
        public void take_many_damage_on_took_damage_event_triggered_many_time(int value)
        {
            var health = GetHealth(100);
            int damageLoop = value;

            _attacker.Damage.Returns(1);

            int damageCounter = value;
            health.OnTookDamage += () => damageCounter++;

            for (int i = 0; i < damageLoop; i++)
            {
                health.TakeDamage(_attacker);    
            }
            
            Assert.AreEqual(damageCounter,damageCounter);
        }

        [Test]
        public void take_fatal_damage_on_dead_triggered()
        {
            int maxHealth = 100;
            var health = GetHealth(maxHealth);

            _attacker.Damage.Returns(maxHealth + 1);

            string message = string.Empty;
            health.OnDead += () => message = "On Dead event Triggered";
            health.TakeDamage(_attacker);
            
            Assert.AreNotEqual(string.Empty, message);
        }

        [Test]
        public void take_normal_damage_on_dead_not_triggered()
        {
            int maxHealth = 100;
            var health = GetHealth(maxHealth);

            _attacker.Damage.Returns(maxHealth / 2);

            string expectedResult = string.Empty;
            string message = expectedResult;
            health.OnDead += () => message = "On Dead event Triggered";
            health.TakeDamage(_attacker);
            
            Assert.AreEqual(expectedResult, message);
        }

        [Test]
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(10)]
        public void take_fatal_damage_many_time_on_took_damage_triggered_one_time(int value)
        {
            int maxHealth = 100;
            var health = GetHealth(maxHealth);
            int damageLoop = value;

            _attacker.Damage.Returns(maxHealth + 1);
            int damageCounter = 0;
            health.OnTookDamage += () => damageCounter++;

            for (int i = 0; i < damageLoop; i++)
            {
                health.TakeDamage(_attacker);
            }
            
            Assert.AreEqual(1,damageCounter);
        }
    }
}