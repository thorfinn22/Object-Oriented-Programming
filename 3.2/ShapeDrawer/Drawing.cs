using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace ShapeDrawer
{
	public class Drawing
	{
		private readonly List<Shape> _shapes;

		private Color _background;
    
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
			foreach(Shape shape in _shapes)
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
				foreach(Shape shape in _shapes)
				{
					if (shape.Selected)
						result.Add(shape);
				}
				return result; 
			}
		}

		public void RemoveShape(Shape shape)
		{
			_shapes.Remove(shape);
		}
	}
}

