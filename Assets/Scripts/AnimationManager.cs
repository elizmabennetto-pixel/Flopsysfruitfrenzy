using UnityEngine;

public class AnimationManager : MonoBehaviour {
    private Animator animator;
    [SerializeField] private float animationSpeed = 1.0f;

    void Start() {
        animator = GetComponent<Animator>();
        if (animator == null) {
            Debug.LogError("Animator component not found on " + gameObject.name);
        }
    }

    public void PlayIdleAnimation() {
        if (animator != null) {
            animator.SetBool("IsWalking", false);
            animator.SetFloat("AnimSpeed", animationSpeed);
        }
    }

    public void PlayWalkAnimation(Vector3 direction) {
        if (animator != null) {
            animator.SetBool("IsWalking", true);
            animator.SetFloat("MoveX", direction.x);
            animator.SetFloat("MoveZ", direction.z);
            animator.SetFloat("AnimSpeed", animationSpeed);
        }
    }

    public void PlayCollectAnimation() {
        if (animator != null) {
            animator.SetTrigger("Collect");
            animator.SetFloat("AnimSpeed", animationSpeed);
        }
    }

    public void PlayCelebrationAnimation() {
        if (animator != null) {
            animator.SetTrigger("Celebrate");
            animator.SetFloat("AnimSpeed", animationSpeed);
        }
    }

    public void SetAnimationSpeed(float speed) {
        animationSpeed = speed;
        if (animator != null) {
            animator.SetFloat("AnimSpeed", animationSpeed);
        }
    }

    public string GetCurrentAnimationState() {
        if (animator != null) {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            return stateInfo.name;
        }
        return "None";
    }
}