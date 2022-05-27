using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RandomSpawnerV : MonoBehaviour
{
	public GameObject[] enemies;
	[SerializeField] private TMP_Text TimeToSpawn;
	[SerializeField] private TMP_Text Heart;
	[SerializeField] private GameObject gameover;
	[SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;
	// AudioSource audioSource;

	public int maxtimer = 20;
	public int mintimer = 3;
	private float timer;
	public float timetospawn;
	public int xmin=-20, xmax=20;
	public int ymin=-10,ymax=10;
	private int objX,objY;
	public bool is_spawn;
	private int heart;
	// Use this for initialization
	void Start () {
		timetospawn = 10;	 //random awal
		heart = 3;
		Heart.text = heart.ToString();
		restartButton.onClick.AddListener(RestartGame);
        mainMenuButton.onClick.AddListener(ExitGame);
		gameover.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		timetospawn -= Time.deltaTime;
		if(timetospawn < 0){ //apabila sudah mencapai waktunya spawn
			if(GameObject.FindWithTag("Ghost") != null){
				heart--;
				Heart.text = heart.ToString();
			}
			if(Heart.text == "0"){
				Time.timeScale = 0;
                gameover.SetActive(true);
				// audioSource.mute = false;
			}
			timetospawn = 11; //random ulang lagi
			Debug.Log(timetospawn); //cetak catatan ke debug window
			RandomPosition();
			Spawn(Random.Range(0, enemies.Length)); //random musuh yang akan dimunculkan
			is_spawn = true;
		}
		if(is_spawn){
			TimeToSpawn.text = ((int)(timetospawn)).ToString();
		}
	}

	public void RestartGame()
    {
        Time.timeScale = 1;
		heart = 3;
        gameover.SetActive(false);
        // audioSource.mute = true;
    }
    
    public void ExitGame()
    {
        SceneManager.LoadScene("MenusScene");
    }

	void RandomPosition(){
		objX = Random.Range(xmin, xmax);
		objY = Random.Range(ymin, ymax);
	}

	void Spawn(int index){
		Destroy (GameObject.FindWithTag("Ghost"));
		if (index == 1){
			GameObject pocong = Instantiate(enemies[index], new Vector3(objX, objY, 0), Quaternion.identity);
			pocong.transform.rotation = Quaternion.Euler(-86.69f, 200.6f, 0);
		}else{
			Instantiate(enemies[index],new Vector3(objX,objY,transform.position.z),transform.rotation); //memunculkan musuh pada index "index"
		}
	}
}
