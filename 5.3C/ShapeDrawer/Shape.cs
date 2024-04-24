using System;
using SplashKitSDK;
using System.IO;

namespace ShapeDrawer

{
    public abstract class Shape
    {
        public Color _color;
        private float _x, _y;
        private int _width, _height;
        private bool _selected;

        public Shape(Color color)
        {
            _color = color;
            _x = 0;
            _y = 0;
            _width = 100; _height = 100;
            _selected = false;
        }

        public Color color
        {
            get { return _color; }
            set { _color = value; }

        }

        public float X
        {

            get { return _x; }
            set { _x = value; }

        }

        public float Y
        {
            get { return _y; }
            set
            {
                _y = value;

            }
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

        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
            }
        }

        public abstract void Draw();


        public abstract bool IsAt(Point2D pt);
      

        public abstract void DrawOutline();
       
        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteColor(_color);
            writer.WriteLine(X);
            writer.WriteLine(Y);
        }
        public virtual void LoadFrom(StreamReader reader)
        {
            color = reader.ReadColor();
            X = reader.ReadInteger();
            Y = reader.ReadInteger();
        }

        
    }
}


