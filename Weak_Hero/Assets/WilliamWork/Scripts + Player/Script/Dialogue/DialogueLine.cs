using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueLine : IntroDialogue
{
    private Text textHolder;
    
    [Header("Text")]
    [SerializeField] string input;
    [SerializeField] private Color textColor;
    [SerializeField] private Font textFont;

    [Header("Time Para")] 
    [SerializeField] private float delay;
    
    [Header("Sound")] 
    [SerializeField] private AudioClip sound;
    
    [Header("Image")] 
    [SerializeField] private Sprite charSprite; 
    [SerializeField] private Image ImgHolder;
    
    private void Awake()
    {
        textHolder = GetComponent<Text>();
        textHolder.text = "";

        ImgHolder.sprite = charSprite;
        ImgHolder.preserveAspect = true;
    }

    private void Start()
    {
        StartCoroutine(WriteText(input, textHolder, textColor, textFont, delay, sound));
    }
}

