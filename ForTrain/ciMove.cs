using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForTrain
{
    //задаем мувпойнт для теста дальности
    public class ciMove
    {
        System.Drawing.PointF _mp;
        public System.Drawing.PointF MovePoint
        {
            get
            {
                return _mp;
            }
            set
            {
                _mp = value;
            }
        }        

    }

    public class iMove 
    {

        static System.Drawing.PointF _mp;
        public static System.Drawing.PointF M_Point
        {
            get
            {
                return _mp;
            }
            set
            {
                _mp = value;
            }
        } 

        static System.Drawing.PointF _sp;
        public static System.Drawing.PointF StartPoint
        {
            get
            {
                return _sp;
            }
            set
            {
                _sp = value;
            }
        }
    }

    public class Hand
    {
        public Hand()
        {
            _color = System.Drawing.Color.Black;
            _w = 1;
        }

        System.Drawing.Color _color;
        int _w;
        public System.Drawing.Color ColorOf
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }
        public int Width
        {
            get
            {
                return _w;
            }
            set
            {
                _w = value;
            }
        }
    }
}
