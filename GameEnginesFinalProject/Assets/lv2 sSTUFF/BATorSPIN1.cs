using UnityEngine;

public class BATorSPIN1 : MonoBehaviour
{
   public Vector3 rotationSpeed=new Vector3(0,100,0);

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
