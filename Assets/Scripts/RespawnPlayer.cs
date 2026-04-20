using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vector3 respawnPoint = new Vector3(-10,1,0);
    

    public void SetRespawnPoint(Vector3 respawnPoint)
    {
        this.respawnPoint = respawnPoint;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("fallen down");
        other.transform.position = respawnPoint;
    }
}
