using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTargetDetector : MonoBehaviour
{
    [SerializeField][Min(0)] float maxDistance;

    private List<GameObject> testObjects = new List<GameObject>();
    private new Collider collider;
    Plane[] planes;


    private void FixedUpdate()
    {
        CalculateFrustum();
        if (testObjects.Count > 0) ChecktargetableObjects();
    }

    private void ChecktargetableObjects()
    {
        foreach (GameObject obj in testObjects)
        {
            collider = obj.GetComponent<Collider>();

            if (IsOnRange(collider))
            {
                GameEvents.Instance.TargetView(obj.GetComponent<Targetable>());
            }

            if (IsOnRange(collider) && Input.GetKey(KeyCode.Space))
            {
                GameEvents.Instance.TargetLock(obj.GetComponent<Targetable>());
            }

            if (!IsOnRange(collider))
            {
                GameEvents.Instance.TargetUnview(obj.GetComponent<Targetable>());
            }
        }
    }
    public bool IsOnRange(Collider collider)
    {

        if (GeometryUtility.TestPlanesAABB(planes, collider.bounds))
        {
            if (Vector3.Distance(Camera.main.transform.position, collider.transform.position) < maxDistance)
            {
                return true;
            }
        }

        return false;

    }

    private void CalculateFrustum()
    {
        planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
    }

    private void OnDrawGizmos()
    {
        Transform camTransform = Camera.main.transform;

        Gizmos.color = Color.yellow;
        //Line of Distance
        Gizmos.DrawLine(camTransform.position, camTransform.position + camTransform.forward * maxDistance);

        var frustumHeight = 2.0f * maxDistance * Mathf.Tan(Camera.main.fieldOfView * 0.5f * Mathf.Deg2Rad);
        var frustumWidth = frustumHeight * Camera.main.aspect;

        Vector3[] farPlanePoints =  {
           camTransform.position +camTransform.forward * maxDistance + camTransform.up * frustumHeight / 2 + camTransform.right * frustumWidth / 2,
           camTransform.position +  camTransform.forward * maxDistance + camTransform.up * -frustumHeight / 2 + camTransform.right * frustumWidth / 2,
           camTransform.position +  camTransform.forward* maxDistance +camTransform.up * -frustumHeight / 2 + camTransform.right * -frustumWidth / 2,
            camTransform.position +  camTransform.forward * maxDistance + camTransform.up * frustumHeight / 2 + camTransform.right * -frustumWidth / 2,

        };
        Gizmos.DrawLineStrip(farPlanePoints.AsSpan(), true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Targetable>() != null) testObjects.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        testObjects.Remove(other.gameObject);
    }
}
