using KarelRobotCore.Interfaces;
using KarelTheRobotLib;
using KarelTheRobotLib.Factories;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace KarelSpecFlowTest
{
    [Binding]
    public class RobotMoveDefinition
    {
        private const int NoOfAvenues = 5;
        private const int NoOfStreets = 5;

        private IWorld _world;
        private IRobot _robot;

        [Given(@"I have set up robot to move")]
        public void GivenIHaveSetUpRobotToMove()
        {
            _world = new World(NoOfAvenues, NoOfStreets);
            _robot = new RobotFactory().CreateRobot(_world);
        }

        [When(@"I ask robot to move")]
        public void WhenIAskRobotToMove()
        {
            _robot.Move();
            _robot.PutBeeper();
            _robot.PickBeeper();
            _robot.Move();
            _robot.TurnLeft();
            _robot.TurnLeft();
            _robot.TurnLeft();
            _robot.TurnLeft();
            _robot.Move();
            _robot.Move();
            _robot.PutBeeper();
        }

        [Then(@"the robot should have moved")]
        public void ThenTheRobotShouldHaveMoved()
        {
            Assert.AreEqual(_robot.Street, 5);
        }
    }
}
