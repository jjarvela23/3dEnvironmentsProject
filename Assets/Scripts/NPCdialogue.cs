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
    private bool text1active = false;
    private bool text2active = false;
    private bool text3active = false;
    private bool text4active = false;
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
        if ()
    }

    private void Started(InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }
}
