using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
	public float laserPwr = 150f;
	public GameObject wall2;
	
	private int Kills;
    // Start is called before the first frame update
    void Start()
    {
        Kills = 0;

        wall2 = GameObject.FindWithTag("PWall2");
    }

    // Update is called once per frame
    void Update()
    {
    	if(Input.GetMouseButtonDown(0)){



        Ray damager = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(damager, out hit, 10000f)){
        	Debug.Log("Hit" + hit.transform.gameObject.name);
        } 

        if  (hit.transform.gameObject.CompareTag("Enemy")){
        	Destroy(hit.collider.gameObject);
        	Kills = Kills + 1;
        	}
        
        if (Kills == 4){
        	Destroy(wall2);
        }

        }

    }
}
