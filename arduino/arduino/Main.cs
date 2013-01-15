using System;
using Gtk;
using System.IO.Ports;
using System.Threading;

namespace arduino
{
	/**
	 * http://playground.arduino.cc/Interfacing/Mono 
	**/
	class MainClass:Window
	{
		SerialPort sPort = new SerialPort ();
				
		public MainClass ():base("Buttons")
		{
	 
			sPort.PortName = "/dev/ttyACM0";
			sPort.BaudRate = 9600;
			sPort.Open ();
			
			SetDefaultSize (250, 300);
			SetPosition (WindowPosition.Center);
			DeleteEvent += delegate{
				Application.Quit ();
			};
			
			Fixed fix = new Fixed ();
			Button green = new Button ("Green");
			green.Name = ("Green");
			green.SetSizeRequest(50,30);
			
			Button red = new Button ("Red");
			red.Name = ("Red");
			red.SetSizeRequest(50,30);
			
			Button yellow = new Button ("Yellow");
			yellow.Name = ("Yellow");
			yellow.SetSizeRequest(50,30);
			
			green.Clicked += new EventHandler (OnClick);
			red.Clicked += new EventHandler (OnClick);
			yellow.Clicked += new EventHandler (OnClick);
			
			fix.Put(green,20,30);
			fix.Put (red, 80, 30);
			fix.Put (yellow, 140, 30);
			Add (fix);
			ShowAll ();
			
		}

		void OnClick (object sender, EventArgs args)
		{
			
			Button temp = (Button)sender;
			string name = temp.Name;
			switch (name) {
			
			case "Green":
				Thread.Sleep (500);
				sPort.Write ("1");
				Thread.Sleep (500);
				break;
			case "Red":					
				Thread.Sleep (500);
				sPort.Write ("2");
				Thread.Sleep (500);
				break;
			
			case "Yellow":
				Thread.Sleep (500);
				sPort.Write ("3");
				Thread.Sleep (500);
				break;
			}
			
			
		}
		
		public static void Main (string[] args)
		{
			
			Application.Init ();
			MainClass win = new MainClass ();
			win.Show ();
			Application.Run ();
		
		
		
		
		}
	}

}
