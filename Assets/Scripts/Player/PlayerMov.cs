using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public float PlayerSpeed;
    private float xAxis;
    private float zAxis;

    public float DashSpeed;
    public float DashTime;
    private bool isDashing;

    Vector3 dir;

    private Rigidbody rb;

    public float TurnSpeed;
    public LayerMask LayerMask;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Run(dir);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //Dash2(xRaw,zRaw);
            if (!isDashing)
            {
                StartCoroutine(Dashing());
            }
        }

        RotatePlayer();
    }

    private void FixedUpdate()
    {
        if (!isDashing)
        {
            Run(dir);
        }
    }

    private void Run(Vector3 dir)
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        dir = new Vector3(x, 0, z);
        dir.Normalize();

        rb.velocity = (new Vector3(dir.x * PlayerSpeed, 0, dir.z * PlayerSpeed));
    }

    private void RotatePlayer() //methode von Maik ps. Maik ist doof!
    {
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, LayerMask))
        {
            Vector3 targetPoint = raycastHit.point;
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, TurnSpeed * Time.deltaTime);
        }
    }

    IEnumerator Dashing()
    {
        isDashing = true;

        if (xAxis != 0 || zAxis != 0)
        {
            rb.AddForce(new Vector3(xAxis, 0, zAxis).normalized * DashSpeed, ForceMode.Impulse);
            yield return new WaitForSeconds(DashTime);
        }
        else
        {
            rb.AddForce(transform.forward * DashSpeed, ForceMode.Impulse);
            yield return new WaitForSeconds(DashTime);
        }

        isDashing = false;
    }
}
