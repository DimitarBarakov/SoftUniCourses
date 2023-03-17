using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        [Test]
        public void NameSetShouldThrowExceptionIfItsNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var gym = new Gym("", 20);
                var gym1 = new Gym(" ", 20);
            }, "Invalid gym name.");
        }
        [Test]
        public void CapacitySetShouldThrowExceptionIfItsBelow0()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var gym = new Gym("asd", -1);
            });
        }

        [Test]
        public void AddAthleteShoulWorkCorrectly()
        {
            var gym = new Gym("asd", 2);
            Athlete athlete = new Athlete("Mite");
            gym.AddAthlete(athlete);

            Assert.That(gym.Count == 1);
        }
        [Test]
        public void AddAthleteShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var gym = new Gym("asd", 1);
                Athlete athlete = new Athlete("Mite");
                gym.AddAthlete(athlete);
                Athlete athlete1 = new Athlete("Mitko");
                gym.AddAthlete(athlete1);
            }, "The gym is full.");
        }
        [Test]
        public void RemoveAthleteShoulWorkCorrectly()
        {
            var gym = new Gym("asd", 2);
            Athlete athlete = new Athlete("Mite");
            gym.AddAthlete(athlete);
            Athlete athlete1 = new Athlete("Mitko");
            gym.AddAthlete(athlete1);
            gym.RemoveAthlete("Mite");

            Assert.That(gym.Count == 1);
        }
        [Test]
        public void RemoveAthleteShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var gym = new Gym("asd", 2);
                Athlete athlete = new Athlete("Mite");
                gym.AddAthlete(athlete);
                Athlete athlete1 = new Athlete("Mitko");
                gym.AddAthlete(athlete1);
                gym.RemoveAthlete("ads");
            }, "The athlete ads doesn't exist.");
        }

        [Test]
        public void InjureAthleteShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var gym = new Gym("asd", 2);
                Athlete athlete = new Athlete("Mite");
                gym.AddAthlete(athlete);
                Athlete athlete1 = new Athlete("Mitko");
                gym.AddAthlete(athlete1);
                gym.InjureAthlete("ads");
            }, "The athlete ads doesn't exist.");
        }
        [Test]
        public void InhureAthleteSHopulWork()
        {
            var gym = new Gym("asd", 2);
            Athlete athlete = new Athlete("Mite");
            gym.AddAthlete(athlete);
            Athlete athlete1 = new Athlete("Mitko");
            gym.AddAthlete(athlete1);
            Athlete injured = gym.InjureAthlete("Mitko");

            Assert.That(injured, Is.EqualTo(athlete1));
            Assert.That(athlete1.IsInjured);
        }

        [Test]
        public void Report()
        {
            var gym = new Gym("asd", 3);
            Athlete athlete = new Athlete("Mite");
            gym.AddAthlete(athlete);
            Athlete athlete1 = new Athlete("Mitko");
            gym.AddAthlete(athlete1);
            Athlete athlete2 = new Athlete("qwe");
            gym.AddAthlete(athlete2);
            Athlete injured = gym.InjureAthlete("qwe");

            string expected = "Active athletes at asd: Mite, Mitko";
            string report = gym.Report();
            Assert.That(expected, Is.EqualTo(report));
        }
    }
}
