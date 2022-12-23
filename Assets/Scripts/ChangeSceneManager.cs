using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneManager : MonoBehaviour
{
    public static ChangeSceneManager Instance;
    public Action OnChangeBackScene;
    private void Awake()
    {
        if (!Instance)
            Instance = this;
    }   
}
