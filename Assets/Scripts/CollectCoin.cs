using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private CoinCounter CoinCounter;
    private GameObject audioplayer;
    void Start()
    {
        audioplayer = GameObject.FindGameObjectWithTag("spawnpoint");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("touching coin");
        CoinCounter.GetComponent<CoinCounter>().AddCoin();
        audioplayer.GetComponent<AudioSource>().Play();
        gameObject.SetActive(false);
    }
}
