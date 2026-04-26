using UnityEngine;
using UnityEngine.InputSystem;

public class PurpleNPCScript : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject text1;
    [SerializeField] private GameObject text2;
    [SerializeField] private GameObject text3;
    [SerializeField] private GameObject coin1;
    [SerializeField] private GameObject coin2;
    [SerializeField] private GameObject coin3;
    private int current = 0;
    InputAction talk;
    void Start()
    {
        talk = InputSystem.actions.FindAction("Interact");
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
        else if (other.tag == "ball")
        {
            canvas.SetActive(true);
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(true);
            coin1.SetActive(true);
            coin2.SetActive(true);
            coin3.SetActive(true);
            current = 2;
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
        }
    }

    private void Started(InputAction.CallbackContext obj)
    {
        if (current == 0 && !text3.activeSelf)
        {
            text1.SetActive(false);
            text2.SetActive(true);
            current++;
        }
        if (current == 2)
        {
            text2.SetActive(false);
            text1.SetActive(false);
        }
    }
}
