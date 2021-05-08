using UnityEngine;

public class Flag : MonoBehaviour
{
    public static GameObject redTaker;
    public static GameObject blueTaker;

    public static bool redTaken;
    public static bool blueTaken;

    private void OnCollisionEnter(Collision collision)
    {
        /*if (gameObject.tag == "Red")
        {
            if (collision.gameObject.tag == "Blue") { redTaken = true;  redTaker = collision.gameObject;  collision.gameObject.GetComponent<Player>().redFlag.SetActive(true); }
            if (collision.gameObject == blueTaker) { blueTaken = false; blueTaker = null; ScoreManager.redScore = ScoreManager.redScore + 1; collision.gameObject.GetComponent<Player>().blueFlag.SetActive(false); }
        }

        if (gameObject.tag == "Blue") 
        {
            if (collision.gameObject.tag == "Red") { blueTaken = true; blueTaker = collision.gameObject; collision.gameObject.GetComponent<Player>().blueFlag.SetActive(true); }
            if (collision.gameObject == redTaker) { redTaken = false; redTaker = null; ScoreManager.blueScore = ScoreManager.redScore + 1; collision.gameObject.GetComponent<Player>().redFlag.SetActive(false); }
        }*/

        if (gameObject.tag == "Collectable")
        {
            if (collision.gameObject.tag == "Blue") { redTaken = true; redTaker = collision.gameObject; collision.gameObject.GetComponent<Player>().redFlag.SetActive(true); }
            if (collision.gameObject == blueTaker) { blueTaken = false; blueTaker = null; ScoreManager.redScore = ScoreManager.redScore + 1; collision.gameObject.GetComponent<Player>().blueFlag.SetActive(false); }
        }

        if (gameObject.tag == "Player")
        {
            if (collision.gameObject.tag == "Red") { blueTaken = true; blueTaker = collision.gameObject; collision.gameObject.GetComponent<Player>().blueFlag.SetActive(true); }
            if (collision.gameObject == redTaker) { redTaken = false; redTaker = null; ScoreManager.blueScore = ScoreManager.redScore + 1; collision.gameObject.GetComponent<Player>().redFlag.SetActive(false); }
        }
    }
}
