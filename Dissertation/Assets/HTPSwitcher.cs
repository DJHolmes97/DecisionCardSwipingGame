using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HTPSwitcher : MonoBehaviour
{
    [SerializeField] private Sprite page1;
    [SerializeField] private Sprite page2;
    [SerializeField] private Sprite page3;
    [SerializeField] private Sprite page4;
    [SerializeField] private Sprite page5;
    [SerializeField] private Sprite page6;
    [SerializeField] private Sprite page7;
    [SerializeField] private Sprite page8;

    [SerializeField] private Image imageRenderer;

    private int index;

    public void Start()
    {
        imageRenderer.sprite = page1;
        index = 0;
    }

    public void Update()
    {
        switch (index)
        {
            case 0:
                imageRenderer.sprite = page1;
                break;
            case 1:
                imageRenderer.sprite = page2;
                break;
            case 2:
                imageRenderer.sprite = page3;
                break;
            case 3:
                imageRenderer.sprite = page4;
                break;
            case 4:
                imageRenderer.sprite = page5;
                break;
            case 5:
                imageRenderer.sprite = page6;
                break;
            case 6:
                imageRenderer.sprite = page7;
                break;
            case 7:
                imageRenderer.sprite = page8;
                break;
        }
    }

    public void OnBack()
    {
        index--;
        if (index < 0)
        {
            SceneManager.LoadScene(0);
        }

    }

    public void OnNext()
    {
        index++;
        if (index > 7)
        {
           SceneManager.LoadScene(0);
        }
    }

    public void OnExit()
    {
        SceneManager.LoadScene(0);
    }

}
