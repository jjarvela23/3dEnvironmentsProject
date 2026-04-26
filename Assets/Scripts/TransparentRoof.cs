using UnityEngine;

public class TransparentRoof : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private GameObject roof;
    [SerializeField] private GameObject Sun;
    [SerializeField] private GameObject HouseLight;
    [SerializeField] private GameObject ceiling;
    private Color transparent;
    private Color original;
    void Start()
    {
        transparent = new Color(96, 47, 0, 0f);
        original = roof.GetComponent<MeshRenderer>().materials[0].color;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //roof.GetComponent<MeshRenderer>().materials[0].SetColor("_Color", transparent);
            roof.GetComponent<MeshRenderer>().materials[0].color = transparent;
            ceiling.GetComponent<MeshRenderer>().enabled = false;
            Sun.GetComponent<Light>().enabled = false;
            HouseLight.GetComponent<Light>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //roof.GetComponent<MeshRenderer>().materials[0].SetColor("_Color", transparent);
            roof.GetComponent<MeshRenderer>().materials[0].color = original;
            ceiling.GetComponent<MeshRenderer>().enabled = true;
            Sun.GetComponent<Light>().enabled = true;
            HouseLight.GetComponent<Light>().enabled = false;
        }
    }
}
