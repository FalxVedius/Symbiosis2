using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCheck : MonoBehaviour
{
    public int lightNum;
    
    public Material isOn;
    public Material isActive;
    public Material isCorrect;

    public bool lightOn;
    public bool lightActive;
    public bool lightCorrect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOn()
    {
        GetComponent<Renderer>().material = isOn;
        lightOn = true;
    }

    public void TurnActive()
    {
        GetComponent<Renderer>().material = isActive;
        lightActive = true;
    }

    public void TurnCorrect()
    {
        GetComponent<Renderer>().material = isCorrect;
        lightCorrect = true;
    }
}
