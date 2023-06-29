using System;
using UnityEngine;
using UnityEngine.UI;


public class InputName : MonoBehaviour
{
    public InputField inputField1;
    
    public static string Name;

    public void Update()
    {
        Name = inputField1.text;
    }

    public void OnButtonClick()
    {
        
        
    }
}