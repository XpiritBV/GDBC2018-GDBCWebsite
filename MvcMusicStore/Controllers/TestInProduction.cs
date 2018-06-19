using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Web.Http;
using System.Web.Mvc;

namespace MvcMusicStore
{
    public class TestInProductionController : Controller
    {
        private RerouteChangeRequest _latestCall;

        public string Index()
        {
            var metrics = new List<string>();
            if (_latestCall != null)
            {
                foreach (var metric in _latestCall.Metrics)
                {
                    metrics.Add(metric.Key + ":" + metric.Value);
                }
                return string.Join("\n",metrics.ToArray());
            }
            else
            {
                return  "No Callback yet" ;
            }
        }

        [System.Web.Mvc.HttpPost]
        public ChangeDirectionResult GetRoutingDirection([FromBody] RerouteChangeRequest metrics)
        {
            // Use either Step or RoutingPercentage. If both returned RoutingPercentage takes precedence
            _latestCall = metrics;

            return new ChangeDirectionResult
            {
                Step = (int)metrics.Metrics["self"].Requests,
                RoutingPercentage = 10
            };
        }
    }

    /// <summary>
    /// Return information how to change TiP ramp up percentage.
    /// Use either Step or RoutingPercentage. If both returned RoutingPercentage takes precedence
    /// Either way MinRoutingPercentage and MaxRoutingPercentage set in API rule are in force
    /// </summary>
    [DataContract]
    public class MetricsWrapper
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember]
        public object Activity { get; set; }
    }

    [DataContract]
    public class Metrics
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        public SiteHttpActivity Activity { get; set; }
    }


    /// <summary>
    /// Return information how to change TiP ramp up percentage.
    /// Use either Step or RoutingPercentage. If both returned RoutingPercentage takes precedence
    /// Either way MinRoutingPercentage and MaxRoutingPercentage set in API rule are in force
    /// </summary>
    [DataContract]
    public class ChangeDirectionResult
    {
        /// <summary>
        /// Step to change the Routing percentage. Positive number will increase it routing.
        /// Negative will decrease it.
        /// </summary>
        [DataMember(Name = "step")]
        public int? Step { get; set; }

        /// <summary>
        /// Hard routing percentage to set regardless of step.
        /// </summary>
        [DataMember(Name = "routingPercentage")]
        public int? RoutingPercentage { get; set; }
    }

    [DataContract]
    public class RerouteChangeRequest
    {
        [DataMember]
        public Dictionary<string, SiteHttpActivity> Metrics { get; set; }
    }

    [DataContract]
    public class SiteHttpActivity
    {
        [DataMember]
        public long Requests { get; set; }

        [DataMember]
        public long IncomingRequestResponseBytes { get; set; }

        [DataMember]
        public long IncomingRequestBytes { get; set; }

        [DataMember]
        public long OutgoingRequestResponseBytes { get; set; }

        [DataMember]
        public long OutgoingRequestBytes { get; set; }

        [DataMember]
        public long LocalReadBytes { get; set; }

        [DataMember]
        public long LocalWrittenBytes { get; set; }

        [DataMember]
        public long NetworkReadBytes { get; set; }

        [DataMember]
        public long NetworkWrittenBytes { get; set; }

        [DataMember]
        public int StopRequests { get; set; }

        [DataMember]
        public TimeSpan ProcessorTime { get; set; }

        [DataMember]
        public int Http2xx { get; set; }

        [DataMember]
        public int Http3xx { get; set; }

        [DataMember]
        public int Http401 { get; set; }

        [DataMember]
        public int Http403 { get; set; }

        [DataMember]
        public int Http404 { get; set; }

        [DataMember]
        public int Http406 { get; set; }

        [DataMember]
        public int Http4xx { get; set; }

        [DataMember]
        public int Http5xx { get; set; }

        [DataMember]
        public long CurrentMemoryWorkingSet { get; set; }

        [DataMember]
        public long MaxMemoryWorkingSet { get; set; }

        [DataMember]
        public long MinMemoryWorkingSet { get; set; }

        [DataMember]
        public double AverageMemoryWorkingSet { get; set; }

        [DataMember]
        public double AverageTimeTaken { get; set; }
    }

}