using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ForTrain
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender">объект</param>
    public delegate void Selected(object sender);//выделение обьекта

    /// <summary>
    ////Структура плоскости
    /// </summary>
    [Serializable]
    public struct layer
    {
        /// <summary>
        /// Срабатывает при смене активной плоскости проектирования (прорисовки)
        /// </summary>
        /// <param name="pl">новая активная плоскость</param>
        internal delegate void EventHandler(Place pl);
        /// <summary>
        /// Срабатывает при смене активной плоскости
        /// </summary>
        internal event EventHandler ChoicePlane;  

        internal enum Place
        {
            XY = 0,
            XZ = 1,
            YZ = 2
        }

        internal Place PLO;
        internal int OFFs;

        private bool achoi;
        /// <summary>
        /// Активен ли выбор плоскости
        /// </summary>
        public bool ActChoi
        {
            get 
            { 
                return achoi; 
            }
            set
            {                  
                achoi = value;
                if(achoi) ChoicePlane(this.PLO);//событие активации
            }
        }
    }

    [Serializable]
    public class Predoc
    {
        Color _col = Color.Black;
        int _w;//ширина линии
        PointF _p1;
        PointF _p2;

        bool _selected = false;        

        public Color ColorOf { get { return _col; } set { _col = value; } }

        public int Width { get { return _w; } set { _w = value; } }

        public virtual PointF P2  { get { return _p2; } set { _p2 = value; }}
        
        public PointF P1 { get { return _p1; } set { _p1 = value; } }

        public bool Selected { get { return _selected; } set { _selected = value;} }

        public virtual Predoc Copy()
        {
            Predoc pr = new Predoc();            
            pr.P1 = new PointF(P1.X,P1.Y);
            pr.P2 = new PointF(P2.X, P2.Y);
            pr.Width = this.Width;
            pr.ColorOf = this.ColorOf;
            pr.Selected = true;//спорно, но пусть
            return pr;
        }//*/

        internal void SetPlane(layer.Place pl)
        {

        }
        //public interface 

    }

    [Serializable]public class Line: Predoc
    {
        public Line() { }

        public Line(PointF p1, PointF p2)
        {
            base.P1 = p1; base.P2 = p2;
        }

        public Line(PointF p1, PointF p2, Hand h)
        {
            base.P1 = p1; base.P2 = p2;
            base.ColorOf = h.ColorOf;
            base.Width = h.Width;
        }

        private float coordSect(float Xp, float dP, float m)
        {
            if (m < 0.25) m = 0.125F;
            return dP < Xp ? (dP + (Xp-dP) * m) : (dP + (Xp - dP) * m);
        }


        public void Draw(Graphics g, float m, Point dP)
        {           
            //g.DrawLine(new Pen(base.ColorOf, base.Width), P1.X/m,P1.Y/m, P2.X/m,P2.Y/m);//исходн.


            g.DrawLine(new Pen(base.ColorOf, base.Width),
                coordSect(P1.X, dP.X, m),
                coordSect(P1.Y, dP.Y, m),
                coordSect(P2.X, dP.X, m),
                coordSect(P2.Y, dP.Y, m));


            //выделяем, если есть выделение
            if (this.Selected == true)
            {
                g.FillRectangle(Brushes.Yellow,
                    P1.X - 10, P1.Y - 10, 2 * 10, 2 * 10);
                g.FillRectangle(Brushes.Yellow,
                        P2.X - 10, P2.Y - 10, 2 * 10, 2 * 10);
            }
        }

        public void DrawXZ(Graphics g, int Z, float m)
        {
            //this.ColorOf = c;
            g.DrawLine(new Pen(base.ColorOf, base.Width), 
                P1.X/m, 
                Z/m,
                P2.X/m,
                Z/m);


            if (this.Selected == true)
            {
                g.FillRectangle(Brushes.Yellow,
                    P1.X - 10, P1.Y - 10, 2 * 10, 2 * 10);
                g.FillRectangle(Brushes.Yellow,
                        P2.X - 10, P2.Y - 10, 2 * 10, 2 * 10);
            }
        }


        internal void DrawYZ(Graphics g, int Z, float m)
        {
            //this.ColorOf = c;
            g.DrawLine(new Pen(base.ColorOf, base.Width),
                Z / m,
                P1.Y / m,
                Z / m,
                P2.Y / m);          

            if (this.Selected == true)
            {
                g.FillRectangle(Brushes.Yellow,
                    P1.X - 10, P1.Y - 10, 2 * 10, 2 * 10);
                g.FillRectangle(Brushes.Yellow,
                        P2.X - 10, P2.Y - 10, 2 * 10, 2 * 10);
            }
        }

        /*public override Line Copy()
        {
            Line pr = new Line();
            pr.P1 = new PointF(P1.X, P1.Y);
            pr.P2 = new PointF(P2.X, P2.Y);
            pr.Width = this.Width;
            pr.ColorOf = this.ColorOf;
            pr.Selected = true;//спорно, но пусть
            return pr;
        }//*/
    }

    [Serializable]
    public class Text : Predoc
    {        

        public void CreateTextBox(System.Windows.Forms.PictureBox PictuBox)
        {
            System.Windows.Forms.TextBox tbox = new System.Windows.Forms.TextBox();            
            tbox.Location = new Point ((int)P1.X,(int)P1.Y);
            tbox.KeyDown += new System.Windows.Forms.KeyEventHandler(tbox_KeyDown);
            tbox.LostFocus += new EventHandler(tbox_LostFocus);

            this.FontOf = tbox.Font;

            PictuBox.Controls.Add(tbox);
            tbox.Focus();
        }

        void tbox_LostFocus(object sender, EventArgs e)
        {
            
        }

        public Text(PointF p1, PointF p2, Hand h, string text)
        {
            base.P1 = p1; base.P2 = p2;
            base.ColorOf = h.ColorOf;
            base.Width = h.Width;
            _text = text;
        }

        public override PointF P2 { get { return base.P1; } set { return; } }

        string _text;
        public string TextOf
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }

        Font _font;
        public Font FontOf
        {
            get
            {
                return _font;
            }
            set
            {
                _font = value;
            }
        }

        public void Draw(Graphics g)
        {

            g.DrawString(
                this.TextOf,
                new Font(this.FontOf.FontFamily, this.FontOf.Size, this.FontOf.Style),
                new SolidBrush(base.ColorOf),
                new PointF(P1.X, P1.Y));


            //выделение кружочком выделения
            if (this.Selected == true)
            {
                g.FillRectangle(Brushes.Yellow,
                    P1.X - 10, P1.Y - 10, 2 * 10, 2 * 10);
                /*g.FillRectangle(Brushes.Yellow,
                        P2.X - 10, P2.Y - 10, 2 * 10, 2 * 10);*/
            }

        }

        void tbox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyValue == 13) {//энтер

                this.TextOf = ((System.Windows.Forms.TextBox)sender).Text;
                this.FontOf = ((System.Windows.Forms.TextBox)sender).Font;
                /*new PointF(
                    base.P2.X + ((System.Windows.Forms.TextBox)sender).CreateGraphics().MeasureString(this.TextOf, this.FontOf).Width, 
                    base.P2.Y + this.FontOf.Size);//*/
                ((System.Windows.Forms.TextBox)sender).Dispose(); 
            }
        }

    }

    [Serializable]
    public class Rectangle : Predoc
    {
        public Rectangle(PointF p1, PointF p2)
        {
            base.P1 = p1; base.P2 = p2;
        }

        public void Draw(Graphics g)
        {
            g.DrawRectangle(new Pen(base.ColorOf),
                Math.Min(base.P1.X, base.P2.X),
                Math.Min(base.P1.Y, base.P2.Y),
                Math.Abs(base.P2.X - base.P1.X),
                Math.Abs(base.P2.Y - base.P1.Y));

            //рисуем выделение
            if (this.Selected == true)
            {
                g.FillRectangle(Brushes.Yellow,
                    P1.X - 10, P1.Y - 10, 2 * 10, 2 * 10);
                g.FillRectangle(Brushes.Yellow,
                    P1.X - 10, P2.Y - 10, 2 * 10, 2 * 10);
                g.FillRectangle(Brushes.Yellow,
                    P2.X - 10, P1.Y - 10, 2 * 10, 2 * 10);
                g.FillRectangle(Brushes.Yellow,
                        P2.X - 10, P2.Y - 10, 2 * 10, 2 * 10);
            }
        }
    }


    [Serializable]
    public class Circle : Predoc
    {
        public Circle(PointF p1, PointF p2)
        {
            base.P1 = p1; base.P2 = p2;
        }

        public int Radius
        {
            get
            {
                return (int)Math.Sqrt(Math.Pow((P2.X - P1.X), 2) + Math.Pow((P2.Y - P1.Y), 2));
            }
        }

        public void Draw(Graphics g)
        {
             
            int r = (int)Math.Sqrt(Math.Pow((P2.X - P1.X), 2) + Math.Pow((P2.Y - P1.Y), 2));

            g.DrawEllipse(new Pen(base.ColorOf),
                P1.X - r,
                P1.Y - r,
                r * 2,
                r * 2);



            //Если выделен, то показываем
            if (this.Selected == true)
            {
                g.FillRectangle(Brushes.Yellow,
                    P1.X - 10, P1.Y - 10, 2 * 10, 2 * 10);
            }



        }
    }


    [Serializable]
    public class Pazl : List<Predoc>
    {
        public Pazl()
        {
            this.PlaneVal.PLO = layer.Place.XY;                 //по умолчанию
            PlaneVal.ChoicePlane += new layer.EventHandler(PlaneVal_ChoicePlane);            
        }        

        /// <summary>
        /// Срабатывает при смене активной плоскости проектирования (прорисовки)
        /// </summary>
        /// <param name="pl">новая активная плоскость</param>
        void PlaneVal_ChoicePlane(layer.Place pl)
        {
            //активация выбора плоскости
            throw new NotImplementedException();
        }

        private PointF GetCoordbyScaleF(float px, float py)
        {
            /*
            if (m < 0.25) m = 0.125F; //dP - это PointScale
            return dP < Xp ? (dP + (Xp - dP) * m) : (dP + (Xp - dP) * m);*/
            float m = ScaleM;
            if (m < 0.25) m = 0.125F;
            //float um = 1 / m;//обратный масштаб
            float Xr = (px - ScaPoint.X + ScaPoint.X * m) / m;
            float Yr = (py - ScaPoint.Y + ScaPoint.Y * m) / m;
            return new PointF(Xr,Yr);
        }

        private Point GetCoordbyScale(int px, int py)
        {
            /*
            if (m < 0.25) m = 0.125F; //dP - это PointScale
            return dP < Xp ? (dP + (Xp - dP) * m) : (dP + (Xp - dP) * m);*/
            float m = ScaleM;
            if (m < 0.25) m = 0.125F;
            //float um = 1 / m;//обратный масштаб
            int Xr = (int)((px - ScaPoint.X + ((int)(ScaPoint.X * ScaleM))) / ScaleM);
            int Yr = (int)((py - ScaPoint.Y + ((int)(ScaPoint.Y * ScaleM))) / ScaleM);
            return new Point(Xr, Yr);
        }


        internal void AddElement(Predoc pr)//byScale
        {
            //масштабируем точки согласно свойствам масштаба

            //pr.P1 = GetCoordbyScaleF(pr.P1.X,pr.P1.Y);
            //pr.P2 = GetCoordbyScaleF(pr.P2.X, pr.P2.Y);
            switch (this.PlaneVal.PLO)
            {
                //case layer.Place.XY: pr.
            }

            base.Add(pr);
        }//*/

        public enum Childs
        {
            Line,
            Circle
        };        

        float _scale;
        public Point ScaPoint { get; set; }

        internal layer PlaneVal;

        public float ScaleM
        {
            get
            {
                return _scale;
            }
            set
            {
                _scale = value;
            }
        }

        public void Draw(Graphics g, float m)
        {
            switch (this.PlaneVal.PLO)
            {
                case layer.Place.XY:
                    DrawXY(g, m);
                    break;
                case layer.Place.XZ:
                    DrawXZ(g,this.PlaneVal.OFFs, m);
                    break;
                case layer.Place.YZ:
                    DrawYZ(g,this.PlaneVal.OFFs, m);
                    break;
            }
        }

        bool b = true;
        public void DrawXY(Graphics g, float m)
        {
            for (int i=0; i < this.Count; i++)
            {
                
                switch (this[i].GetType().ToString())
                {
                    case "ForTrain.Line":
                        ((Line)this[i]).Draw(g,m,this.ScaPoint);                        
                        break;
                    case "ForTrain.Circle":
                        ((Circle)this[i]).Draw(g);
                        break;
                    case "ForTrain.Rectangle":
                        ((Rectangle)this[i]).Draw(g);
                        break;
                    case "ForTrain.Text":
                        ((Text)this[i]).Draw(g);
                        break;
                }
            }
        }

        public void DrawXZ(Graphics g, int Z, float m)
        {
            for (int i = 0; i < this.Count; i++)
            {

                switch (this[i].GetType().ToString())
                {
                    case "ForTrain.Line":
                        ((Line)this[i]).DrawXZ(g,Z,m);
                        break;
                    case "ForTrain.Circle":
                        ((Circle)this[i]).Draw(g);
                        break;
                    case "ForTrain.Rectangle":
                        ((Rectangle)this[i]).Draw(g);
                        break;
                    case "ForTrain.Text":
                        ((Text)this[i]).Draw(g);
                        break;
                }
            }
        }

        public void DrawYZ(Graphics g, int Z, float m)
        {
            for (int i = 0; i < this.Count; i++)
            {

                switch (this[i].GetType().ToString())
                {
                    case "ForTrain.Line":
                        ((Line)this[i]).DrawYZ(g, Z, m);
                        break;
                    case "ForTrain.Circle":
                        ((Circle)this[i]).Draw(g);
                        break;
                    case "ForTrain.Rectangle":
                        ((Rectangle)this[i]).Draw(g);
                        break;
                    case "ForTrain.Text":
                        ((Text)this[i]).Draw(g);
                        break;
                }
            }
        }

        public bool Opened
        {
            get
            {
                //if (this.Count 
                return b;
            }
            set
            {
                b = value;
            }

        }

    }
    
    public class Select : Predoc
    {
        //событие попадания в область выделения каких-либо объектов
        /// <summary>
        /// событие попадания в область выделения каких-либо объектов
        /// </summary>
        public event Selected SelectObject;

        public Select(Point p1, Point p2)
        {
            base.P1 = p1; base.P2 = p2;
        }

        public Select(Point p1, Point p2, Hand h)
        {
            base.P1 = p1; base.P2 = p2;
            base.ColorOf = h.ColorOf;
        }

        public void Draw(Graphics g, System.ComponentModel.ComponentResourceManager resources)
        {
            //this.ColorOf = c;
            /*g.FillRectangle(new TextureBrush(
                ((System.Drawing.Image)(resources.GetObject("undoToolStripButton.Image")))),
                Math.Min(base.P1.X, base.P2.X),
                Math.Min(base.P1.Y, base.P2.Y),
                Math.Abs(base.P2.X - base.P1.X),
                Math.Abs(base.P2.Y - base.P1.Y));
            */
            g.FillRectangle(SystemBrushes.ActiveBorder,
                Math.Min(base.P1.X, base.P2.X),
                Math.Min(base.P1.Y, base.P2.Y),
                Math.Abs(base.P2.X - base.P1.X),
                Math.Abs(base.P2.Y - base.P1.Y));
            
        }

        bool sel = false;
        public bool Activate
        {
            get
            {
                return sel;
            }
            set
            {
                sel = value;
            }

        }

        /// <summary>
        /// Выделяет выделенные объекте на карте
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Pazl TestOnSelect(Pazl p)
        {
            float MinX = Math.Min(this.P1.X, this.P2.X);
            float MaxX = Math.Max(this.P1.X, this.P2.X);
            float MinY = Math.Min(this.P1.Y, this.P2.Y);
            float MaxY = Math.Max(this.P1.Y, this.P2.Y);

            for (int i = 0; i < p.Count; i++)
            {
                if ((p[i].P1.X >  MinX && p[i].P1.X < MaxX)
                    &&
                    ((p[i].P1.Y > MinY) && (p[i].P1.Y < MaxY))
                    &&
                    ((p[i].P2.X > MinX) && (p[i].P2.X < MaxX))
                    &&
                    ((p[i].P2.Y > MinY) && (p[i].P2.Y < MaxY))
                    &&
                    (this.Activate == true))
                {
                    if (SelectObject != null) this.SelectObject(p[i]);//событие выделения
                    //для наглядности

                    p[i].Selected = true;
                }
                else
                {
                    p[i].Selected = false;
                }
            }
            return p;
        }

    }

    public class Point3D
    {
        

        int x, y, z;

        public Point3D(Point xyPoint)
        {
            x = xyPoint.X;
            y = xyPoint.Y;
        }

        public Point3D(int _x, int _y, int _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }

        public Point3D(Point xyPoint, int _Z)
        {
            x = xyPoint.X;
            y = xyPoint.Y;
            z = _Z;
        }

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public int Z
        {
            get
            {
                return z;
            }
            set
            {
                z = value;
            }
        }

        public void OffSet(int _x, int _y, int _z)
        { 
            x += _x;
            y += _y;
            z += _z;
        }

        

    }
}
