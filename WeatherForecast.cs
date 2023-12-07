// Yani Joel Solano Flores
// Harold Steven Monge Cascante
// Melvin Fernando Mora Delgado 
// Asignacion #3 API personas


namespace PersonasAPI
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}
