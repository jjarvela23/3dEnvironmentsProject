using UnityEngine;
using UnityEngine.InputSystem;

public class NPCdialogue : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject canvas;
    InputAction talk;
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
        if (talk.IsPressed())
        {
            Debug.Log("talked");
        }
    }
}
