namespace Utilities
{
    public static class ArrayUtility
    {
        public static int GetRangeIndex(float value, float[] pos)
        {
            if (value < pos[0])
                return 4;
            if (value >= pos[0] && value < pos[1])
                return 3;
            if (value >= pos[1] && value < pos[2])
                return 2;
            if (value >= pos[2] && value < pos[3])
                return 1;
            if (value >= pos[3])
                return 0;
            return 5;
        }
    }
}