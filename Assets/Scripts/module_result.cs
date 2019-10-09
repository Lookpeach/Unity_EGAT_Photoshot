using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class module_result : MonoBehaviour {

    public Texture2D photo;
    public Image newPhoto;
    public string get_code, filePath;
	Texture2D myTexture;
    public GameObject canvasOutput, canvasThank;

	void Start () {
		get_code = PlayerPrefs.GetString ("code");
		Debug.Log ("photos/" + get_code + ".png");
		myTexture = null;
		byte[] fileData;
		filePath = "photos/" + get_code + ".png";
		if (File.Exists (filePath)) {
			Debug.Log ("get");
			fileData = File.ReadAllBytes (filePath);
			myTexture = new Texture2D (2, 2);
			myTexture.LoadImage (fileData);
			GameObject rawImage = GameObject.Find ("RawImage");
			rawImage.GetComponent<RawImage> ().texture = myTexture;
		}
	}
    public void CancleBtn()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(1);
    }
    public void OKbtn()
    {
        canvasOutput.SetActive(false);
        canvasThank.SetActive(true);
    }
}
