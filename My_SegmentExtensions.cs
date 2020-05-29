﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GeometryPainting
{
    //Напишите здесь код, который заставит работать методы segment.GetColor и segment.SetColor
    public static class My_SegmentExtensions
    {
        static Dictionary<Segment, Color> dictionary = new Dictionary<Segment, Color>();
        public static void SetColor(this Segment segment, Color color)
        {
            if (dictionary.ContainsKey(segment))
            {
                dictionary[segment] = color;
            }
            else
            {
                dictionary.Add(segment, color);
            }
        }

        public static Color GetColor(this Segment segment)
        {
            if (dictionary.ContainsKey(segment))
            {
                return dictionary[segment];
            }
            return Color.Black;
        }
    }
}
