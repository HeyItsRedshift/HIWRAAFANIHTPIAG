using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject MainMenu;             // Reference to the main menu
    public GameObject OptionsMenu;          // Reference to the options menu
    public GameObject Leaderboards;     // Reference to the leaderboards menu

    public Button OptionsButton;        // Button in the main menu that switches to options
    public Button LeaderboardsButton;   // Button in the main menu that switches to leaderboards
    public Button HeadsUp;     // The default button in the options menu
    public Button ExitButton;// The default button in the leaderboards menu

    private EventSystem eventSystem;

    private void Start()
    {
        eventSystem = EventSystem.current;

        // Button listeners
       HeadsUp.onClick.AddListener(SwitchToOptions);
       ExitButton.onClick.AddListener(SwitchToLeaderboards);
    }

    public void SwitchToOptions()
    {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
        Leaderboards.SetActive(false);

        SetDefaultSelectedButton(HeadsUp);
    }

    public void SwitchToLeaderboards()
    {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        Leaderboards.SetActive(true);

        SetDefaultSelectedButton(ExitButton);
    }

    private void SetDefaultSelectedButton(Button defaultButton)
    {
        eventSystem.SetSelectedGameObject(null); // Clear current selection
        eventSystem.SetSelectedGameObject(defaultButton.gameObject);
    }

    // ... Any other functions you might need
}
