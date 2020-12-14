using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnCollisionEnter2D(Collision2D collision) {
		if(gameObject.name.Equals("Hitbox1"))
			PlayerController.hitBoxFlag1 = true;
		else
			PlayerController.hitBoxFlag2 = true;
	}
}
