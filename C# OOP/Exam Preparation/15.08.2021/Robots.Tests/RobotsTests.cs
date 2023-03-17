namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        [Test]
        public void CapacityThrowExceptionIfItsBelow0()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var robots = new RobotManager(-1);
            }, "Invalid capacity!");
        }
        [Test]
        public void AddRobbotThrowExceptionIfRobbotExists()
        {
            var robots = new RobotManager(2);
            Robot robot = new Robot("asd", 23);
            Assert.Throws<InvalidOperationException>(() =>
            {

                robots.Add(robot);
                robots.Add(robot);
            }, $"There is already a robot with name {robot.Name}!");
        }
        [Test]
        public void AddShouldWork()
        {
            var robots = new RobotManager(1);
            Robot robot = new Robot("asd", 23);
            robots.Add(robot);
            Assert.AreEqual(1, robots.Count);
        }
        [Test]
        public void AddRobbotThrowExceptionIfNoCApacity()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var robots = new RobotManager(1);
                Robot robot = new Robot("asd", 23);
                robots.Add(robot);
                Robot robot1 = new Robot("qwe", 12);
                robots.Add(robot1);
            }, "Not enough capacity!");
        }
        [Test]
        public void RemoveThrowException()
        {
            var robots = new RobotManager(1);
            Robot robot = new Robot("asd", 23);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robots.Remove("qwe");
            }, "Robot with the name qwe doesn't exist!");
        }
        [Test]
        public void RemoveShouldWork()
        {
            var robots = new RobotManager(1);
            Robot robot = new Robot("asd", 23);
            robots.Add(robot);
            robots.Remove("asd");
            Assert.AreEqual(0, robots.Count);
        }
        [Test]
        public void ChargeThrowException()
        {
            var robots = new RobotManager(1);
            Robot robot = new Robot("asd", 23);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robots.Charge("qwe");
            }, "Robot with the name qwe doesn't exist!");
        }
        [Test]
        public void ChargeShoulWork()
        {
            var robots = new RobotManager(1);
            Robot robot = new Robot("asd", 23);
            robots.Add(robot);
            robots.Work("asd", "qe", 10);
            robots.Charge("asd");
            Assert.AreEqual(23, robot.Battery);
        }
        [Test]
        public void WorkShouldThrowExceptionIfRobotDoesntExist()
        {
            var robots = new RobotManager(1);
            Robot robot = new Robot("asd", 23);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robots.Work("qwe", "", 12);
            }, "Robot with the name qwe doesn't exist!");
        }
        [Test]
        public void WorkShouldThrowExceptionIfRobotBatteryIsLower()
        {
            var robots = new RobotManager(1);
            Robot robot = new Robot("asd", 23);
            robots.Add(robot);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robots.Work("asd", "qe", 24);
            }, $"{robot.Name} doesn't have enough battery!");
        }
        [Test]
        public void WorkShouldWork()
        {
            var robots = new RobotManager(1);
            Robot robot = new Robot("asd", 23);
            robots.Add(robot);
            robots.Work("asd", "qe", 10);
            Assert.AreEqual(13, robot.Battery);
        }
    }
}
