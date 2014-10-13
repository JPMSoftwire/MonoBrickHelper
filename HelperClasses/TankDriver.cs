
using System;
using MonoBrickFirmware;
using MonoBrickFirmware.Display.Dialogs;
using MonoBrickFirmware.Display;
using MonoBrickFirmware.Movement;
using System.Threading;

namespace MonoBrickHelloWorld
{
	public class TankDriver
	{
		private Motor leftMotor;
		private Motor rightMotor;
		public TankDriver(MotorPort leftMotorPort, MotorPort rightMotorPort)
		{
			leftMotor = new Motor (leftMotorPort);
			rightMotor = new Motor (rightMotorPort);
		}

		private void brakeMotors ()
		{
			leftMotor.Brake ();
			rightMotor.Brake ();
		}

		public void rotateLeft(int degrees)
		{
			leftMotor.SetSpeed (-100);
			rightMotor.SetSpeed (100);
			Thread.Sleep (degrees * 9);
			brakeMotors ();

		}

		public void Stop()
		{
			leftMotor.Off ();
			rightMotor.Off ();
		}

	}

}

