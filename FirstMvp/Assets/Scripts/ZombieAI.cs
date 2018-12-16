using UnityEngine;

public class ZombieAI : MonoBehaviour
{

    private Transform Player;
    private Transform aiTransform;
    private int moveSpeed = 5;
    private float stop = 0;
    private int _health { get; set; }

    private void Awake()
    {
        _health = 10;
        aiTransform = transform;
    }

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        DeathCheck();
        MoveTowardPlayer();
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.name == "Player")
    //    {
    //        aiTransform.position -= aiTransform.forward * (moveSpeed + 3) * Time.deltaTime;
    //    }
    //    Debug.Log(collision.gameObject.name);
    //    if (collision.gameObject.tag == "Sword")
    //    {
    //        _health -= 5;
    //        aiTransform.position -= aiTransform.forward * (moveSpeed + 50) * Time.deltaTime;
    //        Debug.Log("Collision with weapon");
    //    }
    //}

    #region(Private Methods)
    private void DeathCheck()
    {
        if (_health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void MoveTowardPlayer()
    {
        var distance = Vector3.Distance(Player.position, aiTransform.position);

        if (distance < 100)
        {
            aiTransform.transform.LookAt(Player);

            if (distance > stop)
            {
                aiTransform.position += aiTransform.forward * moveSpeed * Time.deltaTime;
            }
        }
    }
    #endregion
}