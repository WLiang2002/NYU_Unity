using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public float moveSpeed = 1;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("moveX", moveX);

        bool IsMoving = !Mathf.Approximately(moveX, 0f);
        
        animator.SetBool("IsMoving", IsMoving);




        var move = Input.GetAxis("Hortizontal");
        transform.position += new Vector3(move, 0, 0) * Time.deltaTime * moveSpeed;
    }
}
