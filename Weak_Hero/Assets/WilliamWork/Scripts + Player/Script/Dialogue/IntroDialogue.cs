using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IntroDialogue : MonoBehaviour
{
    public bool finish { get; private set; }
 protected IEnumerator WriteText(string input, Text textHolder, Color textColor, Font textFont, float delay, AudioClip sound)
 {
     textHolder.color = textColor;
     textHolder.font = textFont;
     
     for (int i = 0; i < input.Length; i++)
     {
         textHolder.text += input[i];
         //SoundManager.instance.PlaySound(sound);
         yield return new WaitForSeconds(delay);
     }

     yield return new WaitUntil((() => Input.GetMouseButton(0))); 
     finish = true;
 }
}
