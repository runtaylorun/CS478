using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class Combat : MonoBehaviour
{

    public GameObject arrowPrefab;
    public float shootCooldown = 0.7f;
    public float arrowVelocity = 6f;
    public AudioSource shootSound;

    private float nextShoot = 0;
    private Transform playerTransform;
    private Animator playerAnimator;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerTransform = GetComponent<Transform>();
    }

    public void OnFire(InputValue value)
    {
        if (Time.time > nextShoot && !playerAnimator.GetBool("isClimbing") && !playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Passing") && Time.timeScale == 1f)
        {
            shootSound.Play();
            nextShoot = Time.time + shootCooldown;

            playerAnimator.SetTrigger("shoot");

            bool playerFacingLeft = playerTransform.localScale.x == -1;
            GameObject arrow = Instantiate(
                  arrowPrefab,
                  new Vector3(playerTransform.position.x + (0.5f * playerTransform.localScale.x), playerTransform.position.y - 0.3f, 0),
                  new Quaternion(0, playerFacingLeft ? 180 : 0, 0, 1)
                  );

            arrow.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(playerFacingLeft ? arrowVelocity * -1 : arrowVelocity, 0));
        }
    }
}
