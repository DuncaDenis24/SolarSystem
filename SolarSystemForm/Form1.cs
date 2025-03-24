using SolarSystem;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

        }

        private void simulateSystem_Click(object sender, EventArgs e)
        {
            
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
            Planet planet = new Planet();
            planets = planet.ReturnPlanetInfo();
            planets = planet.ReturnSolarSystemInfo(planets);

            float margin = 20f;
            float availableRadius = Math.Min(panelSolarSystem.Width, panelSolarSystem.Height) / 2f - margin;

            // Find min and max AU
            float minAU = float.MaxValue;
            float maxAU = 0;
            foreach (var p in planets)
            {
                if (p.orbitalRadius < minAU) minAU = p.orbitalRadius;
                if (p.orbitalRadius > maxAU) maxAU = p.orbitalRadius;
            }

            float innerRadius = 30f;     // a small offset from the center
            float maxSimOrbit = availableRadius;

            // Precompute log(minAU + 1) and log(maxAU + 1) so we avoid log(0)
            double logMin = Math.Log(minAU + 1);
            double logMax = Math.Log(maxAU + 1);

            // We'll keep your desiredSimFactor for the period's logarithmic conversion
            float desiredSimFactor = 30f;

            foreach (var p in planets)
            {
                p.planetName = p.planetName.Replace(":", "");

                // --- LOGARITHMIC MAPPING FOR ORBITAL RADIUS ---
                // shift radius by +1 so Mercury (0.39) doesn't produce a very small log
                double logVal = Math.Log(p.orbitalRadius + 1);
                double ratio = (logVal - logMin) / (logMax - logMin);

                // Now map ratio -> [innerRadius, maxSimOrbit]
                p.orbitalRadius = innerRadius + (float)ratio * (maxSimOrbit - innerRadius);

                // --- LOGARITHMIC MAPPING FOR PERIOD ---
                double simPeriod = desiredSimFactor * Math.Log(p.period / 365.0 + 1);
                p.period = (int)simPeriod;

                p.angularPosition = 0;

                // Colors & sizes as before
                if (p.planetName.Contains("Mercury"))
                {
                    p.Color = Color.Gray;
                    p.Size = 4;
                }
                else if (p.planetName.Contains("Venus"))
                {
                    p.Color = Color.Orange;
                    p.Size = 6;
                }
                else if (p.planetName.Contains("Earth"))
                {
                    p.Color = Color.Blue;
                    p.Size = 7;
                }
                else if (p.planetName.Contains("Mars"))
                {
                    p.Color = Color.Red;
                    p.Size = 6;
                }
                else if (p.planetName.Contains("Jupiter"))
                {
                    p.Color = Color.Brown;
                    p.Size = 10;
                }
                else if (p.planetName.Contains("Saturn"))
                {
                    p.Color = Color.Goldenrod;
                    p.Size = 9;
                }
                else if (p.planetName.Contains("Uranus"))
                {
                    p.Color = Color.LightBlue;
                    p.Size = 8;
                }
                else if (p.planetName.Contains("Neptune"))
                {
                    p.Color = Color.DarkBlue;
                    p.Size = 8;
                }
                else if (p.planetName.Contains("Pluto"))
                {
                    p.Color = Color.Purple;
                    p.Size = 3;
                }
            }
        }




        private void loadPlanets_Click(object sender, EventArgs e)
        {
            int count = 0;
            Planet planet=new Planet();
            planets = planet.ReturnPlanetInfo();
            foreach (Planet p in planets)
            {
                count++;
                planetsList_Box.Items.Add(p.planetName);
            }
            loadPlanets.Enabled = false;
            
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
            Planet planet = new Planet();
            planets = planet.CalculateEscapeVelocity(planets);
            
            foreach (Planet p in planets)
            {
                richTextBox1.Text+=($"\nEscape Velocity of {p.planetName.Replace(":", "")} is {p.escapeVelocity} m/s");
            }
        }

        private void TimeAndDistance(object sender, EventArgs e)
        {
           
            foreach (Planet p in planets)
            {
                richTextBox3.Text+= (p.LeaveTimeAndDistanceTraveled(p));
            }
        }

        private void SolarSystemInfo(object sender, EventArgs e)
        {
            Planet planet = new Planet();
            planets = planet.ReturnSolarSystemInfo(planets);
           
            foreach (Planet p in planets)
            {
                richTextBox4.Text += ($"\n{p.planetName.Replace(":", "")} Period: {p.period} days, Orbital Radius: {p.orbitalRadius} AU");
            }
            button4.Enabled = false;
            simulateSystem.Enabled = true;
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
