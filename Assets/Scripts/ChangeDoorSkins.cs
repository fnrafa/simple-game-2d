using UnityEngine;

public class ChangeDoorSkins : MonoBehaviour
{
    public GameObject skinsPanel;
    public PlayerSelect playerSelect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && skinsPanel != null)
        {
            skinsPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (skinsPanel != null)
        {
            skinsPanel.SetActive(false);
        }
    }

    private void SetPlayerSkin(PlayerSelect.PlayerType playerType)
    {
        PlayerPrefs.SetString("playerSelected", playerType.ToString());
        ResetPlayerSkin();
    }

    private void ResetPlayerSkin()
    {
        if (skinsPanel != null)
        {
            skinsPanel.SetActive(false);
        }
        
        if (playerSelect != null)
        {
            playerSelect.ChangePlayerInMenu();
        }
    }

    public void SetPlayerFrog()
    {
        SetPlayerSkin(PlayerSelect.PlayerType.Frog);
    }

    public void SetPlayerMaskDude()
    {
        SetPlayerSkin(PlayerSelect.PlayerType.MaskDude);
    }

    public void SetPlayerPinkMan()
    {
        SetPlayerSkin(PlayerSelect.PlayerType.PinkMan);
    }

    public void SetPlayerVirtualGuy()
    {
        SetPlayerSkin(PlayerSelect.PlayerType.VirtualGuy);
    }
}