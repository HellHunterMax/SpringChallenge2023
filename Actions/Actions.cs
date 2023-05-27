public static class Actions
{
    /// <summary>
    /// place a beacon of strength strength on cell index.
    /// </summary>
    /// <param name="index">cell index</param>
    /// <param name="strength">beacon strength </param>
    /// <returns>String command</returns>
    public static string BEACON(int index, int strength)
    {
        return $"BEACON {index} {strength}";
    }

    /// <summary>
    /// place beacons all along a path from index1 to index2, all of strength strength. A shortest path is chosen automatically.
    /// </summary>
    /// <param name="startIndex">index start</param>
    /// <param name="endIndex">Index end</param>
    /// <param name="beaconStrength">Strength of all the beacons in the line</param>
    /// <returns>String command</returns>
    public static string LINE(int startIndex, int endIndex, int beaconStrength)
    {
        return $"LINE {startIndex} {endIndex} {beaconStrength}";
    }

    /// <summary>
    /// do nothing.
    /// </summary>
    /// <returns>String command</returns>
    public static string WAIT() => "WAIT";

    /// <summary>
    /// Displays text on your side of the HUD.
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string MESSAGE(string text) => $"MESSAGE {text}";
}