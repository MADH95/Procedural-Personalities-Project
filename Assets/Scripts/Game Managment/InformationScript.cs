
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InformationScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI titleText;

    [SerializeField]
    private TextMeshProUGUI contentText;

    [SerializeField]
    private List<InformationObject> infoObjs= new List<InformationObject>();

    public void UpdateInfo( int index )
	{
        titleText.text = infoObjs[index].Title;
        contentText.text = infoObjs[index].Content;
	}
}
