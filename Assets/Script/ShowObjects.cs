using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowObjects : MonoBehaviour
{
    public GameObject starObject;
    public GameObject diamondObject;

    // Start is called before the first frame update
    void Start()
    {
        starObject.SetActive(false);
        diamondObject.SetActive(false);
    }

    public void ShowStar()
    {
        starObject.SetActive(true);
        diamondObject.SetActive(false);
    }

    public void ShowDiamond()
    {
        starObject.SetActive(false);
        diamondObject.SetActive(true);
    }

}
