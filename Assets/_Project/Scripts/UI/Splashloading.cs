using UnityEngine;
using UnityEngine.UI;

public class Splashloading : MonoBehaviour
{
    public string[] Text;
    public Text Assetloadingtext;
    public Text LOADINDOT;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(LaodingDots),0.5F,0.5f);
        InvokeRepeating(nameof(Laodassets),1.5F,1.5F);
    }
    int dot,index= 0;
    private void LaodingDots()
    {
        dot++;
        if (dot == 1)
            LOADINDOT.text = ".";
        else if (dot == 2)
            LOADINDOT.text = ". .";
        else
        {
            LOADINDOT.text = ". . .";
            dot = 0;
        }

    }
    private void Laodassets()
    {
        if (Assetloadingtext == null)
            return;
        index++;
        if (index == 1)
            Assetloadingtext.text = Text[0];
        else if (index == 2)
            Assetloadingtext.text = Text[1];
        else if (index == 3)
            Assetloadingtext.text = Text[2];
        else if (index == 4)
            Assetloadingtext.text = Text[3];
        else
        {
            Assetloadingtext.text = "READY";
            index = 0;
        }
    }

}
