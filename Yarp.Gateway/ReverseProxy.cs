using Yarp.ReverseProxy.Configuration;

public static class ReverseProxy
{
    public static IReadOnlyList<RouteConfig> Routes =>
        new List<RouteConfig>()
        {
            new RouteConfig()
            {
                RouteId = "user-route",
                ClusterId = "user-cluster",
                Match = new()
                {
                    Path = "user-api/{**catch-all}"
                },
                Transforms = new List<IReadOnlyDictionary<string, string>>()
                {
                    new Dictionary<string, string>
                    {
                        { "PathPattern", "{**catch-all}" }
                    }
                }
            },
            new RouteConfig()
            {
                RouteId = "product-route",
                ClusterId = "product-cluster",
                Match = new()
                {
                    Path = "product-api/{**catch-all}"
                },
                Transforms = new List<IReadOnlyDictionary<string, string>>()
                {
                    new Dictionary<string, string>
                    {
                        { "PathPattern", "{**catch-all}" }
                    }
                }
            }
        };

    public static IReadOnlyList<ClusterConfig> Clusters =>
        new List<ClusterConfig>()
        {
            new ClusterConfig()
            {
                ClusterId = "user-cluster",
                Destinations = new Dictionary<string, DestinationConfig>()
                {
                    {
                        "destination-1",
                        new DestinationConfig()
                        {
                            // While Aspire is running go to details and look for variable key in environment variables
                            Address = Environment.GetEnvironmentVariable("services__user-api__http__0")!
                        }
                    }
                }
            },
            new ClusterConfig()
            {
                ClusterId = "product-cluster",
                Destinations = new Dictionary<string, DestinationConfig>()
                {
                    {
                        "destination-1",
                        new DestinationConfig()
                        {
                            // While Aspire is running go to details and look for variable key in environment variables
                            Address = Environment.GetEnvironmentVariable("services__product-api__http__0")!
                        }
                    }
                }
            }
        };
}