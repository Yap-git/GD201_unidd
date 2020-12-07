using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part1Tst : MonoBehaviour
{
	void Start ()
	{
		gameObject.SetActive(false);

	}
    void Update()
    {
    	transform.Rotate(new Vector3(15,30,45) * Time.deltaTime);
        
    }
}

