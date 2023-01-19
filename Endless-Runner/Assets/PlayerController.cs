using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public AnimationClip newAnimation;
    public AnimationClip newAnimation2;
    private bool toggle = true;
    private int defaultLayer = 0;

    // Update is called once per frame
    void Start()
    {
        defaultLayer = animator.GetLayerIndex("Base Layer");
    }
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (toggle)
            {
                animator.Play(newAnimation.name);
            }
            else
            {
                animator.Play(newAnimation2.name);
            }
            toggle = !toggle;
        }
    }
    void OnAnimatorMove()
    {
        if(animator.IsInTransition(defaultLayer)) return;
        if(animator.GetCurrentAnimatorStateInfo(defaultLayer).normalizedTime >= 1)
        {
            animator.Play(animator.GetCurrentAnimatorClipInfo(defaultLayer)[0].clip.name, defaultLayer, 0f);
        }
    }
}
