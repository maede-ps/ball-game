using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="data set " ,menuName = "data set" )]
public class ball_skin_data_set : ScriptableObject
{
    public int level = 1;

    public Player_skin level_2;
    public Player_skin level_3;
    public Player_skin level_4;
}

[System.Serializable]
public class Player_skin
{
    public Sprite Skin;

    public int score;
}
