
using System;
using UnityEngine;

public class UserInteraction : MonoBehaviour
{
    Animator myAnimator;
    float bendAnimationLength;
    public Energy energy;
    public Vector3 originalTop;
    public Transform topJoint;

    void Start()
    {
        originalTop = topJoint.position;
        myAnimator = GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        myAnimator.SetBool("UserTapping", true);

        // HACK: For some unknown reason, the length I receive is the half of the actual clip duration.
        var blendClipInfo = myAnimator.GetCurrentAnimatorStateInfo(0);
        var clipLength = blendClipInfo.length * 2 * blendClipInfo.speed;

        Invoke("Break", clipLength);
    }
    void OnMouseUp()
    {
        CancelInvoke("Break");
        myAnimator.SetBool("UserTapping", false);
        if (energy != null)
            energy.Launch(originalTop - topJoint.position);

        GetComponent<Collider>().enabled = false;
    }

    public void Break()
    {
        Debug.LogWarning("Break");
    }

}
