using UnityEngine;

public class ButtonPress : MonoBehaviour
{
public GameObject PPobject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

public void ButtonClick()
{

if (Input.GetKeyDown(KeyCode.E))
            {
              Debug.Log("Button Click");
PPobject.SetActive(false);
            }

}


}
