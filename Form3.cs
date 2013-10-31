using System;

using Phidgets;         //needed for the interfacekit class and the phidget exception class
using Phidgets.Events;
using System.Drawing;
using System.Windows.Forms;

//using Graphics;
namespace InterfaceKit_full
{
    public partial class Form3 : Form
    {
        private InterfaceKit ifKit;
        private Shape[] circleArray;
        Graphics g;

        public Form3()
        {
            InitializeComponent();
            BackColor = Color.Black;
            g = this.CreateGraphics();
            
            circleArray = new Shape[8];
            initCircleArray();
           
           

        }

        public void initCircleArray(){
            //For all possible sensors in the Phidget Interface
            for (int i = 0; i < 8; i++)
            {
                // For each sensor, create an initial circle shape
                Point p = new Point(100, 100);
                circleArray[i] = new Shape("ellipse", Color.Red, p, g);
                circleArray[i].changeSize(new Point(300, 300));
                
                // Place shape somewhere on the form
                if (i < 4)
                {
                    circleArray[i].changePosition(new Point((i + 1) * 50, (i+1)*50));
                }
                else
                {
                    circleArray[i].changePosition(new Point((i + 1) * 50, 0));
                }

                //Draw the shapes
                // If you input the string "gradient",any gradient changes will be applied
                circleArray[i].Draw("normal");
            }// end for loop


        }
        
        //Initialize the device
        public void Form3_Load(object sender, EventArgs e)
        {

        }

        //IfKit attach event handler
        public void ifKit_Attach(object sender, AttachEventArgs e)
        {
            BackColor = Color.Black;
        }

        //Ifkit detach event handler
        public void ifKit_Detach(object sender, DetachEventArgs e)
        {
            BackColor = Color.White;
        }

        //Sensor input change event handler
        public void ifKit_SensorChange(object sender, SensorChangeEventArgs e)
        {
           
                if (e.Index==0)
                {
                    circleArray[e.Index].changeColor(Color.FromArgb(e.Value * 1 / 4, e.Value * 1 / 4, e.Value * 1 / 4));
                    circleArray[e.Index].changeSize(new Point((e.Value) + 1, (e.Value) + 1));
                }   
                   

            
                g.Clear(Color.Black);
                
                for (int i = 0; i < 8; i++)
                {
                    // Draw (with gradients)
                    circleArray[i].Draw("");
                   
                 }
        }


    }
}

