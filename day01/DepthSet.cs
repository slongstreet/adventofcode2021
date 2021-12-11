public class DepthSet
{
    public IEnumerable<int> depths { get; private set; }

    public DepthSet(IEnumerable<int> depths)
    {
        this.depths = depths;
    }

    public static DepthSet FromRawText(string text)
    {
        List<int> depths = new List<int>();

        foreach (string line in text.Split("\n"))
        {
            int depth;
            if (!int.TryParse(line, out depth))
            {
                throw new ArgumentException(string.Format("Input string not in expected format: {0}", line));
            }

            depths.Add(depth);
        }

        return new DepthSet(depths);
    }

    public int CountDepthIncreases()
    {
        int lastDepth = 0, increases = 0;
        foreach (int depth in this.depths)
        {
            if (depth > lastDepth && lastDepth != 0) 
            {
                ++increases;
            }

            lastDepth = depth;
        }

        return increases;
    }

    public int CountSlidingWindowIncreases()
    {
        // Build window values...
        List<int> windowMeasurements = new List<int>();
        int[] depthsArray = this.depths.ToArray();
        for (int i = 1; i < depthsArray.Length - 1; ++i)
        {
            int measurement = depthsArray[i-1] + depthsArray[i] + depthsArray[i+1];
            windowMeasurements.Add(measurement);
        }

        return new DepthSet(windowMeasurements).CountDepthIncreases();
    }
}