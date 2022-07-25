using UnityEngine;

public class playerRespawn : MonoBehaviour
{
  
   private Transform currentCheck;
   private Health playerHealth;

   private void Awake()
   {
      playerHealth = GetComponent<Health>();
   }

   public void Respawn()
   {
      playerHealth.Respawn();
      transform.position = currentCheck.position;
      //return;
     
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.transform.tag == "Checkpoint")
      {
         currentCheck = collision.transform;
         collision.GetComponent<Collider2D>().enabled = false;
         collision.GetComponent<Animator>().SetTrigger("Reached");
      }
   }
   
}
