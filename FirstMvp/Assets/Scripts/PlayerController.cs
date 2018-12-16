using Assets.Enums;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public float speed;
    private RaycastHit hit;

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        transform.LookAt(hit.point);
        transform.Translate(x, 0, z);
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
        if(isLocalPlayer)
        {
            Camera.main.GetComponent<CameraFollow>().setTarget(gameObject.transform);
        }
    }
}