using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentAnimationBehaviour : StateMachineBehaviour
{
    private float animationTime = 0f;

    private bool hasEntered = false;

    override public void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        // Use hasEntered as a one-call-buffer check to only respond upon 
        // the first OnStateEnter call, not the one thats spurred on from the animator.Play() call
        // below.
        if ( !hasEntered )
        {
            hasEntered = true;
            animator.Play(stateInfo.fullPathHash, layerIndex, this.animationTime);
        }
        else {
            hasEntered = false;
        }
    }

    override public void OnStateExit( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        this.animationTime = stateInfo.normalizedTime;
    }
}
