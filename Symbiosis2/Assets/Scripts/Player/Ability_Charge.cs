using UnityEngine;

public class Ability_Charge : MonoBehaviour
{
    public Transform jebseeOrientation;
    public Rigidbody rigidBod;
    public PlayerMovement jebseeMovement;
    public GameObject charSwitch;

    private float chargeSpeed = 200.0f;
    private float chargeTime = 0.5f;

    private bool isJebsee = false;

    private float currTime = 0.0f;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && currTime <= 0.0f && charSwitch.GetComponent<CharacterSwitch>().GetCurrCharacter() == 1)
        {
            currTime = chargeTime;
        }

        if(currTime > 0.0f)
        {
            currTime -= Time.deltaTime;

            if(jebseeMovement.grounded)
            {
                rigidBod.velocity = (-1 * jebseeOrientation.forward) * chargeSpeed;
            }
        }
    }
}
