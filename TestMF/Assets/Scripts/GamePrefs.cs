using UnityEngine;
public enum GameMode
{
    Platformer,
    Scroller

}
public class GamePrefs : MonoBehaviour
{
    [SerializeField] private GameMode gameMode;
    private Rigidbody2D playerRig;
    private Player player;
    public GameMode GameMode => gameMode;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        playerRig = player.GetComponent<Rigidbody2D>();
        SetPrefs();
    }
    private void Update()
    {
        if(gameMode == GameMode.Platformer) { SetPrefs(); }
        if (gameMode == GameMode.Scroller) { SetPrefs(); }
    }

    private void SetPrefs()
    {
        if (gameMode == GameMode.Scroller)
        {
            playerRig.gravityScale = 0;
            playerRig.drag = 5;
            player.LookAtCursor();
            
        }
        if (gameMode == GameMode.Platformer)
        {
            playerRig.gravityScale = 1.0f;
            playerRig.drag = 5;
            player.SetZeroRotation();
        }
    }
}
