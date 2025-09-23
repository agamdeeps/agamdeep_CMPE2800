using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ReviewLab
{
    public enum handTypes { Rock, Paper, Scissors };

    public struct Hand
    {
        public Color handColor;
        public Point handPosition;
        public handTypes type;

        public Hand(Color _hColor, Point _hPosition, handTypes hType) 
        { 
            handColor = _hColor;
            handPosition = _hPosition;
            type = hType;
        }
        
        public static handOverlap()
        {

        }
    }
}
