using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
 
            new Window("Shape Drawer", 800, 600);

            Drawing drawing = new Drawing();

            do
            {
                SplashKit.ProcessEvents();
                drawing.Draw();
                Shape newShape = new Shape();
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    
                    newShape.X = SplashKit.MouseX();
                    newShape.Y = SplashKit.MouseY();
                    drawing.AddShape(newShape);
                }
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    drawing.Background = SplashKit.RandomColor();
                }
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    drawing.SelectShapesAt(SplashKit.MousePosition());
                }

                if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    foreach (Shape shape in drawing.SelectedShapes)
                    {
                        drawing.RemoveShape(shape);
                    }
                        
                }
                
                SplashKit.RefreshScreen();
            }
            while (!SplashKit.WindowCloseRequested("Shape Drawer"));
        }
    }
}
