using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour
{
    public GameObject TextBox;

    public Text theText;
    public TextAsset textfile;
    public string[] textlines;

    public int currentline;
    public int endatline;

    public PlayerManager player;
    // Use this for initialization
    void Start()
    {
        
        if (textfile != null)
        {
            textlines = (textfile.text.Split('\n'));
        }

        if(endatline == 0)
        {
            endatline = textlines.Length - 1;
        }

    }
    void Update()
    {
        theText.text = textlines[currentline];
        if (Input.GetKeyDown(KeyCode.Return))
        {
            currentline = currentline + 1;
        }
        if (currentline > endatline)
        {
            TextBox.SetActive(false);
            currentline = 0;
        }
    }
}
