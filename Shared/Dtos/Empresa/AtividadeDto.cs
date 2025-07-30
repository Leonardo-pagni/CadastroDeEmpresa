using Newtonsoft.Json;
using System.Text.Json.Serialization;

public record AtividadeDto(
    [property: JsonProperty("code")] string Codigo,
    [property: JsonProperty("text")] string Descricao
);