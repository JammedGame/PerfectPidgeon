using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using OpenTK.Input;

namespace PerfectPidgeon.Draw
{
    public enum SelectedController
    {
        KeyboardAndMouse,
        LeapMotion,
        Gamepad1,
        Gamepad2,
        Gamepad3,
        Gamepad4
    }
    public class ControlSetup
    {
        public SelectedController Controller;
        public Key GunRotateLeft = Key.Q;
        public Key GunRotateRight = Key.E;
        public Key GunTurnLeft = Key.A;
        public Key GunTurnRight = Key.D;
        public Key GunTurnFront = Key.W;
        public Key GunTurnBack = Key.W;
    }
    public class Settings
    {
        public static class Graphics
        {
            public static bool Fullscreen;
            public static Point Resolution;
        }
        public static class Audio
        {
            public static int Volume;
        }
        public static class Controls
        {
            public static ControlSetup Setup1;
            public static ControlSetup Setup2;
        }
    }
}
