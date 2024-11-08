using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    public bool enableSelectCharacter;

    public enum PlayerType
    {
        Frog,
        PinkMan,
        VirtualGuy,
        MaskDude
    }

    public PlayerType playerSelected = PlayerType.Frog;

    public RuntimeAnimatorController[] playersController;
    public Sprite[] playersRenderer;

    private PlayerInit _currentPlayerInit;

    private void Start()
    {
        _currentPlayerInit = GetComponent<PlayerInit>();

        if (!enableSelectCharacter)
        {
            ChangePlayerInMenu();
        }
        else
        {
            SetPlayerSkin(playerSelected);
        }
    }

    public void ChangePlayerInMenu()
    {
        var selectedPlayer = PlayerPrefs.GetString("playerSelected", "PinkMan");
        var playerType = (PlayerType)System.Enum.Parse(typeof(PlayerType), selectedPlayer);
        SetPlayerSkin(playerType);
    }

    private void SetPlayerSkin(PlayerType playerType)
    {
        var index = (int)playerType;

        if (_currentPlayerInit != null)
        {
            _currentPlayerInit.SetSkin(playersController[index], playersRenderer[index]);
        }
    }
}