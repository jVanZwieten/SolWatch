using System;

namespace SolWatch
{
    public static class Utilities
    {
        public static float RadiansFromDegrees(float angleInDegrees) => angleInDegrees * MathF.PI / 180f;
    }
}
