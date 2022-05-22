using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Threading;

public class ShootEnemy : MonoBehaviour
{
	[SerializeField] private GameObject captured;
	public int distanceOfRay = 20; //jarak raycast, atau titik cursor dari camera ke objek
	private RaycastHit hit; //untuk menerima objek apa yang terkena raycast	
	private string directoryName = "GhostGallery";
    private string fileName = "ghost_";
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

	private IEnumerator Screenshot(){
		yield return new WaitForEndOfFrame();
		Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

		texture.ReadPixels(new Rect( 0, 0, Screen.width, Screen.height), 0, 0);
		texture.Apply();

		string name = fileName + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
		//PC
        // DirectoryInfo screenshotDirectory = Directory.CreateDirectory(directoryName);
        // string fullPath = Path.Combine(screenshotDirectory.FullName, name);

        // ScreenCapture.CaptureScreenshot(fullPath);
		//Mobile 
		captured.SetActive(false);
		Thread.Sleep(2);
		NativeGallery.SaveImageToGallery(texture, directoryName, name);
		Time.timeScale = 1;
		Destroy(texture);
	}
	
	public void TakeScreenshot(){
		Time.timeScale = 0;
		captured.SetActive(true);
		StartCoroutine("Screenshot");
	}
}
