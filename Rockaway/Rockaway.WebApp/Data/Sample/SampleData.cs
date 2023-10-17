using System.Net.Sockets;

namespace Rockaway.WebApp.Data.Sample;

public partial class SampleData {
	private static Guid TestGuid(int seed, char pad)
		=> new(seed.ToString().PadLeft(32, pad));
}