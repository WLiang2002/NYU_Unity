using System;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
        [SerializeField] private float healthVal;

        private void OnTriggerEnter2D(Collider2D collision)
        {
                if (collision.tag == "Player")
                {
                        collision.GetComponent<Health>().AddHealth(healthVal);
                gameObject.SetActive(false);
                }
        }
}
