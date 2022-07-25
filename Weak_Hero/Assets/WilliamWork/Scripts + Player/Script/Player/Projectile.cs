
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit;
    private Animator animate;
    private CircleCollider2D cirCollider;
    private float life;
   
    


    private void Awake()
    {
        animate = GetComponent<Animator>();
        cirCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed,0,0);

        life += Time.deltaTime;
        if (life > 5) gameObject.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        cirCollider.enabled = false;
        animate.SetTrigger("Explode");
    }

    public void SetDirection(float _direction)
    {
        life = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        cirCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if(Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
    gameObject.SetActive(false);
    }
}
