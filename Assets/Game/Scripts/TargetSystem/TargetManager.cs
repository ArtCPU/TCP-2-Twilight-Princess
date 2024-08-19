using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Game;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TargetManager : MonoBehaviour
{
    [SerializeField] private TargetDetector targetDetector;
    [SerializeField] private Image warningTargetImage;
    [SerializeField] private Image lockOnTargetImage;
    [SerializeField] private CinemachineFreeLook liveCamera;

    private Camera mainCamera;
    int closestIndex;
    private int targetIndex;
    public Collider ClosestTarget { get; private set; }
    public Collider LockedTarget { get; private set; }
    public List<Collider> Targets => targetDetector.Targets;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        UpdateClosestTarget();
        //UpdateLockOnTarget();
    }

    private void OnEnable()
    {
        targetDetector.OnTargetEnter += WarnClosestTarget;
    }

    private void WarnClosestTarget(Collider target)
    {
        UpdateClosestTarget();
        UpdateTargetWarning();
    }

    public void WarnTarget()
    {
        lockOnTargetImage.gameObject.SetActive(false);
        warningTargetImage.gameObject.SetActive(true);
        warningTargetImage.transform.position = mainCamera.WorldToScreenPoint(ClosestTarget.transform.position + Vector3.up * ClosestTarget.bounds.size.y / 1.5f);
    }

    public void LockOnTarget()
    {
        warningTargetImage.gameObject.SetActive(false);
        lockOnTargetImage.gameObject.SetActive(true);
        if (LockedTarget == null)
        {
            targetIndex = closestIndex;
            LockedTarget = ClosestTarget;
        }

        lockOnTargetImage.transform.position = mainCamera.WorldToScreenPoint(LockedTarget.transform.position + Vector3.up * LockedTarget.bounds.size.y / 1.5f);
    }

    public void ReleaseTarget()
    {
        lockOnTargetImage.gameObject?.SetActive(false);
        warningTargetImage.gameObject.SetActive(true);
        LockedTarget = null;
    }

    private void UpdateClosestTarget()
    {
        if (targetDetector.Targets.Count < 1) return;


        if (targetDetector.Targets.Count > 1)
        {
            if (ClosestTarget == null) ClosestTarget = targetDetector.Targets[0];
            float distance = 0f;
            float smallestDistance = (targetDetector.Targets[0].transform.position - transform.position).magnitude;
            closestIndex = 0;

            for (int i = 0; i < targetDetector.Targets.Count; i++)
            {
                distance = (targetDetector.Targets[i].transform.position - transform.position).magnitude;
                if (distance < smallestDistance)
                {
                    smallestDistance = distance;
                    closestIndex = i;
                }
            }
            ClosestTarget = targetDetector.Targets[closestIndex];
            UpdateTargetWarning();
            return;
        }

        ClosestTarget = targetDetector.Targets[0];
        closestIndex = 0;
        UpdateTargetWarning();
    }

    private void UpdateTargetWarning()
    {
        if (!warningTargetImage.gameObject.activeSelf || ClosestTarget == null) return;
        if (LockedTarget == null) WarnTarget();

    }

    public void UpdateNextTargetWarning()
    {
        if (!warningTargetImage.gameObject.activeSelf || LockedTarget == null) return;
        WarnNextTarget();
    }

    public void UpdateLockOnTarget()
    {
        if (!lockOnTargetImage.gameObject.activeSelf || LockedTarget == null) return;
        LockOnTarget();
    }

    public void LockOnNextTarget()
    {
        if (targetDetector.Targets.Count < 2)
        {
            targetIndex = 0;
            LockedTarget = targetDetector.Targets[targetIndex];
            LockOnTarget();
            return;
        }

        if (targetDetector.Targets.Count - 1 > targetIndex)
        {
            targetIndex++;
            LockedTarget = targetDetector.Targets[targetIndex];
            LockOnTarget();
            return;
        }

        if (targetDetector.Targets.Count - 1 == targetIndex)
        {
            targetIndex = 0;
            LockedTarget = targetDetector.Targets[targetIndex];
            LockOnTarget();
        }
    }

    public void WarnNextTarget()
    {
        lockOnTargetImage.gameObject.SetActive(false);
        warningTargetImage.gameObject.SetActive(true);
        warningTargetImage.transform.position = mainCamera.WorldToScreenPoint(LockedTarget.transform.position + Vector3.up * LockedTarget.bounds.size.y / 1.5f);
    }

    public void LookAtTarget(Transform target)
    {
        liveCamera.LookAt = target;
        transform.LookAt(target);
    }

    public void LookAtPlayer()
    {
        liveCamera.LookAt = transform;
    }

    private void OnDisable()
    {
        targetDetector.OnTargetEnter -= WarnClosestTarget;
    }



}
