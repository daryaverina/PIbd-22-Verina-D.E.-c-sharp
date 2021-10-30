﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsPlanes
{
    public partial class FormPlane : Form
    {
        private ITransport plane;
        public FormPlane()
        {
            InitializeComponent();
        }

        public void SetPlane(ITransport plane)
        {
            this.plane = plane;
            Draw();
        }


        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxPlanes.Width, pictureBoxPlanes.Height);
            Graphics gr = Graphics.FromImage(bmp);
            plane?.DrawTransport(gr);
            pictureBoxPlanes.Image = bmp;
        }
        private void buttonMove_Click(object sender, EventArgs e)
        {
            //получаем имя кнопки
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    plane.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    plane.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    plane.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    plane.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }



        private void buttonCreatePlane_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            plane = new Plane(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Blue);
            plane.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxPlanes.Width,
           pictureBoxPlanes.Height);
            Draw();
        }
        private void buttonCreateAirbus_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            plane = new Airbus(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Blue,
           Color.Yellow, true, true);
            plane.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxPlanes.Width,
          pictureBoxPlanes.Height);
            Draw();
        }

      
    }
}