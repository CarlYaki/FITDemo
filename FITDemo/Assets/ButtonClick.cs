using UnityEngine;
using System.Collections;
using System;

public class ButtonClick : MonoBehaviour {

    
    private int id;
    public void Click()
    {
        Debug.Log(this.name);
        switch (modelStatus.status)
        {
            case Status.merged:
                if (this.name == "split")
                {
                    GameObject.Find("root").GetComponent<ModelControl>().split();
                    modelStatus.status = Status.split;
                }
                else
                {
                    Debug.Log("Merged now. Can't be done.");
                }
                break;
            case Status.split:
                if (this.name == "merge")
                {
                    GameObject.Find("root").GetComponent<ModelControl>().merge();
                    modelStatus.status = Status.merged;
                }
                else if (this.name == "modelUp")
                {

                }
                else if (this.name == "modelDown")
                {

                }
                else if (this.name == "split")
                {
                    Debug.Log("Already split. Can't be done.");
                }
                else
                {
                    id = Convert.ToInt32(this.name);
                    GameObject.Find("root").GetComponent<ModelControl>().choose(id);
                    modelStatus.status = Status.single;
                }
                break;
            case Status.single:
                if (this.name == "1" || this.name == "2" || this.name == "3" || this.name == "4" || this.name == "5" || this.name == "6")
                {
                    GameObject.Find("root").GetComponent<ModelControl>().showAll();
                    modelStatus.status = Status.split;
                }
                break;
        }
    }





	// Use this for initialization
	void Start () {
        modelStatus.status = Status.merged;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
