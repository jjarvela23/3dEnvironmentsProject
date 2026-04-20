using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private CoinCounter CoinCounter;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("touching coin");
        CoinCounter.GetComponent<CoinCounter>().AddCoin();
        gameObject.GetComponent<AudioSource>().Play();
    }
}
