using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public Transform Start;
    public Transform End;

    public float speed = 1.0f;
    public float journeyLength = 1.0f;
    private float startTime;

    public GameObject Indi;
    public GameObject Jebsee;

    void Update()
    {
        float distCovered = Mathf.PingPong(Time.time - startTime, journeyLength / speed);
        transform.position = Vector3.Lerp(Start.position, End.position, distCovered / journeyLength);
    }

    private void OnCollisionStay(Collision player)
    {
        if (player.gameObject == Indi)
        {
            Indi.transform.parent = this.transform;
        }
        else if (player.gameObject == Jebsee)
        {
            Jebsee.transform.parent = this.transform;
        }
    }

    private void OnCollisionExit(Collision player)
    {
        if (player.gameObject == Indi)
        {
            Indi.transform.parent = null;
        }
        else if (player.gameObject == Jebsee)
        {
            Jebsee.transform.parent = null;
        }
    }
}
