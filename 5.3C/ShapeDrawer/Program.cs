using System;
using System.Drawing;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }
        public static void Main()
        {

            ShapeKind kindToAdd = ShapeKind.Circle;
            Drawing drawing = new Drawing();

            new Window("Shape Drawer", 800, 600);


            do
            {
                SplashKit.ProcessEvents();
                drawing.Draw();

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;
                    if (kindToAdd == ShapeKind.Rectangle)
                    {
                        MyRectangle newRect = new MyRectangle();

                        newShape = newRect;
                    }
                    else if (kindToAdd == ShapeKind.Circle)
                    {

                        MyCircle newCircle = new MyCircle();

                        newShape = newCircle;

                    }
                    else
                    {
                        MyLine newLine = new MyLine();

                        newShape = newLine;
                    }
                    newShape.X = SplashKit.MouseX();
                    newShape.Y = SplashKit.MouseY();
                    drawing.AddShape(newShape);

                }
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    drawing.SelectShapesAt(SplashKit.MousePosition());
                }
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    drawing.Background = SplashKit.RandomColor();
                }
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    drawing.SelectShapesAt(SplashKit.MousePosition());
                }

                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }

                if (SplashKit.KeyTyped(KeyCode.CKey))
                {

                    kindToAdd = ShapeKind.Circle;
                }

                if (SplashKit.KeyTyped(KeyCode.LKey))
                { 

                    kindToAdd = ShapeKind.Line;
                }

                if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {

                    foreach (Shape shape in drawing.SelectedShapes)
                    {
                        drawing.RemoveShape(shape);
                    }
                }
                if (SplashKit.KeyTyped(KeyCode.SKey))
                {
                    drawing.Save("/Users/hareemon/Desktop/TestDrawing.txt");
                }

                if (SplashKit.KeyTyped(KeyCode.OKey))
                {
                    try
                    {
                        drawing.Load("/Users/hareemon/Desktop/TestDrawing.txt");
                    }
                    catch(Exception e)
                    {
                        Console.Error.WriteLine("Error loading file: {0}", e.Message);
                    }
                }

                SplashKit.RefreshScreen();
            }
            while (!SplashKit.WindowCloseRequested("Shape Drawer"));
        }
    }
}
