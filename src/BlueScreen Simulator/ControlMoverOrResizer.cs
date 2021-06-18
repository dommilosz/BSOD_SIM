using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ControlManager
{
    internal class ControlMoverOrResizer
    {
        private static bool _moving;
        private static Point _cursorStartPoint;
        private static bool _moveIsInterNal;
        private static bool _enabled = false;
        private static bool _resizing;
        private static Size _currentControlStartSize;
        public static Size minSize = new Size(25, 25);
        internal static bool MouseIsInLeftEdge { get; set; }
        internal static bool MouseIsInRightEdge { get; set; }
        internal static bool MouseIsInTopEdge { get; set; }
        internal static bool MouseIsInBottomEdge { get; set; }

        internal enum MoveOrResize
        {
            Move,
            Resize,
            MoveAndResize
        }

        internal static MoveOrResize WorkType { get; set; }

        internal static void Init(Control control)
        {
            Init(control, control);
        }
        internal static void Unload(Control control)
        {
            Unload(control, control);
        }
        internal static void DrawFrames(Control c)
        {
            Form f = c.FindForm();
            Graphics g = f.CreateGraphics();
            g.Clear(f.BackColor);
            g.DrawRectangle(Pens.Red, c.Location.X - 1, c.Location.Y - 1, c.Size.Width, c.Size.Height);
            g.DrawRectangle(Pens.Red, c.Location.X, c.Location.Y, c.Size.Width, c.Size.Height);
        }
        internal static void Init(Control control, Control container)
        {
            _moving = false;
            _resizing = false;
            _moveIsInterNal = false;
            _cursorStartPoint = Point.Empty;
            MouseIsInLeftEdge = false;
            MouseIsInLeftEdge = false;
            MouseIsInRightEdge = false;
            MouseIsInTopEdge = false;
            MouseIsInBottomEdge = false;
            WorkType = MoveOrResize.MoveAndResize;
            DrawFrames(control);
            control.MouseDown += (sender, e) => StartMovingOrResizing(control, e);
            control.MouseUp += (sender, e) => StopDragOrResizing(control);
            control.MouseMove += (sender, e) => MoveControl(container, e);
            _enabled = true;
        }
        internal static void Unload(Control control, Control container)
        {
            _moving = false;
            _resizing = false;
            _moveIsInterNal = false;
            _cursorStartPoint = Point.Empty;
            MouseIsInLeftEdge = false;
            MouseIsInLeftEdge = false;
            MouseIsInRightEdge = false;
            MouseIsInTopEdge = false;
            MouseIsInBottomEdge = false;
            WorkType = MoveOrResize.MoveAndResize;
            control.RemoveEvents("Event" + nameof(control.MouseDown));
            control.RemoveEvents("Event" + nameof(control.MouseUp));
            control.RemoveEvents("Event" + nameof(control.MouseMove));
            _enabled = false;
        }

        private static void UpdateMouseEdgeProperties(Control control, Point mouseLocationInControl)
        {
            if (WorkType == MoveOrResize.Move)
            {
                return;
            }
            MouseIsInLeftEdge = Math.Abs(mouseLocationInControl.X) <= 5;
            MouseIsInRightEdge = Math.Abs(mouseLocationInControl.X - control.Width) <= 5;
            MouseIsInTopEdge = Math.Abs(mouseLocationInControl.Y) <= 5;
            MouseIsInBottomEdge = Math.Abs(mouseLocationInControl.Y - control.Height) <= 10;
        }

        private static void UpdateMouseCursor(Control control)
        {
            if (WorkType == MoveOrResize.Move)
            {
                return;
            }
            if (MouseIsInLeftEdge)
            {
                if (MouseIsInTopEdge)
                {
                    control.Cursor = Cursors.SizeNWSE;
                }
                else if (MouseIsInBottomEdge)
                {
                    control.Cursor = Cursors.SizeNESW;
                }
                else
                {
                    control.Cursor = Cursors.SizeWE;
                }
            }
            else if (MouseIsInRightEdge)
            {
                if (MouseIsInTopEdge)
                {
                    control.Cursor = Cursors.SizeNESW;
                }
                else if (MouseIsInBottomEdge)
                {
                    control.Cursor = Cursors.SizeNWSE;
                }
                else
                {
                    control.Cursor = Cursors.SizeWE;
                }
            }
            else if (MouseIsInTopEdge || MouseIsInBottomEdge)
            {
                control.Cursor = Cursors.SizeNS;
            }
            else
            {
                control.Cursor = Cursors.Default;
            }
        }

        private static void StartMovingOrResizing(Control control, MouseEventArgs e)
        {
            if (_moving || _resizing || !_enabled)
            {
                return;
            }
            if (WorkType != MoveOrResize.Move &&
                (MouseIsInRightEdge || MouseIsInLeftEdge || MouseIsInTopEdge || MouseIsInBottomEdge))
            {
                _resizing = true;
                _currentControlStartSize = control.Size;
            }
            else if (WorkType != MoveOrResize.Resize)
            {
                _moving = true;
                control.Cursor = Cursors.Hand;
            }
            _cursorStartPoint = new Point(e.X, e.Y);
            control.Capture = true;
        }

        private static void MoveControl(Control control, MouseEventArgs e)
        {
            if (!_enabled) return;
            BlueScreen_Simulator.BSODData.form.UpdateSelectedControl();
            DrawFrames(control);
            if (!_resizing && !_moving)
            {
                UpdateMouseEdgeProperties(control, new Point(e.X, e.Y));
                UpdateMouseCursor(control);
            }
            if (_resizing)
            {
                if (MouseIsInLeftEdge)
                {
                    if (MouseIsInTopEdge)
                    {
                        control.Width -= (e.X - _cursorStartPoint.X);
                        control.Left += (e.X - _cursorStartPoint.X);
                        control.Height -= (e.Y - _cursorStartPoint.Y);
                        control.Top += (e.Y - _cursorStartPoint.Y);
                    }
                    else if (MouseIsInBottomEdge)
                    {
                        control.Width -= (e.X - _cursorStartPoint.X);
                        control.Left += (e.X - _cursorStartPoint.X);
                        control.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;
                    }
                    else
                    {
                        control.Width -= (e.X - _cursorStartPoint.X);
                        control.Left += (e.X - _cursorStartPoint.X);
                    }
                }
                else if (MouseIsInRightEdge)
                {
                    if (MouseIsInTopEdge)
                    {
                        control.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                        control.Height -= (e.Y - _cursorStartPoint.Y);
                        control.Top += (e.Y - _cursorStartPoint.Y);

                    }
                    else if (MouseIsInBottomEdge)
                    {
                        control.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                        control.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;
                    }
                    else
                    {
                        control.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                    }
                }
                else if (MouseIsInTopEdge)
                {
                    control.Height -= (e.Y - _cursorStartPoint.Y);
                    control.Top += (e.Y - _cursorStartPoint.Y);
                }
                else if (MouseIsInBottomEdge)
                {
                    control.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;
                }
                else
                {
                    StopDragOrResizing(control);
                }
            }
            else if (_moving)
            {
                _moveIsInterNal = !_moveIsInterNal;
                if (!_moveIsInterNal)
                {
                    int x = (e.X - _cursorStartPoint.X) + control.Left;
                    int y = (e.Y - _cursorStartPoint.Y) + control.Top;
                    control.Location = new Point(x, y);
                }
            }

            if (control.Size.Width < minSize.Width || control.Size.Height < minSize.Height)
            {
                var width = Math.Max(minSize.Width, control.Size.Width);
                var height = Math.Max(minSize.Height, control.Size.Height);
                control.Size = new Size(width, height);
            }
        }

        private static void StopDragOrResizing(Control control)
        {
            _resizing = false;
            _moving = false;
            control.Capture = false;
            UpdateMouseCursor(control);
            BlueScreen_Simulator.BSODData.SaveTransformEntry(control);
        }

        #region Save And Load

        private static List<Control> GetAllChildControls(Control control, List<Control> list)
        {
            List<Control> controls = control.Controls.Cast<Control>().ToList();
            list.AddRange(controls);
            return controls.SelectMany(ctrl => GetAllChildControls(ctrl, list)).ToList();
        }

        internal static string GetSizeAndPositionOfControlsToString(Control container)
        {
            List<Control> controls = new List<Control>();
            GetAllChildControls(container, controls);
            CultureInfo cultureInfo = new CultureInfo("en");
            string info = string.Empty;
            foreach (Control control in controls)
            {
                info += control.Name + ":" + control.Left.ToString(cultureInfo) + "," + control.Top.ToString(cultureInfo) + "," +
                        control.Width.ToString(cultureInfo) + "," + control.Height.ToString(cultureInfo) + "*";
            }
            return info;
        }
        internal static void SetSizeAndPositionOfControlsFromString(Control container, string controlsInfoStr)
        {
            List<Control> controls = new List<Control>();
            GetAllChildControls(container, controls);
            string[] controlsInfo = controlsInfoStr.Split(new[] { "*" }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, string> controlsInfoDictionary = new Dictionary<string, string>();
            foreach (string controlInfo in controlsInfo)
            {
                string[] info = controlInfo.Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                controlsInfoDictionary.Add(info[0], info[1]);
            }
            foreach (Control control in controls)
            {
                string propertiesStr;
                controlsInfoDictionary.TryGetValue(control.Name, out propertiesStr);
                string[] properties = propertiesStr.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                if (properties.Length == 4)
                {
                    control.Left = int.Parse(properties[0]);
                    control.Top = int.Parse(properties[1]);
                    control.Width = int.Parse(properties[2]);
                    control.Height = int.Parse(properties[3]);
                }
            }
        }

        #endregion
    }
    public static class EventExtension
    {
        public static void RemoveEvents<T>(this T target, string eventName) where T : Control
        {
            if (ReferenceEquals(target, null)) throw new NullReferenceException("Argument \"target\" may not be null.");
            FieldInfo fieldInfo = typeof(Control).GetField(eventName, BindingFlags.Static | BindingFlags.NonPublic);
            if (ReferenceEquals(fieldInfo, null)) throw new ArgumentException(
                string.Concat("The control ", typeof(T).Name, " does not have a property with the name \"", eventName, "\""), nameof(eventName));
            object eventInstance = fieldInfo.GetValue(target);
            PropertyInfo propInfo = typeof(T).GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
            EventHandlerList list = (EventHandlerList)propInfo.GetValue(target, null);
            list.RemoveHandler(eventInstance, list[eventInstance]);
        }
    }
}