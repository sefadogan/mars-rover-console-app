using NUnit.Framework;
using Sefd.MarsRover.Common.Abstracts;
using Sefd.MarsRover.Common.Concretes;
using Sefd.MarsRover.Common.Consts.Enums;
using Sefd.MarsRover.UnitTests.TestHelper;

namespace Sefd.MarsRover.UnitTests.Common.Concretes
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class RoverTests : BaseTestFixture
    {
        #region Properties - SetUp
        private IRover _rover;

        [SetUp]
        public void SetUp()
        {
            _rover = new Rover();
        }
        #endregion

        #region TurnLeft Tests
        [Test]
        [TestCase(RoverDirection.N, RoverDirection.W)]
        [TestCase(RoverDirection.E, RoverDirection.N)]
        [TestCase(RoverDirection.S, RoverDirection.E)]
        [TestCase(RoverDirection.W, RoverDirection.S)]
        public void TurnLeft_WhenCalled_SetTheDirection(RoverDirection currentDirection, RoverDirection expectedResult)
        {
            // Arrange
            _rover.Position = new RoverPosition
            {
                Direction = currentDirection
            };

            // Act
            _rover.TurnLeft();

            // Assert
            Assert.That(_rover.Position.Direction, Is.EqualTo(expectedResult));
        }
        #endregion
    }
}
