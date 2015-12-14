using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _1312077_MyPaint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int objectDraw = 1;
        int strokeThick = 1;        
        bool IsMouseDowned = false;
        Point startPoint;
        Brush brush = Brushes.Black;
        //Shape lastShape = null;
        Line lastLine;
        Rectangle lastRectangle;
        Ellipse lastEllipse;
        Shape lastShape = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void bt_line_Click(object sender, RoutedEventArgs e)
        {
            objectDraw = 1;
        }

        private void bt_ellipse_Click(object sender, RoutedEventArgs e)
        {
            objectDraw = 3;
        }

        private void bt_rectangle_Click(object sender, RoutedEventArgs e)
        {
            objectDraw = 2;
        }

        private void clean_bt_Click(object sender, RoutedEventArgs e)
        {
            canvasPaint.Children.Clear();
        }

        private void strokeThick_cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int t = strokeThick_cb.SelectedIndex;
            switch (t)
            {
                case 0:
                    strokeThick = 1;
                    break;
                case 1:
                    strokeThick = 2;
                    break;
                case 2:
                    strokeThick = 5;
                    break;
                case 3:
                    strokeThick = 10;
                    break;
            }
        }

        private void coloPick_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            brush = new SolidColorBrush((Color)coloPick.SelectedColor);
        }

        private Shape draw(int a,Point start, Point end)
        {
            Shape shapeDraw = null;
            switch (a)
            {
                case 1:
                    Line line = new Line();
                    line.Stroke = brush;
                    line.StrokeThickness = strokeThick;
                    
                    line.X1 = start.X;
                    line.Y1 = start.Y;
                    line.X2 = end.X;
                    line.Y2 = end.Y;
                    shapeDraw = line;
                    break;
                case 2:
                    Rectangle rectangle = new Rectangle();
                    rectangle.Stroke = brush;
                    rectangle.StrokeThickness = strokeThick;
                    if (Keyboard.IsKeyDown(Key.LeftShift))
                    {                        
                        Point tP = changePoint(start, end);
                        rectangle.SetValue(Canvas.LeftProperty, tP.X);
                        rectangle.SetValue(Canvas.TopProperty, tP.Y);
                        rectangle.Width = rectangle.Height = Math.Min(Math.Abs(start.X - end.X), Math.Abs(start.Y - end.Y));
                    }
                    else
                    {
                        rectangle.SetValue(Canvas.LeftProperty, Math.Min(end.X, start.X));
                        rectangle.SetValue(Canvas.TopProperty, Math.Min(end.Y, start.Y));
                        rectangle.Width = Math.Abs(start.X - end.X);
                        rectangle.Height = Math.Abs(start.Y - end.Y);
                    }                    
                    shapeDraw = rectangle;
                    break;
                case 3:
                    Ellipse elip = new Ellipse();
                    elip.Stroke = brush;
                    elip.StrokeThickness = strokeThick;
                    if (Keyboard.IsKeyDown(Key.LeftShift))
                    {
                        Point tP = changePoint(start, end);
                        elip.SetValue(Canvas.LeftProperty, tP.X);
                        elip.SetValue(Canvas.TopProperty, tP.Y);
                        elip.Width = elip.Height = Math.Min(Math.Abs(start.X - end.X), Math.Abs(start.Y - end.Y));
                    }
                    else
                    {
                        elip.SetValue(Canvas.LeftProperty, Math.Min(end.X, start.X));
                        elip.SetValue(Canvas.TopProperty, Math.Min(end.Y, start.Y));
                        elip.Width = Math.Abs(start.X - end.X);
                        elip.Height = Math.Abs(start.Y - end.Y);
                    }                    
                    shapeDraw = elip;
                    break;
                default:
                    break;
            }
            return shapeDraw;
        }

        private void canvasPaint_MouseDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(canvasPaint);
            IsMouseDowned = true;
        }
        
        private Point changePoint(Point start, Point end)
        {
            Point target = new Point();
            double t = Math.Min(Math.Abs(start.X - end.X), Math.Abs(start.Y - end.Y));
            if (end.Y < start.Y)
            {
                if (end.X > start.X)
                {                    
                    target.X = start.X;
                }
                else
                {                    
                    target.X = Math.Abs(t - start.X);
                }
                target.Y = Math.Abs(t - start.Y);
            }
            else
            {
                if (end.X < start.X)
                {                   
                    target.X = Math.Abs(start.X - t);                   
                    target.Y = start.Y;
                }
                else
                {                    
                    target.X = Math.Min(end.X, start.X);                 
                    target.Y = Math.Min(end.Y, start.Y);
                }
            }
            return target;
        }
        private void canvasPaint_MouseMove(object sender, MouseEventArgs e)
        {
            PositionCanvas.Content = "X= " + e.GetPosition(canvasPaint).X + "\n" + "Y= " + e.GetPosition(canvasPaint).Y;
            if (IsMouseDowned)
                //{
                //    Point endPoint = e.GetPosition((IInputElement)sender);
                //    if (objectDraw == 1)
                //    {
                //        bool addLine = false;
                //        if (lastLine == null)
                //        {
                //            lastLine = new Line();
                //            addLine = true;
                //        }
                //        lastLine.Stroke = brush;
                //        lastLine.StrokeThickness = strokeThick;
                //        lastLine.StrokeDashArray = new DoubleCollection() { 2 };
                //        lastLine.X1 = startPoint.X;
                //        lastLine.Y1 = startPoint.Y;
                //        lastLine.X2 = endPoint.X;
                //        lastLine.Y2 = endPoint.Y;
                //        if (addLine)
                //            canvasPaint.Children.Add(lastLine);
                //    }

                //    if (objectDraw == 2)
                //    {
                //        bool addRectangle = false;
                //        if (lastRectangle == null)
                //        {
                //            lastRectangle = new Rectangle();
                //            addRectangle = true;
                //        }

                //        lastRectangle.Stroke = brush;
                //        lastRectangle.StrokeThickness = strokeThick;
                //        if (Keyboard.IsKeyDown(Key.LeftShift))
                //        {
                //            Point te = changePoint(startPoint, endPoint);
                //            lastRectangle.SetValue(Canvas.LeftProperty, te.X);
                //            lastRectangle.SetValue(Canvas.TopProperty, te.Y);
                //            lastRectangle.Height = lastRectangle.Width = Math.Min(Math.Abs(startPoint.X - endPoint.X), Math.Abs(startPoint.Y - endPoint.Y));
                //        }
                //        else
                //        {
                //            lastRectangle.SetValue(Canvas.LeftProperty, Math.Min(endPoint.X, startPoint.X));
                //            lastRectangle.SetValue(Canvas.TopProperty, Math.Min(endPoint.Y, startPoint.Y));
                //            lastRectangle.Height = Math.Abs(startPoint.Y - endPoint.Y);
                //            lastRectangle.Width = Math.Abs(startPoint.X - endPoint.X);
                //        }
                //        if (addRectangle)
                //            canvasPaint.Children.Add(lastRectangle);
                //    }

                //    if (objectDraw == 3)
                //    {
                //        bool addEllipse = false;
                //        if (lastEllipse == null)
                //        {
                //            lastEllipse = new Ellipse();
                //            addEllipse = true;
                //        }

                //        lastEllipse.Stroke = brush;
                //        lastEllipse.StrokeThickness = strokeThick;
                //        double t = Math.Min(Math.Abs(startPoint.X - endPoint.X), Math.Abs(startPoint.Y - endPoint.Y));
                //        if (Keyboard.IsKeyDown(Key.LeftShift))
                //        {
                //            Point te = changePoint(startPoint, endPoint);                        
                //            lastEllipse.SetValue(Canvas.LeftProperty, te.X);
                //            lastEllipse.SetValue(Canvas.TopProperty, te.Y);
                //            lastEllipse.Height = lastEllipse.Width = t;
                //        }
                //        else
                //        {
                //            lastEllipse.SetValue(Canvas.LeftProperty, Math.Min(endPoint.X, startPoint.X));
                //            lastEllipse.SetValue(Canvas.TopProperty, Math.Min(endPoint.Y, startPoint.Y));
                //            lastEllipse.Width = Math.Abs(startPoint.X - endPoint.X);
                //            lastEllipse.Height = Math.Abs(startPoint.Y - endPoint.Y);
                //        }                    
                //        if (addEllipse)
                //            canvasPaint.Children.Add(lastEllipse);
                //    }
                //}

                /*Khi vẽ Line hoặc Rectangle không hiểu sao khi ké thả quá lâu thì nhả chuột ra vẫn kô vẽ được vẫn thực hiện sự kiện MouseMove*/
                if (IsMouseDowned)
                {
                    Point endPoint = e.GetPosition((IInputElement)sender);
                    if (lastShape != null)
                        canvasPaint.Children.Remove(lastShape);
                    lastShape = draw(objectDraw, startPoint, endPoint);                    
                    canvasPaint.Children.Add(lastShape);
                }
        }

        private void canvasPaint_MouseUp(object sender, MouseButtonEventArgs e)
        {
            IsMouseDowned = false;
            Point endPoint = e.GetPosition((IInputElement)sender);
            Shape shapeDraw = draw(objectDraw, startPoint, endPoint);
            MessageBox.Show(shapeDraw.Name);
            canvasPaint.Children.Add(shapeDraw);
            lastLine = null;
            lastRectangle = null;
            lastEllipse = null;           
        }

        private bool IsKeyPressed = false;
        private void canvasPaint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftShift)
                IsKeyPressed = true;
        }

        private void canvasPaint_KeyUp(object sender, KeyEventArgs e)
        {
            IsKeyPressed = false;
        }
    }
}
