using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
//using Leap;

namespace PerfectPidgeon.Draw
{
    /* class PidgeonLeapListener : Listener
     {
         public bool Connected = false;
         public bool Left = false;
         public bool Right = false;
         public bool RightCollected = false;
         public bool LeftCollected = false;
         public Point LeftHandLocation;
         public Point RightHandLocation;
         private Object thisLock = new Object();
         private void SafeWriteLine(String line)
         {
             lock (thisLock)
             {
                 Console.WriteLine(line);
             }
         }
         public override void OnConnect(Controller controller)
         {
             Connected = true;
         }
         public override void OnDisconnect(Controller arg0)
         {
             Connected = false;
         }
         private bool IsCollected(Hand Handy)
         {
             bool Value = true;
             for (int i = 0; i < Handy.Fingers.Count; i++) if (Handy.Fingers[0].IsExtended) Value = false;
             return Value;
         }
         public override void OnFrame(Controller controller)
         {
             Frame frame = controller.Frame();
             if (frame.Hands.Count > 1)
             {
                 Hand LeftHand = null;
                 Hand RightHand = null;
                 if (frame.Hands[0].IsLeft)
                 {
                     LeftHand = frame.Hands[0];
                     RightHand = frame.Hands[1];
                 }
                 else
                 {
                     RightHand = frame.Hands[0];
                     LeftHand = frame.Hands[1];
                 }
                 if (RightHand != null)
                 {
                     RightCollected = IsCollected(RightHand);
                     RightHandLocation = new Point((int)RightHand.WristPosition.x, (int)RightHand.WristPosition.y);
                     this.Right = true;
                 }
                 else this.Right = false;
                 if (LeftHand != null)
                 {
                     LeftCollected = IsCollected(LeftHand);
                     LeftHandLocation = new Point(-(int)LeftHand.WristPosition.x, (int)LeftHand.WristPosition.y);
                     this.Left = true;
                 }
                 else this.Left = false;
             }
             else if (frame.Hands.Count > 0)
             {
                 Hand LeftHand = null;
                 Hand RightHand = null;
                 if (frame.Hands[0].IsLeft) LeftHand = frame.Hands[0];
                 else RightHand = frame.Hands[0];
                 if (LeftHand != null)
                 {
                     LeftCollected = IsCollected(LeftHand);
                     LeftHandLocation = new Point((int)LeftHand.WristPosition.x, (int)LeftHand.WristPosition.y);
                     this.Left = true;
                 }
                 else this.Left = false;
                 if (RightHand != null)
                 {
                     RightCollected = IsCollected(RightHand);
                     RightHandLocation = new Point((int)RightHand.WristPosition.x, (int)RightHand.WristPosition.y);
                     this.Right = true;
                 }
                 else this.Right = false;
             }
         }
     }*/
}
