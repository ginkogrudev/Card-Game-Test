using UnityEngine;
using System.Collections;

public class MyButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void ReloadLevel()
    {
        Application.LoadLevel("CardGameDemo");
    }
}
