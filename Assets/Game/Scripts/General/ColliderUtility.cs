using System;
using UnityEngine;

namespace Game
{
    public static class ColliderUtil
    {
        public static bool IsTargetTag<T>(this GameObject gameObject, T enumValue) where T : Enum
        {
            //if (enumValue.ExistAsUnityTag()) return false;
            try
            {
                string tag = gameObject.tag;
                T tTag = (T)Enum.Parse(typeof(T), tag);
                return (Convert.ToInt32(tTag) & Convert.ToInt32(enumValue)) != 0;

            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Overlaps Capsule Collider Gizmos
        /// </summary>
        /// <param name="collider"></param>
        public static void DrawCapsuleGizmos(CapsuleCollider collider, Color color = default)
        {
            Gizmos.color = color;
            Bounds bounds = collider.bounds;

            float step = 0.2f;
            float r = Mathf.Min(bounds.size.x, bounds.size.y) / 2;
            float d = Mathf.Max(bounds.size.x, bounds.size.y) / 2 - r;
            Vector3 lp = Vector3.positiveInfinity;
            for (float i = -Mathf.PI; i <= Mathf.PI + step; i += step)
            {
                float x = Mathf.Cos(i);
                float y = Mathf.Sin(i);
                Vector3 np = new Vector3(x, y) * r + collider.center;
                np += (collider.direction == (int)CapsuleDirection2D.Horizontal ? Vector3.up : Vector3.zero) * d * Mathf.Sign(y);
                np += (collider.direction == (int)CapsuleDirection2D.Vertical ? Vector3.right : Vector3.zero) * d * Mathf.Sign(x);
                np = collider.transform.TransformPoint(np);
                if (lp != Vector3.positiveInfinity) Gizmos.DrawLine(lp, np);
                lp = np;
            }
        }

        public static void DrawCapsuleGizmos(GameObject go, Bounds bounds, Color color = default)
        {
            Gizmos.color = color;

            float step = 0.2f;
            float r = Mathf.Min(bounds.size.x, bounds.size.y) / 2;
            float d = Mathf.Max(bounds.size.x, bounds.size.y) / 2 - r;
            Vector3 lp = Vector3.positiveInfinity;
            for (float i = -Mathf.PI; i <= Mathf.PI + step; i += step)
            {
                float x = Mathf.Cos(i);
                float y = Mathf.Sin(i);
                Vector3 np = new Vector3(x, y) * r + bounds.center;
                np += Vector3.up * d * Mathf.Sign(y);
                np += Vector3.zero * d * Mathf.Sign(x);
                if (lp != Vector3.positiveInfinity) Gizmos.DrawLine(lp, np);
                lp = np;
            }
        }

    }
}




