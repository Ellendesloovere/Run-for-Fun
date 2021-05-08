using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rig;
    public float moveForce;
    public float sprintForce;
    public float rotateForce;

    public float jumpForce;
    public float jumpsLeft;
    public float downForce;

    public GameObject redFlag;
    public GameObject blueFlag;

    void Update()
    {
        if (Input.GetKey(KeyCode.W)) { rig.AddRelativeForce(Vector3.forward * moveForce * Time.deltaTime); }
        if (Input.GetKey(KeyCode.S)) { rig.AddRelativeForce(Vector3.back * moveForce * Time.deltaTime); }

        if (Input.GetKey(KeyCode.A)) { transform.Rotate(new Vector3(0, -rotateForce, 0)); }
        if (Input.GetKey(KeyCode.D)) { transform.Rotate(new Vector3(0, rotateForce, 0)); }

        if (Input.GetKeyDown(KeyCode.LeftShift)) { moveForce = moveForce * sprintForce; }
        if (Input.GetKeyUp(KeyCode.LeftShift)) { moveForce = moveForce / sprintForce; }

        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0) { rig.AddForce(Vector3.up * jumpForce * Time.deltaTime); jumpsLeft = jumpsLeft - 1; }
        rig.AddForce(Vector3.down * downForce * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") { jumpsLeft = 2; }
    }

}
