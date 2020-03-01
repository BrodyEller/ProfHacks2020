using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdminLogin : MonoBehaviour
{
    public InputField userNameField;
    public InputField passwordField;
    public Button loginButton;

    void Start()
    {
        loginButton.onClick.AddListener(adminDetails);
    }

    Dictionary<string, string> staffDetails = new Dictionary<string, string>
    {
        {"test@gamedev.com", "1234"},
        {"test@students.rowan.edu", "1234"},
        {"test@gmail.com","1234" },
        {"test@yahoo.com","1234" },
        {"test@rowan.edu","1234" }
    };


    public void adminDetails()
    {
        string foundPassword;
        if (staffDetails.TryGetValue(userNameField.text, out foundPassword) && (foundPassword == passwordField.text))
        {
            Debug.Log("User authenticated");
        }
        else
        {
            
            Debug.Log("Invalid password");
        }
    }
}
