using System;
using SplashKitSDK;
using System.IO;

namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        private float _endX, _endY;
        public MyLine() : this(Color.Red, 0, 0, 100, 0)
        { }

        public MyLine(Color color, float x, float y, float endX, float endY) : base(color)
        {
            X = x;
            Y = y;
            EndX = endX;
            EndY = endY;
        }

        public float EndX
        {
            get
            {
                return _endX;
            }
            set { _endX = value; }
        }
        public float EndY
        {
            get { return _endY; }
            set { _endY = value; }
        }
        public override void Draw()
        {
            if (Selected)
                DrawOutline();
            SplashKit.DrawLine(_color, X, Y, X + EndX, Y + EndY);
        }
        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color.Black, X, Y, 5);
            SplashKit.DrawCircle(Color.Black, X + EndX, Y + EndY, 5);
        }
        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointOnLine(pt, SplashKit.LineFrom(X, Y, X + EndX, Y + EndY));
        }
        public override void SaveTo(StreamWriter writer)
        {
            base.SaveTo(writer);
            writer.WriteLine("Line");
            writer.WriteLine(EndX);
            writer.WriteLine(EndY);
        }
        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            EndX = reader.ReadSingle();
            EndY = reader.ReadSingle();
        }
    }
}

