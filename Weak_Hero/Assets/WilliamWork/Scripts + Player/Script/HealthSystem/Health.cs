using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
   [Header ("Health")]
   [SerializeField] private float startHealth;
   public float currentHealth { get; private set; }
   private Animator animate;
   public bool dead;

   [Header("iFrames")]
   [SerializeField] private float IframeDur;
   [SerializeField] private int FlashNum;
   private SpriteRenderer spriteRende;

   [SerializeField] private Behaviour[] components;
   private bool invulnerable;
   

   private void Awake()
   {
      currentHealth = startHealth;
      animate = GetComponent<Animator>();
      spriteRende = GetComponent<SpriteRenderer>();
   }

   public void Dmg(float _damage)
   {
      if (invulnerable) return;
      currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startHealth);

      if (currentHealth > 0)
      {
         //hit
         animate.SetTrigger("Hurt");
         StartCoroutine(Invulnerability());
      }
      else
      {
         if (!dead)
         {

            foreach (Behaviour component in components)
               component.enabled = false;
            
            //death
            animate.SetBool("Grounded", true);
            animate.SetTrigger("Death");
            GetComponent<playerMovement>().enabled = false;
            dead = true; 
         }
         }
      
   }

   
   public void Respawn()
   {
      dead = false;
      AddHealth(startHealth);
      animate.ResetTrigger("Death");
      animate.Play("Player_idle");
      
      

     foreach (Behaviour component in components)
         component.enabled = true;


   }

   public void AddHealth(float _value)
   {
      currentHealth = Mathf.Clamp(currentHealth + _value, 0, startHealth); 
   }

   private IEnumerator Invulnerability()
   {
      
      //invincible duration
      invulnerable = true;
      Physics2D.IgnoreLayerCollision(7,8, true);
      for (int i = 0; i < FlashNum; i++)
      {
         spriteRende.color = new Color(1,0,0,0.5f);
         yield return new WaitForSeconds(IframeDur / (FlashNum * 2));
         spriteRende.color = Color.gray;
         yield return new WaitForSeconds(IframeDur / (FlashNum * 2));

      }
     
      Physics2D.IgnoreLayerCollision(7,8, false);
      invulnerable = false;
   }


}
