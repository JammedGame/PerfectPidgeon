using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;

namespace PerfectPidgeon.Draw
{
    public enum JoystickButton
    {
        Move,
        Shoot,
        WeaponBack,
        WeaponForth
    }
    public delegate void AxisEvent(double Angle);
    public delegate void ButtonPress(JoystickButton Button, bool Pressed);
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
        private List<JoystickButton> _Pressed;
        public event AxisEvent LeftAxisChange;
        public event AxisEvent RightAxisChange;
        public event ButtonPress JoystickButtonPress;
        public Joystick()
        {
            this._Joy = OpenTK.Input.Joystick.GetState(0);
            this.LeftAxisChange = new AxisEvent(this.OnLeftChange);
            this.RightAxisChange = new AxisEvent(this.OnRightChange);
            this.JoystickButtonPress = new ButtonPress(this.OnButtonPress);
            this._Pressed = new List<JoystickButton>();
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
            ButtonPressCheck();
        }
        private AxisState GetLeftAxis()
        {
            this._Joy = OpenTK.Input.Joystick.GetState(0);
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
            this._Joy = OpenTK.Input.Joystick.GetState(0);
            AxisState State = new AxisState();
            if (Math.Abs(this._Joy.GetAxis(OpenTK.Input.JoystickAxis.Axis3)) > 0.004 || Math.Abs(this._Joy.GetAxis(OpenTK.Input.JoystickAxis.Axis2)) > 0.004)
            {
                State.Status = AxisStateStatus.Angle;
                State.Angle = -(Math.Atan2(this._Joy.GetAxis(OpenTK.Input.JoystickAxis.Axis3), this._Joy.GetAxis(OpenTK.Input.JoystickAxis.Axis2)) * (360 / (Math.PI * 2)) - 180);
            }
            else State.Status = AxisStateStatus.None;
            return State;
        }
        private void ButtonPressCheck()
        {
            this._Joy = OpenTK.Input.Joystick.GetState(0);
            if (this._Joy.IsButtonDown(OpenTK.Input.JoystickButton.Button7))
            {
                if (!this._Pressed.Contains(JoystickButton.Move))
                {
                    this._Pressed.Add(JoystickButton.Move);
                    JoystickButtonPress.Invoke(JoystickButton.Move, true);
                }
            }
            else
            {
                if (this._Pressed.Contains(JoystickButton.Move))
                {
                    this._Pressed.Remove(JoystickButton.Move);
                    JoystickButtonPress.Invoke(JoystickButton.Move, false);
                }
            }
            if (this._Joy.IsButtonDown(OpenTK.Input.JoystickButton.Button5))
            {
                if (!this._Pressed.Contains(JoystickButton.Shoot))
                {
                    this._Pressed.Add(JoystickButton.Shoot);
                    JoystickButtonPress.Invoke(JoystickButton.Shoot, true);
                }
            }
            else
            {
                if (this._Pressed.Contains(JoystickButton.Shoot))
                {
                    this._Pressed.Remove(JoystickButton.Shoot);
                    JoystickButtonPress.Invoke(JoystickButton.Shoot, false);
                }
            }
        }
        private void OnLeftChange(double Angle)
        {

        }
        private void OnRightChange(double Angle)
        {

        }
        private void OnButtonPress(JoystickButton Button, bool Pressed)
        {

        }
    }
    
}
