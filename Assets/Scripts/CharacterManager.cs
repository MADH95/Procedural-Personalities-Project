
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ProcGen;

public class CharacterManager : MonoBehaviour
{
    public static int Seed = 12345;

    public const float InGameSecond = 0.016f;

    [SerializeField] private TMP_Dropdown Dropdown;

    [Header( "Personality" )]
    [SerializeField] private TextMeshProUGUI Openness;
    [SerializeField] private TextMeshProUGUI Conscientiousness;
    [SerializeField] private TextMeshProUGUI Extraversion;
    [SerializeField] private TextMeshProUGUI Agreeableness;
    [SerializeField] private TextMeshProUGUI Neuroticism;

    [Header( "Utilities" )]
    [SerializeField] private TextMeshProUGUI Hunger;
    [SerializeField] private TextMeshProUGUI Money;
    [SerializeField] private TextMeshProUGUI Energy;

    [Header( "Action History" )]
    [SerializeField] private TextMeshProUGUI History;

    [Header( "Current Action" )]
    [SerializeField] private GameObject CurrentActionPanel;
    [SerializeField] private TextMeshProUGUI CurrentActionText;

    [SerializeField]
    private List<GameObject> characters = new List<GameObject>();

    private int currentIndex = 0;

    private void Start()
    {
        for ( int i = 0; i < characters.Count; ++i )
        {
            Dropdown.options[i].text = characters[i].name;
        }

        Dropdown.value = Dropdown.options.Count - 1;
    }

	private void Update ()
	{
        UpdateDropdown();
	}

    private void UpdateDropdown()
	{
        bool check = currentIndex < characters.Count;

        Actor character = check ? characters[currentIndex].GetComponent<Actor>() : null;

        Openness.text = check ? character.personality.Openness.ToString( "0.00" ) : "0.0";
        Conscientiousness.text = check ? character.personality.Conscientiousness.ToString( "0.00" ) : "0.0";
        Extraversion.text = check ? character.personality.Exatraversion.ToString( "0.00" ) : "0.0";
        Agreeableness.text = check ? character.personality.Agreeableness.ToString( "0.00" ) : "0.0";
        Neuroticism.text = check ? character.personality.Neuroticism.ToString( "0.00" ) : "0.0";

        Hunger.text = check ? character.utilities.Hunger.ToString( "0.00" ) : "0.0";
        Money.text = check ? character.utilities.Money.ToString( "0.00" ) : "0.0";
        Energy.text = check ? character.utilities.Energy.ToString( "0.00" ) : "0.0";

        History.text = string.Empty;

        CurrentActionPanel.SetActive( check );

        if ( !check )
            return;

        foreach ( var action in character.actionHistory )
        {
            History.text += $"{ action.ID }\n";
        }

        CurrentActionText.text = $"{ character.name } is { character.utilities.OutputLine }";
    }

	public void DropdownChanged( int index )
    {
        currentIndex = index;
	}
}
