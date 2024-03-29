using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Targetable : MonoBehaviour
{
    [SerializeField] private float targetableMarkOffset = 2;
    [SerializeField] private float targetMarkOffset = 2;
    private GameObject targetMark, targetableMark;

    private new MeshRenderer renderer;

    private void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        GameEvents.Instance.OnTargetView += BecomeTargetable;
        GameEvents.Instance.OnTargetLock += BecomeTargeted;
        GameEvents.Instance.OnTargetDeview += BecomeUntargetable;
        GameEvents.Instance.OnTargetRelease += BecomeUntargeted;
    }
  

    private void OnDisable()
    {
        GameEvents.Instance.OnTargetView -= BecomeTargetable;
        GameEvents.Instance.OnTargetLock -= BecomeTargeted;
        GameEvents.Instance.OnTargetDeview -= BecomeUntargetable;
        GameEvents.Instance.OnTargetRelease -= BecomeUntargeted;
    }

    public void BecomeTargetable(Targetable target)
    {
        if (target == this)
        {
            if (targetableMark == null)
            {
                targetableMark = Instantiate(Resources.Load("TargetableFeedback"),
                new Vector3(transform.position.x, transform.position.y + targetableMarkOffset, transform.position.z), transform.rotation) as GameObject;
            }

            UpdateMarkPosition(targetableMark, targetableMarkOffset, "y");

            Debug.Log("I´m TARGETABLE");
            renderer.material.color = Color.green;
        }
    }

    public void BecomeTargeted(Targetable target)
    {
        if (target == this)
        {
            if (targetMark == null)
            {
                targetMark = Instantiate(Resources.Load("TargetedFeedback"),
                new Vector3(transform.position.x, transform.position.y, transform.position.z - targetMarkOffset), transform.rotation) as GameObject;
            }

            UpdateMarkPosition(targetMark, targetMarkOffset, "z");

            Debug.Log("I´m TARGETED");

            renderer.sharedMaterial.color = Color.blue;
        }

    }

    private void UpdateMarkPosition(GameObject mark, float markOffset, string axis)
    {
        if (mark != null && axis == "z")
        {
            mark.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - targetMarkOffset);
        }

        if (mark != null && axis == "y")
        {
            mark.transform.position = new Vector3(transform.position.x, transform.position.y + targetableMarkOffset, transform.position.z);
        }

    }

    public void BecomeUntargeted(Targetable target)
    {
        if (target == this)
        {
            Debug.Log("i´m DETARGETED");
            Destroy(target.targetMark);
        }
    }

    public void BecomeUntargetable(Targetable target)
    {
        if (target == this)
        {
            Debug.Log("I´m OUT OF RANGE");
            Destroy(target.targetableMark);
            Destroy(target.targetMark);

            renderer.material.color = Color.black;
        }
    }
}
