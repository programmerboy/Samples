using System.Collections.Generic;

namespace Basics
{
    public class Comparer
    {
        public Comparer(int h, int l, int w)
        {
            Height = h;
            Length = l;
            this.Width = w;
        }

        public int Height { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }

        public override string ToString()
        {
            return string.Format("(Height: {0}, Length: {1}, Width: {2})", Height, Length, Width);
        }
    }

    class BoxSameVolume : EqualityComparer<Comparer>
    {
        public override bool Equals(Comparer b1, Comparer b2)
        {
            if (b1 == null && b2 == null)
                return true;
            else if (b1 == null || b2 == null)
                return false;

            if (b1.Height * b1.Width * b1.Length ==
                  b2.Height * b2.Width * b2.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode(Comparer bx)
        {
            int hCode = bx.Height * bx.Length * bx.Width;
            return hCode.GetHashCode();
        }
    }

    class BoxSameDimensionsComparer : IEqualityComparer<Comparer>
    {
        public bool Equals(Comparer b1, Comparer b2)
        {
            if (b2 == null && b1 == null)
                return true;
            else if (b1 == null | b2 == null)
                return false;
            else if (b1.Height == b2.Height && b1.Length == b2.Length && b1.Width == b2.Width)
                return true;
            else
                return false;
        }

        public int GetHashCode(Comparer bx)
        {
            int hCode = bx.Height ^ bx.Length ^ bx.Width;
            return hCode.GetHashCode();
        }
    }
}
