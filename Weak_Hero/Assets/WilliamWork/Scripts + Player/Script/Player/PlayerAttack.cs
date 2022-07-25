
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   [SerializeField] private float attackCD;
   [SerializeField] private Transform bulletPoint;
   [SerializeField] private GameObject[] bullets;
   private Animator animate;
   private playerMovement PlayerMovement;
   private float CDTimer = Mathf.Infinity;

   private void Awake()
   {
      animate = GetComponent<Animator>();
      PlayerMovement = GetComponent<playerMovement>();
   }

   private void Update()
   {
      if (Input.GetKey(KeyCode.J) && CDTimer > attackCD && PlayerMovement.canAttack())
         Attack();

      CDTimer += Time.deltaTime;
      
   }
   

   private void Attack()
   {
      animate.SetTrigger("Attack");
      CDTimer = 0;

      bullets[FindBullet()].transform.position = bulletPoint.position;
      bullets[FindBullet()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));

   }


  private int FindBullet()
   {
      for (int i = 0; i < bullets.Length; i++)
      {
         if (!bullets[i].activeInHierarchy)
            return i;
      }

      return 0;
   }
   
}
