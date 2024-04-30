namespace Diplom_AQA_MTS.Models;

public class ProjectQase
{
    [JsonPropertyName("title")] public required string Title { get; set; }
    [JsonPropertyName("code")] public required string Code { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
}

public class CreateProjectResponse
{
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("result")] public ResultData? Result { get; set; }
    [JsonPropertyName("errorMessage")] public string ErrorMessage { get; set; }
    [JsonPropertyName("errorFields")] public ErrorData[] ErrorFields { get; set; }

    public class ErrorData
    {
        [JsonPropertyName("field")] public string? Field { get; set; }
        [JsonPropertyName("error")] public string? Error { get; set; }
    }

    public class ResultData
    {
        [JsonPropertyName("code")] public string? Code { get; set; }
    }
}

public class GetProjectResponse
{
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("result")] public ResultData? Result { get; set; }
    [JsonPropertyName("errorMessage")] public string ErrorMessage { get; set; } = string.Empty;

    public class ResultData
    {
        [JsonPropertyName("title")] public string Title { get; set; } = string.Empty;
        [JsonPropertyName("code")] public string Code { get; init; } = string.Empty;
        [JsonPropertyName("counts")] public Counts Counts { get; init; } = new();
    }

    public class Counts
    {
        [JsonPropertyName("cases")] public int Cases { get; set; }
        [JsonPropertyName("suites")] public int Suites { get; set; }
        [JsonPropertyName("milestones")] public int Milestones { get; set; }
        [JsonPropertyName("runs")] public RunsData Runs { get; init; } = new();
        [JsonPropertyName("defects")] public DefectsData Defects { get; init; } = new();

        public class RunsData
        {
            [JsonPropertyName("total")] public int Total { get; set; }
            [JsonPropertyName("active")] public int Active { get; set; }
        }
        public class DefectsData
        {
            [JsonPropertyName("total")] public int Total { get; set; }
            [JsonPropertyName("open")] public int Open { get; set; }
        }
    }
}

public class GetAllProjectsResponse
{
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("result")] public ResultData? Result { get; set; }

    public class ResultData
    {
        [JsonPropertyName("total")] public int Total { get; set; }
        [JsonPropertyName("filtered")] public int Filtered { get; init; }
        [JsonPropertyName("count")] public int Count { get; init; }
        [JsonPropertyName("entities")] public EntitiesData[] Entities { get; set; }
    }
    public class EntitiesData { }
}