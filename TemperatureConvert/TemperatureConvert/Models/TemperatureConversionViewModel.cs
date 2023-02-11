namespace TemperatureConvert.Models;

public enum TemperatureUnit
{
    Celsius,
    Fahrenheit
}

public record TemperatureConversionViewModel
{
    public double Celsius { get; init; }
    public double Fahrenheit { get; init; }
    public TemperatureUnit FromTemperature { get; set; }
    public TemperatureUnit ToTemperature { get; set; } 
}
