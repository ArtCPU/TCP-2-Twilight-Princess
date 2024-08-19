using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Targetable : MonoBehaviour
{
    private GameObject targetMark, targetableMark;

    private new MeshRenderer renderer;

    private void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    //private void Start()
    //{
    //    GameEvents.Instance.OnTargetView += BecomeTargetable;
    //    GameEvents.Instance.OnTargetLock += BecomeTargeted;
    //    GameEvents.Instance.OnTargetDeview += BecomeUntargetable;
    //    GameEvents.Instance.OnTargetRelease += BecomeUntargeted;
    //}


    //private void OnDisable()
    //{
    //    GameEvents.Instance.OnTargetView -= BecomeTargetable;
    //    GameEvents.Instance.OnTargetLock -= BecomeTargeted;
    //    GameEvents.Instance.OnTargetDeview -= BecomeUntargetable;
    //    GameEvents.Instance.OnTargetRelease -= BecomeUntargeted;
    //}

    //public void BecomeTargetable(Targetable target)
    //{
    //    //UpdateMarkPosition(targetableMark, targetableMarkOffset, "y");
    //    //if (target == this)
    //    //renderer.material.color = Color.green;
    //}
    //public void BecomeTargeted(Targetable target)
    //{
    //    if (target == this)

    //        //UpdateMarkPosition(targetMark, targetMarkOffset, "z");
    //    renderer.sharedMaterial.color = Color.blue;
    //}

    //private void UpdateMarkPosition(GameObject mark, float markOffset, string axis)
    //{
    //    if (mark != null && axis == "z")
    //    {
    //        mark.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - targetMarkOffset);
    //    }

    //    if (mark != null && axis == "y")
    //    {
    //        mark.transform.position = new Vector3(transform.position.x, transform.position.y + targetableMarkOffset, transform.position.z);
    //    }

    //}

    //public void BecomeUntargeted(Targetable target)
    //{
    //    if (target == this)
    //    {
    //        //Debug.Log("i´m DETARGETED");

    //        //Destroy(target.targetMark);
    //    }
    //}

    //public void BecomeUntargetable(Targetable target)
    //{
    //    if (target == this)
    //    {
    //        //Debug.Log("I´m OUT OF RANGE");

    //        //Destroy(target.targetableMark);
    //        //Destroy(target.targetMark);

    //        //renderer.material.color = Color.black;
    //    }
    //}
}
