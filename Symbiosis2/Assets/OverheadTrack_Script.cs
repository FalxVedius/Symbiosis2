using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverheadTrack_Script : MonoBehaviour
{
    public GameObject TrackStop;
    public bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving == true)
        {
            float step = 15 * Time.deltaTime; 
            transform.position = Vector3.MoveTowards(transform.position, TrackStop.transform.position, step);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == TrackStop)
        {
            isMoving = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * -25f);
    }

}
