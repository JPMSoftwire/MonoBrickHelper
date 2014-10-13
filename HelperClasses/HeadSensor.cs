
using System;
using MonoBrickFirmware;
using MonoBrickFirmware.Display.Dialogs;
using MonoBrickFirmware.Display;
using MonoBrickFirmware.Movement;
using MonoBrickFirmware.Sensors;
using System.Threading;

namespace MonoBrickHelper
{
	public class HeadSensor
	{
		private EV3IRSensor distanceSensor;
		private Motor headMotor;
		public HeadSensor(MotorPort headMotorPort, SensorPort sensorPort)
		{
			headMotor = new Motor(headMotorPort);
			distanceSensor = new EV3IRSensor (sensorPort);
			headMotor.ResetTacho ();
		}
		public int headPosition {
			get {
				return headMotor.GetTachoCount ();
			}
		}

		public void turnLeft()
		{
			if (headPosition < -90) {
				return;
			}
			headMotor.SetPower (-50);
			while (headPosition > -90) {
			}
			headMotor.Brake ();
		}

		public void turnRight()
		{
			if (headPosition > 90) {
				return;
			}
			headMotor.SetPower (50);
			while (headPosition < 85) {
			}
			headMotor.Brake ();
		}

		public void turnForward()
		{
			if(headPosition < 0)
			{
				headMotor.SetPower (50);
				while(headPosition<0){
				}
				headMotor.Brake();
			} else if(headPosition > 0)
			{
				headMotor.SetPower(-50);
				while(headPosition>0){
				}
				headMotor.Brake();
			}
		}

		private void turnPosition(int positionInDegrees)
		{
			if (headPosition < positionInDegrees) {
				headMotor.SetPower (50);
				while (headPosition < positionInDegrees) {
					Thread.Sleep (1);
				}
				headMotor.Brake ();
			} else if (headPosition > positionInDegrees) {
				headMotor.SetPower (-50);
				while (headPosition > positionInDegrees) {
					Thread.Sleep (1);
				}
				headMotor.Brake ();
			}
		}


		public int getLeftDistance()
		{
			turnLeft ();
			return distanceSensor.ReadDistance ();
		}

		public int getRightDistance()
		{
			turnRight ();
			return distanceSensor.ReadDistance ();
		}

		public int getForwardDistance()
		{
			turnForward ();
			return distanceSensor.ReadDistance ();
		}

		public int getPositionDistance(int positionInDegrees)
		{
			turnPosition (positionInDegrees);
			return distanceSensor.ReadDistance ();
		}

		public void off()
		{
			headMotor.Off ();
		}
	}

}

