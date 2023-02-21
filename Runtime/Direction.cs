using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Direction
{
    public enum Direction8
    {
        UP, LeftUp, LEFT, LeftDown, DOWN, RightDown, RIGHT, RightUp
    }
    public enum Direction4
    {
        UP, LEFT, DOWN, RIGHT
    }

    public static class Direction
    {
        /// <summary>
        /// 角度のずれの絶対値 45度ごとに1
        /// </summary>
        public static int Angle(Direction4 dir1, Direction8 dir2)
        {
            var d1 = (int)dir1 * 2;

            return Angle((Direction8)d1, dir2);
        }
        /// <summary>
        /// 角度のずれの絶対値 45度ごとに1
        /// </summary>
        public static int Angle(Direction4 dir1, Direction4 dir2)
        {
            var d1 = (int)dir1 * 2;
            var d2 = (int)dir2 * 2;
            return Angle((Direction8)d1, (Direction8)d2);
        }
        /// <summary>
        /// 角度のずれの絶対値 45度ごとに1
        /// </summary>
        public static int Angle(Direction8 dir1, Direction8 dir2)
        {
            var d1 = (int)dir1;
            var d2 = (int)dir2;
            int res = Mathf.Min(Mathf.Abs(d1 - d2), Mathf.Abs(d1 - d2 + 8), Mathf.Abs(d1 - d2 - 8));

            return res;
        }

        public static Vector2 GetVector2(Direction4 direction)
        {
            switch (direction)
            {
                case Direction4.UP:
                    return Vector2.up;

                case Direction4.DOWN:
                    return Vector2.down;

                case Direction4.RIGHT:
                    return Vector2.right;

                case Direction4.LEFT:
                    return Vector2.left;
                default:
                    return Vector2.zero;
            }
        }

        public static Vector3 GetVector3(Direction4 direction)
        {
            switch (direction)
            {
                case Direction4.UP:
                    return Vector3.up;

                case Direction4.DOWN:
                    return Vector3.down;

                case Direction4.RIGHT:
                    return Vector3.right;

                case Direction4.LEFT:
                    return Vector3.left;
                default:
                    return Vector3.zero;
            }

        }

        public static Vector2 GetVector2(Direction8 direction, bool normalize = true)
        {
            Vector2 vector;
            switch (direction)
            {
                case Direction8.UP:
                    vector = Vector2.up;
                    break;
                case Direction8.LeftUp:
                    vector = Vector2.left + Vector2.up;

                    break;
                case Direction8.LEFT:
                    vector = Vector2.left;

                    break;
                case Direction8.LeftDown:
                    vector = Vector2.left + Vector2.down;

                    break;
                case Direction8.DOWN:
                    vector = Vector2.down;

                    break;
                case Direction8.RightDown:
                    vector = Vector2.right + Vector2.down;

                    break;
                case Direction8.RIGHT:
                    vector = Vector2.right;

                    break;
                case Direction8.RightUp:
                    vector = Vector2.right + Vector2.up;

                    break;
                default:
                    vector = Vector2.zero;
                    break;
            }

            if (normalize)
            {
                return vector / vector.magnitude;
            }
            else
            {
                return vector;
            }
        }


        public static Vector3Int GetVector3Int(Direction8 direction)
        {
            switch (direction)
            {
                case Direction8.UP:
                    return Vector3Int.up;
                    break;
                case Direction8.LeftUp:
                    return Vector3Int.left + Vector3Int.up;

                    break;
                case Direction8.LEFT:
                    return Vector3Int.left;

                    break;
                case Direction8.LeftDown:
                    return Vector3Int.left + Vector3Int.down;

                    break;
                case Direction8.DOWN:
                    return Vector3Int.down;

                    break;
                case Direction8.RightDown:
                    return Vector3Int.right + Vector3Int.down;

                    break;
                case Direction8.RIGHT:
                    return Vector3Int.right;

                    break;
                case Direction8.RightUp:
                    return Vector3Int.right + Vector3Int.up;

                    break;
                default:
                    return Vector3Int.zero;
                    break;
            }
        }




        public static Vector2Int GetVector2Int(Direction4 direction)
        {
            switch (direction)
            {
                case Direction4.UP:
                    return Vector2Int.up;

                case Direction4.DOWN:
                    return Vector2Int.down;

                case Direction4.RIGHT:
                    return Vector2Int.right;

                case Direction4.LEFT:
                    return Vector2Int.left;
                default:
                    return Vector2Int.zero;
            }
        }

        public static Vector2Int GetVector2Int(Direction8 direction)
        {
            switch (direction)
            {
                case Direction8.UP:
                    return Vector2Int.up;

                    break;
                case Direction8.LeftUp:
                    return Vector2Int.up + Vector2Int.left;

                    break;
                case Direction8.LEFT:
                    return Vector2Int.left;

                    break;
                case Direction8.LeftDown:
                    return Vector2Int.left + Vector2Int.down;

                    break;
                case Direction8.DOWN:
                    return Vector2Int.down;

                    break;
                case Direction8.RightDown:
                    return Vector2Int.down + Vector2Int.right;

                    break;
                case Direction8.RIGHT:
                    return Vector2Int.right;

                    break;
                case Direction8.RightUp:
                    return Vector2Int.up + Vector2Int.right;

                    break;
                default:
                    return Vector2Int.zero;

                    break;
            }
        }


        public static Direction4 Reverse(Direction4 dir)
        {
            return (Direction4)(((int)dir + 2) % 4);
        }


        public enum CorrectionMode
        {
            Clockwise,
            CounterClockwise,
        }

        public static Direction8 toDir8(this Direction4 dir)
        {
            return (Direction8)((int)dir * 2);
        }
        public static Direction4 toDir4(this Direction8 dir, CorrectionMode correctionMode)
        {
            switch (dir)
            {
                case Direction8.UP:
                case Direction8.RIGHT:
                case Direction8.LEFT:
                case Direction8.DOWN: 
                   return (Direction4)((int)dir /2);

                case Direction8.LeftUp:
                case Direction8.LeftDown:
                case Direction8.RightDown:
                case Direction8.RightUp:
                    switch (correctionMode)
                    {
                        case CorrectionMode.Clockwise:
                            return (Direction4)(((int)(dir+9) / 2)%8);
                        case CorrectionMode.CounterClockwise:
                            return (Direction4)(((int)(dir + 7) / 2) % 8);
                    }
                    break;
            }
            return (Direction4)((int)dir / 2);


        }
        public static Direction8 Reverse(Direction8 dir)
        {
            return (Direction8)(((int)dir + 4) % 8);
        }
    }

}

