﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlates : MonoBehaviour
{
    public GameObject disabledObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        disabledObject.gameObject.SetActive(false);
    }
}
