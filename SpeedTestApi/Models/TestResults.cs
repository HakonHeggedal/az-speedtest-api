using System;
using System.ComponentModel.DataAnnotations;

namespace SpeedTestApi.Models
{
    public class TestResult
    {
        [Required]
        public Guid SessionId { get; set; }

        [StringLength(500, MinimumLength = 2)]
        [Required]
        public string User { get; set; }

        [Range(1, int.MaxValue)]
        [Required]
        public int Device { get; set; }

        [Range(0, long.MaxValue)]
        [Required]
        public long Timestamp { get; set; }

        [Required]
        public TestData Data { get; set; }
    }

    public class TestData
    {
        [Required]
        public TestSpeeds Speeds { get; set; }

        [Required]
        public TestClient Client { get; set; }

        [Required]
        public TestServer Server { get; set; }
    }

    public class TestSpeeds
    {
        [Range(0, 3000)]
        [Required]
        public double Download { get; set; }

        [Range(0, 3000)]
        [Required]
        public double Upload { get; set; }
    }

    public class TestClient
    {
        [RegularExpression(@"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$")]
        [Required]
        public string Ip { get; set; }

        [Range(-90, 90)]
        public double Latitude { get; set; }

        [Range(-180, 180)]
        public double Longitude { get; set; }

        [StringLength(500, MinimumLength = 2)]
        [Required]
        public string Isp { get; set; }

        [RegularExpression(@"^([A-Z]){2}$")]
        [Required]
        public string Country { get; set; }
    }

    public class TestServer
    {
        [StringLength(500, MinimumLength = 2)]
        [Required]
        public string Host { get; set; }

        [Range(-90, 90)]
        [Required]
        public double Latitude { get; set; }

        [Range(-180, 180)]
        [Required]
        public double Longitude { get; set; }

        [RegularExpression(@"^([A-Z]){2}$")]
        [Required]
        public string Country { get; set; }

        [Range(0, 21000000)]
        [Required]
        public double Distance { get; set; }

        [Range(0, int.MaxValue)]
        [Required]
        public int Ping { get; set; }

        [Range(0, int.MaxValue)]
        [Required]
        public int Id { get; set; }
    }
}