using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public bool bIslocalPlayer = true;

    private SyncPositionRequest scriptSyncPositionRequest;
    private Vector3 lastPosition = Vector3.zero;

	// Use this for initialization
	void Start () {
		if (bIslocalPlayer)
        {
            GetComponent<Renderer>().material.color = Color.green;
            scriptSyncPositionRequest = GetComponent<SyncPositionRequest>();
            InvokeRepeating("SyncPosition", 3, 1 / 5f);//3s后开始每隔1/5f s调用
        }
	}

    void SyncPosition()
    {
        if (Vector3.Distance(transform.position, lastPosition) > 0.1f)
        {
            lastPosition = transform.position;
            scriptSyncPositionRequest.pos = transform.position;
            scriptSyncPositionRequest.DefaultRequest();
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (bIslocalPlayer)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            transform.Translate(new Vector3(h, 0 ,v) * Time.deltaTime);
        }
	}
}
