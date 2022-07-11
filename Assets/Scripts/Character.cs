using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character 
{
    #region variables
    int _level;
    float _life;
    #endregion
    public int Level
    {
        get { return _level; }
        set { _level = value; }
    }

    public float Life
    {
        get { return _life; }
        set { _life = value; }
    }

    public Character(float life)
    {
        _life = life;
    }

}
