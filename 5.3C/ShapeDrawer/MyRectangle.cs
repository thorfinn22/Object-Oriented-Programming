using System;
using SplashKitSDK;
using System.IO;

namespace ShapeDrawer
{
    public class MyRectangle : Shape
    {
        private int _width, _height;

        public MyRectangle() : this(Color.Green, 0, 0, 100, 100) { }

        public MyRectangle(Color color, float x, float y, int width, int height) : base(color)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set
            {
                _height = value;

            }
        }
        public override void Draw()
        {

            if (Selected)
                DrawOutline();
            SplashKit.FillRectangle(_color, X, Y, _width, _height);

        }

        public override bool IsAt(Point2D pt)
        {
            if (((pt.X > X) && (pt.X < X + _width)) && ((pt.Y > Y) && (pt.Y < Y + _height)))
            {
                return true;
            }
            else { return false; }
        }

        public override void DrawOutline()
        {

            SplashKit.DrawRectangle(Color.Black, X - 2, Y - 2, _width + 4, _height + 4);

        }
        public override void SaveTo(StreamWriter writer)
        {
            base.SaveTo(writer);
            writer.WriteLine("Rectangle");
            writer.WriteLine(Width);
            writer.WriteLine(Height);
        }
        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Width = reader.ReadInteger();
            Height = reader.ReadInteger();
        }
    }
}

