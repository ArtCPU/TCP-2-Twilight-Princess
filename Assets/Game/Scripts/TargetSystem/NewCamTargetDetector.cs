using System.Collections;
using UnityEngine;
namespace Game.VisionRange
{
    public class CamTargetDetector : TargetDetector
    {
        [SerializeField][Min(1)] protected float maxDistance = 10;
        [SerializeField][Min(1f)] protected float delayColliderGeneration = 0;
        public float MaxDistance => maxDistance;
        private Camera cam;
        private RangeView rangeView = null;
        public RangeView RangeView => rangeView;

        private void Awake()
        {
            cam = GetComponent<Camera>();
        }
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(delayColliderGeneration);
            RangeView rangeView = new CameraRangeView(cam.gameObject, maxDistance);
            SetRangeView(rangeView);
        }


        public void SetRangeView(RangeView rangeView)
        {
            this.rangeView = rangeView;
            rangeCollider = rangeView.RegenerateCollider();
            RemoveDuplicatedColliders(rangeView.GameObject, rangeCollider);
        }

        public void SetMaxDistance(float maxDistance)
        {
            this.maxDistance = maxDistance;
            rangeCollider = rangeView.RegenerateCollider(maxDistance);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Camera cam;
            if (this.cam == null) cam = Camera.main;
            else cam = this.cam;
            Gizmos.DrawLine(cam.transform.position, cam.transform.position + cam.transform.forward * maxDistance);
        }
    }
}







