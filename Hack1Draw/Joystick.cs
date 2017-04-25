using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;

namespace PerfectPidgeon.Draw
{
    public delegate void AxisEvent(double Angle);
    public delegate void ButtonPress();
    public class Joystick
    {
        private enum AxisStateStatus
        {
            Angle,
            None
        }
        private struct AxisState
        {
            public AxisStateStatus Status;
            public double Angle;
        }
        private OpenTK.Input.JoystickState _Joy;
        private System.Timers.Timer _Time;
        public event AxisEvent LeftAxisChange;
        public event AxisEvent RightAxisChange;
        public Joystick()
        {
            this._Joy = OpenTK.Input.Joystick.GetState(0);
            this.LeftAxisChange = new AxisEvent(this.OnLeftChange);
            this.RightAxisChange = new AxisEvent(this.OnRightChange);
            this._Time = new System.Timers.Timer(10);
            this._Time.Elapsed += new System.Timers.ElapsedEventHandler(this.TimerTick);
            this._Time.Start();
        }
        private void TimerTick(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!_Joy.IsConnected) return;
            AxisState Left = this.GetLeftAxis();
            if (Left.Status == AxisStateStatus.Angle)
            {
                LeftAxisChange.Invoke(Left.Angle);
            }
            AxisState Right = this.GetRightAxis();
            if (Right.Status == AxisStateStatus.Angle)
            {
                RightAxisChange.Invoke(Right.Angle);
            }
        }
        private AxisState GetLeftAxis()
        {
            AxisState State = new AxisState();
            if (Math.Abs(this._Joy.GetAxis(OpenTK.Input.JoystickAxis.Axis1)) > 0.004 || Math.Abs(this._Joy.GetAxis(OpenTK.Input.JoystickAxis.Axis0)) > 0.004)
            {
                State.Status = AxisStateStatus.Angle;
                State.Angle = (Math.Atan2(this._Joy.GetAxis(OpenTK.Input.JoystickAxis.Axis1), this._Joy.GetAxis(OpenTK.Input.JoystickAxis.Axis0)) * (360 / (Math.PI * 2)) + 90);
            }
            else State.Status = AxisStateStatus.None;
            return State;
        }
        private AxisState GetRightAxis()
        {
            AxisState State = new AxisState();
            if (Math.Abs(this._Joy.GetAxis(OpenTK.Input.JoystickAxis.Axis3)) > 0.004 || Math.Abs(this._Joy.GetAxis(OpenTK.Input.JoystickAxis.Axis2)) > 0.004)
            {
                State.Status = AxisStateStatus.Angle;
                State.Angle = -(Math.Atan2(this._Joy.GetAxis(OpenTK.Input.JoystickAxis.Axis3), this._Joy.GetAxis(OpenTK.Input.JoystickAxis.Axis2)) * (360 / (Math.PI * 2)) - 180);
            }
            else State.Status = AxisStateStatus.None;
            return State;
        }
        private void OnLeftChange(double Angle)
        {

        }
        private void OnRightChange(double Angle)
        {

        }
    }
    
}
