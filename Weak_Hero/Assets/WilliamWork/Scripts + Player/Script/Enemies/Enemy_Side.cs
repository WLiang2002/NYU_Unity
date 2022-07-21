using System;
using UnityEngine;

public class Enemy_Side : MonoBehaviour
{
    [SerializeField] private float dmg;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().Dmg(dmg);
        }
    }
}
