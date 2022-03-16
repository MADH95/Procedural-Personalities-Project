
using UnityEngine;

[CreateAssetMenu( fileName = "InformationObject", menuName = "ScriptableObject/InformationObject" )]
public class InformationObject : ScriptableObject
{
    [SerializeField]
    private string title;

    [SerializeField, TextArea(10, 50)]
    private string content;

    public string Title { get { return title; } }

    public string Content { get { return content; } }
}
