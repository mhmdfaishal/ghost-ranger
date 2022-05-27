using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Threading;
using TMPro;

public class ShootEnemy : MonoBehaviour
{
	
    [SerializeField] private GameObject captured;
	public int distanceOfRay = 20; //jarak raycast, atau titik cursor dari camera ke objek
	private RaycastHit hit; //untuk menerima objek apa yang terkena raycast	

	// Update is called once per frame
	private void Start(){
		captured.SetActive(false);
	}

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


	public void ShowMediaPicker()
	{
		if (Application.isEditor)
		{
			Debug.Log("Can't show media picker while in editor.");
		}
		else
		{
			NativeGallery.GetImagesFromGallery((paths) =>
			{
				if (paths.Length == 0)
				{
					captured.SetActive(false);
					Debug.Log("No images selected or the user cancelled.");
				}
				else
				{
					captured.SetActive(true);
					Debug.Log("Image path: " + paths[0]);
				}
			}, "Select a PNG image", "image/png");
		}
	} 

}
