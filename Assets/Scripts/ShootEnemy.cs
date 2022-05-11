using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : MonoBehaviour
{
	public int distanceOfRay = 20; //jarak raycast, atau titik cursor dari camera ke objek
	private RaycastHit hit; //untuk menerima objek apa yang terkena raycast	
	// Update is called once per frame
	void Update(){
		Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); //mengeluarkan raycast dari titik tengah camera
		//Click Input
		Debug.DrawLine (transform.position, hit.point,Color.red);
		if(Physics.Raycast(ray, out hit, distanceOfRay)){ //apabila ada sesuatu dari raycast
			if(Input.GetButtonDown("Fire1") && hit.transform.CompareTag("Enemy")){ //apabila sesuatu itu adalah tag enemy dan kita menekan	tombol	
				Destroy(hit.transform.gameObject); //destroy sesuatu itu
			}
		}		
	}
}
