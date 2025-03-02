using UnityEngine;

[CreateAssetMenu(fileName = "New Team", menuName = "Custom/Team Data")]
public class TeamData : ScriptableObject
{
    public string teamName;
    public string league;
    public string country;

    public Texture2D teamIcon;
    public PlayerData[] players;
}
