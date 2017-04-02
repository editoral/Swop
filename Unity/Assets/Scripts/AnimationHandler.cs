using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler {
    private Animator _animator;

	public AnimationHandler(Animator animator)
    {
        _animator = animator;
    }

    public void directionHandling(float x, float y)
    {
        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            _animator.SetInteger("direction", (x > 0) ? 1 : 3);
        } else
        {
            _animator.SetInteger("direction", (y > 0) ? 0 : 2);
        }
    }
}
