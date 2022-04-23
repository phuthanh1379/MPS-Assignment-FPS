using System;
using UnityEngine;

namespace Scripts.Characteristics
{
    public class HitPoint
    {
        public int CurrentPoint { get; set; }
        public int MaxPoint { get; set; }

        public HitPoint(int currentPoint, int maxPoint)
        {
            CurrentPoint = currentPoint;
            MaxPoint = maxPoint;
        }
    }
}