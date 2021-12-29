namespace System;

internal static class MathEx
{
    #region degree <-> radian
    private const double factorDegreeToRadian = Math.PI / 180.0;
    private const double factorRadianToDegree = 180.0 / Math.PI;

    public static double ToRadian(double degree) => degree * factorDegreeToRadian;
    public static double ToDegree(double radian) => radian * factorRadianToDegree;

    public static float ToRadian(float degree) => (float)(degree * factorDegreeToRadian);
    public static float ToDegree(float radian) => (float)(radian * factorRadianToDegree);
    #endregion

    #region GCD, LCM
    /// <summary>
    /// Greatest common divisor of two integer, using Euclidean algorithm
    /// </summary>
    public static int GCD(int a, int b)
    {
        var min = Math.Min(a, b);
        var max = Math.Max(a, b);
        var reminder = max % min;
        return reminder == 0 ? min : GCD(min, reminder);
    }

    /// <summary>
    /// Least common multiple of two integer
    /// </summary>
    public static int LCM(int a, int b) => a * b / GCD(a, b);
    #endregion
}

