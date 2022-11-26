using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float turnSpeed = 90f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ObstacleManager>() != null)
        {
            Destroy(gameObject);
            return;
        }
        //Check that object we collided with is player
        if (other.gameObject.name != "Player")
        {
            return;
        }
        GameManager.inst.IncrementScore();

        Destroy(gameObject);


    }
    void Start()
    {
        //gameObject here is the coin

    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotateSpeedCoin = 90f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ObstacleManager>() != null)
        {
            Destroy(gameObject);
            return;
        }

        // Check that the object we collided with is the player
        if (other.gameObject.name != "Player")
        {
            return;
        }

        // Add to the player's score
        ScoreManager.inst.IncrementScore();

        // Destroy this coin object
        Destroy(gameObject);
    }
    // private void OnTriggererEnter(Collider other)
    // {
    //     if (other.gameObject.GetComponent<ObstacleManager>() != null)
    //     {
    //         Destroy(gameObject);
    //         return;
    //     }

    //     if (other.gameObject.name != "Player")
    //     {
    //         return;
    //     }


    //     Destroy(gameObject);
    // }
    void Start()
    {
        //gameObject here is the coin

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeedCoin * Time.deltaTime); //Time.deltaTime is the amount of time passed
        //between the last frame to the next frame   
    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CoinManager : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {

//     }

//     // Update is called once per frame
//     void Update()
//     {

//     }
// }
*/
