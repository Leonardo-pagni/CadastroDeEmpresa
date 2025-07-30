using Newtonsoft.Json;

public record EmpresaDto(
    [property: JsonProperty("nome")] string NomeEmpresarial,
    [property: JsonProperty("fantasia")] string NomeFantasia,
    [property: JsonProperty("cnpj")] string CNPJ,
    [property: JsonProperty("situacao")] string Situacao,
    [property: JsonProperty("abertura")] string Abertura,
    [property: JsonProperty("tipo")] string Tipo,
    [property: JsonProperty("natureza_juridica")] string NaturezaJuridica,
    [property: JsonProperty("atividade_principal")] List<AtividadeDto> AtividadePrincipal,
    [property: JsonProperty("logradouro")] string Logradouro,
    [property: JsonProperty("numero")] string Numero,
    [property: JsonProperty("complemento")] string Complemento,
    [property: JsonProperty("bairro")] string Bairro,
    [property: JsonProperty("municipio")] string Municipio,
    [property: JsonProperty("uf")] string UF,
    [property: JsonProperty("cep")] string CEP
);