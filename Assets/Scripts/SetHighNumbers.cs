using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHighNumbers : MonoBehaviour
{
    #region format coins DOUBLE
    public static string FormatGoldDouble(double gold)
    {
        return gold switch
        {
            >= 1E+72 => (gold / 1E+72).ToString("0.###") + LocalizationStrings.trevigintillion,
            >= 1E+69 => (gold / 1E+69).ToString("0.###") + LocalizationStrings.duovigintillion,
            >= 1E+66 => (gold / 1E+66).ToString("0.###") + LocalizationStrings.unvigintillion,
            >= 1E+63 => (gold / 1E+63).ToString("0.###") + LocalizationStrings.vigintillion,
            >= 1E+60 => (gold / 1E+60).ToString("0.###") + LocalizationStrings.novemdecillion,
            >= 1E+57 => (gold / 1E+57).ToString("0.###") + LocalizationStrings.octodecillion,
            >= 1E+54 => (gold / 1E+54).ToString("0.###") + LocalizationStrings.septendecillion,
            >= 1E+51 => (gold / 1E+51).ToString("0.###") + LocalizationStrings.sexdecillion,
            >= 1E+48 => (gold / 1E+48).ToString("0.###") + LocalizationStrings.quindecillion,
            >= 1E+45 => (gold / 1E+45).ToString("0.###") + LocalizationStrings.quattuordecillion,
            >= 1E+42 => (gold / 1E+42).ToString("0.###") + LocalizationStrings.tredecillion,
            >= 1E+39 => (gold / 1E+39).ToString("0.###") + LocalizationStrings.duodecillion,
            >= 1E+36 => (gold / 1E+36).ToString("0.###") + LocalizationStrings.undecillion,
            >= 1E+33 => (gold / 1E+33).ToString("0.###") + LocalizationStrings.decillion,
            >= 1E+30 => (gold / 1E+30).ToString("0.###") + LocalizationStrings.nonillion,
            >= 1E+27 => (gold / 1E+27).ToString("0.###") + LocalizationStrings.octillion,
            >= 1E+24 => (gold / 1E+24).ToString("0.###") + LocalizationStrings.septillion,
            >= 1E+21 => (gold / 1E+21).ToString("0.###") + LocalizationStrings.sextillion,
            >= 1E+18 => (gold / 1E+18).ToString("0.###") + LocalizationStrings.quintillion,
            >= 1E+15 => (gold / 1E+15).ToString("0.###") + LocalizationStrings.quadrillion,
            >= 1E+12 => (gold / 1E+12).ToString("0.###") + LocalizationStrings.trillion,
            >= 1E+09 => (gold / 1E+09).ToString("0.###") + LocalizationStrings.billion,
            >= 1E+06 => (gold / 1E+06).ToString("0.###") + LocalizationStrings.million,
            _ => gold.ToString("0")
        };
    }

    public static string FormatCoinsGoldShort(double gold)
    {
        return gold switch
        {
            >= 1E+72 => (gold / 1E+72).ToString("0.###") + LocalizationStrings.trevigintillionAB,
            >= 1E+69 => (gold / 1E+69).ToString("0.###") + LocalizationStrings.duovigintillionAB,
            >= 1E+66 => (gold / 1E+66).ToString("0.###") + LocalizationStrings.unvigintillionAB,
            >= 1E+63 => (gold / 1E+63).ToString("0.###") + LocalizationStrings.vigintillionAB,
            >= 1E+60 => (gold / 1E+60).ToString("0.###") + LocalizationStrings.novemdecillionAB,
            >= 1E+57 => (gold / 1E+57).ToString("0.###") + LocalizationStrings.octodecillionAB,
            >= 1E+54 => (gold / 1E+54).ToString("0.###") + LocalizationStrings.septendecillionAB,
            >= 1E+51 => (gold / 1E+51).ToString("0.###") + LocalizationStrings.sexdecillionAB,
            >= 1E+48 => (gold / 1E+48).ToString("0.###") + LocalizationStrings.quindecillionAB,
            >= 1E+45 => (gold / 1E+45).ToString("0.###") + LocalizationStrings.quattuordecillionAB,
            >= 1E+42 => (gold / 1E+42).ToString("0.###") + LocalizationStrings.tredecillionAB,
            >= 1E+39 => (gold / 1E+39).ToString("0.###") + LocalizationStrings.duodecillionAB,
            >= 1E+36 => (gold / 1E+36).ToString("0.###") + LocalizationStrings.undecillionAB,
            >= 1E+33 => (gold / 1E+33).ToString("0.###") + LocalizationStrings.decillionAB,
            >= 1E+30 => (gold / 1E+30).ToString("0.###") + LocalizationStrings.nonillionAB,
            >= 1E+27 => (gold / 1E+27).ToString("0.###") + LocalizationStrings.octillionAB,
            >= 1E+24 => (gold / 1E+24).ToString("0.###") + LocalizationStrings.septillionAB,
            >= 1E+21 => (gold / 1E+21).ToString("0.###") + LocalizationStrings.sextillionAB,
            >= 1E+18 => (gold / 1E+18).ToString("0.###") + LocalizationStrings.quintillionAB,
            >= 1E+15 => (gold / 1E+15).ToString("0.###") + LocalizationStrings.quadrillionAB,
            >= 1E+12 => (gold / 1E+12).ToString("0.###") + LocalizationStrings.trillionAB,
            >= 1E+09 => (gold / 1E+09).ToString("0.###") + LocalizationStrings.billionAB,
            >= 1E+06 => (gold / 1E+06).ToString("0.###") + LocalizationStrings.millionAB,
            _ => gold.ToString("0")
        };
    }

    #endregion
}
