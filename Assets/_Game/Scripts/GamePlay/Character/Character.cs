using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected Rigidbody rb;
    [SerializeField] private Animator anim;

    private string currentAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void OnInit()
    {

    }

    private void OnDeath()
    {

    }

    protected void ChangeAnim(string animName)
    {
        if (currentAnim != animName)
        {
            anim.ResetTrigger(currentAnim);
            currentAnim = animName;
            anim.SetTrigger(currentAnim);
        }
    }

    protected void OnMoveStop()
    {
        rb.velocity = Vector3.zero;
        ChangeAnim(Constants.ANIM_IDLE);
    }

    protected virtual void OnAttack()
    {

    }

    private void FindTarget()
    {
    }
}
