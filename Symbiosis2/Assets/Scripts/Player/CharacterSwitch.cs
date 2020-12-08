using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{

    public GameObject indi;
    public GameObject jebsee;
    public GameObject jebseeCam;
    public GameObject indiCam;

    private PlayerMovement indiMovement;
    private PlayerMovement jebseeMovement;

    private int currCharacter = 0;
    void Start()
    {
        indiMovement = indi.GetComponent<PlayerMovement>();
        jebseeMovement = jebsee.GetComponent<PlayerMovement>();

        jebseeCam.SetActive(false);
        indiCam.SetActive(true);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(currCharacter == 0)
            {
                indiMovement.Enabled = false;
                jebseeMovement.Enabled = true;
                currCharacter = 1;

                jebseeCam.SetActive(true);
                indiCam.SetActive(false);
            }
            else if(currCharacter == 1)
            {
                indiMovement.Enabled = true;
                jebseeMovement.Enabled = false;
                currCharacter = 0;

                jebseeCam.SetActive(false);
                indiCam.SetActive(true);
            }
        }
    }

    public int GetCurrCharacter()
    {
        return currCharacter;
    }
}
