
using System;
using MonoBrickFirmware;
using MonoBrickFirmware.Display.Dialogs;
using MonoBrickFirmware.Display;
using MonoBrickFirmware.Movement;
using MonoBrickFirmware.Sensors;
using System.Threading;

namespace MonoBrickHelloWorld
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Motor motor = new Motor (MotorPort.OutA);
			TankDriver tankDriver = new TankDriver (MotorPort.OutA, MotorPort.OutB);
			HeadSensor headSensor = new HeadSensor (MotorPort.OutD, SensorPort.In1); 
			tankDriver.rotateLeft (180);
			Thread.Sleep (500);
			tankDriver.rotateLeft (90);
		}
	}
}

