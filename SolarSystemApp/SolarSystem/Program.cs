using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
    public class Planet
    {
        public string planetName { get; set; }
        public int diameter { get; set; }
        public float mass { get; set; }
        public float escapeVelocity { get; set; }
        public int period { get; set; }            // For simulation: period (in seconds) for a full orbit.
        public float orbitalRadius { get; set; }     // For simulation: drawn radius in pixels.
        public float timeFromSurface { get; set; }
        public float distanceFromSurface { get; set; }
        public float angularPosition { get; set; }   // In degrees.

        // New properties for simulation drawing.
        public Color Color { get; set; }
        public float Size { get; set; }              // Drawn radius in pixels.

        public Planet() { }

        public Planet(string planetName, int diameter, float mass)
        {
            this.planetName = planetName;
            this.diameter = diameter;
            this.mass = mass;
        }

        // Get the current drawing position based on this planet's properties.
        public PointF GetPosition(PointF center)
        {
            double rad = this.angularPosition * Math.PI / 180.0;
            float x = center.X + this.orbitalRadius * (float)Math.Cos(rad);
            float y = center.Y + this.orbitalRadius * (float)Math.Sin(rad);
            return new PointF(x, y);
        }

        // Update the angular position based on the elapsed time.
        public void Update(float deltaTime)
        {
            // Increase the angle proportionally to deltaTime over the orbit period.
            this.angularPosition += 360f * (deltaTime / this.period);
            if (this.angularPosition >= 360f)
            {
                this.angularPosition %= 360f;
            }
        }

        // Returns a list of planets read from file.
        public List<Planet> ReturnPlanetInfo()
        {
            List<Planet> planets = new List<Planet>();

            StreamReader sr = new StreamReader("Planetary_Data.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split(' ');
                // Assume the first part is the planet name and the remaining parts include keywords.
                for (int i = 0; i < parts.Length; i++)
                {
                    planetName = parts[0];

                    if (parts[i] == "diameter")
                    {
                        diameter = int.Parse(parts[i + 2]);
                    }
                    if (parts[i] == "mass")
                    {
                        if (planetName == "Earth:")
                        {
                            mass = 6 * (float)Math.Pow(10, 24);
                        }
                        else
                        {
                            mass = float.Parse(parts[i + 2]);
                        }
                    }
                }
            }
            sr.Close();
            return planets;
        }

        // Calculates escape velocity for each planet.
        public List<Planet> CalculateEscapeVelocity(List<Planet> planets)
        {
            float G = 6.67f * (float)Math.Pow(10, -11);
            foreach (var item in planets)
            {
                // For Earth, use a fixed mass; for others, multiply by 6e24.
                float effectiveMass = (item.planetName == "Earth:" ? 6 * (float)Math.Pow(10, 24) : item.mass * 6 * (float)Math.Pow(10, 24));
                // Convert diameter from km to m.
                float radius = (item.diameter / 2) * 1000;
                item.escapeVelocity = (float)Math.Sqrt((2 * G * effectiveMass) / radius);
            }
            return planets;
        }

        // Reads additional solar system info (such as period and orbital radius) from file.
        public List<Planet> ReturnSolarSystemInfo(List<Planet> planets)
        {
            StreamReader sr = new StreamReader("Solar_System_Data.txt");
            Console.WriteLine("\n1 AU (astronomical unit) is equal to 149597870.7 km");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                Planet p = new Planet();
                string[] parts = line.Split(' ');
                for (int i = 0; i < parts.Length; i++)
                {
                    p.planetName = parts[0];
                    if (parts[i] == "period")
                    {
                        p.period = int.Parse(parts[i + 2]);
                    }
                    if (parts[i] == "orbital" && parts[i + 1] == "radius")
                    {
                        p.orbitalRadius = float.Parse(parts[i + 3]);
                    }
                    // Update the corresponding planet in the list.
                    var target = planets.FirstOrDefault(x => x.planetName == p.planetName);
                    if (target != null)
                    {
                        target.period = p.period;
                        target.orbitalRadius = p.orbitalRadius;
                    }
                }
            }
            sr.Close();
            return planets;
        }

        // Returns a string with the time and distance calculations for a given planet.
        public string LeaveTimeAndDistanceTraveled(Planet planet)
        {
            int acceleration = 4 * 10;
            float time = planet.escapeVelocity / acceleration;
            float distanceFromSurface = acceleration * (float)Math.Pow(time, 2) / 2;
            float distanceFromCenter = (planet.diameter / 2) * (float)Math.Pow(10, 3) + distanceFromSurface;
            return ($"\nTime to leave {planet.planetName} is {Math.Round(time, 2)} seconds" +
                    $"\nDistance traveled from the surface of {planet.planetName} is {distanceFromSurface} m or {Math.Round(distanceFromSurface / 1000, 2)} km" +
                    $"\nDistance traveled from the center of {planet.planetName} is {distanceFromCenter} m or {Math.Round(distanceFromCenter / 1000, 2)} km");
        }

        // Calculates the Euclidean distance between two planets using their orbital radii and angular positions.
        public static float CalculateDistanceBetweenPlanets(Planet p1, Planet p2)
        {
            float distance;
            if (p1.angularPosition == p2.angularPosition)
            {
                distance = Math.Abs(p2.orbitalRadius - p1.orbitalRadius);
            }
            else
            {
                // Convert angles to radians.
                float angle1 = p1.angularPosition * (float)Math.PI / 180f;
                float angle2 = p2.angularPosition * (float)Math.PI / 180f;
                distance = (float)Math.Sqrt(Math.Pow(p2.orbitalRadius * Math.Cos(angle2) - p1.orbitalRadius * Math.Cos(angle1), 2) +
                                            Math.Pow(p2.orbitalRadius * Math.Sin(angle2) - p1.orbitalRadius * Math.Sin(angle1), 2));
            }
            return distance;
        }

        public static int WaitingTimeFreeze(List<Planet> planets, Planet p1, Planet p2)
        {
            int waitingTime = 0;
            float smallestDistance = 1e15f;
            for (int i = 1; i <= 10 * 365; i++)
            {
                planets = UpdateSolarSystem(planets, i);
                float distance = CalculateDistanceBetweenPlanets(p1, p2);
                if (distance < smallestDistance)
                {
                    foreach (var item in planets)
                    {
                        if (item.planetName == p1.planetName || item.planetName == p2.planetName)
                            continue;
                        else if (distance != (CalculateDistanceBetweenPlanets(p1, item) + CalculateDistanceBetweenPlanets(p2, item)))
                        {
                            smallestDistance = distance;
                            waitingTime = i;
                        }
                        else
                        {
                            Console.WriteLine($"Trajectory intersects {item.planetName}");
                            break;
                        }
                    }
                }
            }
            Console.WriteLine($"The planets will be at the smallest distance of {smallestDistance} AU after {waitingTime} days, {Math.Round((float)waitingTime / 365, 2)} years");
            return waitingTime;
        }

        public static float WaitingTimeMoving(List<Planet> planets, Planet p1, Planet p2)
        {
            int waitingTime = 0;
            float smallestDistance = 1e15f;
            for (int i = 1; i <= 10 * 365; i++)
            {
                planets = UpdateSolarSystem(planets, i);
                float distance = CalculateDistanceBetweenPlanets(p1, p2);
                if (distance < smallestDistance)
                {
                    foreach (var item in planets)
                    {
                        if (item.planetName == p1.planetName || item.planetName == p2.planetName)
                            continue;
                        else if (distance > (CalculateDistanceBetweenPlanets(p1, item) + CalculateDistanceBetweenPlanets(p2, item)))
                        {
                            float travelTime = TravelTime(distance, p1, p2);
                            for (int j = 1; j <= Math.Round(travelTime / (68 * 60 * 24)); j++)
                            {
                                planets = UpdateSolarSystem(planets, j);
                                foreach (var item1 in planets)
                                {
                                    if (item1.planetName == p1.planetName || item1.planetName == p2.planetName)
                                        continue;
                                    else if (distance > (CalculateDistanceBetweenPlanets(p1, item1) + CalculateDistanceBetweenPlanets(p2, item1)))
                                    {
                                        smallestDistance = distance;
                                        waitingTime = i;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine($"The planets will be at the smallest distance of {smallestDistance} AU after {waitingTime} days, {Math.Round((float)waitingTime / 365, 2)} years");
            return waitingTime;
        }

        public static float TravelTime(float distance, Planet p1, Planet p2)
        {
            double au = 149597870700;
            float maxVelocity = (p1.escapeVelocity >= p2.escapeVelocity ? p1.escapeVelocity : p2.escapeVelocity);
            float minVelocity = (p1.escapeVelocity <= p2.escapeVelocity ? p1.escapeVelocity : p2.escapeVelocity);
            float accelerationTime = maxVelocity / 40;
            float deccelerationTime = minVelocity / 40;
            float distanceFromSurface1 = 40 * (float)Math.Pow(accelerationTime, 2) / 2;
            float distanceFromSurface2 = 40 * (float)Math.Pow(deccelerationTime, 2) / 2;
            double distanceCruising = (au * distance) - distanceFromSurface1 - distanceFromSurface2;
            double totalTime = distanceCruising / maxVelocity + accelerationTime + deccelerationTime;
            return (float)totalTime;
        }

        public string CalculateDistance(Planet p1, Planet p2)
        {
            double au = 149597870700;
            float maxVelocity = (p1.escapeVelocity >= p2.escapeVelocity ? p1.escapeVelocity : p2.escapeVelocity);
            float minVelocity = (p1.escapeVelocity <= p2.escapeVelocity ? p1.escapeVelocity : p2.escapeVelocity);
            float distance = CalculateDistanceBetweenPlanets(p1, p2);
            float accelerationTime = maxVelocity / 40;
            float deccelerationTime = minVelocity / 40;
            float distanceFromSurface1 = 40 * (float)Math.Pow(accelerationTime, 2) / 2;
            float distanceFromSurface2 = 40 * (float)Math.Pow(deccelerationTime, 2) / 2;
            double distanceCruising = (au * distance) - distanceFromSurface1 - distanceFromSurface2;
            double totalTime = distanceCruising / maxVelocity + accelerationTime + deccelerationTime;
            return ($"Distance between {p1.planetName} and {p2.planetName} is {distance} AU or {au * distance / 1000} km\nThe rocket will reach its cruising velocity in {Math.Round(accelerationTime, 3)} seconds\nThe distance from the surface of the start planet to when it reaches the cruising velocity is {Math.Round(distanceFromSurface1, 3)} m or {Math.Round(distanceFromSurface1 / 1000, 3)} km\nDistance cruising: {Math.Round(distanceCruising, 3)} m or {Math.Round(distanceCruising / 1000, 3)} km, {Math.Round(distanceCruising / au, 3)} AU\nAt a distance of {Math.Round(distanceFromSurface2, 3)} m or {Math.Round(distanceFromSurface2 / 1000, 3)} km from the surface of the destination planet, the rocket starts to deccelerate\nWill deccelerate for {Math.Round(deccelerationTime, 3)} seconds\nTotal travel time will be: {Math.Round(totalTime, 3)} seconds, {Math.Round(totalTime / 60, 3)} minutes, {Math.Round(totalTime / 3600, 3)} hours, {Math.Round(totalTime / (3600 * 24), 3)} days");
        }

        public static void OptimalWindow(List<Planet> planets)
        {
            Console.WriteLine("Choose the planets:");
            double au = 149597870700;
            string planet1 = Console.ReadLine();
            string planet2 = Console.ReadLine();
            float maxVelocity;
            float minVelocity;
            float distance;
            Planet p1 = new Planet();
            Planet p2 = new Planet();
            foreach (var item1 in planets)
            {
                if (item1.planetName == (planet1 + ":"))
                {
                    p1 = item1;
                }
                if (item1.planetName == (planet2 + ":"))
                {
                    p2 = item1;
                }
            }
            distance = CalculateDistanceBetweenPlanets(p1, p2);
            Console.WriteLine($"Distance between {planet1} and {planet2} is {distance} AU");
            float waitingTime = WaitingTimeMoving(planets, p1, p2);
            planets = UpdateSolarSystem(planets, waitingTime);
            foreach (var item in planets)
            {
                Console.WriteLine($"Angular Position for {item.planetName} " + item.angularPosition + " degrees");
            }
            distance = CalculateDistanceBetweenPlanets(p1, p2);
            maxVelocity = (p1.escapeVelocity >= p2.escapeVelocity ? p1.escapeVelocity : p2.escapeVelocity);
            minVelocity = (p1.escapeVelocity <= p2.escapeVelocity ? p1.escapeVelocity : p2.escapeVelocity);
            float accelerationTime = maxVelocity / 40;
            float deccelerationTime = minVelocity / 40;
            float distanceFromSurface1 = 40 * (float)Math.Pow(accelerationTime, 2) / 2;
            float distanceFromSurface2 = 40 * (float)Math.Pow(deccelerationTime, 2) / 2;
            double distanceCruising = (au * distance) - distanceFromSurface1 - distanceFromSurface2;
            double totalTime = distanceCruising / maxVelocity + accelerationTime + deccelerationTime;
            Console.WriteLine($"The rocket will reach its cruising velocity in {Math.Round(accelerationTime, 3)} seconds ");
            Console.WriteLine($"The distance from the surface of the start planet to when it reaches the cruising velocity is {Math.Round(distanceFromSurface1, 3)} m or {Math.Round(distanceFromSurface1 / 1000, 3)} km");
            Console.WriteLine($"Distance cruising: {Math.Round(distanceCruising, 3)} m or {Math.Round(distanceCruising / 1000, 3)} km or {Math.Round(distanceCruising / au, 3)} AU");
            Console.WriteLine($"At a distance of {Math.Round(distanceFromSurface2, 3)} m or {Math.Round(distanceFromSurface2 / 1000, 3)} km from the surface of the destination planet, the rocket starts to deccelerate");
            Console.WriteLine($"It will deccelerate for {Math.Round(deccelerationTime, 3)} seconds");
            Console.WriteLine($"Total travel time will be: {Math.Round(totalTime, 3)} seconds, {Math.Round(totalTime / 60, 3)} minutes, {Math.Round(totalTime / 3600, 3)} hours, {Math.Round(totalTime / (3600 * 24), 3)} days");
        }

        public static List<Planet> UpdateSolarSystem(List<Planet> planets, float days)
        {
            foreach (var item in planets)
            {
                item.angularPosition = (2 * (float)Math.PI * (days + 36500) / item.period) * 180 / (float)Math.PI;
                if (item.angularPosition > 360)
                {
                    item.angularPosition %= 360;
                }
                planets.Find(x => x.planetName == item.planetName).angularPosition = item.angularPosition;
            }
            return planets;
        }

        public static List<Planet> SimulateSolarSystem(List<Planet> planets, int days)
        {
            Console.WriteLine("\nSimulating the Solar System");
            Console.WriteLine($"Angular Position of the planets after {days} days: ");
            foreach (var item in planets)
            {
                item.angularPosition = (2 * (float)Math.PI * days / item.period) * 180 / (float)Math.PI;
                if (item.angularPosition > 360)
                {
                    item.angularPosition %= 360;
                }
                Console.WriteLine($"Angular Position for {item.planetName} " + item.angularPosition + " degrees");
                planets.Find(x => x.planetName == item.planetName).angularPosition = item.angularPosition;
            }
            return planets;
        }

        public static void JourneyPlanning(List<Planet> planets)
        {
            planets = SimulateSolarSystem(planets, 100 * 365);
            OptimalWindow(planets);
        }

        // The Main method below is for console testing.
        // In your Windows Forms project, you will call these methods from your Form.
        class Program
        {
            static void Main(string[] args)
            {
                List<Planet> planets = new List<Planet>();
                Planet planet = new Planet();
                planets = planet.ReturnPlanetInfo();
                Console.WriteLine("Planets in the Solar System");
                foreach (var item in planets)
                {
                    Console.WriteLine($"Planet Name: {item.planetName} Diameter: {item.diameter}, Mass: {item.mass} {(item.planetName == "Earth:" ? "kg" : "Earths")}");
                }
                planets = planet.CalculateEscapeVelocity(planets);
                    Console.WriteLine("\n");
                    foreach (var item in planets)
                    {
                        Console.WriteLine($"Escape Velocity of {item.planetName} is {item.escapeVelocity} m/s");
                    }
                    planets = planet.ReturnSolarSystemInfo(planets);
                    foreach (var item in planets)
                    {
                        Console.WriteLine($"{item.planetName} Period: {item.period} days, Orbital Radius: {item.orbitalRadius} AU");
                    }
                    JourneyPlanning(planets);
                    Console.ReadLine();
                }
            }
        }
    }
