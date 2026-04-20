using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject playerCharacter;
    private Transform playerLocation;
    void Start()
    {
        playerLocation = playerCharacter.GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(playerLocation.position.x, playerLocation.position.y + 8f, playerLocation.position.z - 8f);
    }
}
