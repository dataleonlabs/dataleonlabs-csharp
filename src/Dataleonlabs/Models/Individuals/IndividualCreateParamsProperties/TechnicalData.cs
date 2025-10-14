using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dataleonlabs.Core;
using Dataleonlabs.Models.Individuals.IndividualCreateParamsProperties.TechnicalDataProperties;

namespace Dataleonlabs.Models.Individuals.IndividualCreateParamsProperties;

/// <summary>
/// Technical metadata related to the request or processing.
/// </summary>
[JsonConverter(typeof(ModelConverter<TechnicalData>))]
public sealed record class TechnicalData : ModelBase, IFromRaw<TechnicalData>
{
    /// <summary>
    /// Flag indicating whether there are active research AML (Anti-Money Laundering)
    /// suspicions for the individual when you apply for a new entry or get an existing one.
    /// </summary>
    public bool? ActiveAmlSuspicions
    {
        get
        {
            if (!this.Properties.TryGetValue("active_aml_suspicions", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["active_aml_suspicions"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// URL to call back upon completion of processing.
    /// </summary>
    public string? CallbackURL
    {
        get
        {
            if (!this.Properties.TryGetValue("callback_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["callback_url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// URL for receive notifications about the processing state or status.
    /// </summary>
    public string? CallbackURLNotification
    {
        get
        {
            if (!this.Properties.TryGetValue("callback_url_notification", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["callback_url_notification"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Minimum filtering score (between 0 and 1) for AML suspicions to be considered.
    /// </summary>
    public float? FilteringScoreAmlSuspicions
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "filtering_score_aml_suspicions",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<float?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["filtering_score_aml_suspicions"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Preferred language for communication (e.g., "eng", "fra").
    /// </summary>
    public string? Language
    {
        get
        {
            if (!this.Properties.TryGetValue("language", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["language"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// List of steps to include in the portal workflow.
    /// </summary>
    public List<ApiEnum<string, PortalStep>>? PortalSteps
    {
        get
        {
            if (!this.Properties.TryGetValue("portal_steps", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ApiEnum<string, PortalStep>>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["portal_steps"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Flag indicating whether to include raw data in the response.
    /// </summary>
    public bool? RawData
    {
        get
        {
            if (!this.Properties.TryGetValue("raw_data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["raw_data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ActiveAmlSuspicions;
        _ = this.CallbackURL;
        _ = this.CallbackURLNotification;
        _ = this.FilteringScoreAmlSuspicions;
        _ = this.Language;
        foreach (var item in this.PortalSteps ?? [])
        {
            item.Validate();
        }
        _ = this.RawData;
    }

    public TechnicalData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TechnicalData(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TechnicalData FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
