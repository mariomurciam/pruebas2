using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using Unity.Netcode;

public class Btn1 : NetworkBehaviour
{
    public TMP_Text text;
    public void Uno()
    {
        if (!IsServer && IsClient)
        {
            //Llamo a serverRpc
        }
        else
        {
            //Hago el cambio directamente
        }
        text.text = "1";
    }


}
