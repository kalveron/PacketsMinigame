using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Packets
{
    public static class ListExtensions
    {
        public static T Next<T>(this IList<T> list, int index)
        {
            return  index + 1 >= list.Count ? list[0] : list[index +1];          
        }
        public static T Previous<T>(this IList<T> list, int index)
        {
            return index - 1 >= 0 ? list[index - 1] : list[list.Count - 1];
        }

        public static T GetRandomItem<T>(this IList<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }

        public static T GetRandomItemAndRemove<T>(this IList<T> list)
        {
            int index = Random.Range(0, list.Count);
            list.RemoveAt(index);

            return list[index];
        }
    }
    public static class Vector3Extensions
    {
        public static Vector3 WithX(this Vector3 v, float x)
        {
            return new Vector3(x, v.y, v.z);
        }

        public static Vector3 WithY(this Vector3 v, float y)
        {
            return new Vector3(v.x, y, v.z);
        }
        public static Vector3 WithZ(this Vector3 v, float z)
        {
            return new Vector3(v.x, v.y, z);
        }
    }

}