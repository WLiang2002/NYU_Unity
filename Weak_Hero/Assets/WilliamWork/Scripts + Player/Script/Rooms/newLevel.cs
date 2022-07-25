using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class newLevel : MonoBehaviour
{
  public int index;
  public string lvl;
  
  
  private void OnTriggerEnter2D(Collider2D col)
  {
    if (col.CompareTag("Player"))
    {
      SceneManager.LoadScene(index);
      SceneManager.LoadScene(lvl);
    }
  }
}
