using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private PauseMenu pauseMenu;
    private Player player;
    private float verticalAxis;
    private float horizontalAxis;
    private float jump;
    private float sprint;
    void Start()
    {
        player = FindObjectOfType<Player>();
        pauseMenu = FindObjectOfType<PauseMenu>();
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.ActivePauseMenu();
        }
    }

    void FixedUpdate()
    {
        UpdateAxis();
        SendControls();
    }
    
    private void UpdateAxis()
    {
        jump = 0;
        sprint = 0;
        verticalAxis = Input.GetAxis("Vertical");
        horizontalAxis = Input.GetAxis("Horizontal");
        if(Input.GetKey(KeyCode.Space))
        {
            jump = 1.0f;
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            sprint = 1.0f;
        }
    }
    private void SendControls()
    {
        player.LeftRightMoveControl = horizontalAxis;
        player.UpDownMoveControl = verticalAxis;
        player.SprintControl = sprint;
        player.JumpControl = jump;
    }
}
