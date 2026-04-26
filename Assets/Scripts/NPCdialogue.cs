using UnityEngine;
using UnityEngine.InputSystem;

public class NPCdialogue : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject text1;
    [SerializeField] private GameObject text2;
    [SerializeField] private GameObject text3;
    [SerializeField] private GameObject text4;
    [SerializeField] private GameObject text5;
    private int current = 0;
    InputAction talk;
    [SerializeField] private CoinCounter coinCounter;
    void Start()
    {
        talk  = InputSystem.actions.FindAction("Interact");
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("touching");
            canvas.SetActive(true);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canvas.SetActive(false);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            talk.started += Started;
            talk.performed += Performed;
            
        }
    }

    private void Performed(InputAction.CallbackContext obj)
    {
        
    }

    private void Started(InputAction.CallbackContext obj)
    {
        if (coinCounter.GetCoins() >= 20)
        {
            text5.SetActive(true);
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(false);
            text4.SetActive(false);
            current = 6;
        }
        else if (current == 0)
        {
            text1.SetActive(false);
            text2.SetActive(true);
            current++;
        }
        else if (current == 1)
        {
            text2.SetActive(false);
            text3.SetActive(true);
            current++;
        }
        else if (current == 2)
        {
            text3.SetActive(false);
            text4.SetActive(true);
            current++;
        }
        else if (current == 3)
        {
            canvas.SetActive(false);
            text1.SetActive(true);
            text4.SetActive(false);
            current = 0;
        }
    }
}
