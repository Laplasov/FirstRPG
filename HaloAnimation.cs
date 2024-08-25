using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;


public class HaloAnimation : MonoBehaviour
{
    private Vector3 startPosition;
    private GameObject[] taggedObjects;
    private int currentIndex = 0;
    private bool turgetChoosen = false;
    public TMP_Text mainText;
    public TMP_Text attackText;
    public TMP_Text defenceText; 
    public TMP_Text healthText;
    public Image targetMenuImage;
    private float initialAlpha;


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        taggedObjects = GameObject.FindGameObjectsWithTag("Target");
        initialAlpha = targetMenuImage.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        float sinValue = Mathf.Sin(Time.frameCount * Mathf.PI / 180f);
        Color initialColor = new Color(targetMenuImage.color.r, targetMenuImage.color.g, targetMenuImage.color.b, initialAlpha);

        if (!turgetChoosen) 
        { 
            HandleKeyPress(); 
        }
        else 
        {
            MenuHandler(sinValue, initialColor);
        }

        ArroyPosition(sinValue);

    }

    private void ArroyPosition(float sinValue)
    {
        GameObject currentTarget = taggedObjects[currentIndex];
        float xPos = currentTarget.transform.position.x;
        float zPos = currentTarget.transform.position.z;
        TextHandler();

        transform.position = new Vector3(xPos, startPosition.y + (sinValue / 3), zPos);
    }

    private void TextHandler()
    {
        mainText.text = taggedObjects[currentIndex].name;
        TargetStats targetScript = taggedObjects[currentIndex].GetComponent<TargetStats>();
        attackText.text = "Attack - " + targetScript.attack.ToString();
        defenceText.text = "Defence - " + targetScript.defence.ToString();
        healthText.text = "Health - " + targetScript.health.ToString();

    }

    private void HandleKeyPress()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            DecreaseIndex();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            IncreaseIndex();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(taggedObjects[currentIndex].name + " is selected!");
            turgetChoosen = true;
        }
    }

    private void DecreaseIndex()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
        }
        else
        {
            currentIndex = taggedObjects.Length - 1;
        }
    }

    private void IncreaseIndex()
    {
        if (currentIndex < taggedObjects.Length - 1)
        {
            currentIndex++;
        }
        else
        {
            currentIndex = 0;
        }
    }

    private void MenuHandler(float sinValue, Color initialColor) 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log(taggedObjects[currentIndex].name + " is deselected!");
            turgetChoosen = false;
            targetMenuImage.color = initialColor;
        } 
        else 
        { 
            float alphaSinValue = initialAlpha + (sinValue * sinValue / 2);
            Color newColor = new Color(targetMenuImage.color.r, targetMenuImage.color.g, targetMenuImage.color.b, alphaSinValue);
            targetMenuImage.color = newColor;
        }
}

}
