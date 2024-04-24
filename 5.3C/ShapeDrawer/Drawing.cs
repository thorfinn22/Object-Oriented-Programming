using System;
using System.Collections.Generic;
using SplashKitSDK;
using System.IO;

namespace ShapeDrawer
{
    public class Drawing
    {
        private readonly List<Shape> _shapes;

        private Color _background;
        StreamWriter writer;
        StreamReader reader;

        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }

        public Drawing() : this(Color.White)
        { }

        public int ShapeCount
        {
            get { return _shapes.Count; }
        }

        public Color Background
        {
            get { return _background; }
            set { _background = value; }
        }

        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        public void Draw()
        {
            SplashKit.ClearScreen(_background);

            foreach (Shape shape in _shapes)
            {
                shape.Draw();
            }
        }

        public void SelectShapesAt(Point2D pt)
        {
            foreach (Shape shape in _shapes)
            {
                if (shape.IsAt(pt))
                    shape.Selected = true;
                else shape.Selected = false;
            }
        }

        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result = new List<Shape>();
                foreach (Shape shape in _shapes)

                    if (shape.Selected)
                        result.Add(shape);

                return result;
            }
        }

        public void RemoveShape(Shape shape)
        {
            _shapes.Remove(shape);
        }
        public void Save(string filename)
        {
            writer = new StreamWriter(filename);
            writer.WriteColor(_background);
            writer.WriteLine(ShapeCount);

            foreach(Shape shape in _shapes)
            {
                shape.SaveTo(writer);
            }
            writer.Close();
        }
        public void Load(string filename)
        {
            reader = new StreamReader(filename);
            Shape shape;
            string kind;
            Background = reader.ReadColor();
            int count = reader.ReadInteger();
            _shapes.Clear();

            for(int i = 0; i<count; i++)
            {
                kind = reader.ReadLine();
                switch (kind)
                {
                    case "Rectangle":
                        shape = new MyRectangle();
                        break;
                    case "Circle":
                        shape = new MyCircle();
                        break;
                    case "Line":
                        shape = new MyLine();
                        break;
                    default:
                        throw new InvalidDataException("Error at shape: " + kind);

                }
                shape.LoadFrom(reader);
                AddShape(shape);
            }
            reader.Close();
        }
    }
}

