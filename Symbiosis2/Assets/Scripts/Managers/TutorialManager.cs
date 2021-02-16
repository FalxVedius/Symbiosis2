using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance;

    public bool lightsOn;
    public bool firstLight;
    public bool secondLight;
    public bool thirdLight;
    public bool activePlat;
    public bool reachedPlat;
    public bool openVent;

    public GameObject[] tutLights = new GameObject[3];
    public GameObject tutPlatforms;
    public GameObject tutVent;

    private Animator platAnim;
    private Animator ventAnim;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        platAnim = tutPlatforms.GetComponent<Animator>();
        ventAnim = tutVent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!lightsOn)
            {
                for (int i = 0; i < tutLights.Length; i++)
                {
                    tutLights[i].GetComponent<LightCheck>().TurnOn();
                    lightsOn = true;
                }
                tutLights[0].GetComponent<LightCheck>().TurnActive();
            }
            /*else if (!firstLight && !tutLights[0].GetComponent<LightCheck>().lightActive)
            {
                tutLights[0].GetComponent<LightCheck>().TurnActive();
            }
            else if (!firstLight)
            {
                tutLights[0].GetComponent<LightCheck>().TurnCorrect();
                firstLight = true;
            }
            else if (!secondLight && !tutLights[1].GetComponent<LightCheck>().lightActive)
            {
                tutLights[1].GetComponent<LightCheck>().TurnActive();
            }
            else if (!secondLight)
            {
                tutLights[1].GetComponent<LightCheck>().TurnCorrect();
                secondLight = true;
            }
            else if (!thirdLight && !tutLights[2].GetComponent<LightCheck>().lightActive)
            {
                tutLights[2].GetComponent<LightCheck>().TurnActive();
            }
            else if (!thirdLight)
            {
                tutLights[2].GetComponent<LightCheck>().TurnCorrect();
                thirdLight = true;
            }*/
            else if (!activePlat)
            {
                platAnim.SetBool("isActive", true);
                activePlat = true;
            }
            else if (!reachedPlat)
            {
                platAnim.SetBool("isActive", false);
                reachedPlat = true;
            }
            else if (!openVent)
            {
                ventAnim.SetBool("isOpen", true);
                openVent = true;
            }
        }
    }

    public void CheckFirstLight()
    {
         if (!firstLight && tutLights[0].GetComponent<LightCheck>().lightActive)
        {
            tutLights[0].GetComponent<LightCheck>().TurnCorrect();
            firstLight = true;
            tutLights[1].GetComponent<LightCheck>().TurnActive();
        }
    }

    public void CheckSecondLight()
    {
        if (!secondLight && tutLights[1].GetComponent<LightCheck>().lightActive)
        {
            tutLights[1].GetComponent<LightCheck>().TurnCorrect();
            secondLight = true;
            tutLights[2].GetComponent<LightCheck>().TurnActive();
        }
    }

    public void CheckThirdLight()
    {
        if (!thirdLight && tutLights[2].GetComponent<LightCheck>().lightActive)
        {
            tutLights[2].GetComponent<LightCheck>().TurnCorrect();
            thirdLight = true;
            platAnim.SetBool("isActive", true);
            activePlat = true;
        }
    }

    public void ReachedTopPlat()
    {
        if(activePlat && !reachedPlat)
        {
            platAnim.SetBool("isActive", false);
            reachedPlat = true;

            ventAnim.SetBool("isOpen", true);
            openVent = true;
        }
    }
}
