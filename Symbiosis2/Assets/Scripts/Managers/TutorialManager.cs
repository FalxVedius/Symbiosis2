using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance;

    public bool lightsOn;
    public bool firstLight;
    public bool secondLight;
    public bool thirdLight;
    public bool firstPlat;
    public bool secondPlat;
    public bool thirdPlat;
    public bool activePlat;
    public bool reachedPlat;
    public bool openVent;

    public GameObject[] tutLights = new GameObject[3];
    public GameObject[] tutPlats = new GameObject[3];
    public GameObject lightParent;
    public GameObject raisedPlat;
    public GameObject tutVent;

    public Text tutText;

    private Animator platAnim;
    private Animator ventAnim;
    private Animator lightAnim;

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
        platAnim = raisedPlat.GetComponent<Animator>();
        ventAnim = tutVent.GetComponent<Animator>();
        lightAnim = lightParent.GetComponent<Animator>();
        tutText.text = "Press P Key to Start Tutorial";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!lightsOn)
            {
                lightAnim.SetBool("isActive", true);
                for (int i = 0; i < tutLights.Length; i++)
                {
                    tutLights[i].GetComponent<LightCheck>().TurnOn();
                    tutText.text = "Use Mouse to look around. Press LMB while looking at the Red Light";
                    lightsOn = true;
                }
                tutLights[0].GetComponent<LightCheck>().TurnActive();
            }
            /*else if (!activePlat)
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
            }*/
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
            lightAnim.SetBool("isActive", false);

            tutText.text = "Use WASD to move. Move onto the lit up tiles!";

            tutPlats[0].GetComponent<TutorialPlat>().TurnOn();
        }
    }

    public void CheckFirstPlat()
    {
        if (!firstPlat)
        {
            tutPlats[0].GetComponent<TutorialPlat>().TurnCorrect();
            tutPlats[1].GetComponent<TutorialPlat>().TurnOn();
            firstPlat = true;
        }
    }
    
    public void CheckSecondPlat()
    {
        if (!secondPlat)
        {
            tutPlats[1].GetComponent<TutorialPlat>().TurnCorrect();
            tutPlats[2].GetComponent<TutorialPlat>().TurnOn();
            secondPlat = true;
        }
    }

    public void CheckThirdPlat()
    {
        if (!thirdPlat)
        {
            tutPlats[2].GetComponent<TutorialPlat>().TurnCorrect();
            thirdPlat = true;

            tutText.text = "Press Space to Jump. Reach the top Platform!";
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

            tutText.text = "The Vent appears to have open. Go through it to enter the next room!";
        }
    }
}
