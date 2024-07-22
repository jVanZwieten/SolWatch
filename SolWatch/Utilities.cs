﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Numerics;

namespace SolWatch
{
    public static class Utilities
    {
        public const float FullCircle = 2 * MathF.PI;
        public const float GravitationalParameter_Sol = 1.3271544e11f; // km^3/s^2

        public static float RadiansFromDegrees(float angleInDegrees) => angleInDegrees * MathF.PI / 180f;

        public static float NormalizeAngle(float angle)
        {
            while (angle < 0)
                angle += FullCircle;
            while (angle > FullCircle)
                angle -= FullCircle;

            return angle;
        }

        public static Vector2 Center(this Texture2D texture) => new(texture.Width / 2, texture.Height / 2);
    }
}
