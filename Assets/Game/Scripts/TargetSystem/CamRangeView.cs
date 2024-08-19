using System.Collections.Generic;
using UnityEngine;

namespace Game.VisionRange
{
    public class CameraRangeView : RangeView
    {

        public CameraRangeView(GameObject gameObject, float size) : base(gameObject, size)
        {
            Collider = GenerateCollider(gameObject, size);
        }

        protected override Collider GenerateCollider(GameObject gameObject, float size)
        {

            Mesh mesh = GenerateMesh(CameraRangeViewPoints());
            MeshCollider meshCollider;

            if (gameObject.TryGetComponent<MeshCollider>(out meshCollider))
            {
                meshCollider.sharedMesh = mesh;
            }
            else
            {
                meshCollider = gameObject.AddComponent<MeshCollider>();
                meshCollider.sharedMesh = mesh;
            }
            meshCollider.convex = true;
            meshCollider.isTrigger = true;
            meshCollider.enabled = true;
            return meshCollider;
        }

        private Vector3[] CameraRangeViewPoints()
        {
            Transform camTransform = Camera.main.transform;
            var frustumHeight = 2.0f * size * Mathf.Tan(Camera.main.fieldOfView * 0.5f * Mathf.Deg2Rad);
            var frustumWidth = frustumHeight * Camera.main.aspect;

            Quaternion quaternion = camTransform.rotation;
            Matrix4x4 matrix = camTransform.worldToLocalMatrix * Matrix4x4.Rotate(camTransform.rotation);
            Quaternion magnitude;

            if (camTransform.eulerAngles.y >= 0)
            {
                magnitude = new Quaternion(Mathf.Abs(quaternion.x), -quaternion.y, Mathf.Abs(quaternion.z), Mathf.Abs(quaternion.w));
            }

            else
            {
                magnitude = new Quaternion(Mathf.Abs(quaternion.x), Mathf.Abs(quaternion.y), Mathf.Abs(quaternion.z), Mathf.Abs(quaternion.w));
            }

            return new Vector3[] {
               (magnitude * camTransform.right * 1) * frustumWidth / 2 + (magnitude * camTransform.up * 1) * -frustumHeight / 2 + (magnitude * camTransform.forward * 1) * size,
               (magnitude * camTransform.right * 1) * -frustumWidth / 2 + (magnitude * camTransform.up * 1) * -frustumHeight / 2 + (magnitude * camTransform.forward * 1) * size,
               (magnitude * camTransform.right * 1)  * -frustumWidth / 2 + (magnitude * camTransform.up * 1) * frustumHeight / 2 + (magnitude * camTransform.forward * 1) * size,
               (magnitude * camTransform.right * 1) * frustumWidth / 2 + (magnitude * camTransform.up * 1)  * frustumHeight / 2 + (magnitude * camTransform.forward * 1) * size,
                Vector3.zero,

               //matrix.MultiplyPoint(camTransform.right) * frustumWidth / 2 + matrix.MultiplyPoint(camTransform.up) * -frustumHeight / 2 + matrix.MultiplyPoint(camTransform.forward) * size,
               //matrix.MultiplyPoint(camTransform.right) * -frustumWidth / 2 + matrix.MultiplyPoint(camTransform.up) * -frustumHeight / 2 + matrix.MultiplyPoint(camTransform.forward) * size,
               //matrix.MultiplyPoint(camTransform.right)  * -frustumWidth / 2 + matrix.MultiplyPoint(camTransform.up) * frustumHeight / 2 + matrix.MultiplyPoint(camTransform.forward) * size,
               //matrix.MultiplyPoint(camTransform.right) * frustumWidth / 2 + matrix.MultiplyPoint(camTransform.up)  * frustumHeight / 2 + matrix.MultiplyPoint(camTransform.forward) * size,
                //Vector3.zero,

               // Vector3.zero,
               //(camTransform.forward * 1) * size + (camTransform.up) * frustumHeight / 2 + (camTransform.right * 1)  * -frustumWidth / 2,
               //(camTransform.forward * 1) * size + (camTransform.up) * -frustumHeight / 2 + (camTransform.right * 1) * -frustumWidth / 2,
               //(camTransform.forward * 1) * size + (camTransform.up) * -frustumHeight / 2 + (camTransform.right * 1) * frustumWidth / 2,
               //(camTransform.forward * 1) * size + (camTransform.up)  * frustumHeight / 2 + (camTransform.right * 1) * frustumWidth / 2,

               //matrix.MultiplyVector((camTransform.rotation * camTransform.forward * 1) * size + (camTransform.rotation * camTransform.up) * frustumHeight / 2 + (camTransform.rotation *camTransform.right * 1)  * -frustumWidth / 2),
               //matrix.MultiplyVector((camTransform.rotation * camTransform.forward * 1) * size + (camTransform.rotation * camTransform.up) * -frustumHeight / 2 + (camTransform.rotation * camTransform.right * 1) * -frustumWidth / 2),
               //matrix.MultiplyVector((camTransform.rotation * camTransform.forward * 1) * size + (camTransform.rotation * camTransform.up) * -frustumHeight / 2 + (camTransform.rotation * camTransform.right * 1) * frustumWidth / 2),
               //matrix.MultiplyVector((camTransform.rotation * camTransform.forward * 1) * size + (camTransform.rotation * camTransform.up)  * frustumHeight / 2 + (camTransform.rotation * camTransform.right * 1) * frustumWidth / 2),
               // matrix.MultiplyVector(Vector3.zero), 
                
               // matrix.MultiplyVector((camTransform.forward * 1) * size + (camTransform.up) * frustumHeight / 2 + (camTransform.right * 1)  * -frustumWidth / 2),
               //matrix.MultiplyVector((camTransform.forward * 1) * size + (camTransform.up) * -frustumHeight / 2 + (camTransform.right * 1) * -frustumWidth / 2),
               //matrix.MultiplyVector((camTransform.forward * 1) * size + (camTransform.up) * -frustumHeight / 2 + (camTransform.right * 1) * frustumWidth / 2),
               //matrix.MultiplyVector((camTransform.forward * 1) * size + (camTransform.up)  * frustumHeight / 2 + (camTransform.right * 1) * frustumWidth / 2),
               // matrix.MultiplyVector(Vector3.zero),

            };
        }

        private Mesh GenerateMesh(Vector3[] points)
        {
            if (points == null || points.Length == 0)
            {
                Debug.LogWarning("points are empty.");
                return new Mesh();
            }


            Mesh mesh = new Mesh();
            List<Vector3> vertices = new List<Vector3>();

            vertices.AddRange(points);

            //list<int> triangles = new list<int>();

            //for (int i = 0; i < points.length - 2; i++)
            //{
            //    triangles.add(0);
            //    triangles.add(i + 1);
            //    triangles.add(i + 2);
            //}

            int[] triangles = new int[]
            {
                4, 4, 4,
                4, 4, 4,

                0, 3, 2,
                0, 2, 1,

                4, 4, 0,
                4, 0, 3,
                4, 2, 1,
                4, 1, 4,
                4, 3, 2,
                4, 2, 4,
                4, 4, 1,
                4, 1, 0,
            };

            mesh.vertices = vertices.ToArray();
            mesh.triangles = triangles;
            //mesh.triangles = triangles.ToArray();
            //foreach (var element in triangles.ToArray())
            //{
            //    Debug.Log(element);
            //}

            mesh.RecalculateNormals();
            mesh.RecalculateTangents();
            mesh.RecalculateBounds();
            return mesh;
        }


    }
}
