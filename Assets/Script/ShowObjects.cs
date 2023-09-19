using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowObjects : MonoBehaviour
{
    public GameObject starObject;
    public GameObject diamondObject;

    private bool showingStar;
    private bool showingDiamond;

    // Start is called before the first frame update
    void Start()
    {
        starObject.SetActive(false);
        diamondObject.SetActive(false);
        showingStar = false;
        showingDiamond = false;
    }

    public void ShowStar()
    {
        // If diamond is not showing or we want to prioritize showing star
        if (!showingDiamond || !showingStar)
        {
            showingStar = true;
            showingDiamond = false;
            starObject.SetActive(true);
            diamondObject.SetActive(false);
        }
    }

    public void ShowDiamond()
    {
        // If star is not showing or we want to prioritize showing diamond
        if (!showingStar || !showingDiamond)
        {
            showingDiamond = true;
            showingStar = false;
            starObject.SetActive(false);
            diamondObject.SetActive(true);
        }
    }
}
