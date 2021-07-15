using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public Transform CameraTranst;

    public float PlayerSpeed;

    public float DashSpeed;
    private bool isDashing;

    Vector3 dir;

    [SerializeField] private Rigidbody Rg;

    public float TurnSpeed;
    public LayerMask LayerMask;


    private void Start()
    {
        //player = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        CameraTranst.position = transform.position + new Vector3(2, 12, -15);

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
        Rg.velocity = (new Vector3(dir.x * PlayerSpeed, 0, dir.z * PlayerSpeed));
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

    private void Dash()
    {
        Rg.AddForce(transform.forward * DashSpeed, ForceMode.Impulse);
        isDashing = false;
    }

    IEnumerator Dashing()
    {
        isDashing = true;
        Rg.AddForce(transform.forward * DashSpeed, ForceMode.Impulse);
        yield return new WaitForSeconds(0.5f);
        isDashing = false;
    }
}
