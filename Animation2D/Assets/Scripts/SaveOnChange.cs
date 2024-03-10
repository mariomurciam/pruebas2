using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveOnChange : Singleton<SaveOnChange>
{
    public int lives = 100;
    public int lvl = 1;
    public int lastScene = 0;
}
