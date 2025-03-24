using SolarSystem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SolarSystemForm
{
    public partial class Form1 : Form
    {
        public List<Planet> planets = new List<Planet>();
        DateTime lastUpdateTime;
        public Form1()
        {
            InitializeComponent();
            InitializeSolarSystem();
            lastUpdateTime = DateTime.Now;
            timer1.Interval = 50; // update every 50ms
            timer1.Tick += Timer1_Tick;
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            float deltaTime = (float)(now - lastUpdateTime).TotalSeconds;
            lastUpdateTime = now;

            foreach (var planet in planets)
            {
                planet.Update(deltaTime);
            }
            panelSolarSystem.Invalidate();
        }

        private void panelSolarSystem_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            PointF center = new PointF(panelSolarSystem.Width / 2, panelSolarSystem.Height / 2);
            // Draw Sun
            int sunRadius = 20;
            g.FillEllipse(Brushes.Yellow, center.X - sunRadius, center.Y - sunRadius, sunRadius * 2, sunRadius * 2);

            foreach (var planet in planets)
            {
                // Draw orbit
                g.DrawEllipse(Pens.LightGray, center.X - planet.orbitalRadius, center.Y - planet.orbitalRadius,
                    planet.orbitalRadius * 2, planet.orbitalRadius * 2);

                // Get current position and draw the planet
                PointF pos = planet.GetPosition(center);
                float planetSize = planet.Size;
                using (Brush brush = new SolidBrush(planet.Color))
                {
                    g.FillEllipse(brush, pos.X - planetSize, pos.Y - planetSize, planetSize * 2, planetSize * 2);
                }
            }
        }

        // Initialize all nine planets with simulation parameters
        private void InitializeSolarSystem()
        {
            planets.Clear();

            // Mercury: diameter = 4900 km, mass = 0.06 Earths
            planets.Add(new Planet("Mercury", 4900, 0.06f)
            {
                orbitalRadius = 50,   // pixels
                period = 10,          // seconds per orbit (simulation scale)
                angularPosition = 0,
                Color = Color.Gray,
                Size = 4
            });
            // Venus: diameter = 12100 km, mass = 0.82 Earths
            planets.Add(new Planet("Venus", 12100, 0.82f)
            {
                orbitalRadius = 80,
                period = 20,
                angularPosition = 0,
                Color = Color.Orange,
                Size = 6
            });
            // Earth: diameter = 12800 km, mass = 6e24 kg
            planets.Add(new Planet("Earth", 12800, 6e24f)
            {
                orbitalRadius = 110,
                period = 30,
                angularPosition = 0,
                Color = Color.Blue,
                Size = 7
            });
            // Mars: diameter = 5800 km, mass = 0.11 Earths
            planets.Add(new Planet("Mars", 5800, 0.11f)
            {
                orbitalRadius = 140,
                period = 40,
                angularPosition = 0,
                Color = Color.Red,
                Size = 6
            });
            // Jupiter: diameter = 142800 km, mass = 318 Earths
            planets.Add(new Planet("Jupiter", 142800, 318f)
            {
                orbitalRadius = 180,
                period = 50,
                angularPosition = 0,
                Color = Color.Brown,
                Size = 10
            });
            // Saturn: diameter = 120000 km, mass = 95 Earths
            planets.Add(new Planet("Saturn", 120000, 95f)
            {
                orbitalRadius = 220,
                period = 60,
                angularPosition = 0,
                Color = Color.Goldenrod,
                Size = 9
            });
            // Uranus: diameter = 52400 km, mass = 15 Earths
            planets.Add(new Planet("Uranus", 52400, 15f)
            {
                orbitalRadius = 260,
                period = 70,
                angularPosition = 0,
                Color = Color.LightBlue,
                Size = 8
            });
            // Neptune: diameter = 48400 km, mass = 17 Earths
            planets.Add(new Planet("Neptune", 48400, 17f)
            {
                orbitalRadius = 300,
                period = 80,
                angularPosition = 0,
                Color = Color.DarkBlue,
                Size = 8
            });
            // Pluto: diameter = 2450 km, mass = 0.002 Earths
            planets.Add(new Planet("Pluto", 2450, 0.002f)
            {
                orbitalRadius = 340,
                period = 90,
                angularPosition = 0,
                Color = Color.Purple,
                Size = 3
            });

            // Update the ListBox with planet names.
            planetsList_Box.Items.Clear();
            foreach (var p in planets)
            {
                planetsList_Box.Items.Add(p.planetName);
            }
        }

        private void loadPlanets_Click(object sender, EventArgs e)
        {
            // In your case, you might load from a file via ReturnPlanetInfo().
            // Here we simply update the ListBox using our simulation list.
            planetsList_Box.Items.Clear();
            foreach (Planet p in planets)
            {
                planetsList_Box.Items.Add(p.planetName);
            }
        }

        private void planetsList_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPlanetName = planetsList_Box.SelectedItem.ToString().Replace(":", "");
            try
            {
                pictureBox1.Image = Image.FromFile(selectedPlanetName + ".jpg");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Image not found: " + ex.Message);
            }
            foreach (Planet p in planets)
            {
                if (p.planetName.Replace(":", "") == selectedPlanetName)
                {
                    planetsDescription.Text = $"Diameter: {p.diameter} km, Mass: {p.mass} {(p.planetName == "Earth:" ? "kg" : "Earths")}";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Planet dummy = new Planet();
            planets = dummy.CalculateEscapeVelocity(planets);
            richTextBox1.Clear();
            foreach (Planet p in planets)
            {
                richTextBox1.AppendText($"\nEscape Velocity of {p.planetName.Replace(":", "")} is {p.escapeVelocity} m/s");
            }
        }

        private void TimeAndDistance(object sender, EventArgs e)
        {
            richTextBox3.Clear();
            foreach (Planet p in planets)
            {
                richTextBox3.AppendText(p.LeaveTimeAndDistanceTraveled(p));
            }
        }

        private void SolarSystemInfok(object sender, EventArgs e)
        {
            Planet dummy = new Planet();
            planets = dummy.ReturnSolarSystemInfo(planets);
            richTextBox4.Clear();
            foreach (Planet p in planets)
            {
                richTextBox4.AppendText($"\n{p.planetName.Replace(":", "")} Period: {p.period} days, Orbital Radius: {p.orbitalRadius} AU");
            }
        }

        private void CalculateDistance(object sender, EventArgs e)
        {
            Planet planet1 = new Planet();
            Planet planet2 = new Planet();

            planet1.planetName = textBox1.Text;
            planet2.planetName = textBox2.Text;
            if (radioButton1.Checked)
            {
                richTextBox5.Text = planet1.CalculateDistance(planet1, planet2);
            }
        }
    }
}
