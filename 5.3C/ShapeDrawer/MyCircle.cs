using System;
using SplashKitSDK;
using System.IO;

namespace ShapeDrawer
{
    public class MyCircle : Shape
    {
        public MyCircle() : this(Color.Blue, 50)
        { }
        private int _radius;

        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }
        public MyCircle(Color color, int radius) : base(color)
        {
            _radius = radius;
        }
        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.FillCircle(_color, X, Y, _radius);


        }
        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color.Black, X, Y, _radius + 2);

        }
        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointInCircle(pt, SplashKit.CircleAt(X, Y, _radius));
        }

        public override void SaveTo(StreamWriter writer)
        {
            base.SaveTo(writer);
            writer.WriteLine("Circle");
            writer.WriteLine(Radius);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Radius = reader.ReadInteger();
        }
    }
}
