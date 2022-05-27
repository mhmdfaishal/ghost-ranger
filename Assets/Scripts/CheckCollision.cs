using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Threading;
using TMPro;


public class CheckCollision : MonoBehaviour
{
    [SerializeField] private GameObject captured;
    [SerializeField] RandomSpawnerV randomSpawner;
    [SerializeField] private TMP_Text TimeToSpawn;
    private bool is_collision;
    private string directoryName = "GhostGallery";
    private string fileName = "ghost_";
    // Start is called before the first frame update
    void Start()
    {
        captured.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Ghost"){
			this.is_collision = true;
            Debug.Log("Ini masuk di check collision");
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
		if(this.is_collision){
			randomSpawner.timetospawn = 11;
			randomSpawner.is_spawn = false;
			TimeToSpawn.text = "";
			Destroy(texture);
			Destroy (GameObject.FindWithTag("Ghost"));
		}
	}
	
	public void TakeScreenshot(){
		Time.timeScale = 0;
		captured.SetActive(true);
		StartCoroutine("Screenshot");
	}

}

