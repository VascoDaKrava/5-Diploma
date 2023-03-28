public static class Converter_Float_dB
{

    public static float dB(this float value)
    {
        switch (value)
        {
            case 5: return 0;
            case 4: return -5;
            case 3: return -10;
            case 2: return -15;
            case 1: return -20;
            case 0: return -80;
            default: return default;
        }
    }

    public static float dBtoFloat(this float value)
    {
        switch (value)
        {
            case 0: return 5;
            case -5: return 4;
            case -10: return 3;
            case -15: return 2;
            case -20: return 1;
            case -80: return 0;
            default: return default;
        }
    }

}
