using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float maxMoveSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private GamePrefs gamePrefs;
    [SerializeField] private int layerMask;
    private float visualModelHeight;
    private new Rigidbody2D rigidbody2D;
    public float UpDownMoveControl;
    public float LeftRightMoveControl;
    public float SprintControl;
    public float JumpControl;
    public bool isGrounded;

    
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        layerMask = LayerMask.NameToLayer("Player");
        visualModelHeight = GetComponentInChildren<SpriteRenderer>().size.y / 2 +0.08f;
       
    }

    
    void FixedUpdate()
    {
        UpdateRigidbody();
    }

    private void UpdateRigidbody()
    {
        if (gamePrefs.GameMode == GameMode.Scroller)
        {
            rigidbody2D.AddForce(transform.up * UpDownMoveControl * (moveSpeed + (sprintSpeed * SprintControl)) * Time.fixedDeltaTime, ForceMode2D.Force);
            rigidbody2D.AddForce(transform.right * LeftRightMoveControl * (moveSpeed + (sprintSpeed * SprintControl)) * Time.fixedDeltaTime, ForceMode2D.Force);
            rigidbody2D.AddForce(-rigidbody2D.velocity * (moveSpeed / maxMoveSpeed) * Time.fixedDeltaTime, ForceMode2D.Force);
        }
       
        if (gamePrefs.GameMode == GameMode.Platformer)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, visualModelHeight, layerMask);
            isGrounded = false;
            if (hit) { isGrounded = true; }

            if (isGrounded == true)
            {
                rigidbody2D.AddForce(transform.up * JumpControl * jumpHeight * Time.fixedDeltaTime, ForceMode2D.Impulse);
            }
            rigidbody2D.AddForce(transform.right * LeftRightMoveControl * (moveSpeed + (sprintSpeed * SprintControl)) * Time.fixedDeltaTime, ForceMode2D.Force);
          
        }
    }
    public void LookAtCursor()
    {
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        lookPos -= transform.position;
        float angle = (Mathf.Atan2(lookPos.y, lookPos.x) - Mathf.PI / 2) * Mathf.Rad2Deg ;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    public void SetZeroRotation()
    {
        transform.rotation = Quaternion.AngleAxis(-transform.rotation.z, Vector3.forward);
    }
    

}
