using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlat : MonoBehaviour
{
    public int platNum;

    public bool lightOn;
    public bool lightCorrect;
    public bool lightDeactive;
    public bool raisedPlat;

    public Material isDeactive;
    public Material isOn;
    public Material isCorrect;
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
      if(raisedPlat)
            TutorialManager.instance.ReachedTopPlat();

        if (!raisedPlat && lightOn)
        {
            if(platNum == 1)
            {
                TutorialManager.instance.CheckFirstPlat();
            }
            else if(platNum == 2)
            {
                TutorialManager.instance.CheckSecondPlat();
            }
            else if(platNum == 3)
            {
                TutorialManager.instance.CheckThirdPlat();
            }
        }
        
    }

    public void TurnOn()
    {
        GetComponent<Renderer>().material = isOn;
        lightOn = true;
    }

    public void TurnCorrect()
    {
        GetComponent<Renderer>().material = isCorrect;
        lightCorrect = true;
    }

    public void TurnDeactive()
    {
        GetComponent<Renderer>().material = isDeactive;
        lightDeactive = true;
    }
}
