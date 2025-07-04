namespace WaruSmart.API.Resources.Domain.Model;

    public class IoTData
    {
        public int Id { get; set; }
        public string DeviceIdValue { get; set; }
        public double? Humidity { get; set; }
        public double? TemperatureValue { get; set; }
        public DateTime? Timestamp { get; set; }
        public double? SoilMoistureValue { get; set; }
        public string? Zone { get; set; }
    }
