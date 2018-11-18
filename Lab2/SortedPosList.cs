using System;
using System.Collections.Generic;

namespace Lab2
{
    internal class SortedPosList
    {

        // Props
        private List<Position> positionList;
        public List<Position> PositionList
        {
            get
            {
                if (positionList == null)
                {
                    return new List<Position>();
                }
                return positionList;
            }

            set 
            {
                positionList = value;
            }
        }

        // Constructor
        public SortedPosList() 
        {
            positionList = new List<Position>();
        }

        //public SortedPosList(string filePath)
        //{
        //    positionList = new List<Position>();
        //}

        // Methods

        public int Count()
        {
            return positionList.Count;
        }



        public void Add(Position pos)
        {
            double posLength = pos.Length();
            for (int i = 0; i < positionList.Count; i++) 
            {
                if (posLength < positionList[i].Length())
                {
                    positionList.Insert(i, pos);
                    return;
                }
            }

            PositionList.Add(pos);
        }

        public bool Remove(Position pos)
        {
            for (int i = 0; i < positionList.Count; i++)
            {
                if (positionList[i].Equals(pos))
                {
                    positionList.Remove(positionList[i]);
                    return true;
                }
            }

            return false;
        }

        public SortedPosList Clone() 
        {
            SortedPosList clonedList = new SortedPosList();
            for (int i = 0; i < positionList.Count; i++)
            {
                clonedList.Add(positionList[i].Clone());
            }
            return clonedList;
        }

        public SortedPosList CircleContent(Position centerPos, double radius)
        {
            SortedPosList circleList = new SortedPosList();
            for (int i = 0; i < positionList.Count; i++)
            {
                double diameter = Math.Pow(positionList[i].X - centerPos.X, 2) + Math.Pow(positionList[i].Y - centerPos.Y, 2);
                double squareRoot = Math.Pow(radius, 2);

                if (diameter < squareRoot)
                {
                    circleList.Add(positionList[i].Clone());
                }

            }
            return circleList;
        }

        public override string ToString()
        {
            return string.Join(", ", positionList);
        }

        public static SortedPosList operator + (SortedPosList sp1, SortedPosList sp2)
        {
            SortedPosList clonedList = sp1.Clone();
            for (int i = 0; i < sp2.Count(); i++)
            {
                clonedList.Add(sp2[i].Clone());
            }
            return clonedList;
        }

        public Position this[int i]
        {
            get => positionList[i];
        }
    }
}