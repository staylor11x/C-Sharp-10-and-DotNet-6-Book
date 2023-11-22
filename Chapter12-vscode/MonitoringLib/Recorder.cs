using System.Diagnostics;   //stopwatch

using static System.Console;
using static System.Diagnostics.Process;        //GetCurrentProcess()

namespace Packt.Shared;

public class Recorder
{
    private static Stopwatch timer = new();

    private static long bytesPhysicalBefore = 0;
    private static long bytesVirtualBefore = 0;

    public static void Start()
    {
        // force two garbage collections to release memory that is no longer referenced but has not been releaseed yet
        // doing this is not recommened in any normal application code
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        //store the current and physical memory use
        bytesPhysicalBefore = GetCurrentProcess().WorkingSet64;
        bytesVirtualBefore = GetCurrentProcess().VirtualMemorySize64;
        timer.Restart();
    }

    public static void Stop()
    {
        timer.Stop();
        long bytesPhysicalAfter = GetCurrentProcess().WorkingSet64;

        long bytesVirtualAfter = GetCurrentProcess().VirtualMemorySize64;

        WriteLine("{0:N0} physical bytes used.", bytesPhysicalAfter - bytesPhysicalBefore);

        WriteLine("{0:N0} virtual bytes used.", bytesVirtualAfter - bytesVirtualBefore);

        WriteLine("{0} time span elapsed.", timer.Elapsed);

        WriteLine("{0:N0} total milliseconds ellapsed.", timer.ElapsedMilliseconds);
    }
}
