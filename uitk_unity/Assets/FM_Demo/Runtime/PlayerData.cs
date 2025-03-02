using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Custom/Player Data")]
public class PlayerData : ScriptableObject
{
    public string firstName;
    public string lastName;

    public string fullName => $"{firstName} {lastName}";
    public int age;
    public string dateOfBirth;
    public int jerseyNumber;
    public string position;
    public int rating;

    public int physical;
    public int technical;
    public int strategy;
    public int passing;
    public int shooting;
    public string countryOfBirth;

    public Texture2D playerIcon;
    public TeamData nationalTeam;
    public TeamData club;
}
