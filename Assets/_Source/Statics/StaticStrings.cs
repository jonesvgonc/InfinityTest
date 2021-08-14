using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticStrings
{
    private static string _powerSource = "PowerSource";
    private static string _machine = "Machine";

    public static string PowerSource { get => _powerSource; set => _powerSource = value; }
    public static string Machine { get => _machine; set => _machine = value; }
}
