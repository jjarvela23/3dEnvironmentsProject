using UnityEngine;
using UnityEngine.Rendering.UI;

public class colorswitch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int color = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (color == 0)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
            color = 1;
        }
        else if (color == 1)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            color = 0;

        }
    }
}
