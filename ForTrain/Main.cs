using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ForTrain
{
    public partial class Main : Form
    {

        Pazl p;
        float ScaleM = 1;//масштаб

        ciMove move;
        Boolean boolFarTest = true;
        int _radoflook = 20;//радиус создания кружка
        int FarTestIdTrue;
        Hand hand;
        Select sel;
        List<Tuple<PointF, PointF>> movPoints;

        public Main()
        {
            InitializeComponent();
            p = new Pazl();//
            move = new ciMove();
            hand = new Hand();
            sel = new Select(Point.Empty, Point.Empty);
        }

        private void MAP_MouseDown(object sender, MouseEventArgs e)
        {
            if (p.PlaneVal.ActChoi) p.PlaneVal.ActChoi = false;//если выбор плоскости

            //если выделение активно, то устанавливаем первую точку
            if (sel.Activate == true && sel.P1 == Point.Empty)
            {//,но
                if (boolFarTest == false)//если есть приближение к какому-л объекту//выделение
                {
                    DownPazl(e);//меняем этот объект if (p[FarTestIdTrue].Selected) 
                    //else sel.P1 = PointToScale(e.Location);

                    //сделать функци замены полюсов в самом предке, точнее его модификации, лучше отдельно
                    //а т/же функцию понимания, какой именно из полюсов должен стать активным
                }
                else
                {
                    sel.P1 = PointToScale(e.Location);
                }
            }
            else if (sel.Activate == true && sel.P1 != Point.Empty)//выделение активно, выбираем вторую точку
            {

                sel.P2 = e.Location;

                sel.TestOnSelect(p);//тест

                sel.P1 = Point.Empty;
            }
            else if (toolMove.Checked == true)//если перемещение
            {
                if (iMove.StartPoint == PointF.Empty)//первая точка
                {
                    iMove.StartPoint = PointToScale(e.Location);

                    movPoints = new List<Tuple<PointF, PointF>>();//если есть выделенные объекты, то используем ее

                    //создаем копии выделенных объектов, их оставим на месте?
                    //foreach (Predoc pr in p)
                    for(int i=0;i<p.Count;i++)
                    {                        

                        if (p[i].Selected)
                        {
                            
                            movPoints.Add(new Tuple<PointF, PointF>(p[i].P1, p[i].P2));
                            //p.Add(p[i].Clone());            //по ссылке или по значению?
                            //p[i].Selected = false;          //убираем выделение наверное
                        }
                    }
                }
                else //вторая точка
                {
                    int idMP = 0;
                    foreach (Predoc pr in p)
                    {

                        if (pr.Selected == true)
                        {

                            pr.P1 = new PointF(
                                movPoints[idMP].Item1.X + (e.Location.X - iMove.StartPoint.X),
                                movPoints[idMP].Item1.Y + (e.Location.Y - iMove.StartPoint.Y));

                            pr.P2 = new PointF(
                                movPoints[idMP].Item2.X + (e.Location.X - iMove.StartPoint.X),
                                movPoints[idMP].Item2.Y + (e.Location.Y - iMove.StartPoint.Y));
                            
                            idMP++;

                        }
                    }
                    iMove.StartPoint = Point.Empty;

                }
            }
            else if (toolCopy.Checked)//если копирование
            {
                if (iMove.StartPoint == PointF.Empty)//первая точка
                {
                    iMove.StartPoint = PointToScale(e.Location);

                    movPoints = new List<Tuple<PointF, PointF>>();//если есть выделенные объекты, то используем ее

                    //создаем копии выделенных объектов, их оставим на месте?
                    //foreach (Predoc pr in p)
                    for (int i = 0; i < p.Count; i++)
                    {

                        if (p[i].Selected)
                        {
                            /*так не заработало почему-то
                            PointF[] ps = new PointF[] { 
                                new PointF(p[i].P1.X, p[i].P1.Y), 
                                new PointF(p[i].P2.X, p[i].P2.Y) };
                            p.Add((Predoc)Activator.CreateInstance(p[i].GetType(),ps));//*/

                            p.Add((Predoc)Activator.CreateInstance(p[i].GetType()));
                            p[p.Count - 1].P1 = new PointF(p[i].P1.X, p[i].P1.Y);
                            p[p.Count - 1].P2 = new PointF(p[i].P2.X, p[i].P2.Y);//*/

                            /*p.Add(new Line( 
                               new PointF(p[i].P1.X,p[i].P1.Y),
                               new PointF(p[i].P2.X, p[i].P2.Y)
                            ));//*/
                            movPoints.Add(new Tuple<PointF, PointF>(p[i].P1, p[i].P2));
                            //p.Add(p[i].Clone());            //по ссылке или по значению?
                            //p[i].Selected = false;          //убираем выделение наверное
                        }
                    }
                }
                else//вторая точка
                {
                    int idMP = 0;
                    foreach (Predoc pr in p)
                    {

                        if (pr.Selected == true)
                        {

                            pr.P1 = new PointF(
                                movPoints[idMP].Item1.X + (e.Location.X - iMove.StartPoint.X),
                                movPoints[idMP].Item1.Y + (e.Location.Y - iMove.StartPoint.Y));

                            pr.P2 = new PointF(
                                movPoints[idMP].Item2.X + (e.Location.X - iMove.StartPoint.X),
                                movPoints[idMP].Item2.Y + (e.Location.Y - iMove.StartPoint.Y));

                            idMP++;

                        }
                    }
                    iMove.StartPoint = Point.Empty;

                }
            }
            else //если нет, то просто рисование            
                DownPazl(e);//рисуем обьект

                //sel.TestOnSelect(p);//здесь он очищает выбранные обьекты


        }


        void MAP_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //MAP.Scale(new SizeF(MAP.Size.Width*2, MAP.Size.Height*2)); - не работает
            ScaleM = ScaleM + (float)e.Delta / 480;
            p.ScaleM = ScaleM;

            MAP.Refresh();
        }

        PointF PointToScale(Point e)
        {
            Point sPoi = new Point(MAP.Width / 2, MAP.Height / 2);

            
            //PointF nP = new PointF(e.X * ScaleM, e.Y * ScaleM);
            PointF nP = new PointF(
                sPoi.X - (sPoi.X - e.X) / ScaleM,
                sPoi.Y - (sPoi.Y - e.Y) / ScaleM);
            return nP;
        }

        PointF PointToScale(PointF e)
        {
            PointF nP = new PointF(e.X * ScaleM, e.Y * ScaleM);
            return nP;
        }

        private void DownPazl(MouseEventArgs e)
        {
            //если правая кнопка мыши
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {                
                if                    
                    (boolFarTest) p[p.Count - 1].P2 = PointToScale(e.Location);//
                else
                {
                    //по ходу, если рядом с ориентировкой
                    p[p.Count - 1].P2 = PointToScale(SoPoint(p[FarTestIdTrue], (int)((float)_radoflook * ScaleM), TPaint.Checked));
                }

                p.Opened = false;//закрываем пазл
            }
            else    //если левая кнопка мыши
            {                

                if (boolFarTest)//если нет близких объектов, т.е. они все далеко:
                {                    
                    if (p.Count > 0 && p.Opened == true) //можно просто p.Opened == true. 
                    {
                        //новая позиция в старом пазле, т.е. изменение старой позиции, наск. я понял
                        //p.Add(CreateNewElement(PointToScale(p[p.Count - 1].P2), hand));
                        p.Add(CreateNewElement(p[p.Count - 1].P2, hand));
                    }
                    else        //если новый объект         
                    {
                        //p.AddbyScale(CreateNewElement(e.Location, hand));//создаем новый элемент
                        p.Add(CreateNewElement(PointToScale(e.Location), hand));
                    }
                    
                    //StatusLabel.Text = p[p.Count - 1].P1.ToString();

                }
                else
                {

                    p.Add(CreateNewElement(PointToScale(SoPoint(p[FarTestIdTrue], (int)((float)_radoflook * ScaleM), TPaint.Checked)), hand));
                    //StatusLabel.Text = p[p.Count - 1].P1.ToString(); - не понял, зачем

                }


                if (FindSelectedTool() == 3) toolStripText.Checked = false;

                p.Opened = true;//открываем рисование

            }
        }



        private void MAP_Paint(object sender, PaintEventArgs e)
        {
            p.ScaPoint = new Point(MAP.Width / 2, MAP.Height / 2);//проверим, работает ли ресайз

            //выделение
            if (sel.Activate == true && sel.P1 != Point.Empty) 
                sel.Draw(e.Graphics,
                new System.ComponentModel.ComponentResourceManager(typeof(Main)));
            
            p.Draw(e.Graphics , ScaleM); //рисуем пазл

            boolFarTest = FarTest(e);//тесь на удаленность - рисуем удаленность

           //строка состояния на изо:
            e.Graphics.DrawString(p.Count.ToString(), new Font("Arial", 8), Brushes.Brown, new PointF(5, 8));

            //координаты объектов:
            string scoo = string.Empty;
            foreach (Predoc prc in p) scoo += prc.P1.ToString() + prc.P2.ToString() + Environment.NewLine;
            e.Graphics.DrawString(scoo, new Font("Arial", 8), Brushes.Brown, new PointF(15, 8));//*/

            //перекрестье
            e.Graphics.DrawLine(Pens.Bisque,new Point(MAP.Width / 2, 0),new Point(MAP.Width / 2, MAP.Height));
            e.Graphics.DrawLine(Pens.Bisque, new Point(0, MAP.Height / 2), new Point(MAP.Width, MAP.Height / 2));//*/

            //начало плоскости:
            if (p.PlaneVal.ActChoi) e.Graphics.DrawLine(Pens.Yellow, p.PlaneVal.OFFs, 0, p.PlaneVal.OFFs, MAP.Height);



        }

        private bool FarTest(PaintEventArgs e)
        {
            //рисуем кружок            
            for (int i = 0; i < p.Count; i++)
            {
                Predoc pr = p[i];
                PointF plook = SoPoint(pr, _radoflook, TPaint.Checked);//определяет положительные координаты в случае умещения
                if ((plook.X != -10) && ((i != p.Count - 1) || p.Opened != true))//открыто  
                {
                    e.Graphics.DrawEllipse(Pens.Red,
                        plook.X - _radoflook,
                        plook.Y - _radoflook,
                        2 * _radoflook,
                        2 * _radoflook);

                    FarTestIdTrue = i;

                    return false;
                }
            }

            return true;
        }

        //использ. для того, чтобы показать, находится ли точка движения мыши в определенном диапазоне
        PointF SoPoint(Predoc pr, int _radoflook, bool VMode)
        {
            PointF rPoint = new PointF(-10, -10);//солнце все время существует, но его не видно 

            //move.MovePoint - указатель мыши, pr - ориентируемый объект
            if ((move.MovePoint.X < pr.P2.X + _radoflook && move.MovePoint.X > pr.P2.X - _radoflook)
                    && (move.MovePoint.Y < pr.P2.Y + _radoflook && move.MovePoint.Y > pr.P2.Y - _radoflook))
            {
                if (VMode == true)
                {
                    //вычисляем углы наклона
                    if (Math.Abs(p[p.Count - 1].P2.X - p[p.Count - 1].P1.X) -
                        Math.Abs(p[p.Count - 1].P2.Y - p[p.Count - 1].P1.Y) > 0)
                    { rPoint = new PointF(pr.P2.X, p[p.Count - 1].P1.Y); }
                    else rPoint = new PointF(p[p.Count - 1].P1.X, pr.P2.Y);
                }
                else
                    rPoint = pr.P2;
            }
            else if ((move.MovePoint.X < pr.P1.X + _radoflook && move.MovePoint.X > pr.P1.X - _radoflook)
                    && (move.MovePoint.Y < pr.P1.Y + _radoflook && move.MovePoint.Y > pr.P1.Y - _radoflook))
            {
                if (VMode == true)
                {
                    //вычисляем углы наклона
                    if (Math.Abs(p[p.Count - 1].P2.X - p[p.Count - 1].P1.X) -
                        Math.Abs(p[p.Count - 1].P2.Y - p[p.Count - 1].P1.Y) > 0)
                    { rPoint = new PointF(pr.P1.X, p[p.Count - 1].P1.Y); }
                    else rPoint = new PointF(p[p.Count - 1].P1.X, pr.P1.Y);
                }
                else
                    rPoint = pr.P1;
            }

            return rPoint;//возвращаем точку, рядом с которой нах-ся мышь
        }

        PointF SoPoint(Predoc pr, int _radoflook, bool VMode, out byte n)
        {
            PointF rPoint = new PointF(-10, -10);//солнце все время существует, но его не видно 

            //move.MovePoint - указатель мыши, pr - ориентируемый объект
            if ((move.MovePoint.X < pr.P2.X + _radoflook && move.MovePoint.X > pr.P2.X - _radoflook)
                    && (move.MovePoint.Y < pr.P2.Y + _radoflook && move.MovePoint.Y > pr.P2.Y - _radoflook))
            {
                if (VMode == true)
                {
                    //вычисляем углы наклона
                    if (Math.Abs(p[p.Count - 1].P2.X - p[p.Count - 1].P1.X) -
                        Math.Abs(p[p.Count - 1].P2.Y - p[p.Count - 1].P1.Y) > 0)
                    { rPoint = new PointF(pr.P2.X, p[p.Count - 1].P1.Y); }
                    else rPoint = new PointF(p[p.Count - 1].P1.X, pr.P2.Y);
                }
                else
                    rPoint = pr.P2; n = 2;
            }
            else if ((move.MovePoint.X < pr.P1.X + _radoflook && move.MovePoint.X > pr.P1.X - _radoflook)
                    && (move.MovePoint.Y < pr.P1.Y + _radoflook && move.MovePoint.Y > pr.P1.Y - _radoflook))
            {
                if (VMode == true)
                {
                    //вычисляем углы наклона
                    if (Math.Abs(p[p.Count - 1].P2.X - p[p.Count - 1].P1.X) -
                        Math.Abs(p[p.Count - 1].P2.Y - p[p.Count - 1].P1.Y) > 0)
                    { rPoint = new PointF(pr.P1.X, p[p.Count - 1].P1.Y); }
                    else rPoint = new PointF(p[p.Count - 1].P1.X, pr.P1.Y);
                }
                else
                    rPoint = pr.P1; n = 1;
            }

            n = 0;
            return rPoint;//возвращаем точку, рядом с которой нах-ся мышь
        }

        private void toolLine_Click(object sender, EventArgs e)
        {
            //управление активностью кнопок

            ClearToolStrip();//очищаем все кнопки
            ClearActStrip();

            toolLine.Checked = true;
            
        }

        private void ClearToolStrip()
        {
            //функция по определению, какая из кнопок панели активна, путем перечисления всех кнопок
            for (int i = 0; i < toolStripTools.Items.Count; i++)
            {
                if (((ToolStripButton)toolStripTools.Items[i]).Checked == true)
                { ((ToolStripButton)toolStripTools.Items[i]).Checked = false; }
            }

            //приводим все настройки к по умолчанию
            sel.Activate = false;
            MAP.Cursor = Cursors.Cross;
            
        }


        private void ClearActStrip()
        {
            //функция по определению, какая из кнопок панели активна, путем перечисления всех кнопок
            for (int i = 0; i < toolActes.Items.Count; i++)
            {
                if (((ToolStripButton)toolActes.Items[i]).Checked == true)
                { ((ToolStripButton)toolActes.Items[i]).Checked = false; }
            }

        }

        private void MAP_MouseMove(object sender, MouseEventArgs e)
        {
            StatusLabel.Text = e.Location.ToString();

            if (p.PlaneVal.ActChoi) p.PlaneVal.OFFs = e.X;

            DynamicPaint(e);//динамическое рисование активного обьекта

            move.MovePoint = e.Location;//задаем мувпойнт для теста дальности
            if (sel.Activate == true) sel.P2 = e.Location;

            if (iMove.StartPoint != Point.Empty)
            {
            #region ничего не происходит
                foreach (Predoc pr in p)
                {                    
                    /*
                    if (pr.Selected == true)
                    {

                        Point p1 = pr.P1;
                        Point p2 = pr.P2;

                        pr.P1 = new Point(
                            pr.P1.X + (e.Location.X - p1.X),
                            pr.P1.Y + (e.Location.Y - p1.Y));

                        pr.P2 = new Point(
                            pr.P2.X + (e.Location.X - p1.X),
                            pr.P2.Y + (e.Location.Y - p1.Y));
                    }*/
                }
            #endregion

                if (p.Count(pr => pr.Selected == true) > 0 && (toolMove.Checked || toolCopy.Checked))
                {
                    //передвижение активно и есть выделенные точки
                    int psC = 0;//p.Count(pr => pr.Selected == true);

                    for(int i=0;i<p.Count;i++) //foreach (Predoc pred in p)
                    {
                        if (p[i].Selected)
                        {
                            
                            p[i].P1 = new PointF(
                                movPoints[psC].Item1.X +(e.Location.X - iMove.StartPoint.X),//p[p.Count-psC+i].P1.X
                                movPoints[psC].Item1.Y + (e.Location.Y - iMove.StartPoint.Y));

                            p[i].P2 = new PointF(
                                movPoints[psC].Item2.X + (e.Location.X - iMove.StartPoint.X),
                                movPoints[psC].Item2.Y + (e.Location.Y - iMove.StartPoint.Y));//*/

                            psC++;
                        }
                    }
                    
                }
            }
            else 
            {

            }

            MAP.Refresh();//перерисовка
        }

        private void DynamicPaint(MouseEventArgs e)
        {
            //если в пазле есть элементы и он разрешен к рисованию, то точка 2 меняется
            if (p.Count > 0 && p.Opened == true)
            {
                //если включено вертик-гориз черчение
                if (TPaint.Checked)
                {
                    if (Math.Abs(e.Location.X - p[p.Count - 1].P1.X) -
                        Math.Abs(e.Location.Y - p[p.Count - 1].P1.Y) > 0)
                    { p[p.Count - 1].P2 = PointToScale(new PointF(e.Location.X, p[p.Count - 1].P1.Y)); }
                    else p[p.Count - 1].P2 = PointToScale(new PointF(p[p.Count - 1].P1.X, e.Location.Y));
                }
                else if (toolMove.Checked)//перемещение объектов
                {

                }
                else //иначе просто чертим активную точку. если исп. PointToScale, то это приведение к масштабу
                    p[p.Count - 1].P2 = PointToScale(e.Location);

            }
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            //изменение размера окна
            MAP.Size = new Size
                (this.Width - 150, this.Height - 150);
            MAP_XZ.Location = new Point(toolStrip2.Left + 15, 165);

            //координаты для масштабирования
            p.ScaPoint = new Point(MAP.Width / 2, MAP.Height / 2);
        }

        private void toolCircle_Click(object sender, EventArgs e)
        {

            ClearToolStrip();//очищаем все кнопки
            //управление активностью кнопок
            toolCircle.Checked = true;

        }

        /// <summary>
        /// создает новый элемент
        /// </summary>
        /// <param name="e"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public Predoc CreateNewElement(PointF e, Hand h)
        {
            //создание нового элемента
            int i= FindSelectedTool();
            switch (i)
            {
                case 0:
                    return new Line(e, new Point(),h);
                case 1:
                    return new Circle(e, new PointF());
                case 2:
                    return new Rectangle(e, new PointF());
                case 3:
                    Text t = new Text(e, new PointF(), h, "");                    
                    t.CreateTextBox(MAP);
                    return t;
                case 4:
                    return p[FarTestIdTrue];
                    

            }
            return null;

        }

        private int FindSelectedTool()
        {
            //функция по определению, какая из кнопок панели активна, путем перечисления всех кнопок
            for (int i = 0; i < toolStripTools.Items.Count; i++)
            {
                if (((ToolStripButton)toolStripTools.Items[i]).Checked == true)
                { return i; }
            }
            return 0;
        }

        private void toolStripRect_Click(object sender, EventArgs e)
        {
            //управление активностью кнопок
            ClearToolStrip();//очищаем все кнопки
            toolStripRect.Checked = true;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            MessageBox.Show("Close rool");
            /*
            System.IO.Stream serialStream = new System.IO.FileStream("info.trin", System.IO.FileMode.OpenOrCreate);
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formater = 
                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            formater.Serialize(serialStream, p);
            serialStream.Close();//**/

        }

        private void mOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "Zodchi' Connection|*.trin";
            o.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);                  
            o.ShowDialog();

            if (o.FileName != string.Empty)
            {

                //открытие
                System.IO.Stream serialStream = new System.IO.FileStream(o.FileName, System.IO.FileMode.Open);
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formater =
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                p = (Pazl)formater.Deserialize(serialStream);
                serialStream.Close();
            }
            
            MAP.Refresh();
        }

        private void RedLight_Click(object sender, EventArgs e)
        {
            if (sel.Activate != true) hand.ColorOf = ((ToolStripButton)sender).BackColor;
            else
            {
                for(int i=0;i<p.Count;i++)
                {
                    if (p[i].Selected) p[i].ColorOf = ((ToolStripButton)sender).BackColor;
                }
            }
            
        }

        private void undoToolStripButton_Click(object sender, EventArgs e)
        {
            if (p.Count > 0) p.RemoveAt(p.Count - 1);//если есть элементы, удаляем их
            MAP.Refresh();
        }

        private void toolStripComboBoxWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sel.Activate != true) hand.Width = Convert.ToInt16(toolStripComboBoxWidth.Text.Remove(1));
            else
            {
                for(int i=0;i<p.Count;i++)
                {
                    if (p[i].Selected) p[i].Width = Convert.ToInt16(toolStripComboBoxWidth.Text.Remove(1));
                }
            }
        }

        private void toolStripButtonSelection_Click(object sender, EventArgs e)
        {
            ClearToolStrip();//очищаем все кнопки

            sel.Activate = true;

            toolStripButtonSelection.Checked = true;

        }

        private void toolStripText_Click(object sender, EventArgs e)
        {
            ClearToolStrip();//очищаем все кнопки
            toolStripText.Checked = true;
        }


        private void mMAP_XZ_MouseEnter(object sender, EventArgs e)
        {
            MAP_XZ.Location = new Point(
                MAP.Width - MAP_XZ.Width,
                MAP.Top + 40);
            MAP_XZ.BackColor = Color.Gray;

            MAP_XZ.Width = MAP.Width/4;
            MAP_XZ.Height = MAP.Height/4;

            

            MAP_XZ.Show();
        }

        private void mMAP_XZ_MouseLeave(object sender, EventArgs e)
        {
            MAP_XZ.Visible = false;
        }

        private void mMAP_YZ_MouseEnter(object sender, EventArgs e)
        {
            MAP_YZ.Width = MAP.Width / 4;
            MAP_YZ.Height = MAP.Height / 4;
            MAP_YZ.Location = new Point(
                MAP.Width - MAP_YZ.Width,
                MAP.Top + 40);//MAP.Top + MAP.Height / 4 + 40);//
            MAP_YZ.BackColor = Color.Gray;
            MAP_YZ.Show();
        }

        private void mMAP_YZ_MouseLeave(object sender, EventArgs e)
        {
            MAP_YZ.Visible = false;
        }

        private void toolMove_Click(object sender, EventArgs e)
        {
            //управление активностью кнопок
            ClearToolStrip();//очищаем все кнопки

            //пока не будем делать ее отмеченной
            ((ToolStripButton)sender).Checked = true;

            MAP.Cursor = Cursors.SizeAll;
        }

        private void toolCopy_Click(object sender, EventArgs e)
        {
            ClearActStrip();
            ClearToolStrip();

            //пока не будем делать ее отмеченной
            ((ToolStripButton)sender).Checked = true;

            MAP.Cursor = Cursors.SizeAll;

        }

        private void MAP_XZ_Paint(object sender, PaintEventArgs e)
        {
            p.DrawXZ(e.Graphics, 100, 4);
        }

        private void MAP_YZ_Paint(object sender, PaintEventArgs e)
        {
            p.DrawYZ(e.Graphics, 100, 4);
            //e.Graphics.DrawLine(Pens.Black, Point.Empty, new Point(100, 100));
        }

        private void toolStripCut_Click(object sender, EventArgs e)
        {
            Form fCut = new Form();
            fCut.Name = "fCut";
            fCut.Size = new Size(this.Width/ 2, this.Height / 2);
            fCut.StartPosition = FormStartPosition.CenterScreen;
            fCut.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            fCut.Text = "Выбор сечения";

            //picBox
            PictureBox cutBox = new PictureBox();
            cutBox.Location = new Point(5,35);
            cutBox.Size = new Size(fCut.Size.Width-25, fCut.Size.Height - 80);
            cutBox.BackColor = Color.Gray;
            cutBox.BorderStyle = BorderStyle.Fixed3D;
            cutBox.Paint += new PaintEventHandler(cutBox_Paint);

            //комбобокс: выбор сечения
            ComboBox cBox = new ComboBox();
            cBox.Location = new Point(5  , 10);
            cBox.Width = cutBox.Width / 2 - 65;
            cBox.Items.Add("Уголок");
            cBox.Items.Add("Швеллер");

            //кнопка поворота

            //кнопка утвержд выбор сечения
            Button bCut = new Button();
            bCut.Location = new Point(cutBox.Width - 70, 10);
            bCut.Text = "Ладно";


            fCut.Controls.AddRange(new Control[] { cutBox, cBox, bCut });

            fCut.ShowDialog();

        }

        void cutBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int sX = ((PictureBox)sender).Width / 3; int sY = ((PictureBox)sender).Height/5;
            g.DrawLines(
                new Pen(Brushes.Black, 2),
                new Point[] { 
                    new Point(sX+16, sY), 
                    new Point(sX, sY), 
                    new Point(sX, sY + 250), 
                    new Point(sX + 250, sY + 250),
                    new Point(sX + 250, sY + 234)});//t = 24

            g.DrawArc(
                new Pen(Brushes.Black, 2),
                sX+7, sY, 8*2, 8*2, 270, 90);

            g.DrawArc(
                new Pen(Brushes.Black, 2),
                sX + 250-16, sY+250-24, 8 * 2, 8 * 2, 270, 90);

            g.DrawLine(
                new Pen(Brushes.Black, 2),
                    new Point(sX + 250 - 16+8+(1), sY + 250 - 24), 
                    new Point(sX + 24+24, sY+250-24));

            g.DrawLine(
                new Pen(Brushes.Black, 2),
                    new Point(sX + 24+(1), sY+8),
                    new Point(sX + 24 + (1), sY + 250 - 24 - 24+(1)));

            g.DrawArc(
                new Pen(Brushes.Black, 2),
                sX + 24 + (1), sY + 250 - 24 - 24 -24, 24 * 2, 24 * 2, 90, 90);

        }

        private void TPaint_Click(object sender, EventArgs e)
        {

            if (((ToolStripButton)sender).Checked == true)
            {
                ((ToolStripButton)sender).Checked = false;                
            }
            else ((ToolStripButton)sender).Checked = true;

        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {

            
            if (e.KeyCode == Keys.Delete && sel.Activate == true)
            {
                /*
                p.RemoveAll(
                    delegate(Predoc v) 
                    {
                        return v.Selected == true;
                    });*/

                //lambda - удаляем все выделенные объекты
                p.RemoveAll(pr => pr.Selected == true);
            }

            if (e.KeyCode == Keys.Escape)
            {
                p.Opened = false;
                p.RemoveAt(p.Count-1); //удаляет последний нарисованный объект
            }

        }

        private void MAP_MouseEnter(object sender, EventArgs e)
        {
            MAP.Focus();
        }

        void MAP_PreviewKeyDown(object sender, System.Windows.Forms.PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                for (int i = 0; i < p.Count; i++)
                {
                    if (p[i].Selected == true) 
                        p.RemoveAt(i);
                }
            }
            MAP.Invalidate();
        }

        private void mMAP_YZ_Click(object sender, EventArgs e)
        {
            p.PlaneVal.PLO = layer.Place.YZ;
            p.PlaneVal.ActChoi = true;
        }

        private void mSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog() { Filter = "*|*.trin"};
            if (sv.ShowDialog() == System.Windows.Forms.DialogResult.Cancel) return;

            using (System.IO.Stream serialStream = new System.IO.FileStream(sv.FileName, System.IO.FileMode.OpenOrCreate))
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formater =
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                formater.Serialize(serialStream, p);
            }
        }

    }
}
